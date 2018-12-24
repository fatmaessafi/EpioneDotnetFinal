using Domain;
using Domain.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebEpione.Models;

namespace WebEpione.Controllers
{
    public class ListdocController : Controller
    {

        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;


        public ListdocController()
        {
        }

        public ListdocController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }


        Iservicedoc DS = new Serivicedoc();
        // GET: Listdoc
        public ActionResult Index()
        {

            List<DocViewModel> list = new List<DocViewModel>();

            foreach (var item in DS.GetAll())
            {
                DocViewModel PVM = new DocViewModel();
               PVM.Id = item.Id;
                PVM.firstname = item.FirstName;
                PVM.lastname = item.LastName;
                PVM.Speciality = item.Speciality;
                PVM.Location= item.HomeAddress;

                list.Add(PVM);
            }

            return View(list);
        }





       // GET: Listdoc/Details/5
          public async Task<ActionResult> Details(string firstname)
        {
            var doctor = DS.GetAll().Where(a => a.FirstName.Equals(firstname)).SingleOrDefault();
            //String username = doctor.UserName;
            //User user = await UserManager.FindByEmailAsync(doctor.UserName);

            DocViewModel DocViewModel = new DocViewModel();
           DocViewModel.Id = doctor.Id;
            DocViewModel.firstname = doctor.FirstName;
            DocViewModel.lastname = doctor.LastName;
            DocViewModel.Location = doctor.HomeAddress;
            DocViewModel.Speciality = doctor.Speciality;


            return View(DocViewModel);
        }

        

        // GET: Listdoc/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Listdoc/Create
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

        // GET: Listdoc/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Listdoc/Edit/5
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

        // GET: Listdoc/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Listdoc/Delete/5
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
