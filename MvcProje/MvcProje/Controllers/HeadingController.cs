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
    public class HeadingController : Controller
    {
        // GET: Heading
        HeadingManger hm = new HeadingManger(new EfHeadingDal());
        CategoryManger cm = new CategoryManger(new EfCategoryDal());
        WriterManger wm = new WriterManger(new EfWriterDal());

        public ActionResult Index()
        {
            var headingValues = hm.GetList();
            return View(headingValues);
        }

        [HttpGet]
        public ActionResult AddHeading()
        {
            List<SelectListItem> valueCategory = (
                from x in cm.GetList()
                select new SelectListItem
                {
                    Text = x.CategoryName,
                    Value = x.CategoryId.ToString()
                }).ToList();


            List<SelectListItem> valueWriter = (
              from x in wm.GetList()
              select new SelectListItem
              {
                  Text = x.WriterName,
                  Value = x.WriterId.ToString()
              }).ToList();


            ViewBag.vlc = valueCategory;
            ViewBag.vlw = valueWriter;
            return View();
        }

        [HttpPost]
        public ActionResult AddHeading(Heading heading)
        {
            heading.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            hm.HeadingAdd(heading);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditeHeading(int id)
        {
            List<SelectListItem> valueCategory = (
               from x in cm.GetList()
               select new SelectListItem
               {
                   Text = x.CategoryName,
                   Value = x.CategoryId.ToString()
               }).ToList();
            ViewBag.vlc = valueCategory;

            var headingvalues = hm.GetById(id);
            return View(headingvalues);
        } 
        [HttpPost]
        public ActionResult EditeHeading(Heading heading)
        {
            hm.HeadingUpdate(heading);
            return RedirectToAction("Index");
        }
        public ActionResult DeleteHeading(int id)
        {
            var headingValue = hm.GetById(id);

            if (headingValue.HeadingStatus==true)
            {
                headingValue.HeadingStatus = false;
                hm.HeadingDelet(headingValue);
            }
            else
            {
                headingValue.HeadingStatus = true;
                hm.HeadingDelet(headingValue);
            }
           
            return RedirectToAction("Index");
        }



    }
}