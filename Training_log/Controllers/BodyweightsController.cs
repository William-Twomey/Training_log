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
    public class BodyweightsController : Controller
    {
        private Weight_TrainingDBEntitiesCTX db = new Weight_TrainingDBEntitiesCTX();

        // GET: Bodyweights
        public ActionResult Index()
        {
            return View(db.Bodyweights.ToList());
        }

        // GET: Bodyweights/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bodyweight bodyweight = db.Bodyweights.Find(id);
            if (bodyweight == null)
            {
                return HttpNotFound();
            }
            return View(bodyweight);
        }

        // GET: Bodyweights/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Bodyweights/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,DateOfLift,WeightKG")] Bodyweight bodyweight)
        {
            if (ModelState.IsValid)
            {
                db.Bodyweights.Add(bodyweight);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bodyweight);
        }

        // GET: Bodyweights/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bodyweight bodyweight = db.Bodyweights.Find(id);
            if (bodyweight == null)
            {
                return HttpNotFound();
            }
            return View(bodyweight);
        }

        // POST: Bodyweights/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,DateOfLift,WeightKG")] Bodyweight bodyweight)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bodyweight).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bodyweight);
        }

        // GET: Bodyweights/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bodyweight bodyweight = db.Bodyweights.Find(id);
            if (bodyweight == null)
            {
                return HttpNotFound();
            }
            return View(bodyweight);
        }

        // POST: Bodyweights/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Bodyweight bodyweight = db.Bodyweights.Find(id);
            db.Bodyweights.Remove(bodyweight);
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
