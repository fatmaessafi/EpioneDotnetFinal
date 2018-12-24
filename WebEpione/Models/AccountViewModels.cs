using Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebEpione.Models
{
    public enum Speciality
    {
AnatomicalPathology,
Anesthesiology,
CardiacSurgery,
Cardiology,
ClinicalImmunologyAndAllergy,
ColorectalSurgery,
CriticalCareMedicine,
Dentistry,
Dermatology,
DiagnosticRadiology,
EmergencyMedicine,
EndocrinologyAndMetabolism,
ForensicPathology,
Gastroenterology,
GeneralPathology,
GynecologicReproductiveEndocrinologyaAndInfertility,
GeneralSurgery,
GeneralSurgicalOncology,
GeriatricMedicine,
GeriatricPsychiatry,
GynecologicOncology,
HematologicalPathology,
Hematology,
InfectiousDiseases,
InternalMedicine,
MedicaBiochemistry,
MedicalGenetics,
MedicalMicrobiologyAndInfectiousDiseases,
MedicalOncology,
NeonatalPerinatalMedicine,
GeneralInternalMedicine,
Nephrology,
Neurology,
Neuropathology,
Neurosurgery,
NuclearMedicine,
ObstetricsAndGynecology,
OccupationalMedicine,
Ophthalmology,
OrthopedicSurgery,
OtolaryngologyHeadAndNeckSurgery,
PediatricEmergencyMedicine,
PediatricHematologyAndOncology,
PediatricSurgery,
Pediatrics,
PhysicalMedicineAndRehabilitation,
PlasticSurgery,
Psychiatry,
DevelopmentalPediatrics,
RadiationOncology,
Respirology,
ChildAndAdolescentPsychiatry,
ForensicPsychiatry,
Rheumatology,
ThoracicSurgery,
Urology,
PublicHealthAndPreventiveMedicine,
VascularSurgery,
    }
    public enum Gender
    { Male, Female };
    public enum CivilStatus { Married, Single, Divorced, Engaged };
    public enum Role
    { Doctor, Patient };

    public enum Surgeon
    { Yes, No };
    public enum City
    { Ariana, Béja, BenArous, Bizerte, Gabès, Gafsa, Jendouba, Kairouan, Kasserine, Kébili, Kef, Mahdia, Manouba, Médenine, Monastir, Nabeul, Sfax, SidiBouzid, Siliana, Sousse, Tataouine, Tozeur, Tunis, Zaghouan  };
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class ExternalLoginListViewModel
    {
        public string ReturnUrl { get; set; }
    }

    public class SendCodeViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
        public string ReturnUrl { get; set; }
        public bool RememberMe { get; set; }
    }

    public class VerifyCodeViewModel
    {
        [Required]
        public string Provider { get; set; }

        [Required]
        [Display(Name = "Code")]
        public string Code { get; set; }
        public string ReturnUrl { get; set; }

        [Display(Name = "Remember this browser?")]
        public bool RememberBrowser { get; set; }

        public bool RememberMe { get; set; }
    }

    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }

   

    public class RegisterViewModel
    {   [Required]
        [Display(Name ="First Name*")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Last Name*")]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        [Display(Name = "Email*")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password*")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password*")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Phone Number*")]
        public string PhoneNumber { get; set; }
        [Display(Name = "Gender*")]
        [EnumDataType(typeof(Gender))]
        public string Gender { get; set; }
        [Display(Name = "Birth Date*")]
        
        public DateTime BirthDate { get; set; }
        [Display(Name ="City*")]
        [EnumDataType(typeof(City))]
        public string City { get; set; }
        [Display(Name = "Home Address*")]
        
        public string HomeAddress { get; set; }
        [Display(Name = "Civil Status*")]
        [EnumDataType(typeof(CivilStatus))]
        public string CivilStatus { get; set; }

        public Boolean Enabled { get; set; }
        public DateTime RegistrationDate { get; set; }
        [Display(Name = "Terms and Conditions")]
        [Range(typeof(bool), "true", "true", ErrorMessage = "You have to accept the Terms and Conditions!")]
        public bool TermsAndConditions { get; set; }
        [Required]
        [Display(Name = "Role*")]
        [EnumDataType(typeof(Role),  ErrorMessage = "You have to select a role!")]
        public string Role { get; set; }
        //Patient attributes
        [Display(Name = "Allergies")]
        public string Allergies { get; set; }
        [Display(Name = "Profession*")]

        public string Profession { get; set; }
        [Display(Name = "Special Requirements")]

        public string SpecialReq { get; set; }
        // Doctor attributes
        [Display(Name = "Speciality*")]
        [EnumDataType(typeof(Speciality))]
        public string Speciality { get; set; }
       
        [Display(Name = "Location*")]
        public string Location { get; set; }
        
        [Display(Name = "Surgeon*")]
        [EnumDataType(typeof(Surgeon))]
        public string Surgeon { get; set; }

    }

    public class ResetPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
