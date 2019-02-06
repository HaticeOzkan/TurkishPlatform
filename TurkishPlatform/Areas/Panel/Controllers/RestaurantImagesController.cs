using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TurkishPlatform.Models;

namespace TurkishPlatform.Areas.Panel.Controllers
{
    public class RestaurantImagesController : Controller
    {
        private PlatformContext db = new PlatformContext();

        // GET: Panel/RestaurantImages
        public ActionResult Index()
        {
            var restaurantImages = db.RestaurantImages.Include(r => r.Restaurant);
            return View(restaurantImages.ToList());
        }

        // GET: Panel/RestaurantImages/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RestaurantImage restaurantImage = db.RestaurantImages.Find(id);
            if (restaurantImage == null)
            {
                return HttpNotFound();
            }
            return View(restaurantImage);
        }

        // GET: Panel/RestaurantImages/Create
        public ActionResult Create()
        {
            ViewBag.RestaurantId = new SelectList(db.Restaurants, "RestaurantId", "RestaurantName");
            return View();
        }

        // POST: Panel/RestaurantImages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ImageId,ImageURL,RestaurantId")] RestaurantImage restaurantImage)
        {
            if (ModelState.IsValid)
            {
                db.RestaurantImages.Add(restaurantImage);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RestaurantId = new SelectList(db.Restaurants, "RestaurantId", "RestaurantName", restaurantImage.RestaurantId);
            return View(restaurantImage);
        }

        // GET: Panel/RestaurantImages/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RestaurantImage restaurantImage = db.RestaurantImages.Find(id);
            if (restaurantImage == null)
            {
                return HttpNotFound();
            }
            ViewBag.RestaurantId = new SelectList(db.Restaurants, "RestaurantId", "RestaurantName", restaurantImage.RestaurantId);
            return View(restaurantImage);
        }

        // POST: Panel/RestaurantImages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ImageId,ImageURL,RestaurantId")] RestaurantImage restaurantImage)
        {
            if (ModelState.IsValid)
            {
                db.Entry(restaurantImage).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RestaurantId = new SelectList(db.Restaurants, "RestaurantId", "RestaurantName", restaurantImage.RestaurantId);
            return View(restaurantImage);
        }

        // GET: Panel/RestaurantImages/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RestaurantImage restaurantImage = db.RestaurantImages.Find(id);
            if (restaurantImage == null)
            {
                return HttpNotFound();
            }
            return View(restaurantImage);
        }

        // POST: Panel/RestaurantImages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RestaurantImage restaurantImage = db.RestaurantImages.Find(id);
            db.RestaurantImages.Remove(restaurantImage);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
