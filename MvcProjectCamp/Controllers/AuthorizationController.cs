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
    public class AuthorizationController : Controller
    {
        // GET: Authorization
        AdminManager am = new AdminManager(new EfAdminDal());
        RoleManager rm = new RoleManager(new EfRoleDal());
        public ActionResult Index()
        {
            var adminValues = am.GetList();
            return View(adminValues);
        }
        [HttpGet]
        public ActionResult AddAdmin()
        {
            List<SelectListItem> valueRole = (from x in rm.GetRoles()
                                              select new SelectListItem
                                              {
                                                  Text = x.RoleName,
                                                  Value = x.RoleID.ToString()
                                              }).ToList();
            ViewBag.roles = valueRole;
            return View();
        }
        [HttpPost]
        public ActionResult AddAdmin(Admin p)
        {
            am.AdminAdd(p);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateAdmin(int id)
        {
            List<SelectListItem> roleValue = (from x in rm.GetRoles()
                                              select new SelectListItem
                                              {
                                                  Text = x.RoleName,
                                                  Value = x.RoleID.ToString()
                                              }).ToList();
            ViewBag.roles = roleValue;
            var admin = am.GetByID(id);
            return View(admin);
        }

        [HttpPost]
        public ActionResult UpdateAdmin(Admin p)
        {
            am.EditAdmin(p);
            return RedirectToAction("Index");
        }
    }
}