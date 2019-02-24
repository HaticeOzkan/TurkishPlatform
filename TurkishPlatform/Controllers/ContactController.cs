using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TurkishPlatform.Models;

namespace TurkishPlatform.Controllers
{
    public class ContactController : Controller
    {
		PlatformContext db = new PlatformContext();
        [HttpGet]
		public ActionResult Index()
		{
            Session["TopFive"] = Repository.ScoreViewListFill();
            return View();
		}

		[HttpPost]
        public ActionResult Index(ContactViewModel msg)
        {
			Contact contact = new Contact();

			if (ModelState.IsValid)
			{
				contact.Content = msg.Message;
				int idUser = Convert.ToInt32(Session["EnterID"]);
				contact.User = db.Users.Find(idUser);
				ViewBag.Warning = "Mesajınız gönderildi, teşekkürler :)";

				db.Contacts.Add(contact);
				db.SaveChanges();
			}

			return View();
        }
    }
}