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
        public ActionResult TourismTravelDetails(int id)
        {
            PlatformContext db = new PlatformContext();
            ViewBag.Country = db.Countries.Where(x => x.CountryId == id);
            Country countries =( from c in db.Countries where c.CountryId==id select c).FirstOrDefault();
            return View(countries);
        }
    }
}