using Domain;
using Domain.Entities;
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
        ServiceUser su = new ServiceUser();
        IServiceTreatment st = new ServiceTreatment();
        UserService us = new UserService();
        IServicePatient ps = new ServicePatient();
        IServiceStep ss = new ServiceStep();
        IServiceStepRequest ssr = new ServiceStepRequest();

        IServicePatient sp = new ServicePatient();
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/WSFatma/GetAllPatients")]

        public IEnumerable<User> GetAllPatients()
        {
            return su.GetAllPatients();
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

        [System.Web.Http.Route("api/WSFatma/GetStepRequestByDoctor/{idDoctor:int}")]
        [System.Web.Http.HttpGet]
        public IEnumerable<StepRequest> GetStepRequestByDoctor(int idDoctor)
        {
            List<StepRequest> list = new List<StepRequest>();

            foreach (var item in ssr.GetListStepRequestOrdered(idDoctor))
            {
                StepRequest srvm = new StepRequest();
                srvm.NewStepId = item.NewStepId;
                srvm.NewTreatmentId = item.NewTreatmentId;
                srvm.NewValidation = item.NewValidation;
                srvm.NewLastModificationBy = item.NewLastModificationBy;
                srvm.NewLastModificationDate = item.NewLastModificationDate;
                srvm.NewModificationReason = item.NewModificationReason;
                srvm.NewStepDate = item.NewStepDate;
                srvm.NewStepDescription = item.NewStepDescription;
                srvm.NewStepSpeciality = item.NewStepSpeciality;
                srvm.Type = item.Type;

                list.Add(srvm);



            }
            return list.AsEnumerable();
        }

        [System.Web.Http.Route("api/WSFatma/GetAllStepRequests")]
        [System.Web.Http.HttpGet]
        public IEnumerable<StepRequest> GetAllStepRequests()
        {
            return ssr.GetAll();
        }
    }
}