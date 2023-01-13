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
            string p = (string)Session["AuthorEmail"];
            var numUnreadInbox = mm.GetUnreadMessages(p).Count();
            var numDraft = mm.GetListDraft(p).Count();
            var numSentbox = mm.GetListSendbox(p).Count();
            var numTrash = mm.GetTrashBin(p).Count();
            ViewBag.unreadCount = numUnreadInbox;
            ViewBag.sentCount = numSentbox;
            ViewBag.draftCount = numDraft;
            ViewBag.trashCount = numTrash;
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

        public ActionResult DraftMessages()
        {
            string mail = (string)Session["AuthorEmail"];
            var draftMessages = mm.GetListDraft(mail);
            return View(draftMessages);
        }

        public ActionResult IsDraft(Message p)
        {
            string mail = (string)Session["AuthorEmail"];
            p.SenderMail = mail;
            p.IsDraft = true;
            p.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            p.MessageStatus = true;
            mm.MessageAdd(p);
            return RedirectToAction("DraftMessages");
        }

        public ActionResult GetDraftDetails(int id)
        {
            var values = mm.GetDraftById(id);
            return View(values);
        }

        [HttpGet]
        public ActionResult SentDraft(int id)
        {
            var message = mm.GetDraftById(id);
            string mail = (string)Session["AuthorEmail"];
            return View(message);
        }
        [HttpPost]
        public ActionResult SentDraft(Message p)
        {

            string mail = (string)Session["AuthorEmail"];
            ValidationResult result = messageValidator.Validate(p);
            if (result.IsValid)
            {
                p.IsDraft = false;
                p.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                p.MessageStatus = true;
                mm.MessageUpdate(p);
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
        public ActionResult DeleteMessage(int id)
        {
            var message = mm.GetById(id);
            message.DeleteStatus = true;
            mm.MessageUpdate(message);
            return RedirectToAction("TrashBin");
        }

        public ActionResult TrashBin()
        {
            string mail = (string)Session["AuthorEmail"];
            var trashMessages = mm.GetTrashBin(mail);
            return View(trashMessages);
        }
    }
}