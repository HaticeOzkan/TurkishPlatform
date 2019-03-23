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
            Session["TopFive"] = Repository.ScoreViewListFill();
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
            ViewBag.Comment = db.RestaurantComments.Where(x => x.RestaurantId == id).ToList();
            ViewBag.Country = from c in db.Countries
                              where c.CountryId == FindCountryId()
							  select c.CountryName;


			int FindCountryId()
			{
				if (Session["CountryId"] == null && (int)Session["ChooseCountry"] == 0)
					return 4;

				else if ((int)Session["ChooseCountry"] != 0)
					return (int)Session["ChooseCountry"];

				else
					return (int)Session["CountryId"];
			}

			return View(r);
		}

        [HttpPost]
        public ActionResult RestaurantDetail(string Content, int id)
        {

            RestaurantComment rComment = new RestaurantComment();

            rComment.Content = Content;
            rComment.RestaurantId = id;
			int idUser = Convert.ToInt32(Session["EnterID"]);
			rComment.User = db.Users.Find(idUser);
			//rComment.UserId = idUser; //üstteki yerine bunu yazdık.

            db.RestaurantComments.Add(rComment);
            db.SaveChanges();

            Restaurant rest = (from r in db.Restaurants where r.RestaurantId == id select r).FirstOrDefault();
            ViewBag.Comment = db.RestaurantComments.Where(x => x.RestaurantId == id).ToList();

            return View(rest);
        }

        public JsonResult DeleteComment(int deleteid)
        {
            RestaurantComment delComment = db.RestaurantComments.Find(deleteid);
            db.RestaurantComments.Remove(delComment);
            db.SaveChanges();

            return Json(2);
        }
    }
}
