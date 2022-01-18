using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TruckerPay.Models.WeeklyPay
{
    public class WeeklyPayEdit
    {

        [Required]
        public int WeeklyPayId { get; set; }
        [Required]
        public DateTime PayDate { get; set; }
        public Guid OwnerId { get; set; }
        [Required]
        public DateTime StartPayWeek { get; set; }
        [Required]
        public DateTime EndPayWeek { get; set; }
        [Required]
        public decimal HealthInsuranceCost { get; set; }
        [Required]
        public decimal DentalInsuranceCost { get; set; }
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
    }
}
