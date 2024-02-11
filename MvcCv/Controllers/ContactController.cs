using MvcCv.Models.Entity;
using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class ContactController : Controller
    {
        GenericRepository<tblContact> genericRepository=new GenericRepository<tblContact>();
        public ActionResult Index()
        {
            var values  = genericRepository.List();
            return View(values);
        }
    }
}