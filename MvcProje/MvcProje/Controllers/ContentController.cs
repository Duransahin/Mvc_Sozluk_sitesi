using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProje.Controllers
{
    public class ContentController : Controller
    {
        // GET: Content
        ContentManger cm = new ContentManger(new EfContentDal());
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult ContentByHeading(int id)
        {
            var valuesContent = cm.GetListById(id); 

            return View(valuesContent);
        }
    }
}