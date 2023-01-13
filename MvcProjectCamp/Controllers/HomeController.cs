using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjectCamp.Controllers
{
    public class HomeController : Controller
    {
        HeadingManager hm = new HeadingManager(new EfHeadingDal());
        ContentManager cm = new ContentManager(new EfContentDal());
        AuhtorManager am = new AuhtorManager(new EfAuthorDal());
        CategoryManager ctm = new CategoryManager(new EfCategoryDal());
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [AllowAnonymous]
        public ActionResult HomePage()
        {
            ViewBag.headingCount = hm.GetList().Count();
            ViewBag.entryCount = cm.GetList().Count();
            ViewBag.authorCount = am.GetList().Count();
            ViewBag.categoryCount = ctm.GetList().Count();
            return View();
        }
      
     
     
    }
}