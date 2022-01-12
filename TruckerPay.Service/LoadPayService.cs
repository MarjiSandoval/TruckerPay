using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TruckerPay.Data;
using TruckerPay.Models.LoadPay;

namespace TruckerPay.Service
{
    public class LoadPayService
    {
        private readonly Guid _userId;

        public LoadPayService(Guid userId)
        {
            _userId = userId;
        }
        public bool CreateLoadPay(LoadPayCreate model)
        {
            var entity =
                   new LoadPay()
                   {
                       OwnerId = _userId, 
                       LoadId = model.LoadId,
                       PerDiemRate = model.PerDiemRate,
                       PayRateLoaded = model.PayRateLoadedMiles,
                       PayRateEmpty = model.PayRateEmptyMiles,
                       SentToPayroll = model.SentToPayroll
                   };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.LoadPays.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<LoadPayListItem> GetLoadPay()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .LoadPays
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                        e =>
                            new LoadPayListItem
                            {
                                LoadPayId = e.LoadPayId,
                                PerDiemRate = e.PerDiemRate,
                                PayRateLoaded = e.PayRateLoaded,
                                PayRateEmpty = e.PayRateEmpty,
                                TotalPay = e.TotalPay
                            });
                return query.ToArray();
            }
        }
        public LoadPayDetails GetLoadPayById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .LoadPays
                        .Single(e => e.LoadId == id && e.OwnerId == _userId);
                return
                    new LoadPayDetails
                    {
                        LoadId = entity.LoadId,
                        PerDiemRate = entity.PerDiemRate,
                        PayRateLoadedMiles = entity.PayRateLoaded,
                        PayRateEmptyMiles = entity.PayRateLoaded
                    };
            }
        }
        public bool UpdateLoadPay(LoadPayEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .LoadPays
                        .Single(e => e.LoadId == model.LoadId && e.OwnerId == _userId);
                entity.LoadPayId = model.LoadPayId;
                entity.LoadPayId = model.LoadId;
                entity.PerDiemRate = model.PerDiemRate;
                entity.PayRateLoaded = model.PayRateLoadedMiles;
                entity.PayRateEmpty = model.PayRateEmptyMiles;
                entity.TotalPay = model.TotalPay;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool Delete(int LoadId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .LoadPays
                        .Single(e => e.LoadId == LoadId && e.OwnerId == _userId);
                ctx.LoadPays.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
