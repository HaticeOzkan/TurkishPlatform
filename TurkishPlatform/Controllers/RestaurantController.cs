using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TurkishPlatform.Models;

namespace TurkishPlatform.Controllers
{
    public class RestaurantController : Controller
    {
		// GET: Restaurant
		PlatformContext db = new PlatformContext();
		public ActionResult Index()
        {
			RestaurantViewModel data = new RestaurantViewModel();
			data.RestaurantId = db.Restaurants.Select(x => x.RestaurantId).FirstOrDefault();
			data.RestaurantName = db.Restaurants.Select(x => x.RestaurantName).FirstOrDefault();
			data.Address = db.Restaurants.Select(x => x.Address).FirstOrDefault();
			data.CoverImageURL = db.Restaurants.Select(x => x.CoverImageURL).FirstOrDefault();

			ViewBag.AllRestaurant = db.Restaurants.ToList();

			return View(data);
		}

		
		public ActionResult RestaurantDetail(int id)
		{
			Restaurant r = db.Restaurants.Include("Country").FirstOrDefault(x => x.RestaurantId == id);
			ViewBag.RestaurantId = r.RestaurantId;
            ViewBag.Comment = db.RestaurantComments;

			return View(r);
		}

        [HttpPost]
        public ActionResult RestaurantDetail(RestaurantComment newComment)
        {
            return View();
        }
    }
}