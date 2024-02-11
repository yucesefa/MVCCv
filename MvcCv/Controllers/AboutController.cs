using MvcCv.Models.Entity;
using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class AboutController : Controller
    {
        GenericRepository<tblAbout> repository = new GenericRepository<tblAbout>();
        public ActionResult Index()
        {
            var values = repository.List();
            return View(values);
        }
        [HttpGet]
        public ActionResult AddAbout()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddAbout(tblAbout p)
        {
            repository.TAdd(p);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult EditAbout(int id)
        {
            var values = repository.Find(x => x.ID == id);
            return View(values);
        }
        [HttpPost]
        public ActionResult EditAbout(tblAbout p)
        {
            var values = repository.Find(x => x.ID == p.ID);
            values.Name = p.Name;
            values.Surname = p.Surname;
            values.Address = p.Address;
            values.Mail = p.Mail;
            values.Phone = p.Phone;
            values.Description = p.Description;
            values.Image = p.Image;
            repository.TUpdate(values);
            return RedirectToAction("Index");
        }
        public ActionResult DeleteAbout(int id)
        {
            var values = repository.Find(x => x.ID == id);
            repository.TDelete(values);
            return RedirectToAction("Index");
        }
    }
}