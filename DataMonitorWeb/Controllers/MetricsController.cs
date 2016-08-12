﻿using System;
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
    public class MetricsController : Controller
    {
        private DataMonitorEntities db = new DataMonitorEntities();

        // GET: Metrics
        public ActionResult Index()
        {
            var metrics = db.Metrics.Include(m => m.Source);
            return View(metrics.ToList());
        }

        // GET: Metrics/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Metric metric = db.Metrics.Find(id);
            if (metric == null)
            {
                return HttpNotFound();
            }
            return View(metric);
        }

        // GET: Metrics/Create
        public ActionResult Create()
        {
            ViewBag.SourceId = new SelectList(db.Sources, "Id", "Name");
            return View();
        }

        // POST: Metrics/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,SourceId,Name")] Metric metric)
        {
            if (ModelState.IsValid)
            {
                db.Metrics.Add(metric);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SourceId = new SelectList(db.Sources, "Id", "Name", metric.SourceId);
            return View(metric);
        }

        // GET: Metrics/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Metric metric = db.Metrics.Find(id);
            if (metric == null)
            {
                return HttpNotFound();
            }
            ViewBag.SourceId = new SelectList(db.Sources, "Id", "Name", metric.SourceId);
            return View(metric);
        }

        // POST: Metrics/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,SourceId,Name")] Metric metric)
        {
            if (ModelState.IsValid)
            {
                db.Entry(metric).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SourceId = new SelectList(db.Sources, "Id", "Name", metric.SourceId);
            return View(metric);
        }

        // GET: Metrics/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Metric metric = db.Metrics.Find(id);
            if (metric == null)
            {
                return HttpNotFound();
            }
            return View(metric);
        }

        // POST: Metrics/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Metric metric = db.Metrics.Find(id);
            db.Metrics.Remove(metric);
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
