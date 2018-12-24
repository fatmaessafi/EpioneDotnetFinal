using Data;
using Domain;
using Domain.Entities;
using Microsoft.AspNet.Identity;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebEpione.Models;

namespace WebEpione.Controllers
{
    public class HomeController : Controller
    {
        private Contexte db = new Contexte();
        UserService us = new UserService();
        IUserService uus = new ServiceUser();
        IServicePatient sp = new ServicePatient();
        IServiceTreatment st = new ServiceTreatment();
        Iservicedoc sd = new Serivicedoc();
        public ActionResult Index()
        {
            if (User.Identity.GetUserId() != null)
            {
                int currentUserId = Int32.Parse(User.Identity.GetUserId());
                TempData["currentid"] = currentUserId;
                UserService su = new UserService();
                User user = new User();
                ViewBag.id = currentUserId;
                TempData["id"] = currentUserId;
                string userstring = su.GetUserById(currentUserId).ToString();
                ViewBag.userstring = userstring;

                if (userstring.Contains("Doctor") == true)

                {
                    TempData["role"] = "Doctor";
                }
                else if (userstring.Contains("Patient") == true)
                {
                    TempData["role"] = "Patient";
                }
                else
                {
                    TempData["role"] = "No type";
                }

            }
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public PartialViewResult UserInformations()
        {
            int currentUserId = 0;
            if (User.Identity.GetUserId()!="")
            {
                 currentUserId = Int32.Parse(User.Identity.GetUserId());

            }
           
                var cuser = new Patient();
            if (sp.GetById(currentUserId) != null) { cuser = sp.GetById(currentUserId); }
            PatientViewModel pvm = new PatientViewModel();
            pvm.LastName = cuser.LastName;
            pvm.FirstName = cuser.FirstName;
            pvm.City = cuser.City;
            pvm.BirthDate = cuser.BirthDate;
            pvm.CivilStatus = cuser.CivilStatus;
            pvm.Gender = cuser.Gender;
            pvm.HomeAddress = cuser.HomeAddress;
            pvm.Profession = cuser.Profession;
            pvm.RegistrationDate = cuser.RegistrationDate;
            pvm.Allergies = cuser.Allergies;
            pvm.SpecialReq = cuser.SpecialReq;
            pvm.PhoneNumber = cuser.PhoneNumber;
            List<PatientViewModel> listuser = new List<PatientViewModel>();
            listuser.Add(pvm);
        int nb= st.nbTotalTreatment(currentUserId);
            ViewBag.nbtreat = nb;


            return PartialView(listuser);
        }
        public PartialViewResult DoctorInformations()
        {
            int currentUserId = 0;
            if (User.Identity.GetUserId() != "")
            {
                currentUserId = Int32.Parse(User.Identity.GetUserId());

            }

            var cuser = new Doctor();
            if (sd.GetById(currentUserId) != null) { cuser = sd.GetById(currentUserId); }
            DoctorViewModel pvm = new DoctorViewModel();
            pvm.LastName = cuser.LastName;
            pvm.FirstName = cuser.FirstName;
            pvm.City = cuser.City;
            pvm.BirthDate = cuser.BirthDate;
            pvm.CivilStatus = cuser.CivilStatus;
            pvm.Gender = cuser.Gender;
            pvm.HomeAddress = cuser.HomeAddress;
            pvm.Location = cuser.Location;
            pvm.RegistrationDate = cuser.RegistrationDate;
           if(cuser.Surgeon==true )pvm.Surgeon = "Yes";
            if (cuser.Surgeon == false) pvm.Surgeon = "No";
            pvm.Speciality = cuser.Speciality;
            pvm.PhoneNumber = cuser.PhoneNumber;
            List<DoctorViewModel> listuser = new List<DoctorViewModel>();
            listuser.Add(pvm);
            


            return PartialView(listuser);
        }

        public PartialViewResult UserConnected()
        {
            int currentUserId = 0;
            if (User.Identity.GetUserId() != "")
            {
                currentUserId = Int32.Parse(User.Identity.GetUserId());

            }

            var cuser = new User();
            if (uus.GetById(currentUserId) != null)
            {
                cuser = uus.GetById(currentUserId);
                
            }
            string userstring = us.GetUserById(currentUserId).ToString();
            if (userstring.Contains("Doctor") == true)

                {
                    ViewBag.role = "Doctor";
                    TempData["role"] = "Doctor";
                    Doctor pvm = new Doctor();
                pvm.Id = cuser.Id;
                    pvm.LastName = cuser.LastName;
                    pvm.FirstName = cuser.FirstName;
                    pvm.City = cuser.City;
                    pvm.BirthDate = cuser.BirthDate;
                    pvm.CivilStatus = cuser.CivilStatus;
                    pvm.Gender = cuser.Gender;
                    pvm.HomeAddress = cuser.HomeAddress;
                    pvm.RegistrationDate = cuser.RegistrationDate;

                    pvm.PhoneNumber = cuser.PhoneNumber;
                    List<Doctor> listuser = new List<Doctor>();
                    listuser.Add(pvm);
                return PartialView(listuser);


            }
            else if (userstring.Contains("Patient") == true)
                {
                    ViewBag.role = "Patient";

                    TempData["role"] = "Patient";
                    Patient pvm = new Patient();
                pvm.Id = cuser.Id;
                pvm.LastName = cuser.LastName;
                    pvm.FirstName = cuser.FirstName;
                    pvm.City = cuser.City;
                    pvm.BirthDate = cuser.BirthDate;
                    pvm.CivilStatus = cuser.CivilStatus;
                    pvm.Gender = cuser.Gender;
                    pvm.HomeAddress = cuser.HomeAddress;
                    pvm.RegistrationDate = cuser.RegistrationDate;

                    pvm.PhoneNumber = cuser.PhoneNumber;
                    List<Patient> listuser = new List<Patient>();
                    listuser.Add(pvm);
                return PartialView(listuser);


            }
            else
                {
                    User pvm = new User();
                pvm.Id = cuser.Id;

                pvm.LastName = cuser.LastName;
                    pvm.FirstName = cuser.FirstName;
                    pvm.City = cuser.City;
                    pvm.BirthDate = cuser.BirthDate;
                    pvm.CivilStatus = cuser.CivilStatus;
                    pvm.Gender = cuser.Gender;
                    pvm.HomeAddress = cuser.HomeAddress;
                    pvm.RegistrationDate = cuser.RegistrationDate;

                    pvm.PhoneNumber = cuser.PhoneNumber;
                    List<User> listuser = new List<User>();

                    ViewBag.role = "None";

                    TempData["role"] = "No type";
                    listuser.Add(pvm);
                return PartialView(listuser);


            }




        }

        public PartialViewResult UserByIdInformations(int id)
        {
           

            var cuser = new Patient();
            if (sp.GetById(id) != null) { cuser = sp.GetById(id); }
            PatientViewModel pvm = new PatientViewModel();
            pvm.LastName = cuser.LastName;
            pvm.FirstName = cuser.FirstName;
            pvm.City = cuser.City;
            pvm.BirthDate = cuser.BirthDate;
            pvm.CivilStatus = cuser.CivilStatus;
            pvm.Gender = cuser.Gender;
            pvm.HomeAddress = cuser.HomeAddress;
            pvm.Profession = cuser.Profession;
            pvm.RegistrationDate = cuser.RegistrationDate;
            pvm.Allergies = cuser.Allergies;
            pvm.SpecialReq = cuser.SpecialReq;
            pvm.PhoneNumber = cuser.PhoneNumber;
            List<PatientViewModel> listuser = new List<PatientViewModel>();
            listuser.Add(pvm);
            int nb = st.nbTotalTreatment(id);
            ViewBag.nbtreat = nb;


            return PartialView(listuser);
        }




    }

    }
