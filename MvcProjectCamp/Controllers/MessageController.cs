using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjectCamp.Controllers
{
    public class MessageController : Controller
    {
        // GET: Message
        MessageManager mm = new MessageManager(new EfMessageDal());
        MessageValidator mv = new MessageValidator();
        [Authorize]
        public ActionResult Inbox()
        {
            string p = (string)Session["AuthorEmail"];
            var messageValues = mm.GetListInbox(p);
            return View(messageValues);
        }

        public ActionResult GetInboxDetails(int id)
        {
            var values = mm.GetById(id);
            ViewBag.mID = id;
            return View(values);
        }
        public ActionResult Sendbox()
        {
            string mail = (string)Session["AuthorEmail"];
            var messageValues = mm.GetListSendbox(mail);
            return View(messageValues);
        }

        public ActionResult GetSentBoxDetails(int id)
        {
            var values = mm.GetById(id);
            return View(values);
        }
        [HttpGet]
        public ActionResult NewMessage()
        {
            
            return View();
        }

        [HttpPost]
        public ActionResult NewMessage(Message p)
        {
            ValidationResult result = mv.Validate(p);
            if (result.IsValid)
            {
                p.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                mm.MessageAdd(p);
                return RedirectToAction("Sendbox");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }

        public ActionResult MarkAsRead(int id)
        {
            var message = mm.GetById(id);
            if (message.MessageStatus == true)
            {
                message.MessageStatus = false;
            }
            else
            {
                message.MessageStatus = true;
            }
            mm.MessageUpdate(message);
            return RedirectToAction("Inbox");
        }
    }
}