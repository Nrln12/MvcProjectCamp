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
    public class AuthorPanelContentController : Controller
    {
        ContentManager cm = new ContentManager(new EfContentDal());
        // GET: AuthorPanelContent
        public ActionResult MyContent(string p)
        {
            Context c = new Context();
            p = (string)Session["AuthorEmail"];
            var authorIDInfo = c.Authors.Where(x => x.AuthorEmail == p).Select(y => y.AuthorID).FirstOrDefault();
            var contentValues = cm.GetListByAuthor(authorIDInfo);
            return View(contentValues);
        }
    }
}