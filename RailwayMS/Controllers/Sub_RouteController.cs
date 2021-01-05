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
    public class Sub_RouteController : Controller
    {
        private RailwayMSDbEntities db = new RailwayMSDbEntities();

        // GET: Sub_Route
        public ActionResult Index()
        {
            var sub_Route = db.Sub_Route.Include(s => s.Route);
            return View(sub_Route.ToList());
        }

        // GET: Sub_Route/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sub_Route sub_Route = db.Sub_Route.Find(id);
            if (sub_Route == null)
            {
                return HttpNotFound();
            }
            return View(sub_Route);
        }

        // GET: Sub_Route/Create
        public ActionResult Create()
        {
            ViewBag.RouteId = new SelectList(db.Routes, "Id", "Name");
            ViewBag.Station_Name = new SelectList(db.stations, "Name", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Station_Name,RouteId,IsActive,Distance,ShortOrder")] Sub_Route sub_Route)
        {
            if (ModelState.IsValid)
            {
                db.Sub_Route.Add(sub_Route);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RouteId = new SelectList(db.Routes, "Id", "Name", sub_Route.RouteId);
            ViewBag.Station_Name = new SelectList(db.stations, "Name", "Name", sub_Route.Station_Name);
            return View(sub_Route);
        }

        // GET: Sub_Route/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sub_Route sub_Route = db.Sub_Route.Find(id);
            if (sub_Route == null)
            {
                return HttpNotFound();
            }
            ViewBag.RouteId = new SelectList(db.Routes, "Id", "Name", sub_Route.RouteId);
            return View(sub_Route);
        }

        // POST: Sub_Route/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Station_Name,RouteId,IsActive,Distance,ShortOrder")] Sub_Route sub_Route)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sub_Route).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RouteId = new SelectList(db.Routes, "Id", "Name", sub_Route.RouteId);
            return View(sub_Route);
        }

        // GET: Sub_Route/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sub_Route sub_Route = db.Sub_Route.Find(id);
            if (sub_Route == null)
            {
                return HttpNotFound();
            }
            return View(sub_Route);
        }

        // POST: Sub_Route/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Sub_Route sub_Route = db.Sub_Route.Find(id);
            db.Sub_Route.Remove(sub_Route);
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
