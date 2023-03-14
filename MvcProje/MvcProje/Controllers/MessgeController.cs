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
    public class MessgeController : Controller
    {
        MessageManger ms = new MessageManger(new EfMessageDal()); 
        // GET: Messge
        public ActionResult Inbox()
        {
            var messageList = ms.GetListInbox();
            return View(messageList); 
        }

        public ActionResult Sendbox()
        {
            var messageList = ms.GetListSendbox();
            return View(messageList);
        }

        public ActionResult GetInBoxMessageDetails(int id) 
        {
            var values= ms.GetById(id);

            return View(values);

        }

        [HttpGet]
        public ActionResult NewMessage()
        {
            return View();
        } 
        
        [HttpPost]
        public ActionResult NewMessage(Message message)
        {


            return View();
        }
        
    }
}