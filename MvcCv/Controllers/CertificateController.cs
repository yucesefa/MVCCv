using MvcCv.Models.Entity;
using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class CertificateController : Controller
    {
        GenericRepository<tblCertificate> genericRepository = new GenericRepository<tblCertificate>();
        public ActionResult Index()
        {
            var values = genericRepository.List();
            return View(values);
        }
        [HttpGet]
        public ActionResult EditCertificate(int id)
        {
            var values = genericRepository.Find(x => x.ID == id);
            ViewBag.d=id;   
            return View(values);
        }
        [HttpPost]
        public ActionResult EditCertificate(tblCertificate p)
        {
            var values = genericRepository.Find(x => x.ID == p.ID);
            values.Description = p.Description;
            values.Date = p.Date;
            genericRepository.TUpdate(values);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult AddCertificate()
        {
            return  View();
        }
        [HttpPost]
        public ActionResult AddCertificate(tblCertificate p)
        {
            genericRepository.TAdd(p);
            return RedirectToAction("Index");
        }
        public ActionResult DeleteCertificate(int id)
        {
            var values = genericRepository.Find(x => x.ID == id);
            genericRepository.TDelete(values);
            return RedirectToAction("Index");
        }
    }
}