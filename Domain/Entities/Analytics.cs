using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Analytics
    {   [Key]
        public int StatId { get; set; }
        public DateTime StatDate { get; set; }
        public int NbPatients { get; set; }
        public float CancelingRate { get; set; }
        public Doctor DoctorAnalytics { get; set; }
        public int DoctorId { get; set; }


    }
}
