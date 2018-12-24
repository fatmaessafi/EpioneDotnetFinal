using Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Doctor : User
    {

       
        public string Speciality { get; set; }
        public string Location { get; set; }
        public Boolean Surgeon { get; set; }
        public ICollection<DayOff> ListDayOff { get; set; }
        public ICollection<Analytics> ListAnalytics { get; set; }
        public ICollection<VisitReason> ListVisitReason { get; set; }
        public ICollection<Message> ListMsg { get; set; }
        public ICollection<Appointment> ListAppointment { get; set; }
        public ICollection<Treatment> ListReferringTreatment { get; set; }
        public ICollection<Event> ListEvent { get; set; }
    }
}
