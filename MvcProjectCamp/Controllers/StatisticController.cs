using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjectCamp.Controllers
{
    public class StatisticController : Controller
    {
        // GET: Statistic
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        HeadingManager hm = new HeadingManager(new EfHeadingDal());
        AuhtorManager am = new AuhtorManager(new EfAuthorDal());
        Context c = new Context();
        public ActionResult Index()
        {
            ViewBag.categoryCount = cm.GetList().Count();
            ViewBag.educationContentCount = hm.GetList().Where(x => x.CategoryID == 1).Count();
            ViewBag.authorCount = am.GetList().Where(x => x.AuthorFirstName.ToLower().Contains('a') && x.AuthorLastName.ToLower().Contains('a')).Count();
            ViewBag.maxc = hm.GetList().GroupBy(x => x.CategoryID).Select(x => x.Count()).Max();
            ViewBag.difference = Math.Abs(cm.GetList().Where(x => x.CategoryStatus == true).Count() - cm.GetList().Where(x => x.CategoryStatus == false).Count());
            return View();
        }
        
    }
}