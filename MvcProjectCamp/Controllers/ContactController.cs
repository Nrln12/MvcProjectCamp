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
            var numContact = cm.GetList().Count();
            var numUnreadInbox = mm.GetUnreadMessages().Count();
            var numSentbox = mm.GetListSendbox().Count();
            ViewBag.contCount = numContact;
            ViewBag.unreadCount = numUnreadInbox;
            ViewBag.sentCount = numSentbox;
            return PartialView();
        }
        public ActionResult GetContactDetails(int id)
        {
            var contactValues = cm.GetById(id);
            return View(contactValues);
        }
    }
}