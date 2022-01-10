using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TruckerPay.Models.Load
{
    public class LoadListItem
    {
        public int LoadId { get; set; }
        public string ShipperName { get; set; }
        public string ReceiverName { get; set; }
        public DateTime PickUpAppt { get; set; }
        public DateTime DeliveryAppt { get; set; }
    }
}
