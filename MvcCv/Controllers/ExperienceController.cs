using MvcCv.Models.Entity;
using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class ExperienceController : Controller
    {
        // GET: Experience
        ExperienceRepository experienceRepository = new ExperienceRepository();
        public ActionResult Index()
        {
            var values = experienceRepository.List();
            return View(values);
        }
        [HttpGet]
        public ActionResult AddExperience()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddExperience(tblExpreience p)
        {
            experienceRepository.TAdd(p);
            return RedirectToAction("Index");
        }
        public ActionResult DeleteExperience(int id)
        {
            tblExpreience t = experienceRepository.Find(x => x.ID == id);
            experienceRepository.TDelete(t);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult GetExperience(int id)
        {
            tblExpreience t = experienceRepository.Find(x => x.ID == id);
            return View(t);
        }
        [HttpPost]
        public ActionResult GetExperience(tblExpreience p)
        {
            tblExpreience t = experienceRepository.Find(x => x.ID == p.ID);
            t.Title = p.Title;
            t.Subtitle = p.Subtitle;
            t.Description = p.Description;
            t.Date = p.Date;
            experienceRepository.TUpdate(t);
            return RedirectToAction("Index");
        }

    }
}