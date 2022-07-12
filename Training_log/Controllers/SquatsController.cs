using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Training_log.Models;

namespace Training_log.Controllers
{
    public class SquatsController : Controller
    {
        private Weight_TrainingDBEntitiesCTX db = new Weight_TrainingDBEntitiesCTX();

        // GET: Squats
        public ActionResult Index()
        {
            return View(db.Squats.ToList());
        }

        // GET: Squats/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Squat squat = db.Squats.Find(id);
            if (squat == null)
            {
                return HttpNotFound();
            }
            return View(squat);
        }

        // GET: Squats/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Squats/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,DateOfLift,WeightKG,Repetitions")] Squat squat)
        {
            if (ModelState.IsValid)
            {
                db.Squats.Add(squat);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(squat);
        }

        // GET: Squats/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Squat squat = db.Squats.Find(id);
            if (squat == null)
            {
                return HttpNotFound();
            }
            return View(squat);
        }

        // POST: Squats/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,DateOfLift,WeightKG,Repetitions")] Squat squat)
        {
            if (ModelState.IsValid)
            {
                db.Entry(squat).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(squat);
        }

        // GET: Squats/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Squat squat = db.Squats.Find(id);
            if (squat == null)
            {
                return HttpNotFound();
            }
            return View(squat);
        }

        // POST: Squats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Squat squat = db.Squats.Find(id);
            db.Squats.Remove(squat);
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
