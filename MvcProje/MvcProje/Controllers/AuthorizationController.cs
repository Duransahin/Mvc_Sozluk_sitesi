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
    public class AuthorizationController : Controller
    {
        AdminManger adminManger = new AdminManger(new EfAdminDal());
        // GET: Authorization
        public ActionResult Index()
        {
            var adminValues = adminManger.GetList();

            return View(adminValues);
        }

        [HttpGet]
        public ActionResult AddAdmin()
        {
            return View();
        }
        
        
        [HttpPost]
        public ActionResult AddAdmin(Admin admin)
        {
            adminManger.AdminAdd(admin);
            return RedirectToAction("Index");
        }
    }
}