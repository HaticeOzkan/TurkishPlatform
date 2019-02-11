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
        public ActionResult Index()
        {
			PlatformContext db = new PlatformContext();
			RestaurantViewModel data = new RestaurantViewModel();
			data.RestaurantId = db.Restaurants.Select(x => x.RestaurantId).FirstOrDefault();
			data.RestaurantName = db.Restaurants.Select(x => x.RestaurantName).FirstOrDefault();
			data.Address = db.Restaurants.Select(x => x.Address).FirstOrDefault();
			data.CoverImageURL = db.Restaurants.Select(x => x.CoverImageURL).FirstOrDefault();

			ViewBag.AllRestaurant = db.Restaurants.ToList();

			return View(data);
		}

		public ActionResult RestaurantDetail(int id, HttpPostedFileBase Image)
		{
			PlatformContext db = new PlatformContext();
			int RestaurantId = (from b in db.Restaurants
							  where b.RestaurantId == id
							  select b.RestaurantId).FirstOrDefault();
			ViewBag.Id = id;


			List<Restaurant> Restaurants = (from a in db.Restaurants
										 where a.RestaurantId == id
										 select a).ToList();
			
			
			return View(Restaurants);
		}
    }
}