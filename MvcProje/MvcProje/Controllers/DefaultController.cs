using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProje.Controllers

{

    [AllowAnonymous]
    public class DefaultController : Controller
    {
        ContentManger cm = new ContentManger(new EfContentDal());
        HeadingManger hm = new HeadingManger(new EfHeadingDal());
        // GET: Default
        public ActionResult Headings()
        {
            var headingList = hm.GetList();
            return View(headingList);
        } 
        
        
        public PartialViewResult Index(int id=0)
        {
            var contentList = cm.GetListById(id);
            return PartialView(contentList);
        }
    }
}