using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TruckerPay.Models.Load
{
    public class LoadEdit
    {
        public int LoadId { get; set; }
        public string ShipperName { get; set; }
        public string ShipperLocation { get; set; }
        public string ShipperPhone { get; set; }
        public string ReceiverName { get; set; }
        public string ReceiverLocation { get; set; }
        public string ReceiverPhone { get; set; }
        public int EmptyMiles { get; set; }
        public int LoadedMiles { get; set; }
    }
}
