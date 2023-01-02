using MvcProjectCamp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjectCamp.Controllers
{
    public class ChartController : Controller
    {
        // GET: Chart
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CategoryChart()
        {
            return Json(BlogList(), JsonRequestBehavior.AllowGet);
        }
        public List<CategoryClass> BlogList()
        {
            List<CategoryClass> ct = new List<CategoryClass>();
            ct.Add(new CategoryClass() { CategoryName = "Programming", CategoryCount = 8 });
            ct.Add(new CategoryClass() { CategoryName = "Travel", CategoryCount = 5 });
            ct.Add(new CategoryClass() { CategoryName = "Technology", CategoryCount = 3 });
            ct.Add(new CategoryClass() { CategoryName = "Sport", CategoryCount = 1 });

            return ct;
        }
    }
}