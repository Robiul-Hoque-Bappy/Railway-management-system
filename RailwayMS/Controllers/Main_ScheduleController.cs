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
    public class Main_ScheduleController : Controller
    {
        private RailwayMSDbEntities db = new RailwayMSDbEntities();

        // GET: Main_Schedule
        public ActionResult Index()
        {
            var main_Schedule = db.Main_Schedule.Include(m => m.Route).Include(m => m.Sub_Route).Include(m => m.train).OrderBy(x => x.RouteId);
            return View(main_Schedule.OrderBy(x=>x.Sub_Route.ShortOrder).ToList());
        }

        // GET: Main_Schedule/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Main_Schedule main_Schedule = db.Main_Schedule.Find(id);
            if (main_Schedule == null)
            {
                return HttpNotFound();
            }
            return View(main_Schedule);
        }

        public ActionResult Create()
        {
            ViewBag.RouteId = new SelectList(db.Routes, "Id", "Name");
            ViewBag.SubRouteId = new SelectList(db.Sub_Route, "Id", "Station_Name");
            ViewBag.TrainId = new SelectList(db.trains, "id", "name");
            ViewBag.Day = new SelectList(db.DaysLists, "DayName", "DayName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Main_Schedule main_Schedule)
        {
            if (ModelState.IsValid)
            {
                // string Sql= $@"select  date,train,route from RegularSchedule where train
                //= {main_Schedule.TrainId} and  day =  and route = @route"

                var list = db.Main_Schedule.Where(x => (x.TrainId == main_Schedule.TrainId && x.Day == main_Schedule.Day && x.RouteId == main_Schedule.RouteId) || (x.TrainId == main_Schedule.TrainId && x.Day == main_Schedule.Day && x.ArrivalTime >= main_Schedule.ArrivalTime && x.DepartureTime <= main_Schedule.ArrivalTime)).FirstOrDefault();
                if(list != null)
                {
                    ViewBag.message = "Sorry !";
                    return View();
                }

                double speed = Convert.ToDouble(db.trains.Find(main_Schedule.TrainId).speed);
                double startingTime = Convert.ToDouble(main_Schedule.ArrivalTime);
                List<Sub_Route> subroute = new List<Sub_Route>();
                subroute = db.Sub_Route.Where(x => x.RouteId == main_Schedule.RouteId).OrderBy(x => x.ShortOrder).ToList();
                if(subroute != null)
                {
                    double dis = 0;
                    double atime =0.00;
                    double dtime = 0.00;
                    double spd = Convert.ToDouble(db.trains.Find(main_Schedule.TrainId).speed);  //Speed comes from the train table .. class is Schedulecalcu
                    double stime = Convert.ToDouble(main_Schedule.ArrivalTime);

                    foreach (var item in subroute)
                    {
                            dis = Convert.ToDouble(item.Distance);
                            //totaldis = totaldis + dt[i]; //total distance store kortase ai variable

                            double du = ((double)dis / (double)speed) * 60;
                            double temp5 = du % 60;

                            double temp2 = temp5 / 100;

                            double temp = du / 60;
                            double temp1 = (int)temp + temp2;

                            stime = tcal(stime, temp1);

                            double temp3 = stime - (int)stime;

                            while (temp3 > .59)
                            {
                                stime = stime - .6;
                                stime = stime + 1;
                                temp3 = stime - (int)stime;
                            }


                            if (stime > 23.59)
                            {
                                stime = stime - 23.00;
                            }

                            atime = (float)stime;
                            dtime = atime + .1;
                            double temp4 = dtime - (int)dtime;
                            while (temp4 > .59)
                            {
                                dtime = dtime - .6;
                                dtime = dtime + 1;
                                temp4 = dtime - (int)dtime;
                            }

                        main_Schedule.TrainId = main_Schedule.TrainId;
                        main_Schedule.RouteId = item.RouteId;
                        main_Schedule.SubRouteId = item.Id;
                        main_Schedule.Day = main_Schedule.Day;
                        main_Schedule.ArrivalTime = System.Math.Round(atime, 2);
                        main_Schedule.DepartureTime = System.Math.Round(dtime, 2);
                        main_Schedule.IsActive = true;
                        db.Main_Schedule.Add(main_Schedule);
                        db.SaveChanges();

                        stime = dtime;
                    }

                    Main_Schedule_Details mainScheduleDetails = new Main_Schedule_Details();
                    mainScheduleDetails.RouteId = main_Schedule.RouteId;
                    mainScheduleDetails.TrainId = main_Schedule.TrainId;
                    mainScheduleDetails.ArrivalTime = main_Schedule.ArrivalTime;
                    mainScheduleDetails.ReachedTime = stime;
                    mainScheduleDetails.Day = main_Schedule.Day;
                    mainScheduleDetails.Status = "Yes";
                    db.Main_Schedule_Details.Add(mainScheduleDetails);

                }
                else
                {
                    return HttpNotFound();
                }

                
                return RedirectToAction("Index");
            }

            ViewBag.RouteId = new SelectList(db.Routes, "Id", "Name", main_Schedule.RouteId);
            ViewBag.SubRouteId = new SelectList(db.Sub_Route, "Id", "Station_Name", main_Schedule.SubRouteId);
            ViewBag.TrainId = new SelectList(db.trains, "id", "name", main_Schedule.TrainId);
            ViewBag.Day = new SelectList(db.DaysLists, "DayName", "DayName");
            return View(main_Schedule);
        }

        public static double tcal(double n, double m)
        {
            double f1, f2, f3, f4, f5, f6;
            f1 = n - (int)n;
            f2 = m - (int)m;
            f1 = f1 * 100;
            f2 = f2 * 100;
            f3 = f1 + f2;
            f4 = f3 % 60;
            f4 = f4 / 100;
            f5 = f3 / 60;
            f5 = (int)f5 + f4;
            f6 = (int)n + (int)m + f5;
            return f6;
        }

        // GET: Main_Schedule/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Main_Schedule main_Schedule = db.Main_Schedule.Find(id);
            if (main_Schedule == null)
            {
                return HttpNotFound();
            }
            ViewBag.RouteId = new SelectList(db.Routes, "Id", "Name", main_Schedule.RouteId);
            ViewBag.SubRouteId = new SelectList(db.Sub_Route, "Id", "Station_Name", main_Schedule.SubRouteId);
            ViewBag.TrainId = new SelectList(db.trains, "id", "name", main_Schedule.TrainId);
            return View(main_Schedule);
        }

        // POST: Main_Schedule/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,TrainId,SubRouteId,RouteId,Day,ArrivalTime,DepartureTime,IsActive")] Main_Schedule main_Schedule)
        {
            if (ModelState.IsValid)
            {
                db.Entry(main_Schedule).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RouteId = new SelectList(db.Routes, "Id", "Name", main_Schedule.RouteId);
            ViewBag.SubRouteId = new SelectList(db.Sub_Route, "Id", "Station_Name", main_Schedule.SubRouteId);
            ViewBag.TrainId = new SelectList(db.trains, "id", "name", main_Schedule.TrainId);
            return View(main_Schedule);
        }

        // GET: Main_Schedule/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Main_Schedule main_Schedule = db.Main_Schedule.Find(id);
            if (main_Schedule == null)
            {
                return HttpNotFound();
            }
            return View(main_Schedule);
        }

        // POST: Main_Schedule/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Main_Schedule main_Schedule = db.Main_Schedule.Find(id);
            db.Main_Schedule.Remove(main_Schedule);
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
