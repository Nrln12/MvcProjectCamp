using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using FluentValidation.Results;
using BusinessLayer.ValidationRules;

namespace MvcProjectCamp.Controllers
{
    public class AuthorPanelController : Controller
    {
        // GET: AuthorPanel
        HeadingManager hm = new HeadingManager(new EfHeadingDal());
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        AuhtorManager am = new AuhtorManager(new EfAuthorDal());
        Context c = new Context();
        AuthorValidator validator = new AuthorValidator();

        int authorIDInfo;

        [HttpGet]
        public ActionResult AuthorProfile(int id=0)
        {
            string p = (string)Session["AuthorEmail"];
            ViewBag.d = p;
            id = c.Authors.Where(x => x.AuthorEmail == p).Select(y => y.AuthorID).FirstOrDefault();
            var author = am.GetById(id);
            return View(author);
        }

        [HttpPost]
        public ActionResult AuthorProfile(Author p)
        {
            ValidationResult result = validator.Validate(p);
            if (result.IsValid)
            {
                am.AuthorUpdate(p);
                return RedirectToAction("AllHeadings","AuthorPanel");
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

        [AllowAnonymous]
        public ActionResult MyHeading(string p)
        {
            p = (string)Session["AuthorEmail"];
            authorIDInfo = c.Authors.Where(x => x.AuthorEmail == p).Select(y => y.AuthorID).FirstOrDefault();
            var values = hm.GetListByAuthor(authorIDInfo);
            return View(values);
        }
        [HttpGet]
        public ActionResult NewHeading()
        {
            
            List<SelectListItem> valuecategory = (from x in cm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryID.ToString()
                                                  }).ToList();
            ViewBag.vlc = valuecategory;

            return View();
        }

        [HttpPost] 
        public ActionResult NewHeading(Heading p)
        {
            string mail = (string)Session["AuthorEmail"];
            var authorIdInfo = c.Authors.Where(x => x.AuthorEmail == mail).Select(y => y.AuthorID).FirstOrDefault();
            ViewBag.m = authorIdInfo;
            p.HeadingDate =DateTime.Parse(DateTime.Now.ToShortDateString());
            p.AuthorID = authorIdInfo;
            hm.HeadingAdd(p);
            return RedirectToAction("MyHeading");
        }

        [HttpGet]
        public ActionResult EditHeading(int id)
        {
            List<SelectListItem> valuecategory = (from x in cm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryID.ToString()
                                                  }).ToList();
            ViewBag.vlc = valuecategory;
            var HeadingValue = hm.GetByID(id);
            return View(HeadingValue);
        }

        [HttpPost]
        public ActionResult EditHeading(Heading p)
        {
            p.HeadingStatus = true;
            hm.HeadingUpdate(p);
            return RedirectToAction("MyHeading");
        }

        public ActionResult DeleteHeading(int id)
        {
            var heading= hm.GetByID(id);
            if (heading.HeadingStatus == false)
            {
                heading.HeadingStatus = true;
                hm.HeadingUpdate(heading);
            }
            else
            {
                heading.HeadingStatus = false;
                hm.HeadingUpdate(heading);
            }
            
            return RedirectToAction("MyHeading");
        }

        public ActionResult AllHeadings(int p=1)
        {
            var headings = hm.GetList().ToPagedList(p, 4);
            return View(headings);
        }
    }
}