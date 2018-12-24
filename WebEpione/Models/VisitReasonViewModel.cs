using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace WebEpione.Models
{
    public class VisitReasonViewModel
    {
        [Key]
        public int VRId { get; set; }
        public string VRDescription { get; set; }
        public Doctor DoctorVisitReason { get; set; }
        public int DoctorId { get; set; }
    }
}