using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
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