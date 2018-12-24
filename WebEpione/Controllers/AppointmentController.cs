using Domain;
using Domain.Entities;
using Microsoft.AspNet.Identity;
using Service;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using WebEpione.Models;

namespace WebEpione.Controllers
{
    public class AppointmentController : Controller
    {
        UserService us = new UserService();
        IserviceAppointment AS = new ServiceAppointment();
        Iservicedoc DS = new Serivicedoc();
        // GET: Appointment
        public ActionResult Index()
        {


            List<AppointmentViewModel> list = new List<AppointmentViewModel>();

            foreach (var item in AS.GetAll())
            {    
                AppointmentViewModel PVM = new AppointmentViewModel();
                if (item.PatientId == int.Parse(User.Identity.GetUserId()))
                {
                    PVM.AppDate = item.AppDate;
                    PVM.VisitReason = item.VisitReason;
                    PVM.AppointmentId = item.AppointmentId;
                    PVM.AppRate = item.AppRate;
                    PVM.DoctorId = item.DoctorId;
                    // PVM.ReportId=item.ReportId;
                    PVM.PatientId = item.PatientId;

                    list.Add(PVM);
                }
            }

            return View(list);

        }

        // GET: Appointment/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Appointment/Create
        public ActionResult Create()
        {
            List<String> Visitreason = (new List<String> { "caries", "tooth pain", "Tooth Pulled", "others" });
            ViewBag.list1 = Visitreason;

            return View();
        
    }
        // GET: Appointment/CreateAppointment
        public ActionResult CreateAppointment()
        {
            return View();
        }


        // POST: Appointment/Create
        [HttpPost]
        public ActionResult Create(  int Id , AppointmentViewModel collection)
        {
            Appointment a = new Appointment();

           



            //  appdate=collection.AppDate+collection.app 
            a.AppDate = collection.AppDate;



            a.AppointmentId = collection.AppointmentId;
            a.AppRate = collection.AppRate;
            a.VisitReason = collection.VisitReason;
            //  a.DoctorId = collection.DoctorId;
            a.DoctorId = Id;
            a.PatientId = int.Parse(User.Identity.GetUserId());


            Event e = new Event();
            e.Subject = us.GetUserById(a.PatientId).FirstName+" "+us.GetUserById(a.PatientId).LastName;
            e.Description = collection.VisitReason;
            e.Start = collection.AppDate;
            TimeSpan tspan = new TimeSpan(0, 0, 15, 0);

            e.End = collection.AppDate + tspan;
            e.ThemeColor = "green";
            e.DoctorId = Id;

            EventService SV = new EventService();
            SV.Add(e);
            SV.Commit();

            AS.Add(a);
            AS.Commit();

            DateTime today = DateTime.Today;
            TimeSpan gap = collection.AppDate - today;


            /****Mail****/
            // if (gap < 24)
            {
                try
                {
                    MailMessage message = new MailMessage("wael.gatri@esprit.tn", "wael.gatri@esprit.tn", "RENDEZ-VOUS", "vous avez un rdv le ");
                    message.IsBodyHtml = true;
                    SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                    client.EnableSsl = true;
                    client.Credentials = new System.Net.NetworkCredential("wael.gatri@esprit.tn", "motdepasse");
                    client.Send(message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.StackTrace);
                }


                /****Mail****/


                return RedirectToAction("Index");

            }
        }

        // GET: Appointment/Edit/5
        public ActionResult Edit(int id)
        {
            var app = AS.GetById(id);
            AppointmentViewModel bvm = new AppointmentViewModel();
            bvm.AppDate = app.AppDate;
            bvm.AppRate = app.AppRate;
            bvm.DoctorId = app.DoctorId;
            bvm.VisitReason = app.VisitReason;
            bvm.PatientId = int.Parse(User.Identity.GetUserId());




            // bvm.ReportId = app.ReportId;
            // bvm.AppointmentId = app.AppointmentId;


            //var bib1 = AS.GetAll();

            //List<AppointmentViewModel> lbvm = new List<AppointmentViewModel>();
            //foreach (var item in bib1)
            //{
            //    AppointmentViewModel bvm1 = new AppointmentViewModel();
            //    bvm1.AppDate = item.AppDate;
            //    bvm1.AppRate = item.AppRate;
            //    bvm1.VisitReason = app.VisitReason;
            //    bvm1.ReportId = app.ReportId;
            //    lbvm.Add(bvm1);

            //}
            //ViewData["app"] = new SelectList(lbvm, "Code", "Code");

            return View(bvm);
        }


        // POST: Appointment/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, AppointmentViewModel collection)
        {
            Appointment a = AS.GetById(id);


            a.AppDate = collection.AppDate;
            a.AppRate = collection.AppRate;
            a.DoctorId = collection.DoctorId;
         
            //a.ReportId = collection.ReportId;
            a.VisitReason = collection.VisitReason;
            a.PatientId = int.Parse(User.Identity.GetUserId());

            AS.Update(a);
            AS.Commit();
            return RedirectToAction("Index");
        }

        // GET: Appointment/Delete/5
        public ActionResult Delete(int id)
        {
            var app = AS.GetById(id);


            AppointmentViewModel bvm = new AppointmentViewModel();
            bvm.AppDate = app.AppDate;
            bvm.AppRate = app.AppRate;
            bvm.DoctorId = app.DoctorId;
            bvm.VisitReason = app.VisitReason;
            //  bvm.ReportId = app.ReportId;

            return View(bvm);

        }

        // POST: Appointment/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, AppointmentViewModel collection)
        {
            Appointment a = AS.GetById(id);


            //  a.AppointmentId = collection.AppointmentId;
            a.AppDate = collection.AppDate;
            a.AppRate = collection.AppRate;
            a.VisitReason = collection.VisitReason;
            a.DoctorId = collection.DoctorId;
            a.PatientId = collection.PatientId;
            //  a.ReportId = collection.ReportId;

            AS.Delete(a);
            AS.Commit();

            return RedirectToAction("Index");
        }










    }
}
