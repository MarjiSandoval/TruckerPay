using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TruckerPay.Data
{
    public class LoadPay
    {
        [Key]
        public int LoadPayId { get; set; }
        public Guid OwnerId { get; set; }
        [ForeignKey(nameof(Load))]
        [Required]
        public int LoadId { get; set; }
        public virtual Load Load { get; set; }
        [Required]
        public decimal PerDiemRate { get; set; }
        [Required]
        public decimal PayRateLoaded { get; set; }
        [Required]
        public decimal PayRateEmpty { get; set; }
        [Required]
        public DateTime SentToPayroll { get; set; }
        public int EmptyMiles { get; set; }
        public int LoadedMiles { get; set; }
    }
}
