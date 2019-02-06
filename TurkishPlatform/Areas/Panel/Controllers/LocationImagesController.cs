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
    public class LocationImagesController : Controller
    {
        private PlatformContext db = new PlatformContext();

        // GET: Panel/LocationImages
        public ActionResult Index()
        {
            var locationImages = db.LocationImages.Include(l => l.Location);
            return View(locationImages.ToList());
        }

        // GET: Panel/LocationImages/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LocationImage locationImage = db.LocationImages.Find(id);
            if (locationImage == null)
            {
                return HttpNotFound();
            }
            return View(locationImage);
        }

        // GET: Panel/LocationImages/Create
        public ActionResult Create()
        {
            ViewBag.LocationId = new SelectList(db.Tourisms, "LocationId", "LocationName");
            return View();
        }

        // POST: Panel/LocationImages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ImageId,ImageURL,LocationId")] LocationImage locationImage)
        {
            if (ModelState.IsValid)
            {
                db.LocationImages.Add(locationImage);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.LocationId = new SelectList(db.Tourisms, "LocationId", "LocationName", locationImage.LocationId);
            return View(locationImage);
        }

        // GET: Panel/LocationImages/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LocationImage locationImage = db.LocationImages.Find(id);
            if (locationImage == null)
            {
                return HttpNotFound();
            }
            ViewBag.LocationId = new SelectList(db.Tourisms, "LocationId", "LocationName", locationImage.LocationId);
            return View(locationImage);
        }

        // POST: Panel/LocationImages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ImageId,ImageURL,LocationId")] LocationImage locationImage)
        {
            if (ModelState.IsValid)
            {
                db.Entry(locationImage).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.LocationId = new SelectList(db.Tourisms, "LocationId", "LocationName", locationImage.LocationId);
            return View(locationImage);
        }

        // GET: Panel/LocationImages/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LocationImage locationImage = db.LocationImages.Find(id);
            if (locationImage == null)
            {
                return HttpNotFound();
            }
            return View(locationImage);
        }

        // POST: Panel/LocationImages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LocationImage locationImage = db.LocationImages.Find(id);
            db.LocationImages.Remove(locationImage);
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
