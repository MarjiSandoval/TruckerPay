using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TruckerPay.Data
{
    public class LoadPay
    {
        [Key]
        public int LoadId { get; set; }
        [Required]
        public decimal PerDiemRate { get; set; }
        [Required]
        public decimal PayRateLoadedMiles { get; set; }
        [Required]
        public decimal PayRateEmptyMiles { get; set; }
        [Required]
        public DateTime SentToPayroll { get; set; }
        [Required]
        public decimal TotalPay { get; set; }
    }
}
