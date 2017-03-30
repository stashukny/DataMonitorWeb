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
    public class WatchersController : Controller
    {
        private DataMonitorEntities db = new DataMonitorEntities();

        // GET: Watchers
        public ActionResult Index()
        {
            var watchers = db.Watchers.Include(w => w.Client).Include(w => w.Level).Include(w => w.Metric).Include(w => w.Notification).Include(w => w.Source).Include(w => w.Threashold);
            return View(watchers.ToList());
        }

        // GET: Watchers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Watcher watcher = db.Watchers.Find(id);
            if (watcher == null)
            {
                return HttpNotFound();
            }
            return View(watcher);
        }

        // GET: Watchers/Create
        public ActionResult Create()
        {
            ViewBag.ClientId = new SelectList(db.Clients, "Id", "Name");
            ViewBag.LevelId = new SelectList(db.Levels, "Id", "Name");
            ViewBag.MetricId = new SelectList(db.Metrics, "Id", "Name");
            ViewBag.NotificationId = new SelectList(db.Notifications, "Id", "Name");
            ViewBag.SourceId = new SelectList(db.Sources, "Id", "Name");
            ViewBag.ThreasholdId = new SelectList(db.Threasholds, "Id", "Name");
            return View();
        }

        // POST: Watchers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,LevelId,ClientId,SourceId,MetricId,ThreasholdId,NotificationId,LastValue")] Watcher watcher)
        {
            if (ModelState.IsValid)
            {
                db.Watchers.Add(watcher);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClientId = new SelectList(db.Clients, "Id", "Name", watcher.ClientId);
            ViewBag.LevelId = new SelectList(db.Levels, "Id", "Name", watcher.LevelId);
            ViewBag.MetricId = new SelectList(db.Metrics, "Id", "Name", watcher.MetricId);
            ViewBag.NotificationId = new SelectList(db.Notifications, "Id", "Name", watcher.NotificationId);
            ViewBag.SourceId = new SelectList(db.Sources, "Id", "Name", watcher.SourceId);
            ViewBag.ThreasholdId = new SelectList(db.Threasholds, "Id", "Name", watcher.ThreasholdId);
            return View(watcher);
        }

        public JsonResult Sources_List(int ClientId)
        {
            var sources = db.Sources
            .Where(f => f.ClientId == ClientId)
            .ToList()
            .Select(c => new
            {                
                SourceId = c.Id,
                SourceText = c.Name
            });

            return Json(new SelectList(sources.ToArray(), "SourceId", "SourceText"), JsonRequestBehavior.AllowGet);
        }

        public JsonResult Metrics_List(int SourceId)
        {
            var metrics = db.Metrics
            .Where(f => f.SourceId == SourceId)
            .ToList()
            .Select(c => new
            {                
                MetricId = c.Id,
                MetricText = c.Name
            });

            return Json(new SelectList(metrics.ToArray(), "MetricId", "MetricText"), JsonRequestBehavior.AllowGet);
        }

        // GET: Watchers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Watcher watcher = db.Watchers.Find(id);
            if (watcher == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClientId = new SelectList(db.Clients, "Id", "Name", watcher.ClientId);
            ViewBag.LevelId = new SelectList(db.Levels, "Id", "Name", watcher.LevelId);
            ViewBag.SourceId = new SelectList(db.Sources.Where(f => f.ClientId == watcher.ClientId), "Id", "Name", watcher.SourceId);
            ViewBag.MetricId = new SelectList(db.Metrics.Where(f => f.SourceId == watcher.SourceId), "Id", "Name", watcher.MetricId);
            ViewBag.NotificationId = new SelectList(db.Notifications, "Id", "Name", watcher.NotificationId);
            
            ViewBag.ThreasholdId = new SelectList(db.Threasholds, "Id", "Name", watcher.ThreasholdId);
            return View(watcher);
        }

        // POST: Watchers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,LevelId,ClientId,SourceId,MetricId,ThreasholdId,NotificationId,LastValue")] Watcher watcher)
        {
            if (ModelState.IsValid)
            {
                db.Entry(watcher).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClientId = new SelectList(db.Clients, "Id", "Name", watcher.ClientId);
            ViewBag.LevelId = new SelectList(db.Levels, "Id", "Name", watcher.LevelId);
            ViewBag.MetricId = new SelectList(db.Metrics, "Id", "Name", watcher.MetricId);
            ViewBag.NotificationId = new SelectList(db.Notifications, "Id", "Name", watcher.NotificationId);
            ViewBag.SourceId = new SelectList(db.Sources, "Id", "Name", watcher.SourceId);
            ViewBag.ThreasholdId = new SelectList(db.Threasholds, "Id", "Name", watcher.ThreasholdId);
            return View(watcher);
        }

        // GET: Watchers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Watcher watcher = db.Watchers.Find(id);
            if (watcher == null)
            {
                return HttpNotFound();
            }
            return View(watcher);
        }

        // POST: Watchers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Watcher watcher = db.Watchers.Find(id);
            db.Watchers.Remove(watcher);
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
