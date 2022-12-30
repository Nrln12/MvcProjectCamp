using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcProjectCamp.Controllers
{
    public class LoginController : Controller
    {
        Context c = new Context();
        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Admin p)
        {
            
            var adminUserInfo = c.Admins.FirstOrDefault(x => x.AdminUserName == p.AdminUserName && x.AdminPassword == p.AdminPassword);
            if (adminUserInfo != null)
            {
                FormsAuthentication.SetAuthCookie(adminUserInfo.AdminUserName,false);
                Session["AdminUserName"] = adminUserInfo.AdminUserName;
                return RedirectToAction("Index", "AdminCategory");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
        [HttpGet]
        public ActionResult AuthorLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AuthorLogin(Author p)
        {
           
            var authorUserInfo = c.Authors.FirstOrDefault(x => x.AuthorEmail == p.AuthorEmail && x.AuthorPassword == p.AuthorPassword);
            if(authorUserInfo != null)
            {
                FormsAuthentication.SetAuthCookie(authorUserInfo.AuthorEmail, false);
                Session["AuthorEmail"] = authorUserInfo.AuthorEmail;
                return RedirectToAction("MyContent", "AuthorPanelContent");
            }
            else
            {
                return RedirectToAction("AuthorLogin");
            }
        }
    }
}