using Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebEpione.Models;


namespace WebEpione.Controllers
{
    public class AdminController : Controller
    {
        ServiceDoctolib userservice = new ServiceDoctolib();
        private int reTryCounter;

        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult RecupDoc(string url)
        {
            List<UserViewModel> lists = new List<UserViewModel>();


            HtmlAgilityPack.HtmlWeb web = new HtmlAgilityPack.HtmlWeb();
            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();


            web.PreRequest = delegate (HttpWebRequest webRequest)
            {
                webRequest.Timeout = 15000;
                return true;
            };

            try { doc = web.Load(url); }
            catch (WebException ex)
            {
                reTryCounter++;
                if (reTryCounter == 19) { }
            }
            catch (IOException ex2)
            {

            }

            var HeaderNames = doc.DocumentNode.SelectNodes("//a[@class='dl-search-result-name js-search-result-path']").ToArray();
            var Headerspec = doc.DocumentNode.SelectNodes("//div[@class='dl-search-result-subtitle']").ToArray();
            var HeaderAdd = doc.DocumentNode.SelectNodes("//div[@class='dl-text dl-text-body']").ToArray();


            int i = 0;

            foreach (var item3 in HeaderNames)
            {

                UserViewModel UserViewModl = new UserViewModel();
                UserViewModl.doctolibName = item3.InnerText;
                UserViewModl.doctolibAdress = HeaderAdd[i].InnerText;
                UserViewModl.doctolibSpec = Headerspec[i].InnerText;

                ;

                string[] ADD = HeaderAdd[i].InnerText.ToString().Split(' ');
                UserViewModl.doctolibADD = ADD[ADD.Length - 1];
                string[] NOM = item3.InnerText.ToString().Split(' ');
                UserViewModl.doctolibNOM = (NOM[1] + "-" + NOM[2]).ToLowerInvariant().Replace("é", "e").Replace("è", "e");
                string[] SPC = Headerspec[i].InnerText.ToString().Split(' ');
                if (SPC.Length == 2)
                {
                    UserViewModl.doctolibSPC = (SPC[0] + "-" + SPC[1]).ToLowerInvariant().Replace("é", "e").Replace("è", "e");

                }
                else
                {
                    UserViewModl.doctolibSPC = SPC[0].ToLowerInvariant().Replace("é", "e").Replace("è", "e");

                }

                i++;
                lists.Add(UserViewModl);
            }


            try
            {
                // TODO: Add insert logic here
                return View(lists);
            }
            catch
            {
                return View();
            }

            return View();
        }


        public ActionResult ConfirmDocs()
        {
            List<UserViewModel> lists = new List<UserViewModel>();

            foreach (var item in userservice.GetListUser())
            {

                UserViewModel UserViewModl = new UserViewModel();


                UserViewModl.FirstName = item.FirstName;
                UserViewModl.Email = item.Email;
                UserViewModl.LastName = item.LastName;
                UserViewModl.Speciality = item.Speciality;
                UserViewModl.Location = item.LastName;
                UserViewModl.address = item.HomeAddress;
                UserViewModl.birthDate = item.BirthDate;
                UserViewModl.gender = item.Gender;
                UserViewModl.phoneNumber = item.PhoneNumber;
                UserViewModl.Id = item.Id;




                lists.Add(UserViewModl);


            }

            try
            {
                // TODO: Add insert logic here
                return View(lists);
            }
            catch
            {
                return View();
            }

        }


        public ActionResult DetailsDoc(string add, string nom, string spc)
        {
            List<DocIndivViewModel> lists = new List<DocIndivViewModel>();

            string adress = "https://www.doctolib.fr/" + spc + "/" + add + "/" + nom;
            HtmlAgilityPack.HtmlWeb web = new HtmlAgilityPack.HtmlWeb();
            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            Console.WriteLine(adress);

            web.PreRequest = delegate (HttpWebRequest webRequest)
            {
                webRequest.Timeout = 15000;
                return true;
            };


            try { doc = web.Load(adress); }
            catch (WebException ex)
            {
                reTryCounter++;
                if (reTryCounter == 19) { }
            }
            catch (IOException ex2)
            {

            }

            var HeaderNames = doc.DocumentNode.SelectNodes("//h1[@class='dl-profile-header-name']").ToArray();
            var Headerspec = doc.DocumentNode.SelectNodes("//h2[@class='dl-profile-header-speciality']").ToArray();
            var HeaderAdd = doc.DocumentNode.SelectNodes("//div[@class='dl-profile-text']").ToArray();
            var HeaderDesc = doc.DocumentNode.SelectNodes("//div[@class='dl-profile-text js-bio dl-profile-bio']").ToArray();
            var HeaderIMG = doc.DocumentNode.SelectNodes("//div[@class='dl-profile-header-photo']").ToArray();



            int i = 0;

            foreach (var item3 in HeaderNames)
            {

                DocIndivViewModel UserViewModl = new DocIndivViewModel();
                UserViewModl.doctolibName = item3.InnerText;
                UserViewModl.doctolibAdress = HeaderAdd[i].InnerText;
                UserViewModl.doctolibSpec = Headerspec[i].InnerText;
                UserViewModl.doctolibDesc = HeaderDesc[i].InnerText;

                string[] IMG = HeaderIMG[i].InnerText.ToString().Split('=');
                UserViewModl.doctolibIMG = IMG[0];
                i++;
                lists.Add(UserViewModl);
            }


            try
            {
                // TODO: Add insert logic here
                return View(lists);
            }
            catch
            {
                return View();
            }

            return View();
        }


