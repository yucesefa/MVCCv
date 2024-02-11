using MvcCv.Models.Entity;
using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class AdminController : Controller
    {
        AdminRepository repository = new AdminRepository();
        public ActionResult Index()
        {
            var values = repository.List();
            return View(values);
        }
        [HttpGet]
        public ActionResult AddAdmin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddAdmin(tblAdmin p)
        {
            repository.TAdd(p);
            return RedirectToAction("Index");
        }
        public ActionResult DeleteAdmin(int id)
        {
            tblAdmin t = repository.Find(x => x.ID == id);
            repository.TDelete(t);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult GetAdmin(int id)
        {
            tblAdmin t = repository.Find(x => x.ID == id);
            return View(t);
        }
        [HttpPost]
        public ActionResult GetAdmin(tblAdmin p)
        {
            tblAdmin t = repository.Find(x => x.ID == p.ID);
            t.UserName = p.UserName;
            t.Password = p.Password;
            repository.TUpdate(t);
            return RedirectToAction("Index");
        }
    }
}