using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using PagedList;
using PagedList.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProje.Controllers
{
    public class WriterPanelController : Controller
    {
        HeadingManger hm = new HeadingManger(new EfHeadingDal());
        CategoryManger cm = new CategoryManger(new EfCategoryDal());
        WriterManger wm = new WriterManger(new EfWriterDal());
        WriterValidator writerValidator = new WriterValidator();
        Context c = new Context();

        // GET: WriterPanel
        [HttpGet]
        public ActionResult WriterProfile(int id=0)
        {
            
          string  p = (string)Session["WriterMail"];

            id = c.Writers.Where(x => x.WriterMail == p).Select(y => y.WriterId).FirstOrDefault();

            var writerValues = wm.GetById(id);

            return View(writerValues);
        }
        [HttpPost]
        public ActionResult WriterProfile(Writer writer)
        {
            
            ValidationResult results = writerValidator.Validate(writer);//using FluentValidation.Results; burada kulanmamazı gereken using kısmı bu olmalı yoksa hatta alırsın!!!!!
            if (results.IsValid)
            {
                wm.WriterUpdate(writer);
                return RedirectToAction("AllHeading","WriterPanel");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();

        }
        public ActionResult MyHeading(string p)
        {

            p = (string)Session["WriterMail"];
            var  writerİdİnfo = c.Writers.Where(x => x.WriterMail == p).Select(y => y.WriterId).FirstOrDefault();
            // ViewBag.d = writerİdİnfo;

            var values = hm.GetListByWriter(writerİdİnfo);
            return View(values);

        }


        [HttpGet]
        public ActionResult NewHeading()
        {

            List<SelectListItem> valueCategory = (
               from x in cm.GetList()
               select new SelectListItem
               {
                   Text = x.CategoryName,
                   Value = x.CategoryId.ToString()
               }).ToList();
            ViewBag.vlc = valueCategory;
            return View();

        } 
        
        [HttpPost]
        public ActionResult NewHeading(Heading heading)
        {
            string deger = (string)Session["WriterMail"];
            var writerİdİnfo = c.Writers.Where(x => x.WriterMail == deger).Select(y => y.WriterId).FirstOrDefault();
            
            heading.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            heading.WriterId =writerİdİnfo ;
            heading.HeadingStatus = true;
            hm.HeadingAdd(heading);
            return RedirectToAction("MyHeading");
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
            return RedirectToAction("MyHeading");
        }


        public ActionResult DeleteHeading(int id)
        {
            var headingValue = hm.GetById(id);

            if (headingValue.HeadingStatus == true)
            {
                headingValue.HeadingStatus = false;
                hm.HeadingDelet(headingValue);
            }
            else
            {
                headingValue.HeadingStatus = true;
                hm.HeadingDelet(headingValue);
            }

            return RedirectToAction("MyHeading");
        }
        public ActionResult AllHeading(int p=1)
        {
            var headings = hm.GetList().ToPagedList(p,4);
            return View(headings);
        }
    }
}