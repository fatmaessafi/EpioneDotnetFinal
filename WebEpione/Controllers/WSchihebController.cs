using Domain;
using Domain.Entities;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace WebEpione.Controllers
{
    public class WSchihebController : ApiController
    {
        VisitReasonIService VRS = new VisitReasonService();
       
        // GET: WSchiheb
        [System.Web.Http.HttpGet]
        public IEnumerable<VisitReason> GetAllVRS()
        {
            return VRS.GetAll();
        }
        [System.Web.Http.HttpGet]
        public IEnumerable<VisitReason> VRGetId(int id)
        {
            return (IEnumerable<VisitReason>)GetAllVRS().Where(t => t.DoctorId == id);


        }

        /*[System.Web.Http.HttpGet]
        public IEnumerable<Event> GetAllEvent()
        {
            return ES.GetAll();
        }

        public IEnumerable<Event> eventGetAll(int id)
        {

            return (IEnumerable<Event>)GetAllEvent().Where(t => t.DoctorId == id);
        }*/


    }
}
