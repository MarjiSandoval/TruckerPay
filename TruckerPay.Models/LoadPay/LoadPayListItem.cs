using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TruckerPay.Models.LoadPay
{
    public class LoadPayListItem
    {
        [Key]
        public int LoadPayId { get; set; }
        [Required]
        public decimal PerDiemRate { get; set; }
        [Required]
        public decimal PayRateLoaded { get; set; }
        [Required]
        public decimal PayRateEmpty { get; set; }
        [Required]
        public decimal TotalPay { get; set; }
    }
}
