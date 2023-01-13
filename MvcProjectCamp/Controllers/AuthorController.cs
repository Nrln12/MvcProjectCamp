using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjectCamp.Controllers
{
    public class AuthorController : Controller
    {
        // GET: Author
        AuhtorManager am = new AuhtorManager(new EfAuthorDal());
        AuthorValidator validator = new AuthorValidator();

        public ActionResult Index()
        {
            var AuthorValues = am.GetList();
            return View(AuthorValues);
        }

        [HttpGet]
        public ActionResult AddAuthor()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddAuthor(Author p)
        {
            
            ValidationResult result = validator.Validate(p);
            if (result.IsValid)
            {
                if (Request.Files.Count > 0)
                {
                    string docName = Path.GetFileName(Request.Files[0].FileName);
                    string extension = Path.GetExtension(Request.Files[0].FileName);
                    string url = "~/Image/" + docName + extension;
                    Request.Files[0].SaveAs(Server.MapPath(url));
                    p.AuthorImage = "/Image/" + docName + extension;
                }
                am.AuthorAdd(p);
                return RedirectToAction("Index");
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

        [HttpGet]
        public ActionResult EditAuthor(int id)
        {
            var authorValue = am.GetById(id);
            return View(authorValue);
        }

        [HttpPost]
        public ActionResult EditAuthor(Author p)
        {
            ValidationResult result = validator.Validate(p);
            if (result.IsValid)
            {
                if (Request.Files.Count > 0)
                {
                    string docName = Path.GetFileName(Request.Files[0].FileName);
                    string extension = Path.GetExtension(Request.Files[0].FileName);
                    string url = "~/Image/" + docName + extension;
                    Request.Files[0].SaveAs(Server.MapPath(url));
                    p.AuthorImage = "/Image/" + docName + extension;
                }
                am.AuthorUpdate(p);
                return RedirectToAction("Index");
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
    }
}