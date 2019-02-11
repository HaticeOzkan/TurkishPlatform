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

			ViewBag.AllRestaurant = db.Restaurants.ToList();

			return View(data);
		}
    }
}