using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TurkishPlatform.Models;

namespace TurkishPlatform.Areas.Panel.Controllers
{
    public class ActivitieController : Controller
    {
        PlatformContext Db = new PlatformContext();
        // GET: Panel/Activitie
        public ActionResult Index()
        {
            
            return View(Db.Activities.ToList());
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Edit()
        {
            return View();
        }
        //public JsonResult Delete()
        //{

        //}

        
    }
}