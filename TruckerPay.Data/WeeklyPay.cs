﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TruckerPay.Data
{
    public class WeeklyPay
    {
        [Key]
        public DateTime PayDate { get; set; }
        [Required]
        public DateTime StartPayWeek { get; set; }
        [Required]
        public DateTime EndPayWeek { get; set; }
        [Required]
        public int EmptyMiles { get; set; }
        [Required]
        public int LoadedMiles { get; set; }
        [Required]
        public decimal PerDiemRate { get; set; }
        [Required]
        public decimal PayRateLoaded { get; set; }
        [Required]
        public decimal PayRateEmpty { get; set; }
        [Required]
        public decimal HealthInsuranceCost { get; set; }
        [Required]
        public decimal LifeInsuranceCost { get; set; }
        [Required]
        public decimal LayOverPay { get; set; }
        [Required]
        public decimal AdvancesTaken { get; set; }
        [Required]
        public decimal BreakdownPay { get; set; }
        [Required]
        public decimal DetentionPay { get; set; }
        [Required]
        public decimal Bonuses { get; set; }
        [Required]
        public decimal TaxRate { get; set; }
        [Required]
        public decimal TotalPay { get; set; }
    }
}
