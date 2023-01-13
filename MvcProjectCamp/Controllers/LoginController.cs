using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcProjectCamp.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        Context c = new Context();
        AuthorLoginManager alm = new AuthorLoginManager(new EfAuthorDal());
       
        AuhtorManager am = new AuhtorManager(new EfAuthorDal());
       
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

            //var authorUserInfo = c.Authors.FirstOrDefault(x => x.AuthorEmail == p.AuthorEmail && x.AuthorPassword == p.AuthorPassword);
            var authorUserInfo = alm.GetAuthor(p.AuthorEmail, p.AuthorPassword);
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
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(Author p)
        {
            AuthorValidator av = new AuthorValidator();
            ValidationResult result = av.Validate(p);
            if (result.IsValid)
            {
                var author = am.GetByEmail(p.AuthorEmail);
                if (author == null)
                {
                    if (Request.Files.Count > 0)
                    {
                        string docName = Path.GetFileName(Request.Files[0].FileName);
                        string extension = Path.GetExtension(Request.Files[0].FileName);
                        string url = "~/Image/" + docName + extension;
                        Request.Files[0].SaveAs(Server.MapPath(url));
                        p.AuthorImage = "/Image/" + docName + extension;
                    }
                    p.AuthorStatus = true;
                    am.AuthorAdd(p);
                    ViewBag.errorMessage = "";
                    return RedirectToAction("AuthorLogin");
                }
                else
                {
                    ViewBag.errorMessage = "This email already exists.";
                    return View();
                }
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }

        [HttpPost]
        public ActionResult AdditionalInf(int id)
        {
            var author = am.GetById(id);
            am.AuthorUpdate(author);
            author.AuthorStatus = true;
            return View();
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Headings", "Default");
        }
    }
}