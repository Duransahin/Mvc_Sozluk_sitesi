using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProje.Controllers
{
    public class AboutController : Controller
    {
        // GET: About

        AboutManger abm = new AboutManger( new EfAboutDal());

        public ActionResult Index()
        {
            var aboutValues = abm.GetList();
            return View(aboutValues);
        }


        [HttpGet]
        public ActionResult AddAbout()
        {

            return View();
        }
        
        [HttpPost]
        public ActionResult AddAbout(About about)
        {
            abm.AboutAdd(about);
            return RedirectToAction("Index");
        }
        public PartialViewResult AboutPartial()
        {
            return PartialView();
        }
    }
}