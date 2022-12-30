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
    public class AuthorPanelController : Controller
    {
        // GET: AuthorPanel
        HeadingManager hm = new HeadingManager(new EfHeadingDal());
        CategoryManager cm = new CategoryManager(new EfCategoryDal());

        public ActionResult AuthorProfile()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult MyHeading()
        {
          
            var values = hm.GetListByHeading();
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
            p.HeadingDate =DateTime.Parse(DateTime.Now.ToShortDateString());
            p.AuthorID = 4;
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
    }
}