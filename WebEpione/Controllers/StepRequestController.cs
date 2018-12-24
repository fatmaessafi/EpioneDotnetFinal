using Domain;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebEpione.Models;

namespace WebEpione.Controllers
{
    public class StepRequestController : Controller
    {

        UserService us = new UserService();
        IServiceStep ss = new ServiceStep();
        IServiceTreatment st = new ServiceTreatment();
        IServiceStepRequest ssr = new ServiceStepRequest();

        public ActionResult Accept(int id)
        {
            var StepReq=ssr.GetById(id);
            if (StepReq.Type == "Add")
            {
                Step step = new Step();
                step.StepDate = StepReq.NewStepDate;
                step.StepDescription = StepReq.NewStepDescription;
                step.StepSpeciality = StepReq.NewStepSpeciality;
                step.TreatmentId = StepReq.NewTreatmentId;
                step.Validation = false;
                step.NbModifications = 0;
                step.LastModificationBy = StepReq.NewLastModificationBy;
                step.LastModificationDate = StepReq.NewLastModificationDate;
                step.ModificationReason = "No modifications yet";
                ss.Add(step);
                ss.Commit();
                ssr.Delete(StepReq);
                ssr.Commit();
            }
            else if (StepReq.Type=="Update")
            {
                Step step = ss.GetById(StepReq.StepId);
                step.StepDate = StepReq.NewStepDate;
                step.StepDescription = StepReq.NewStepDescription;
                step.StepSpeciality = StepReq.NewStepSpeciality;
                step.TreatmentId = StepReq.NewTreatmentId;
                step.Validation = StepReq.NewValidation;
                step.NbModifications += 1;
                step.LastModificationBy = StepReq.NewLastModificationBy;
                step.LastModificationDate = StepReq.NewLastModificationDate;
                step.ModificationReason = StepReq.NewModificationReason;
                ss.Update(step);
                ss.Commit();
                ssr.Delete(StepReq);
                ssr.Commit();
            }
               
            return Redirect(Request.UrlReferrer.ToString());
        }
        
        public ActionResult Deny(int id)
        {
            if (ssr.GetById(id) != null)
                { var StepReq = ssr.GetById(id);
                ssr.Delete(StepReq);
                ssr.Commit();
            }
            return Redirect(Request.UrlReferrer.ToString());
        }
        // GET: StepRequest

        public ActionResult Index(int id)
        {
            List<StepRequestViewModel> list = new List<StepRequestViewModel>();
           
                foreach (var item in ssr.GetListStepRequestOrdered(1007))
                {
                    StepRequestViewModel srvm = new StepRequestViewModel();
                    srvm.NewStepId = item.NewStepId;
                    srvm.NewTreatmentId = item.NewTreatmentId;
                    srvm.NewTreatmentIllness = st.GetById(item.NewTreatmentId).Illness;
                    if (item.NewValidation == true) { srvm.NewValidation = "Valid"; }
                    else if (item.NewValidation == false) { srvm.NewValidation = "NotValid"; }
                    srvm.NewLastModificationBy = us.GetUserById(item.NewLastModificationBy).FirstName + " " + us.GetUserById(item.NewLastModificationBy).LastName;
                    srvm.NewLastModificationDate = item.NewLastModificationDate;
                    srvm.NewModificationReason = item.NewModificationReason;
                    srvm.NewStepDate = item.NewStepDate;
                    srvm.NewStepDescription = item.NewStepDescription;
                    srvm.NewStepSpeciality = item.NewStepSpeciality;
                    srvm.Type = item.Type;
                    srvm.Patient = us.GetUserById(st.GetById(item.NewTreatmentId).PatientId).FirstName + " " + us.GetUserById(st.GetById(item.NewTreatmentId).PatientId).LastName;

                    list.Add(srvm);


                
            }
            return View(list);
        }

        // GET: StepRequest/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: StepRequest/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StepRequest/Create
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

        // GET: StepRequest/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: StepRequest/Edit/5
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

        // GET: StepRequest/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: StepRequest/Delete/5
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
