using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DataMonitorWeb.Models;

namespace DataMonitorWeb.Controllers
{
    public class ThreasholdsController : Controller
    {
        private DataMonitorEntities db = new DataMonitorEntities();

        // GET: Threasholds
        public ActionResult Index()
        {
            return View(db.Threasholds.ToList());
        }

        // GET: Threasholds/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Threashold threashold = db.Threasholds.Find(id);
            if (threashold == null)
            {
                return HttpNotFound();
            }
            return View(threashold);
        }

        // GET: Threasholds/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Threasholds/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Percentage")] Threashold threashold)
        {
            if (ModelState.IsValid)
            {
                db.Threasholds.Add(threashold);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(threashold);
        }

        // GET: Threasholds/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Threashold threashold = db.Threasholds.Find(id);
            if (threashold == null)
            {
                return HttpNotFound();
            }
            return View(threashold);
        }

        // POST: Threasholds/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Percentage")] Threashold threashold)
        {
            if (ModelState.IsValid)
            {
                db.Entry(threashold).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(threashold);
        }

        // GET: Threasholds/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Threashold threashold = db.Threasholds.Find(id);
            if (threashold == null)
            {
                return HttpNotFound();
            }
            return View(threashold);
        }

        // POST: Threasholds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Threashold threashold = db.Threasholds.Find(id);
            db.Threasholds.Remove(threashold);
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
