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
                       SentToPayroll = model.SentToPayroll,
                   };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.LoadPays.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public int TotalMiles(LoadPay loadpay)
        {
            return loadpay.Load.EmptyMiles + loadpay.Load.LoadedMiles;
        }
        public decimal TotalPay(LoadPay loadpay)
        {
            return (loadpay.Load.LoadedMiles * loadpay.PayRateLoaded) + (loadpay.PayRateEmpty * loadpay.Load.EmptyMiles) + (loadpay.PerDiemRate * TotalMiles(loadpay));
        }

        public IEnumerable<LoadPayListItem> GetLoadPay()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .LoadPays
                        .Where(e => e.OwnerId == _userId).ToList()
                        .Select(
                        e =>
                            new LoadPayListItem
                            {
                                LoadPayId = e.LoadPayId,
                                PerDiemRate = e.PerDiemRate,
                                PayRateLoaded = e.PayRateLoaded,
                                PayRateEmpty = e.PayRateEmpty,
                                TotalPay = TotalPay(e),
                                TotalMiles = TotalMiles(e)
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
                        .Single(e => e.LoadPayId == id && e.OwnerId == _userId);
                return
                    new LoadPayDetails
                    {
                        LoadId = entity.LoadId,
                        PerDiemRate = entity.PerDiemRate,
                        PayRateLoadedMiles = entity.PayRateLoaded,
                        PayRateEmptyMiles = entity.PayRateLoaded,
                        EmptyMiles = entity.Load.EmptyMiles,
                        LoadedMiles = entity.Load.LoadedMiles
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
                        .Single(e => e.LoadPayId == model.LoadPayId && e.OwnerId == _userId);
                entity.LoadPayId = model.LoadPayId;
                entity.LoadId = model.LoadId;
                entity.PerDiemRate = model.PerDiemRate;
                entity.PayRateLoaded = model.PayRateLoadedMiles;
                entity.PayRateEmpty = model.PayRateEmptyMiles;
                entity.SentToPayroll = model.SentToPayroll;
               

                return ctx.SaveChanges() == 1;
            }
        }
        public bool Delete(int LoadPayId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .LoadPays
                        .Single(e => e.LoadPayId == LoadPayId && e.OwnerId == _userId);
                ctx.LoadPays.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
