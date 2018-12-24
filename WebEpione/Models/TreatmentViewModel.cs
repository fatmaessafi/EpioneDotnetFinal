using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebEpione.Models
{
    public class TreatmentViewModel
    {
        
        public int TreatmentId { get; set; }
        public string Illness { get; set; }
        public string Validation { get; set; }
        public string Patient { get; set; }
        public string Doctor { get; set; }
    }
}