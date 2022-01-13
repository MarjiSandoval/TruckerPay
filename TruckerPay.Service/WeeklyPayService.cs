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
                    SentToPayRoll = model.SentToPayRoll,
                    StartPayWeek = model.StartPayWeek,
                    PayDate = model.PayDate,
                    EndPayWeek = model.EndPayWeek,
                    EmptyMiles = model.EmptyMiles,
                    LoadedMiles = model.LoadedMiles,
                    PerDiemRate = model.PerDiemRate,
                    PayRateEmpty = model.PayRateEmpty,
                    PayRateLoaded = model.PayRateLoaded,
                    HealthInsuranceCost = model.HealthInsuranceCost,
                    DentalInsuranceCost = model.DentalInsuranceCost,
                    LifeInsuranceCost = model.LifeInsuranceCost,
                    LayOverPay = model.LayOverPay,
                    AdvancesTaken = model.AdvancesTaken,
                    BreakdownPay = model.BreakdownPay,
                    DetentionPay = model.DetentionPay,
                    Bonuses = model.Bonuses,
                    TaxRate = model.TaxRate,
                    TotalPay = model.TotalPay
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
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                        e =>
                            new WeeklyPayListItem
                            {
                                PayDate = e.PayDate,
                                StartPayWeek = e.StartPayWeek,
                                EndPayWeek = e.EndPayWeek,
                                EmptyMiles = e.EmptyMiles,
                                LoadedMiles = e.LoadedMiles,
                                PerDiemRate = e.PerDiemRate,
                                PayRateLoaded = e.PayRateLoaded,
                                PayRateEmpty = e.PayRateEmpty,
                                HealthInsuranceCost = e.HealthInsuranceCost,
                                DentalInsuranceCost = e.DentalInsuranceCost,
                                LifeInsuranceCost = e.LifeInsuranceCost,
                                LayOverPay = e.LayOverPay,
                                AdvancesTaken = e.AdvancesTaken,
                                BreakdownPay = e.BreakdownPay,
                                DetentionPay = e.DetentionPay,
                                Bonuses = e.Bonuses,
                                TaxRate = e.TaxRate,
                                TotalPay = e.TotalPay
                            });
                return query.ToArray();
            }
        }
        public bool UpdateWeeklyPay(WeeklyPayEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .WeeklyPays
                        .Single(e => e.LoadId == model.LoadId && e.OwnerId == _userId);
                entity.PayDate = model.PayDate;
                entity.StartPayWeek = model.StartPayWeek;
                entity.EndPayWeek = model.EndPayWeek;
                entity.EmptyMiles = model.EmptyMiles;
                entity.LoadedMiles = model.LoadedMiles;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool Delete(int LoadId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .WeeklyPays
                        .Single(e => e.LoadId == LoadId && e.OwnerId == _userId);
                ctx.WeeklyPays.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
