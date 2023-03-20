using MvcProje.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProje.Controllers
{
    public class ChartController : Controller
    {
        // GET: Chart
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult CategoryChart()
        {
            return Json(BlogList(), JsonRequestBehavior.AllowGet);
        }
        public List<CategoryModel> BlogList()
        {
            List<CategoryModel> categoryModels = new List<CategoryModel>();
            categoryModels.Add(new CategoryModel()
            {
                CategoryName = "Yazılım",
                CategoryCaount = 8,
                
            }) ;
            categoryModels.Add(new CategoryModel()
            {
                CategoryName = "Seyehat",
                CategoryCaount = 4
            });
            return categoryModels;
        }
    }
}