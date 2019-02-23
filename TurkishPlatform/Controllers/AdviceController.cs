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

<<<<<<< HEAD
        public ActionResult Content()
=======
        public ActionResult Contents()
>>>>>>> afcc95ed4cda52096032ac384c59d7c9407f59ed
        {
            return View();
        }
    }
}