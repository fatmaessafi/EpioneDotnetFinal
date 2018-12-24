using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class StepRequest
    {
        [Key]
        public int NewStepId { get; set; }
        public int StepId { get; set; }
        public string NewStepDescription { get; set; }
        public string NewStepSpeciality { get; set; }
        public DateTime NewStepDate { get; set; }
        public Boolean NewValidation { get; set; }
        public int NewLastModificationBy { get; set; }
        public DateTime NewLastModificationDate { get; set; }
        public string NewModificationReason { get; set; }
        public int NewTreatmentId { get; set; }
        public string Type { get; set; }
    }
}
