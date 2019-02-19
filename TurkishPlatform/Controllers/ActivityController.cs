using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TurkishPlatform.Models;

namespace TurkishPlatform.Controllers
{
    public class ActivityController : Controller
    {
        // GET: Activity
        [HttpGet]
        public ActionResult Index()
        {
            PlatformContext db = new PlatformContext();

            //ViewBag.ParticipationF = db.Activities.Where(x => x.Participation == false).Count();
       
            return View(db.Activities.ToList());
        }
        [HttpPost]
        public ActionResult Index(string Search)
        {
            PlatformContext db = new PlatformContext();
            var activity = from m in db.Activities
                           select m;

            if (!String.IsNullOrEmpty(Search))
            {
                activity = activity.Where(a => a.Title.Contains(Search));

            }
            return View(activity.ToList());

            //return View(db.Activities.ToList());
        }
        [HttpGet]
        public ActionResult Create()
        {
            PlatformContext db = new PlatformContext();
            
            ViewBag.Ukeler = db.Activities.ToList();

            //ViewBag.PossibleParents = db.Activities.ToList();
            return View();
        }
        [HttpPost]
        public ActionResult Create(string name, DateTime date, DateTime StartTime, DateTime FinishTime, HttpPostedFileBase Image, string Content, string Address, int Kontejyan)
        {
            PlatformContext db = new PlatformContext();
           
                string klasor = Server.MapPath("/Uploads/Activity/");
            Image.SaveAs(klasor + Image.FileName);

            Activity activity = new Activity();
            activity.Address = Address;
            activity.Title = name;
            activity.StartTime = StartTime;
            activity.FinishTime = FinishTime;
            activity.Date = date;
            activity.CountryId = 2;
            activity.Content = Content;
            activity.ImageURL = "/Uploads/Activity/" + Image.FileName;
            activity.UserId = 35;
            activity.NumberofParticipations = Kontejyan;



            if (ModelState.IsValid)
            {
                try
                {
                    db.Activities.Add(activity);
                    try
                    {
                        db.SaveChanges();
                    }
                    catch (DbUpdateException ex1)
                    {
                        var b = ex1.InnerException;

                    }


                }
                catch (DbEntityValidationException ex)

                {
                    var a = ex.EntityValidationErrors;
                }

                return RedirectToAction("Index");
            }

            //ViewBag.PossibleParents = db.Activities.ToList();
            return View();
        }
        [HttpGet]
        public ActionResult ActivityDetails(int id, HttpPostedFileBase Image, int kullaniciId)
        {

            PlatformContext db = new PlatformContext();
            int AvtivityId = (from b in db.Activities
                              where b.ActivityId == id
                              select b.ActivityId).FirstOrDefault();
            int KullaniciId = (from b in db.Activities
                               where b.UserId == kullaniciId
                               select b.UserId).FirstOrDefault();
            ViewBag.Id = id;
            ViewBag.KullaniciId = KullaniciId;
            Activity Activities = (from a in db.Activities
                                   where a.ActivityId == id & a.UserId == kullaniciId
                                   select a).FirstOrDefault();
            return View(Activities);

        }

        [HttpPost]

        public ActionResult ActivityDetails(int id, int kullaniciId)
        {
            PlatformContext db = new PlatformContext();
            int AvtivityId = (from b in db.Activities
                              where b.ActivityId == id
                              select b.ActivityId).FirstOrDefault();
            int KullaniciId = (from b in db.Activities
                               where b.UserId == kullaniciId
                               select b.UserId).FirstOrDefault();
            ViewBag.Id = id;
            ViewBag.KullaniciId = KullaniciId;
            Activity Activities = (from a in db.Activities
                                   where a.ActivityId == id & a.UserId == kullaniciId
                                   select a).FirstOrDefault();
            return View(Activities);

        }

        //[HttpPost]

        public JsonResult AcceptDeny(int id, int kullaniciId, int sonuc)
        {
            PlatformContext db = new PlatformContext();
            Activity a = new Activity();
            if (sonuc == 1)
            {
                var update = db.Activities.FirstOrDefault(x => x.ActivityId == id && x.UserId == kullaniciId);
                update.Participation = true;
                db.SaveChanges();
                //a.Participation = true;
                //a.ActivityId = id;
                //a.UserId = kullaniciId;
                return Json(a);

            }
            else
            {
                //a.Participation = false;
                //a.ActivityId = id;
                //a.UserId = kullaniciId;
                string message = "";
                try
                {
                    //DB Update işlemleri yapılacak
                    //var update = db.Activities.Where(x => x.ActivityId == id);
                    var update = db.Activities.FirstOrDefault(x => x.ActivityId == id && x.UserId == kullaniciId);
                    update.Participation = false;
                    db.SaveChanges();

                    message = "Success";
                }
                catch (Exception ex)
                {
                    message = "Error";
                }

                return Json(message);
                //kim hangi etkinliğe katılıyor oonu onu bul onun üsütnden calış
            }

        }
    }
}


