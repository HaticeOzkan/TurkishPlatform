using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TurkishPlatform.Models;

namespace TurkishPlatform.Controllers
{
    public class AdviceController : Controller
    {
        PlatformContext db = new PlatformContext();

        public ActionResult Index()
        {
            ViewBag.Topics = db.AdviceTopics.ToList();
            return View();
        }

        [HttpGet]
        public ActionResult Contents()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Contents(int id)
        {
            Advice adv = db.Advices.Find(id);
            return View(adv);
        }
    }
}