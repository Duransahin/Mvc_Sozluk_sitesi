using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Security;
using System.Web;
using System.Web.Mvc;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;

namespace MvcProje.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        AdminManger ad = new AdminManger(new EfAdminDal());
        WriterLoginManger wrl = new WriterLoginManger(new EfWriterDal());
        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {

            return View();
        }

        [HttpPost]//burayı Business Katmanına taşı unutma 
        public ActionResult Index(Admin admin)
        {
            //Context c = new Context();
            var adminUserİnfo = ad.GetList().FirstOrDefault(x => x.UserName == admin.UserName && x.AdminPassword == admin.AdminPassword);
            if (adminUserİnfo != null)
            {
                FormsAuthentication.SetAuthCookie(adminUserİnfo.UserName, false);
                Session["UserName"] = adminUserİnfo.UserName;
                return RedirectToAction("Index", "AdminCategory");
            }
            else
            {

                // her hangi bir bilgi yalnışsa mesajla yalnış olduğunu söyle unutma 
                return RedirectToAction("Index");
                //Mimariue Uygun yap.....
            }
        }

        [HttpGet]
        public ActionResult WriterLogin()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult WriterLogin(Writer writer)
        {
            //Context c = new Context();
            //var writerUserİnfo = c.Writers.FirstOrDefault(x => x.WriterMail == writer.WriterMail && x.WriterPassword == writer.WriterPassword);
            var writerUserİnfo = wrl.GetWriter(writer.WriterMail, writer.WriterPassword);
            if (writerUserİnfo != null)
            {
                FormsAuthentication.SetAuthCookie(writerUserİnfo.WriterMail, false);
                Session["WriterMail"] = writerUserİnfo.WriterMail;
                return RedirectToAction("MyContent", "WriterContent");
            }
            else
            {

                // her hangi bir bilgi yalnışsa mesajla yalnış olduğunu söyle unutma 
                return RedirectToAction("WriterLogin");
                //Mimariue Uygun yap.....
            }
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Headings", "Default");
        }
    }
}