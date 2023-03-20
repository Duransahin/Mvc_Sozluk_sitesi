using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
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
        MessageValidator messageValidator = new MessageValidator(); 
        // GET: Messge
        public ActionResult Inbox(string p)
        {
            var messageList = ms.GetListInbox(p);
            return View(messageList); 
        }

        public ActionResult Sendbox(string p)
        {
            var messageList = ms.GetListSendbox(p);
            return View(messageList);
        }

        public ActionResult GetInBoxMessageDetails(int id) 
        {
            var values= ms.GetById(id);

            return View(values);

        }


        public ActionResult GetSendMessageDetails(int id)
        {
            var values = ms.GetById(id);

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
            ValidationResult results = messageValidator.Validate(message);//using FluentValidation.Results; burada kulanmamazı gereken using kısmı bu olmalı yoksa hatta alırsın!!!!!
            if (results.IsValid)
            {
                message.MessageDate =DateTime.Parse( DateTime.Now.ToShortDateString());
                ms.MessageAdd(message);
                return RedirectToAction("Sendbox");
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
        
    }
}