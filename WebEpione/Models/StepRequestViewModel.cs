using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebEpione.Models
{
    public class StepRequestViewModel
    {

        public int NewStepId { get; set; }

        [Display(Name = "New Description")]
        public int StepId { get; set; }

        public string NewStepDescription { get; set; }
        [Display(Name = "New Speciality")]

        public string NewStepSpeciality { get; set; }
        [Display(Name = "New Date")]

        public DateTime NewStepDate { get; set; }
        [Display(Name = "New Validation")]
        [EnumDataType(typeof(ValidationType))]
        public string NewValidation { get; set; }
        [Display(Name = "Last Modified By")]

        public string NewLastModificationBy { get; set; }
        [Display(Name = "Modification Date")]

        public DateTime NewLastModificationDate { get; set; }
        [Display(Name = "Modification Reason")]

        public string NewModificationReason { get; set; }
        public int NewTreatmentId { get; set; }
        [Display(Name = "Illness")]

        public string NewTreatmentIllness { get; set; }
        [Display(Name = "Patient")]
        public string Patient { get; set; }
        public string Type { get; set; }
    }
}