using Domain;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using WebEpione.Models;

namespace WebEpione.Controllers
{

    public class WSFatmaController : ApiController
    {

        IServiceTreatment st = new ServiceTreatment();
        UserService us = new UserService();
        IServicePatient ps = new ServicePatient();
        IServiceStep ss = new ServiceStep();
        [System.Web.Http.HttpGet]
        public IEnumerable<Patient> GetAllPatient()
        {
            return ps.GetAll();
            // st.GetAll().Where(a=>a.PatientId==idUser).ToList():
            // return st.GetListTreatmentOrdered(idUser);
        }
        [System.Web.Http.HttpGet]
        public IEnumerable<Treatment> GetTreatmentById(int idTreatment)
        {

            return st.GetAll().Where(a=>a.TreatmentId==idTreatment);
            // st.GetAll().Where(a=>a.PatientId==idUser).ToList():
            // return st.GetListTreatmentOrdered(idUser);
        }
        [System.Web.Http.HttpGet]

        public IEnumerable<Treatment> GetTreatmentByPatient(int idPatient)
        {

            return st.GetAll().Where(a => a.PatientId == idPatient);
            // st.GetAll().Where(a=>a.PatientId==idUser).ToList():
            // return st.GetListTreatmentOrdered(idUser);
        }
        [System.Web.Http.HttpGet]

        public IEnumerable<Step> GetStepsByIdTreatment(int idTreatmentStep)
        {

            return ss.GetAll().Where(a => a.TreatmentId == idTreatmentStep);
            // st.GetAll().Where(a=>a.PatientId==idUser).ToList():
            // return st.GetListTreatmentOrdered(idUser);
        }
      
        //public IHttpActionResult GetTreatmentById(int id)
        //{
        //    TreatmentViewModel tvm = null;
        //    Treatment t = st.GetById(id);
        //    tvm.TreatmentId = t.TreatmentId;
        //    tvm.Illness = t.Illness;
        //    if (t.Validation == true) { tvm.Validation = "Valid"; }
        //    else if (t.Validation == false) { tvm.Validation = "NotValid"; }
        //    tvm.Doctor = us.GetUserById(t.DoctorId).FirstName + " " + us.GetUserById(t.DoctorId).LastName;
        //    tvm.Patient = us.GetUserById(t.PatientId).FirstName + " " + us.GetUserById(t.PatientId).LastName;
        //    if (t == null)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(t);
        //}

    }
}