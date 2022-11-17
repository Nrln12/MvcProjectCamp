using BusinessLayer.Concrete;
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
        public ActionResult Index()
        {

            return View();
        }
        public PartialViewResult CategoryCount()
        {
            return PartialView(cm.Count());
        }
    }
}