using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TruckerPay.Models.WeeklyPay
{
    public class WeeklyPayListItem
    {
        public int WeeklyPayId { get; set; }
        public DateTime PayDate { get; set; }
        public DateTime StartPayWeek { get; set; }
        public DateTime EndPayWeek { get; set; }
        public decimal TotalPay { get; set; }
        public int TotalMiles { get; set; }
    }
}
