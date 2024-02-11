using MvcCv.Models.Entity;
using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class ProjectController : Controller
    {
        GenericRepository<tblProject> repository= new GenericRepository<tblProject>();
        public ActionResult Index()
        {
            var values = repository.List();
            return View(values);
        }
        [HttpGet]
        public ActionResult AddProject()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddProject(tblProject p)
        {
            repository.TAdd(p);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult EditProject(int id)
        {
            var values = repository.Find(x => x.ID == id);
            return View(values);
        }
        [HttpPost]
        public ActionResult EditProject(tblProject p)
        {
            var values = repository.Find(x => x.ID == p.ID);
            values.Title = p.Title;
            values.Link = p.Link;
            values.ImageUrl = p.ImageUrl;
            repository.TUpdate(values);
            return RedirectToAction("Index");
        }
        public ActionResult DeleteProject(int id)
        {
            var values = repository.Find(x => x.ID == id);
            repository.TDelete(values);
            return RedirectToAction("Index");
        }
    }
}