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
        PlatformContext db = new PlatformContext();
        // GET: TourismTravel
        public ActionResult Index()
        {
            Session["TopFive"] = Repository.ScoreViewListFill();            
            ViewBag.AllTourism = db.Tourisms.ToList();
            return View(db.Tourisms.ToList());
        }

        [HttpGet]
        public ActionResult TourismTravelDetails(int id, int? UserId, int locationId)
        {          
            ViewBag.Name = UserId;
            ViewBag.c = (Session["EnterID"] == null); 
            ViewBag.user = db.Users.Find(id);
            ViewBag.Comment = db.LocationComments.ToList();
            ViewBag.Tourism = db.Tourisms.Where(x => x.CountryId == id);
            Tourism countries = (from c in db.Tourisms where c.CountryId == id select c).FirstOrDefault();
            ViewBag.Comments = db.LocationComments.Where(x => x.LocationId == locationId & x.UserId == UserId);
            return View(countries);
        }


        [HttpPost]
        public ActionResult TourismTravelDetails(string comment, int id, int? UserId, int locationId)
        {         
            ViewBag.c = (Session["EnterID"] == null);
            ViewBag.Name = UserId;
                //int a = (int)Session["EnterID"];
                if (!string.IsNullOrEmpty(comment))
            {
                LocationComment lc = new LocationComment();
                lc.Content = comment;
                lc.LocationId = (int)locationId;
                lc.UserId = (int)UserId;
                db.LocationComments.Add(lc);
                db.SaveChanges();
            } 

            ViewBag.user = db.Users.Find(UserId);
            ViewBag.Comment = db.LocationComments.ToList();
            ViewBag.Tourism = db.Tourisms.Where(x => x.CountryId == id);
            Tourism countries = (from c in db.Tourisms where c.CountryId == id select c).FirstOrDefault();
            ViewBag.Comments = db.LocationComments.Where(x => x.LocationId == locationId & x.UserId == UserId);
            return View(countries);
        }
        public JsonResult DeleteComment(int deleteid)
        {
            LocationComment delete = db.LocationComments.FirstOrDefault(x => x.CommentId == deleteid);
            db.LocationComments.Remove(delete);
            db.SaveChanges();
            return Json(2);
        }
    }
}