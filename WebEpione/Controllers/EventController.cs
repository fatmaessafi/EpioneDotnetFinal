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
    public class EventController : Controller
    {
        EventIservice se = new EventService();
        // GET: Event
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult IndexPatient(int id)
         {
            TempData["idUser"] = id;
            return View();
        }

        public JsonResult GetEvents()
        {

            int userconnect = Int32.Parse(User.Identity.GetUserId());
            var events = se.GetAll().Where(t=>t.DoctorId==userconnect);
            
            return new JsonResult { Data = events, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
        public JsonResult GetEventse(int id)
        {

          
            var events = se.GetAll().Where(t => t.DoctorId == id);

            return new JsonResult { Data = events, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }


        // GET: Event/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Event/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Event/Create
        [HttpPost]
        public ActionResult Create(EventViewModel EVM)
        {
            EventIservice EVS = new EventService();
            int userconnect = Int32.Parse(User.Identity.GetUserId());
            int a = 0;
            var events = EVS.eventGetAll(userconnect);
            List<DateTime> d = new List<DateTime>();

            foreach (var item in events)
            {
                d.Add(item.Start);
            }
            if (d.Contains(EVM.Start)==false)
            {
                if ((EVM.Start > DateTime.Now) || (EVM.Start >EVM.End)) { 
                Event Ev = new Event();
                Ev.Description = EVM.Description;
                Ev.IsFullDay = 0;
                Ev.DoctorId = userconnect;
                Ev.Start = EVM.Start;
                Ev.End = EVM.End;
                Ev.ThemeColor = "red";
                Ev.Subject = EVM.Subject;
                EVS.Add(Ev);
                EVS.Commit();
                }
            }

            return RedirectToAction("Index");


        }

        // GET: Event/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Event/Edit/5
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

        // GET: Event/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Event/Delete/5
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
