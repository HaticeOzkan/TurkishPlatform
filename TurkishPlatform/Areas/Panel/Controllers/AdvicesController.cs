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
    public class AdvicesController : Controller
    {
        private PlatformContext db = new PlatformContext();

        // GET: Panel/Advices
        public ActionResult Index()
        {
            return View(db.Advices.ToList());
        }

        // GET: Panel/Advices/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Advice advice = db.Advices.Find(id);
            if (advice == null)
            {
                return HttpNotFound();
            }
            return View(advice);
        }

        // GET: Panel/Advices/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Panel/Advices/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AdviceId,Title,Content,ImageURL,Date,AdviceTopicID")] Advice advice)
        {
            if (ModelState.IsValid)
            {
                db.Advices.Add(advice);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(advice);
        }

        // GET: Panel/Advices/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Advice advice = db.Advices.Find(id);
            if (advice == null)
            {
                return HttpNotFound();
            }
            return View(advice);
        }

        // POST: Panel/Advices/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AdviceId,Title,Content,ImageURL,Date,AdviceTopicID")] Advice advice)
        {
            if (ModelState.IsValid)
            {
                db.Entry(advice).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(advice);
        }

        // GET: Panel/Advices/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Advice advice = db.Advices.Find(id);
            if (advice == null)
            {
                return HttpNotFound();
            }
            return View(advice);
        }

        // POST: Panel/Advices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Advice advice = db.Advices.Find(id);
            db.Advices.Remove(advice);
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
