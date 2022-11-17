using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjectCamp.Controllers
{
    public class DraftMessageController : Controller
    {
        // GET: DraftMessage
        DraftMessageManager dmm = new DraftMessageManager(new EfDraftMessageDal());
        public ActionResult Index()
        {
            var dmmValues = dmm.GetList();
            return View(dmmValues);
        }
    }
}