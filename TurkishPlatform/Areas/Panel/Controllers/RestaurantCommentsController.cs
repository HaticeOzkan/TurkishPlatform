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
    public class RestaurantCommentsController : Controller
    {
        private PlatformContext db = new PlatformContext();

        // GET: Panel/RestaurantComments
        public ActionResult Index()
        {
            var restaurantComments = db.RestaurantComments.Include(r => r.Restaurant).Include(r => r.User);
            return View(restaurantComments.ToList());
        }

        // GET: Panel/RestaurantComments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RestaurantComment restaurantComment = db.RestaurantComments.Find(id);
            if (restaurantComment == null)
            {
                return HttpNotFound();
            }
            return View(restaurantComment);
        }

        // GET: Panel/RestaurantComments/Create
        public ActionResult Create()
        {
            ViewBag.RestaurantId = new SelectList(db.Restaurants, "RestaurantId", "RestaurantName");
            ViewBag.UserId = new SelectList(db.Users, "UserId", "NameSurname");
            return View();
        }

        // POST: Panel/RestaurantComments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CommentId,Content,UserId,RestaurantId")] RestaurantComment restaurantComment)
        {
            if (ModelState.IsValid)
            {
                db.RestaurantComments.Add(restaurantComment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RestaurantId = new SelectList(db.Restaurants, "RestaurantId", "RestaurantName", restaurantComment.RestaurantId);
            ViewBag.UserId = new SelectList(db.Users, "UserId", "NameSurname", restaurantComment.UserId);
            return View(restaurantComment);
        }

        // GET: Panel/RestaurantComments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RestaurantComment restaurantComment = db.RestaurantComments.Find(id);
            if (restaurantComment == null)
            {
                return HttpNotFound();
            }
            ViewBag.RestaurantId = new SelectList(db.Restaurants, "RestaurantId", "RestaurantName", restaurantComment.RestaurantId);
            ViewBag.UserId = new SelectList(db.Users, "UserId", "NameSurname", restaurantComment.UserId);
            return View(restaurantComment);
        }

        // POST: Panel/RestaurantComments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CommentId,Content,UserId,RestaurantId")] RestaurantComment restaurantComment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(restaurantComment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RestaurantId = new SelectList(db.Restaurants, "RestaurantId", "RestaurantName", restaurantComment.RestaurantId);
            ViewBag.UserId = new SelectList(db.Users, "UserId", "NameSurname", restaurantComment.UserId);
            return View(restaurantComment);
        }

        // GET: Panel/RestaurantComments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RestaurantComment restaurantComment = db.RestaurantComments.Find(id);
            if (restaurantComment == null)
            {
                return HttpNotFound();
            }
            return View(restaurantComment);
        }

        // POST: Panel/RestaurantComments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RestaurantComment restaurantComment = db.RestaurantComments.Find(id);
            db.RestaurantComments.Remove(restaurantComment);
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
