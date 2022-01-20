using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TruckerPay.Data
{
    public class Load
    {
        [Key]
        public int LoadId { get; set; }
        public Guid OwnerId { get; set; }
        [Required]
        public long LoadNumber { get; set; }
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
        public string ShipperPhone { get; set; }
        public string ReceiverPhone { get; set; }
        [Required]
        public int EmptyMiles { get; set; }
        [Required]
        public int LoadedMiles { get; set; }
    }
}
