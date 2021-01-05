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
    public class DaysListsController : Controller
    {
        private RailwayMSDbEntities db = new RailwayMSDbEntities();

        // GET: DaysLists
        public ActionResult Index()
        {
            return View(db.DaysLists.ToList());
        }

        // GET: DaysLists/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DaysList daysList = db.DaysLists.Find(id);
            if (daysList == null)
            {
                return HttpNotFound();
            }
            return View(daysList);
        }

        // GET: DaysLists/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DaysLists/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,DayName")] DaysList daysList)
        {
            if (ModelState.IsValid)
            {
                db.DaysLists.Add(daysList);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(daysList);
        }

        // GET: DaysLists/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DaysList daysList = db.DaysLists.Find(id);
            if (daysList == null)
            {
                return HttpNotFound();
            }
            return View(daysList);
        }

        // POST: DaysLists/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,DayName")] DaysList daysList)
        {
            if (ModelState.IsValid)
            {
                db.Entry(daysList).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(daysList);
        }

        // GET: DaysLists/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DaysList daysList = db.DaysLists.Find(id);
            if (daysList == null)
            {
                return HttpNotFound();
            }
            return View(daysList);
        }

        // POST: DaysLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DaysList daysList = db.DaysLists.Find(id);
            db.DaysLists.Remove(daysList);
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
