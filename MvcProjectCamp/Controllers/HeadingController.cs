using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjectCamp.Controllers
{
    public class HeadingController : Controller
    {
        // GET: Heading
        HeadingManager hm = new HeadingManager(new EfHeadingDal());
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        AuhtorManager am = new AuhtorManager(new EfAuthorDal());
        public ActionResult Index()
        {
            var headingValues = hm.GetList();
            return View(headingValues);
        }
        public ActionResult HeadingReport()
        {
            var headingValues = hm.GetList();
            return View(headingValues);
        }
        public ActionResult GetHeadingsByCategory(int id)
        {
            var headings = hm.GetListByCategory(id);
            ViewBag.category = hm.GetList().Where(x=>x.CategoryID==id).Select(x=>x.Category.CategoryName).FirstOrDefault().ToString();
            return View(headings);
        }

        public ActionResult GetHeadingByAuthor(int id)
        {
            var headingByAuthor = hm.GetListByAuthor(id);
            ViewBag.author = hm.GetListByAuthor(id).Select(x => x.Author.AuthorFirstName + " "+ x.Author.AuthorLastName).FirstOrDefault().ToString();
            return View(headingByAuthor);
        }
        [HttpGet]
        public ActionResult AddHeading()
        {
            List<SelectListItem> valueCategory = (from x in cm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryID.ToString()
                                                  }).ToList();
            ViewBag.vlc = valueCategory;

            List<SelectListItem> valueAuthor = (from x in am.GetList()
                                                select new SelectListItem
                                                {
                                                    Text = x.AuthorFirstName + " " + x.AuthorLastName,
                                                    Value = x.AuthorID.ToString()
                                                }).ToList();
            ViewBag.vla = valueAuthor;
            return View();
        }
        [HttpPost]
        public ActionResult AddHeading(Heading p)
        {
            p.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            hm.HeadingAdd(p);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditHeading(int id)
        {
            List<SelectListItem> valueCategory = (from x in cm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryID.ToString()
                                                  }).ToList();
            ViewBag.vlc = valueCategory;
            var headingVal = hm.GetByID(id);
            return View(headingVal);
            
        }

        [HttpPost]
        public ActionResult EditHeading(Heading p)
        {
            hm.HeadingUpdate(p);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteHeading(int id)
        {
            var headingValue = hm.GetByID(id);
            if (headingValue.HeadingStatus == false)
            {
                headingValue.HeadingStatus = true;
                hm.HeadingUpdate(headingValue);
            }
            else
            {
                headingValue.HeadingStatus = false;
                hm.HeadingDelete(headingValue);
            }
            
            return RedirectToAction("Index");
        }
    }
}