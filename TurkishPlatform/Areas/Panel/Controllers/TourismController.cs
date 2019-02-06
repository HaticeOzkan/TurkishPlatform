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
    public class TourismController : Controller
    {
        private PlatformContext db = new PlatformContext();

        // GET: Panel/Tourism
        public ActionResult Index()
        {
            var tourisms = db.Tourisms.Include(t => t.Country);
            return View(tourisms.ToList());
        }

        // GET: Panel/Tourism/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tourism tourism = db.Tourisms.Find(id);
            if (tourism == null)
            {
                return HttpNotFound();
            }
            return View(tourism);
        }

        // GET: Panel/Tourism/Create
        public ActionResult Create()
        {
            ViewBag.CountryId = new SelectList(db.Countries, "CountryId", "CountryName");
            return View();
        }

        // POST: Panel/Tourism/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LocationId,LocationName,Content,Address,CountryId")] Tourism tourism)
        {
            if (ModelState.IsValid)
            {
                db.Tourisms.Add(tourism);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CountryId = new SelectList(db.Countries, "CountryId", "CountryName", tourism.CountryId);
            return View(tourism);
        }

        // GET: Panel/Tourism/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tourism tourism = db.Tourisms.Find(id);
            if (tourism == null)
            {
                return HttpNotFound();
            }
            ViewBag.CountryId = new SelectList(db.Countries, "CountryId", "CountryName", tourism.CountryId);
            return View(tourism);
        }

        // POST: Panel/Tourism/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LocationId,LocationName,Content,Address,CountryId")] Tourism tourism)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tourism).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CountryId = new SelectList(db.Countries, "CountryId", "CountryName", tourism.CountryId);
            return View(tourism);
        }

        // GET: Panel/Tourism/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tourism tourism = db.Tourisms.Find(id);
            if (tourism == null)
            {
                return HttpNotFound();
            }
            return View(tourism);
        }

        // POST: Panel/Tourism/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tourism tourism = db.Tourisms.Find(id);
            db.Tourisms.Remove(tourism);
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
