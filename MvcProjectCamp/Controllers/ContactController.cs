using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjectCamp.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        ContactManager cm = new ContactManager(new EfContactDal());
        MessageManager mm = new MessageManager(new EfMessageDal());
        ContactValidator cv = new ContactValidator();
        public ActionResult Index()
        {
            var contactValues = cm.GetList();
            return View(contactValues);
        }

        public PartialViewResult ContactPartial()
        {
            string p = (string)Session["AdminUserName"];
            var numUnreadInbox = mm.GetUnreadMessages(p).Count();
            var numDraft = mm.GetListDraft(p).Count();
            var numSentbox = mm.GetListSendbox(p).Count();
            ViewBag.unreadCount = numUnreadInbox;
            ViewBag.sentCount = numSentbox;
            ViewBag.draftCount = numDraft;
            return PartialView();
        }
        public ActionResult GetContactDetails(int id)
        {
            var contactValues = cm.GetById(id);
            return View(contactValues);
        }
    }
}