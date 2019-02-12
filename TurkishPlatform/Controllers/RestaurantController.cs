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

		
		public JsonResult RestaurantDetail(int id)
		{
			Restaurant r = db.Restaurants.Where(x => x.RestaurantId == id).FirstOrDefault();
			return Json(r, JsonRequestBehavior.AllowGet);
		}
    }
}