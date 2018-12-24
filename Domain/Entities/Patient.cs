using Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Patient : User
    {
        
        public string Allergies { get; set; }
        public string Profession { get; set; }
        public string SpecialReq { get; set; }
        public ICollection<Message> ListMsg { get; set; }
        public ICollection<Appointment> ListAppointment { get; set; }
        public ICollection<Treatment> ListTreatment { get; set; }
    }
}
