using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RailwayMS.Models;

namespace RailwayMS.Controllers
{
    public class Main_Schedule_DetailsController : Controller
    {
        private RailwayMSDbEntities db = new RailwayMSDbEntities();

        // GET: Main_Schedule_Details
        public ActionResult Index()
        {
            var main_Schedule_Details = db.Main_Schedule_Details.Include(m => m.Route);
            return View(main_Schedule_Details.ToList());
        }

        // GET: Main_Schedule_Details/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Main_Schedule_Details main_Schedule_Details = db.Main_Schedule_Details.Find(id);
            if (main_Schedule_Details == null)
            {
                return HttpNotFound();
            }
            return View(main_Schedule_Details);
        }

        // GET: Main_Schedule_Details/Create
        public ActionResult Create()
        {
            ViewBag.RouteId = new SelectList(db.Routes, "Id", "Name");
            return View();
        }

        // POST: Main_Schedule_Details/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Day,RouteId,ArrivalTime,ReachedTime,Status")] Main_Schedule_Details main_Schedule_Details)
        {
            if (ModelState.IsValid)
            {
                db.Main_Schedule_Details.Add(main_Schedule_Details);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RouteId = new SelectList(db.Routes, "Id", "Name", main_Schedule_Details.RouteId);
            return View(main_Schedule_Details);
        }

        // GET: Main_Schedule_Details/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Main_Schedule_Details main_Schedule_Details = db.Main_Schedule_Details.Find(id);
            if (main_Schedule_Details == null)
            {
                return HttpNotFound();
            }
            ViewBag.RouteId = new SelectList(db.Routes, "Id", "Name", main_Schedule_Details.RouteId);
            return View(main_Schedule_Details);
        }

        // POST: Main_Schedule_Details/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Day,RouteId,ArrivalTime,ReachedTime,Status")] Main_Schedule_Details main_Schedule_Details)
        {
            if (ModelState.IsValid)
            {
                db.Entry(main_Schedule_Details).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RouteId = new SelectList(db.Routes, "Id", "Name", main_Schedule_Details.RouteId);
            return View(main_Schedule_Details);
        }

        // GET: Main_Schedule_Details/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Main_Schedule_Details main_Schedule_Details = db.Main_Schedule_Details.Find(id);
            if (main_Schedule_Details == null)
            {
                return HttpNotFound();
            }
            return View(main_Schedule_Details);
        }

        // POST: Main_Schedule_Details/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Main_Schedule_Details main_Schedule_Details = db.Main_Schedule_Details.Find(id);
            db.Main_Schedule_Details.Remove(main_Schedule_Details);
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
