using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjectCamp.Controllers
{
    public class AuthorPanelController : Controller
    {
        // GET: AuthorPanel
        HeadingManager hm = new HeadingManager(new EfHeadingDal());

        public ActionResult AuthorProfile()
        {
            return View();
        }

        public ActionResult MyHeading()
        {
          
            var values = hm.GetListByHeading();
            return View(values);
        }
    }
}