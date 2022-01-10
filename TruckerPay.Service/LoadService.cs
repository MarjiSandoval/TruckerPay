using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TruckerPay.Data;
using TruckerPay.Models.Load;
using TruckerPayRedBadge.Models;

namespace TruckerPay.Service
{
    public class LoadService
    {
        private readonly Guid _userId;

        public LoadService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateLoad (LoadCreate model)
        {
            var entity =
                new Load()
                {
                    //userId= _userId,
                    ShipperName = model.ShipperName,
                    ShipperLocation = model.ShipperLocation,
                    ShipperPhone = model.ShipperPhone,
                    ReceiverName = model.ReceiverName,
                    ReceiverLocation = model.ReceiverLocation,
                    ReceiverPhone = model.ReceiverPhone,
                    EmptyMiles = model.EmptyMiles,
                    LoadedMiles = model.LoadedMiles
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Loads.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<LoadListItem> GetLoads()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Loads
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                        e =>
                            new LoadListItem
                            {
                                LoadId = e.LoadId,
                                ShipperName = e.ShipperName,
                                ReceiverName = e.ReceiverName,
                                PickUpAppt = e.PickUpAppt,
                                DeliveryAppt = e.DeliveryAppt
                            }
                            );
                return query.ToArray();
            }
        }
        public LoadDetails GetLoadById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                       .Loads
                       .Single(e => e.LoadId == id && e.OwnerId == _userId);
                return
                    new LoadDetails
                    {
                        LoadId = entity.LoadId,
                        ShipperName = entity.ShipperName,
                        ReceiverName = entity.ReceiverName,
                        PickUpAppt = entity.PickUpAppt,
                        DeliveryAppt = entity.DeliveryAppt
                    };
            }
        }

    }
}
