using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TruckerPay.Data
{
    public class Load
    {
        [Key]
        public int LoadId { get; set; }
        [Required]
        public string ShipperLocation { get; set; }
        [Required]
        public string ReceiverLocation { get; set; }
        [Required]
        public DateTime PickUpAppt { get; set; }
        [Required]
        public DateTime DeliveryAppt { get; set; }
        [Required]
        public string ShipperName { get; set; }
        [Required]
        public string ReceiverName { get; set; }
        public int ShipperPhone { get; set; }
        public int ReceiverPhone { get; set; }
        [Required]
        public int EmptyMiles { get; set; }
        [Required]
        public int LoadedMiles { get; set; }
    }
}
