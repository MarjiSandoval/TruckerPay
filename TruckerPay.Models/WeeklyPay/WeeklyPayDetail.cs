using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TruckerPay.Models.WeeklyPay
{
    public class WeeklyPayDetail
    {
        public int WeeklyPayId { get; set; }
        public DateTime PayDate { get; set; }
        
        public DateTime StartPayWeek { get; set; }
        public DateTime EndPayWeek { get; set; }
        public decimal HealthInsuranceCost { get; set; }
        public decimal DentalInsuranceCost { get; set; }
        public decimal LifeInsuranceCost { get; set; }
        public decimal LayOverPay { get; set; }
        public decimal AdvancesTaken { get; set; }
        public decimal BreakdownPay { get; set; }
        public decimal DetentionPay { get; set; }
        public decimal Bonuses { get; set; }
        public decimal TaxRate { get; set; }
        public int LoadId { get; set; }
        public int EmptyMiles { get; set; }
        public int LoadedMiles { get; set; }
        public decimal TotalPay { get; set; }
        public int TotalMiles { get; set; }
    }
}
