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
    }
}
