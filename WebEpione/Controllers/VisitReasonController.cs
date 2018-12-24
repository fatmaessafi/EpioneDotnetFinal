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
    public class VisitReasonController : Controller
    {
            VisitReasonIService VRS = new VisitReasonService();

        // GET: VisitReason
        public ActionResult Index()
        {
            if (User.Identity.GetUserId()!=null) { 
            int userconnect = Int32.Parse(User.Identity.GetUserId());

            List<VisitReasonViewModel> lists = new List<VisitReasonViewModel>();
            foreach (var item in VRS.VRGetId(userconnect))
            {
                VisitReasonViewModel VRVM = new VisitReasonViewModel();
                VRVM.VRDescription = item.VRDescription;
                VRVM.DoctorId = item.DoctorId;
                VRVM.VRId = item.VRId;
              
                lists.Add(VRVM);
                
            }
                return View(lists);

            }
            else
            {
                return View();
            }
        }

        // GET: VisitReason/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: VisitReason/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VisitReason/Create
        [HttpPost]
        public ActionResult Create(VisitReasonViewModel VRVM)
        {
            int userconnect = Int32.Parse(User.Identity.GetUserId());
            VisitReason vs = new VisitReason();
            vs.VRId = VRVM.VRId;
            vs.VRDescription = VRVM.VRDescription;
            vs.DoctorId = userconnect;
            VRS.Add(vs);
            VRS.Commit();
            return RedirectToAction("Index");

        }

        // GET: VisitReason/Edit/5
        public ActionResult Edit(int id)
        {
            VisitReason visitservice = VRS.GetById(id);



            VisitReasonViewModel vrvm = new VisitReasonViewModel();
            vrvm.VRDescription = visitservice.VRDescription;
            vrvm.VRId = visitservice.VRId;
           // vrvm.DoctorId = visitservice.DoctorId;
            return View(vrvm);
        }

        // POST: VisitReason/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, VisitReasonViewModel VRVM)
        {
            VisitReason vr = VRS.GetById(id);
           // int userconnect = Int32.Parse(User.Identity.GetUserId());
           
            vr.VRDescription = VRVM.VRDescription;
            //vr.DoctorId = userconnect;
            VRS.Update(vr);
            VRS.Commit();
            return RedirectToAction("Index");

        }

        // GET: VisitReason/Delete/5
        public ActionResult Delete(int id)
        {
            VisitReason visitservice = VRS.GetById(id);
            


            VisitReasonViewModel vrvm = new VisitReasonViewModel();
            vrvm.VRDescription = visitservice.VRDescription;
            vrvm.VRId = visitservice.VRId;
            vrvm.DoctorId = visitservice.DoctorId;
            return View(vrvm);
        }

        // POST: VisitReason/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, VisitReasonViewModel VRVM)
        {            
            VisitReason vr = VRS.GetById(id);
          /*  VRVM.VRId =vr.VRId;
            VRVM.VRDescription = vr.VRDescription;
            VRVM.DoctorId = vr.DoctorId;*/
            VRS.Delete(vr);
            VRS.Commit();
            return RedirectToAction("Index");
        }
    }
}
