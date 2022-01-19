using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TruckerPay.Models.LoadPay
{
    public class LoadPayEdit
    {
        [Key]
        public int LoadPayId { get; set; }
        [ForeignKey(nameof(Load))]
        public int LoadId { get; set; }
        [Required]
        public decimal PerDiemRate { get; set; }
        [Required]
        public decimal PayRateLoadedMiles { get; set; }
        [Required]
        public decimal PayRateEmptyMiles { get; set; }
        [Required]
        public DateTime SentToPayroll { get; set; }

    }
}
