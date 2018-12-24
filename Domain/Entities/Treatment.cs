using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Treatment
    {
        [Key]
        public int TreatmentId { get; set; }
        public string Illness { get; set; }
        public Patient Patient { get; set; }
        public int PatientId { get; set; }
        public Doctor ReferringDoctor { get; set; }
        public int DoctorId { get; set; }
        public bool Validation { get; set; }
        public  ICollection<Step> ListSteps { get; set; }
       


    }
}
