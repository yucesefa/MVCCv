using MvcCv.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class DefaultController : Controller
    {
        DbCvEntities db = new DbCvEntities();
        public ActionResult Index()
        {
            var values = db.tblAbout.ToList();
            return View(values);
        }
        public PartialViewResult Experience()
        {
            var values = db.tblExpreience.ToList();
            return PartialView(values);
        }
        public PartialViewResult Education()
        {
            var values = db.tblEducation.ToList();
            return PartialView(values);
        }
        public PartialViewResult Skills()
        {
            var values = db.tblSkills.ToList();
            return PartialView(values);
        }
        public PartialViewResult Project()
        {
            var values = db.tblProject.ToList();
            return PartialView(values);
        }
        public PartialViewResult Certificate()
        {
            var values = db.tblCertificate.ToList();
            return PartialView(values);
        } public PartialViewResult SocialMedia()
        {
            var values = db.tblSocialMedia.ToList();
            return PartialView(values);
        }
        public PartialViewResult Script()
        {
            return PartialView();
        }
        public PartialViewResult Head()
        {
            return PartialView();
        }
        [HttpGet]
        public PartialViewResult Contact()
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult Contact(tblContact contact)
        {
            contact.Date =DateTime.Parse(DateTime.Now.ToShortDateString());
            db.tblContact.Add(contact);
            db.SaveChanges();
            return PartialView();
        }
    }
}