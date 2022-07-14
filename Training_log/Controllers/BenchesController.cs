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
    public class BenchesController : Controller
    {
        private Weight_TrainingDBEntitiesCTX db = new Weight_TrainingDBEntitiesCTX();

        // GET: Benches
        public ActionResult Index()
        {
            return View(db.Benches.ToList());
        }

        // GET: Benches/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bench bench = db.Benches.Find(id);
            if (bench == null)
            {
                return HttpNotFound();
            }
            return View(bench);
        }

        // GET: Benches/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Benches/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,DateOfLift,WeightKG,Repetitions")] Bench bench)
        {
            if (ModelState.IsValid)
            {
                db.Benches.Add(bench);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bench);
        }

        // GET: Benches/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bench bench = db.Benches.Find(id);
            if (bench == null)
            {
                return HttpNotFound();
            }
            return View(bench);
        }

        // POST: Benches/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,DateOfLift,WeightKG,Repetitions")] Bench bench)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bench).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bench);
        }

        // GET: Benches/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bench bench = db.Benches.Find(id);
            if (bench == null)
            {
                return HttpNotFound();
            }
            return View(bench);
        }

        // POST: Benches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Bench bench = db.Benches.Find(id);
            db.Benches.Remove(bench);
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
