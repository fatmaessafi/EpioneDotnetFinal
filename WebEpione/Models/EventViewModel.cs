using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebEpione.Models
{
    public class EventViewModel
    {
        public int EventId { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }

        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string ThemeColor { get; set; }
        public byte IsFullDay { get; set; }
        public Doctor DoctorEvent { get; set; }
        public int DoctorId { get; set; }


    }
}