using Domain;
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
   
    public class TreatmentController : Controller
    {
      
        IServiceTreatment st = new ServiceTreatment();
        UserService us = new UserService();
        ServiceStep ss = new ServiceStep(); 
        // GET: Treatment
        public ActionResult Index(int id)
        {
            TempData["idPatient"] = id;
            //Validation treatment
            foreach (var treat in st.GetListTreatmentOrdered(id))
            {
                bool valid = true;
                foreach(var step in ss.GetListStepOrdered(treat.TreatmentId))
                {
                    
                     if(step.Validation==false)
                    {
                        valid = false;
                    }


                }
                if (valid == true)
                    treat.Validation = true;
                else if (valid == false)
                    treat.Validation = false;

                st.Update(treat);
                st.Commit();
            }

                //!Validation treatment
                List<TreatmentViewModel> list = new List<TreatmentViewModel>();
            foreach (var item in st.GetListTreatmentOrdered(1))
            {
                TreatmentViewModel tvm = new TreatmentViewModel();
                tvm.TreatmentId = item.TreatmentId;
                tvm.Illness = item.Illness;
                if (item.Validation == true) { tvm.Validation = "Valid"; }
                else if(item.Validation==false) { tvm.Validation = "NotValid"; }
                tvm.Doctor = us.GetUserById(item.DoctorId).FirstName + " " + us.GetUserById(item.DoctorId).LastName;
                tvm.Patient = us.GetUserById(item.PatientId).FirstName + " " + us.GetUserById(item.PatientId).LastName;


                list.Add(tvm);
                
            
            }
            return View(list);
        }

        public ActionResult IndexPatient()
        {

            //Validation treatment
            foreach (var treat in st.GetListTreatmentOrdered(Int32.Parse(User.Identity.GetUserId())))
            {
                bool valid = true;
                foreach (var step in ss.GetListStepOrdered(treat.TreatmentId))
                {

                    if (step.Validation == false)
                    {
                        valid = false;
                    }


                }
                if (valid == true)
                    treat.Validation = true;
                else if (valid == false)
                    treat.Validation = false;

                st.Update(treat);
                st.Commit();
            }

            //!Validation treatment
            List<TreatmentViewModel> list = new List<TreatmentViewModel>();
            foreach (var item in st.GetListTreatmentOrdered(Int32.Parse(User.Identity.GetUserId())))
            {
                TreatmentViewModel tvm = new TreatmentViewModel();
                tvm.TreatmentId = item.TreatmentId;
                tvm.Illness = item.Illness;
                if (item.Validation == true) { tvm.Validation = "Valid"; }
                else if (item.Validation == false) { tvm.Validation = "NotValid"; }
                tvm.Doctor = us.GetUserById(item.DoctorId).FirstName + " " + us.GetUserById(item.DoctorId).LastName;
                tvm.Patient = us.GetUserById(item.PatientId).FirstName + " " + us.GetUserById(item.PatientId).LastName;


                list.Add(tvm);


            }
            return View(list);
        }

        // GET: Treatment/Details/id
        public ActionResult Details(int id)
        {

           

            TempData["idTreatment"] = id;
            List<StepViewModel> liststeps = new List<StepViewModel>();
            if (id!=0) { ViewBag.illness = st.GetById(id).Illness;
                TempData["idPatient"] = st.GetById(id).PatientId;
            }
            foreach (var item2 in ss.GetListStepOrdered(id))
            {
                StepViewModel svm = new StepViewModel();
                svm.StepId = item2.StepId;
                svm.StepSpeciality = item2.StepSpeciality;
                svm.StepDescription = item2.StepDescription;
                svm.StepDate = item2.StepDate;
                svm.LastModificationBy = us.GetUserById(item2.LastModificationBy).FirstName + " " + us.GetUserById(item2.LastModificationBy).LastName;
                svm.ModificationReason = item2.ModificationReason;
                svm.LastModificationDate = item2.LastModificationDate.ToString("dd-MM-yyyy");
                if (item2.Validation == true) svm.Validation = "Valid";
                else if (item2.Validation == false) svm.Validation = "NotValid";
                svm.NbModifications = item2.NbModifications;
                svm.TreatmentId = item2.TreatmentId;
                svm.TreatmentIllness = st.GetById(item2.TreatmentId).Illness;

                if (item2.Appointment !=null)
                {
                    svm.AppointmentId = item2.Appointment.AppointmentId;
                    svm.Appointment = "Taken";
                }
                else
                {
                    svm.AppointmentId = 0;
                    svm.Appointment = "Not taken";
                }


                liststeps.Add(svm);
            }
            return View(liststeps);
        }
        public ActionResult DetailsPatient(int id)
        {
            TempData["idTreatment"] = id;
            List<StepViewModel> liststeps = new List<StepViewModel>();
            if (id != 0) { ViewBag.illness = st.GetById(id).Illness; }
            foreach (var item2 in ss.GetListStepOrdered(id))
            {
                StepViewModel svm = new StepViewModel();
                svm.StepId = item2.StepId;
                svm.StepSpeciality = item2.StepSpeciality;
                svm.StepDescription = item2.StepDescription;
                svm.StepDate = item2.StepDate;
                svm.LastModificationBy = us.GetUserById(item2.LastModificationBy).FirstName + " " + us.GetUserById(item2.LastModificationBy).LastName;
                svm.ModificationReason = item2.ModificationReason;
                svm.LastModificationDate = item2.LastModificationDate.ToString("dd-MM-yyyy");
                if (item2.Validation == true) svm.Validation = "Valid";
                else if (item2.Validation == false) svm.Validation = "NotValid";
                svm.NbModifications = item2.NbModifications;
                svm.TreatmentId = item2.TreatmentId;
                svm.TreatmentIllness = st.GetById(item2.TreatmentId).Illness;

                if (item2.Appointment != null)
                {
                    svm.AppointmentId = item2.Appointment.AppointmentId;
                    svm.Appointment = "Taken";
                }
                else
                {
                    svm.AppointmentId = 0;
                    svm.Appointment = "Not taken";
                }

                liststeps.Add(svm);
            }
            return View(liststeps);
        }

        // GET: Treatment/Create
        public ActionResult Create(int id)
        {
            TempData["idPatient"] = id;
            return View();
        }

        // POST: Treatment/Create
        [HttpPost]
        public ActionResult Create(int id,TreatmentViewModel collection)
        {
            TempData["idPatient"] = id;
            try
            {
                Treatment treat = new Treatment();
                treat.TreatmentId = collection.TreatmentId;
                treat.Illness = collection.Illness;
                treat.PatientId = id;
                treat.DoctorId= int.Parse(User.Identity.GetUserId());
                treat.Validation = false;
                st.Add(treat);
                st.Commit();

                return RedirectToAction("Index", new { id = treat.PatientId });
            }
            catch
            {
                return View();
            }
        }

        // GET: Treatment/Edit/5
        public ActionResult Edit(int id)
        {
            TempData["idPatient"] = st.GetById(id).PatientId;
            TempData["idTreatment"] = id;
            var t = st.GetById(id);
            TreatmentViewModel tvm = new TreatmentViewModel();
            tvm.Illness = t.Illness;
            if (t.Validation == true)
            {
                tvm.Validation = "Valid";
            }
            else
            {
                tvm.Validation = "NotValid";
            }
            tvm.Doctor = us.GetUserById(t.DoctorId).FirstName + " " + us.GetUserById(t.DoctorId).LastName;

            
            return View(tvm);
        }

        // POST: Treatment/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, TreatmentViewModel collection)
        {

            // TODO: Add update logic here
            TempData["idPatient"] = st.GetById(id).PatientId;
            Treatment t = st.GetById(id);
            
                try
                {
                    t.Illness = collection.Illness;
                    if (collection.Validation == "Valid")
                    { t.Validation = true;
                    }
                    else
                    {
                        t.Validation = false;
                    }
                    st.Update(t);
                    st.Commit();

                    return RedirectToAction("Index", new { id = t.PatientId });
            }
            catch
            {
                return View();
            }
        }

        // GET: Treatment/Delete/5
        public ActionResult Delete(int id)
        {
            TempData["idPatient"] = st.GetById(id).PatientId;
            var t = st.GetById(id);
            TreatmentViewModel tvm = new TreatmentViewModel();
            tvm.Illness = t.Illness;
            if (t.Validation == true)
            {
                tvm.Validation = "Valid";
            }
            else
            {
                tvm.Validation = "NotValid";
            }
            tvm.Doctor = us.GetUserById(t.DoctorId).FirstName+" "+us.GetUserById(t.DoctorId).LastName;
            return View(tvm);
        }

        // POST: Treatment/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, TreatmentViewModel collection)
        {
            TempData["idPatient"] = st.GetById(id).PatientId;
            Treatment t = st.GetById(id);
            
            try
            {   
                t.Illness = collection.Illness;
                if (collection.Validation == "Valid")
                { t.Validation = true; }
                else
                {
                    t.Validation = false;
                }
                st.Delete(t);
                st.Commit();

                return RedirectToAction("Index", new { id = t.PatientId });
            }
            catch
            {
                return View();
            }
        }
    }
}
