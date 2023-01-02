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
    public class AuthorPanelMessageController : Controller
    {
        MessageManager mm = new MessageManager(new EfMessageDal());
        MessageValidator messageValidator = new MessageValidator();
        public ActionResult Inbox()
        {
            string p = (string)Session["AuthorEmail"];
            var messageList = mm.GetListInbox(p);
            return View(messageList);
        }

        public ActionResult Sendbox()
        {
            string p = (string)Session["AuthorEmail"];
            var messageList = mm.GetListSendbox(p);
            return View(messageList);
        }

        public PartialViewResult MessageListMenu()
        {
            return PartialView();
        }

        public ActionResult GetInboxDetails(int id)
        {
            var values = mm.GetById(id);
            ViewBag.mID = id;
            return View(values);
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
            string mail = (string)Session["AuthorEmail"];
            ValidationResult result = messageValidator.Validate(p);
            if (result.IsValid)
            {
                p.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                p.SenderMail = mail;
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
    }
}