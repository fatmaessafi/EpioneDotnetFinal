using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebEpione.Models;

namespace WebEpione.Controllers
{
    public class PatientFatmaController : Controller
    {
        IServicePatient sp = new ServicePatient();
        // GET: PatientFatma
        public ActionResult Index()
        {
            List<PatientViewModel> list = new List<PatientViewModel>();
            foreach (var item in sp.GetAll())
            {
                PatientViewModel pvm = new PatientViewModel();
                pvm.Id = item.Id;
                pvm.FirstName = item.FirstName;
                pvm.LastName = item.LastName;
                pvm.BirthDate = item.BirthDate;
                pvm.City = item.City;
                pvm.CivilStatus = item.CivilStatus;
                pvm.Gender = item.Gender;
                pvm.HomeAddress = item.HomeAddress;
                pvm.PhoneNumber = item.PhoneNumber;
                pvm.RegistrationDate = item.RegistrationDate;
                pvm.Profession = item.Profession;
                pvm.SpecialReq = item.SpecialReq;
                pvm.Allergies = item.Allergies;
                

                list.Add(pvm);

            }
                return View(list);
        }

        // GET: PatientFatma/Details/5
        public ActionResult Details(int id)
        { 
            return View();
        }

        // GET: PatientFatma/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PatientFatma/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: PatientFatma/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PatientFatma/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: PatientFatma/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PatientFatma/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
