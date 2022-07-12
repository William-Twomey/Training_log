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
    public class DeadliftsController : Controller
    {
        private Weight_TrainingDBEntitiesCTX db = new Weight_TrainingDBEntitiesCTX();

        // GET: Deadlifts
        public ActionResult Index()
        {
            return View(db.Deadlifts.ToList());
        }

        // GET: Deadlifts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Deadlift deadlift = db.Deadlifts.Find(id);
            if (deadlift == null)
            {
                return HttpNotFound();
            }
            return View(deadlift);
        }

        // GET: Deadlifts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Deadlifts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,DateOfLift,WeightKG,Repetitions")] Deadlift deadlift)
        {
            if (ModelState.IsValid)
            {
                db.Deadlifts.Add(deadlift);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(deadlift);
        }

        // GET: Deadlifts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Deadlift deadlift = db.Deadlifts.Find(id);
            if (deadlift == null)
            {
                return HttpNotFound();
            }
            return View(deadlift);
        }

        // POST: Deadlifts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,DateOfLift,WeightKG,Repetitions")] Deadlift deadlift)
        {
            if (ModelState.IsValid)
            {
                db.Entry(deadlift).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(deadlift);
        }

        // GET: Deadlifts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Deadlift deadlift = db.Deadlifts.Find(id);
            if (deadlift == null)
            {
                return HttpNotFound();
            }
            return View(deadlift);
        }

        // POST: Deadlifts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Deadlift deadlift = db.Deadlifts.Find(id);
            db.Deadlifts.Remove(deadlift);
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
