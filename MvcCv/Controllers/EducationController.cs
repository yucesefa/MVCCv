using MvcCv.Models.Entity;
using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    [Authorize]
    public class EducationController : Controller
    {
        GenericRepository<tblEducation> genericRepository = new GenericRepository<tblEducation>();
        public ActionResult Index()
        {
            var values = genericRepository.List();
            return View(values);
        }
        [HttpGet]
        public ActionResult AddEducation()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddEducation(tblEducation p)
        {
            if(!ModelState.IsValid)
            {
                return View("AddEducation");
            }
            genericRepository.TAdd(p);
            return RedirectToAction("Index");
        }
        public ActionResult DeleteEducation(int id)
        {
            var education = genericRepository.Find(x => x.ID == id);
            genericRepository.TDelete(education);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult EditEducation(int id)
        {
            var education = genericRepository.Find(x => x.ID == id);
            return View(education);
        }
        [HttpPost]
        public ActionResult EditEducation(tblEducation p)
        {
            if(!ModelState.IsValid)
            {
                return View("EditEducation");
            }
            var education = genericRepository.Find(x => x.ID == p.ID);
            education.Title= p.Title;
            education.Subtitle1 = p.Subtitle1;
            education.Subtitle2 = p.Subtitle2;
            education.GNO= p.GNO;
            education.Date = p.Date;
            genericRepository.TUpdate(education);
            return RedirectToAction("Index");
        }
    }
}