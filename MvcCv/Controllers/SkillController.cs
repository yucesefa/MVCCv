using MvcCv.Models.Entity;
using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class SkillController : Controller
    {
        SkillRepository skillRepository = new SkillRepository();
        public ActionResult Index()
        {
            var values = skillRepository.List();
            return View(values);
        }
        [HttpGet]
        public ActionResult AddSkill()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddSkill(tblSkills p)
        {
            skillRepository.TAdd(p);
            return RedirectToAction("Index");
        }
        public ActionResult DeleteSkill(int id)
        {
            tblSkills t = skillRepository.Find(x => x.ID == id);
            skillRepository.TDelete(t);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult EditSkill(int id)
        {
            tblSkills t = skillRepository.Find(x => x.ID == id);
            return View(t);
        }
        [HttpPost]
        public ActionResult EditSkill(tblSkills p)
        {
            tblSkills t = skillRepository.Find(x => x.ID == p.ID);
            t.Skill=p.Skill;
            t.Ratio=p.Ratio;
            skillRepository.TUpdate(t);
            return RedirectToAction("Index");
        }
    }
}