        public ActionResult CheckDoc(int id)
        {
            var Doc = userservice.GetById(id);

            UserViewModel UserViewModl = new UserViewModel();
            UserViewModl.doctolibName = "";
            HtmlAgilityPack.HtmlWeb web = new HtmlAgilityPack.HtmlWeb();
            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            web.PreRequest = delegate (HttpWebRequest webRequest)
            {
                webRequest.Timeout = 15000;
                return true;
            };

            try { doc = web.Load("https://www.doctolib.fr/doctors/" + Doc.FirstName + "+" + Doc.LastName + "/france"); }
            catch (WebException ex)
            {
                reTryCounter++;
                if (reTryCounter == 19) { }
            }
            catch (IOException ex2)
            {

            }

            if (doc.DocumentNode.SelectNodes("//a[@class='dl-search-result-name js-search-result-path']") != null)
            {
                var HeaderNames = doc.DocumentNode.SelectNodes("//a[@class='dl-search-result-name js-search-result-path']").ToList();
                var Headerspec = doc.DocumentNode.SelectNodes("//div[@class='dl-search-result-subtitle']").ToList();
                var HeaderAdd = doc.DocumentNode.SelectNodes("//div[@class='dl-text dl-text-body']").ToList();

                var alternatePairs = HeaderNames.Select(
                 (item1, index1) => new
                 {
                     name = item1,
                     address = HeaderAdd[index1 % 2],
                     spec = Headerspec[index1 % 3]

                 });
                foreach (var item3 in alternatePairs)
                {

                    UserViewModl.doctolibName = item3.name.InnerText;
                    UserViewModl.doctolibAdress = item3.address.InnerText;
                    UserViewModl.doctolibSpec = item3.spec.InnerText;

                }
            }

            //if (UserViewModl.doctolibName != "")

            //{

            //}



            UserViewModl.doctolibURL = "https://www.doctolib.fr/" + UserViewModl.doctolibSPC + "/" + UserViewModl.doctolibADD + "/" + UserViewModl.doctolibNOM;
            UserViewModl.Id = Doc.Id;
            UserViewModl.FirstName = Doc.FirstName;
            UserViewModl.Email = Doc.Email;
            UserViewModl.LastName = Doc.LastName;
            UserViewModl.address = Doc.HomeAddress;
            UserViewModl.birthDate = Doc.BirthDate;
            UserViewModl.gender = Doc.Gender;
            UserViewModl.phoneNumber = Doc.PhoneNumber;
            UserViewModl.Speciality = Doc.Speciality;


            if (UserViewModl.doctolibName != "")
            {
                string[] ADD = UserViewModl.doctolibAdress.ToString().Split(' ');
                UserViewModl.doctolibADD = ADD[ADD.Length - 1];
                string[] NOM = UserViewModl.doctolibName.ToString().Split(' ');
                UserViewModl.doctolibNOM = (NOM[1] + "-" + NOM[2]).ToLowerInvariant().Replace("é", "e").Replace("è", "e");
                string[] SPC = UserViewModl.doctolibSpec.ToString().Split(' ');
                if (SPC.Length == 2)
                {
                    UserViewModl.doctolibSPC = (SPC[0] + "-" + SPC[1]).ToLowerInvariant().Replace("é", "e").Replace("è", "e");

                }
                else
                {
                    UserViewModl.doctolibSPC = SPC[0].ToLowerInvariant().Replace("é", "e").Replace("è", "e");

                }
                UserViewModl.avalib = "Doctor available in doctolib";
            }
            else
                UserViewModl.avalib = "Not found in doctolib";


            return View(UserViewModl);
        }




        public ActionResult Redirect(string add, string nom, string spc)
        {
            string adress = "https://www.doctolib.fr/" + spc + "/" + add + "/" + nom;

            return Redirect(adress);
        }
        public ActionResult Confirmer(int id)
        {
            var Doc = userservice.GetById(id);
            Doc.Enabled = true;
            Doc.Surgeon =false;
            // SendSMS.Send("test", "+21696174714");




            try
            {
                // TODO: Add update logic here
                userservice.Update(Doc);
                userservice.Commit();

                return RedirectToAction("ConfirmDocs");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult NotApproved()
        {
            return View();
        }
    }
    }

