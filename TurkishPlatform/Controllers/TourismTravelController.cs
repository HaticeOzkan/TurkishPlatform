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
        public ActionResult TourismTravelDetails(LocationComment d, int id ,int UserId,int locationId)
        { 
            int a = (int)Session["EnterID"];
            
            PlatformContext db = new PlatformContext();
            ViewBag.user = db.Users.Find(id);
            ViewBag.Comment = db.LocationComments.ToList();
            ViewBag.Tourism = db.Tourisms.Where(x => x.CountryId == id);
            Tourism countries =( from c in db.Tourisms where c.CountryId==id select c).FirstOrDefault();
             ViewBag.Comments = db.LocationComments.Where(x => x.LocationId == locationId & x.UserId == UserId);
            return View(countries);
        }
    }
}