using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TruckerPay.Models.LoadPay
{
    public class LoadPayDetails
    {
        [Key]
        public int LoadId { get; set; }
        [Required]
        public decimal PerDiemRate { get; set; }
        [Required]
        public decimal PayRateLoadedMiles { get; set; }
        [Required]
        public decimal PayRateEmptyMiles { get; set; }
    }
}
