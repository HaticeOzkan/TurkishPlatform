using System;
using System.Collections.Generic;
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
        public ActionResult Index()
        {
            PlatformContext db = new PlatformContext();
            return View(db.Activities.ToList());
        }
        [HttpGet]
        public ActionResult Create()
        {
            PlatformContext db = new PlatformContext();
            //ViewBag.PossibleParents = db.Activities.ToList();
            return View();
        }
        [HttpPost]
        public ActionResult Create(string name, DateTime date, DateTime StartTime, DateTime FinishTime, HttpPostedFileBase Image, int CountryId, string Content, string Address)
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
            activity.ImageURL = "/Uploads/Activity/ImageURL" + Image.FileName;
            activity.UserId = 3;
            


            if (ModelState.IsValid)
            {
                try
                {
                    db.Activities.Add(activity);
                    try
                    {
                        db.SaveChanges();
                    }
                    catch (DbUpdateException ex1) {
                        var b = ex1.InnerException;

                    }

               
            }
                catch (DbEntityValidationException ex)

            {
                  var a=  ex.EntityValidationErrors;
            }

            return RedirectToAction("Index");
            }

                //ViewBag.PossibleParents = db.Activities.ToList();
                return View();
            }
        }
    }
