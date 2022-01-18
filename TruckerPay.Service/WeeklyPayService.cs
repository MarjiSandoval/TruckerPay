using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TruckerPay.Data;
using TruckerPay.Models.WeeklyPay;

namespace TruckerPay.Service
{
    public class WeeklyPayService
    {
        private readonly Guid _userId;

        public WeeklyPayService(Guid userId)
        {
            _userId = userId;
        }
        public bool CreateWeeklyPay(WeeklyPayCreate model)
        {
            var entity =
                new WeeklyPay()
                {
                    OwnerId = _userId,
                    StartPayWeek = model.StartPayWeek,
                    PayDate = model.PayDate,
                    EndPayWeek = model.EndPayWeek,
                    HealthInsuranceCost = model.HealthInsuranceCost,
                    DentalInsuranceCost = model.DentalInsuranceCost,
                    LifeInsuranceCost = model.LifeInsuranceCost,
                    LayOverPay = model.LayOverPay,
                    AdvancesTaken = model.AdvancesTaken,
                    BreakdownPay = model.BreakdownPay,
                    DetentionPay = model.DetentionPay,
                    Bonuses = model.Bonuses,
                    TaxRate = model.TaxRate
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.WeeklyPays.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<WeeklyPayListItem> GetWeeklyPay()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .WeeklyPays
                        .Where(e => e.OwnerId == _userId).AsEnumerable()
                        .Select(
                        e =>
                            new WeeklyPayListItem
                            {
                                PayDate = e.PayDate,
                                StartPayWeek = e.StartPayWeek,
                                EndPayWeek = e.EndPayWeek,
                                TotalPay = TotalPay(e)
                            });
                return query.ToArray();
            }
        }
        public decimal TotalPay(WeeklyPay weeklyPay)
        {
            using (var ctx = new ApplicationDbContext())
            {
                List<LoadPay> pays = ctx.LoadPays.Where(l => l.SentToPayroll <= weeklyPay.EndPayWeek && l.SentToPayroll >= weeklyPay.StartPayWeek).ToList();
                //calculate weeklypay methods
                decimal totalEmptyPay = 0;
                decimal totalLoadedPay = 0;
                decimal perDiemTotal = 0;
                foreach (var item in pays)
                {
                    totalEmptyPay += item.Load.EmptyMiles * item.PayRateEmpty;
                    totalLoadedPay += item.Load.LoadedMiles * item.PayRateLoaded;


                    int totalEmptyMiles = 0;
                    int totalLoadedMiles = 0;

                    totalEmptyMiles += item.Load.EmptyMiles;
                    totalLoadedMiles += item.Load.LoadedMiles;
                    int totalMiles = totalEmptyMiles + totalLoadedMiles;
                    perDiemTotal += totalMiles * item.PerDiemRate;

                }
                decimal grossPay = totalEmptyPay + totalLoadedPay;
                decimal insurance = weeklyPay.DentalInsuranceCost + weeklyPay.HealthInsuranceCost;
                decimal lessInsurance = grossPay - insurance;
                decimal rawPay = lessInsurance + perDiemTotal;
                decimal lessTaxes = rawPay * weeklyPay.TaxRate / 100;
                decimal netPay = rawPay - lessTaxes;
                decimal totalPay = netPay - weeklyPay.LifeInsuranceCost - weeklyPay.AdvancesTaken + weeklyPay.Bonuses + weeklyPay.BreakdownPay + weeklyPay.DetentionPay + weeklyPay.LayOverPay;
                return totalPay;
            }

        }
        public int EmptyMiles(WeeklyPay weeklyPay)
            {

            using (var ctx = new ApplicationDbContext())
            {
                List<LoadPay> pays = ctx.LoadPays.Where(l => l.SentToPayroll <= weeklyPay.EndPayWeek && l.SentToPayroll >= weeklyPay.StartPayWeek).ToList();
                // total empty miles
                int totalMtMiles = 0;
                foreach (var item in pays)
                {
                 totalMtMiles += item.Load.EmptyMiles;
                }
                return totalMtMiles;

            }

        }
        public int LoadedMiles(WeeklyPay weeklyPay)
        {
            using (var ctx = new ApplicationDbContext())
            {
                List<LoadPay> pays = ctx.LoadPays.Where(l => l.SentToPayroll <= weeklyPay.EndPayWeek && l.SentToPayroll >= weeklyPay.StartPayWeek).ToList();
                // total empty miles
                int totalLoadedMiles = 0;
                foreach (var item in pays)
                {
                    totalLoadedMiles += item.Load.LoadedMiles;
                }
                return totalLoadedMiles;
            }

        }
        public WeeklyPayDetail GetWeeklyPayById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .WeeklyPays
                        .Single(e => e.WeeklyPayId == id && e.OwnerId == _userId);
                return
                    new WeeklyPayDetail
                    {
                        PayDate = entity.PayDate,
                        EmptyMiles = EmptyMiles(entity),
                        LoadedMiles = LoadedMiles(entity),
                        TotalPay = TotalPay(entity)
                    };

            }
        }
       
        public bool UpdateWeeklyPay(WeeklyPayEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .WeeklyPays
                        .Single(e => e.WeeklyPayId == model.WeeklyPayId && e.OwnerId == _userId);
                entity.PayDate = model.PayDate;
                entity.StartPayWeek = model.StartPayWeek;
                entity.EndPayWeek = model.EndPayWeek;


                return ctx.SaveChanges() == 1;
            }
        }
        public bool Delete(int WeeklyPayId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .WeeklyPays
                        .Single(e => e.WeeklyPayId == WeeklyPayId && e.OwnerId == _userId);
                ctx.WeeklyPays.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
