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
    public class ForumCommentCategoriesController : Controller
    {
        private PlatformContext db = new PlatformContext();

        // GET: Panel/ForumCommentCategories
        public ActionResult Index()
        {
            var forumCommentCategories = db.ForumCommentCategories.Include(f => f.Country);
            return View(forumCommentCategories.ToList());
        }

        // GET: Panel/ForumCommentCategories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ForumCommentCategory forumCommentCategory = db.ForumCommentCategories.Find(id);
            if (forumCommentCategory == null)
            {
                return HttpNotFound();
            }
            return View(forumCommentCategory);
        }

        // GET: Panel/ForumCommentCategories/Create
        public ActionResult Create()
        {
            ViewBag.CountryId = new SelectList(db.Countries, "CountryId", "CountryName");
            return View();
        }

        // POST: Panel/ForumCommentCategories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CategoryId,CategoryName,CountryId")] ForumCommentCategory forumCommentCategory)
        {
            if (ModelState.IsValid)
            {
                db.ForumCommentCategories.Add(forumCommentCategory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CountryId = new SelectList(db.Countries, "CountryId", "CountryName", forumCommentCategory.CountryId);
            return View(forumCommentCategory);
        }

        // GET: Panel/ForumCommentCategories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ForumCommentCategory forumCommentCategory = db.ForumCommentCategories.Find(id);
            if (forumCommentCategory == null)
            {
                return HttpNotFound();
            }
            ViewBag.CountryId = new SelectList(db.Countries, "CountryId", "CountryName", forumCommentCategory.CountryId);
            return View(forumCommentCategory);
        }

        // POST: Panel/ForumCommentCategories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CategoryId,CategoryName,CountryId")] ForumCommentCategory forumCommentCategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(forumCommentCategory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CountryId = new SelectList(db.Countries, "CountryId", "CountryName", forumCommentCategory.CountryId);
            return View(forumCommentCategory);
        }

        // GET: Panel/ForumCommentCategories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ForumCommentCategory forumCommentCategory = db.ForumCommentCategories.Find(id);
            if (forumCommentCategory == null)
            {
                return HttpNotFound();
            }
            return View(forumCommentCategory);
        }

        // POST: Panel/ForumCommentCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ForumCommentCategory forumCommentCategory = db.ForumCommentCategories.Find(id);
            db.ForumCommentCategories.Remove(forumCommentCategory);
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
