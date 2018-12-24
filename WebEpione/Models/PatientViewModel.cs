using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebEpione.Models
{
    public class PatientViewModel
    {
        public int Id { get; set; }
        [Display(Name ="Last Name")]
        public String LastName { get; set; }
        [Display(Name = "First Name")]

        public String FirstName { get; set; }
        [Display(Name = "Gender")]

        public string Gender { get; set; }
        [Display(Name = "Birth Date")]

        public DateTime BirthDate { get; set; }
        [Display(Name = "City")]

        public string City { get; set; }
        [Display(Name = "Home Address")]

        public string HomeAddress { get; set; }
        [Display(Name = "Phone Number")]

        public string PhoneNumber { get; set; }
        [Display(Name = "Civil Status")]

        public string CivilStatus { get; set; }
        [Display(Name = "Registration Date")]

        public DateTime RegistrationDate { get; set; }
        [Display(Name = "Allergies")]

        public string Allergies { get; set; }
        [Display(Name = "Profession")]

        public string Profession { get; set; }
        [Display(Name = "Special Requirements")]

        public string SpecialReq { get; set; }
    }
}