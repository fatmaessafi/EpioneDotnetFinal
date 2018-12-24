using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class DayOff
    {
        [Key]
        public int DayOffId { get; set; }
        public DateTime DayOffDate { get; set; }
        public int StartHour { get; set; }
        public int EndHour { get; set; }
        public Doctor DoctorDayOff { get; set; }
        public int DoctorId { get; set; }

    }
}
