using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TurkishPlatform.Models;

namespace TurkishPlatform.Controllers
{
    public class TourismTravelController : Controller
    {
        // GET: TourismTravel
        public ActionResult Index()
        {
            PlatformContext db = new PlatformContext();

            ViewBag.AllTourism = db.Tourisms.ToList();
            return View(db.Tourisms.ToList());
        }
    }
}