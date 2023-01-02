using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjectCamp.Controllers
{
    public class AuthorPanelContentController : Controller
    {
        ContentManager cm = new ContentManager(new EfContentDal());
        Context c = new Context();

        // GET: AuthorPanelContent
        public ActionResult MyContent(string p)
        {
            p = (string)Session["AuthorEmail"];
            var authorIDInfo = c.Authors.Where(x => x.AuthorEmail == p).Select(y => y.AuthorID).FirstOrDefault();
            var contentValues = cm.GetListByAuthor(authorIDInfo);
            return View(contentValues);
        }

        [HttpGet]
        public ActionResult AddContent(int id)
        {
            ViewBag.d = id;
            return View();
        }

        [HttpPost]
        public ActionResult AddContent(Content p)
        {
            string mail = (string)Session["AuthorEmail"];
            var authorIdInfo = c.Authors.Where(x => x.AuthorEmail == mail).Select(y => y.AuthorID).FirstOrDefault();
            p.AuthorID = authorIdInfo;
            p.ContentDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            p.ContentStatus = true;
            cm.ContentAdd(p);
            return RedirectToAction("MyContent");
        }

        public ActionResult ToDoList()
        {
            return View();
        }
    }
}