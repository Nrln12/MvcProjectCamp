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
    public class SkillController : Controller
    {
        // GET: Skill
        SkillManager sm = new SkillManager(new EfSkillDal());
        SkillValidator skillValidator = new SkillValidator();

        public ActionResult Index()
        {
            var skills = sm.GetList();
            return View(skills);
        }

        public ActionResult SkillCard()
        {
            var skills = sm.GetList();
            return View(skills);
        }
        [HttpGet]
        public ActionResult AddSkill()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddSkill(Skill p)
        {
            ValidationResult result = skillValidator.Validate(p);
            if (result.IsValid)
            {
                p.SkillStatus = true;
                sm.SkillAdd(p);
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
        public ActionResult UpdateSkill(int id)
        {
            var skill = sm.GetById(id);
            return View(skill);
        }

        [HttpPost]
        public ActionResult UpdateSkill(Skill p)
        {
            ValidationResult result = skillValidator.Validate(p);
            if (result.IsValid)
            {
                sm.SkillUpdate(p);
                
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