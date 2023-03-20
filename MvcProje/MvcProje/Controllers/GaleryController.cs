using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProje.Controllers
{
    public class GaleryController : Controller
    {
        // GET: Galery
        ImageFileManger ifm = new ImageFileManger(new EfImageFile());
        public ActionResult Index()
        {
            var files = ifm.GetList();

            return View(files);
        }
    }
}