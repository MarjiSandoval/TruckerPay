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
        [Key]
        public DateTime PayDate { get; set; }
        public int LoadId { get; set; }
        [Required]
        public int EmptyMiles { get; set; }
        [Required]
        public int LoadedMiles { get; set; }
        [Required]
        public decimal TotalPay { get; set; }
    }
}
