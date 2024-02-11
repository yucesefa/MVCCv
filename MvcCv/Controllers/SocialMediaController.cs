using MvcCv.Models.Entity;
using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class SocialMediaController : Controller
    {
        GenericRepository <tblSocialMedia> repository = new GenericRepository<tblSocialMedia>();   
        public ActionResult Index()
        {
            var values = repository.List();
            return View(values);
        }
        [HttpGet]
        public ActionResult AddSocialMedia()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddSocialMedia(tblSocialMedia p)
        {
            repository.TAdd(p);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult EditSocialMedia(int id)
        {
            var values = repository.Find(x => x.SocialMediaID == id);
            return View(values);
        }
        [HttpPost]
        public ActionResult EditSocialMedia(tblSocialMedia p)
        {
            var values = repository.Find(x => x.SocialMediaID == p.SocialMediaID);
            values.SocialMedia = p.SocialMedia;
            values.Link = p.Link;
            values.Icon = p.Icon;
            repository.TUpdate(values);
            return RedirectToAction("Index");
        }
        public ActionResult DeleteSocialMedia(int id)
        {
            var values = repository.Find(x => x.SocialMediaID == id);
            repository.TDelete(values);
            return RedirectToAction("Index");
        }
    }
}