using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TruckerPay.Models.Load
{
    public class LoadDetails
    {
        [Key]
        public int LoadId { get; set; }
        [Required]
        public string ShipperName { get; set; }
        [Required]
        public string ReceiverName { get; set; }
        [Required]
        public DateTime PickUpAppt { get; set; }
        [Required]
        public DateTime DeliveryAppt { get; set; }
        
    }
}
