﻿using System;
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
        [ForeignKey(nameof(Load))]
        public int LoadId { get; set; }
        public virtual Load Loads { get; set; }
        [Required]
        public decimal PerDiemRate { get; set; }
        [Required]
        public decimal PayRateLoaded { get; set; }
        [Required]
        public decimal PayRateEmpty { get; set; }
        [Required]
        public DateTime SentToPayroll { get; set; }
        [Required]
        public decimal TotalPay { get; set; }
    }
}