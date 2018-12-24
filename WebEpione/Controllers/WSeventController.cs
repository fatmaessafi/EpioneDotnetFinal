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
    public class WSeventController : ApiController
    {
        EventIservice ES = new EventService();
        [System.Web.Http.HttpGet]
       public IEnumerable<Event> GetAllEvent()
       {
           return ES.GetAll();
       }

       public IEnumerable<Event> eventGetAll(int id)
       {

           return (IEnumerable<Event>)GetAllEvent().Where(t => t.DoctorId == id);
       }

    }
}