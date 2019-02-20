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
    public class LocationCommentsController : Controller
    {
        private PlatformContext db = new PlatformContext();

        // GET: Panel/LocationComments
        public ActionResult Index()
        {
            var locationComments = db.LocationComments.Include(l => l.Location).Include(l => l.User);
            return View(locationComments.ToList());
        }

        // GET: Panel/LocationComments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LocationComment locationComment = db.LocationComments.Find(id);
            if (locationComment == null)
            {
                return HttpNotFound();
            }
            return View(locationComment);
        }

        // GET: Panel/LocationComments/Create
        public ActionResult Create()
        {
            ViewBag.LocationId = new SelectList(db.Tourisms, "LocationId", "LocationName");
            ViewBag.UserId = new SelectList(db.Users, "UserId", "NameSurname");
            return View();
        }

        // POST: Panel/LocationComments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CommentId,Content,UserId,LocationId,Permission")] LocationComment locationComment)
        {
            if (ModelState.IsValid)
            {
                db.LocationComments.Add(locationComment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.LocationId = new SelectList(db.Tourisms, "LocationId", "LocationName", locationComment.LocationId);
            ViewBag.UserId = new SelectList(db.Users, "UserId", "NameSurname", locationComment.UserId);
            return View(locationComment);
        }

        // GET: Panel/LocationComments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LocationComment locationComment = db.LocationComments.Find(id);
            if (locationComment == null)
            {
                return HttpNotFound();
            }
            ViewBag.LocationId = new SelectList(db.Tourisms, "LocationId", "LocationName", locationComment.LocationId);
            ViewBag.UserId = new SelectList(db.Users, "UserId", "NameSurname", locationComment.UserId);
            return View(locationComment);
        }

        // POST: Panel/LocationComments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CommentId,Content,UserId,LocationId,Permission")] LocationComment locationComment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(locationComment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.LocationId = new SelectList(db.Tourisms, "LocationId", "LocationName", locationComment.LocationId);
            ViewBag.UserId = new SelectList(db.Users, "UserId", "NameSurname", locationComment.UserId);
            return View(locationComment);
        }

        // GET: Panel/LocationComments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LocationComment locationComment = db.LocationComments.Find(id);
            if (locationComment == null)
            {
                return HttpNotFound();
            }
            return View(locationComment);
        }

        // POST: Panel/LocationComments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LocationComment locationComment = db.LocationComments.Find(id);
            db.LocationComments.Remove(locationComment);
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
