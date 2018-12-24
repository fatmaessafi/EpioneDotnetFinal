using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebEpione.Models
{
    public class DocViewModel
    {
        public int Id { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string Speciality { get; set; }
        public string Location { get; set; }
        public Boolean Surgeon { get; set; }

    }
}