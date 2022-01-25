using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TruckerPay.Models.Load
{
    public class LoadCreate
    {
        [Key]
        public int LoadId { get; set; }
        public int LoadNumber { get; set; }
        [Required]
        public string ShipperName { get; set; }
        public string ShipperLocation { get; set; }
        public string ShipperPhone { get; set; }
        [Required]
        public DateTime PickUpAppt { get; set; }
        [Required]
        public DateTime DeliveryAppt { get; set; }
        [Required]
        public string ReceiverName { get; set; }
        public string ReceiverLocation { get; set; }
        public string ReceiverPhone { get; set; }
        [Required]
        public int EmptyMiles { get; set; }
        [Required]
        public int LoadedMiles { get; set; }

    }
}
