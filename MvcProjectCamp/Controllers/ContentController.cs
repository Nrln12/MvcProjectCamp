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
    public class ContentController : Controller
    {
        // GET: Content
        ContentManager cm = new ContentManager(new EfContentDal());

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetAllContent()
        {
            var value = cm.GetList();
            return View(value);
        }

        [HttpPost]
        public ActionResult GetAllContent(string p)
        {
            var value = cm.GetSearchedList(p);
            return View(value);
        }
        public ActionResult ContentByHeading(int id)
        {
            var contentValues = cm.GetListByHeadingId(id);
            return View(contentValues);
        }
    }
}