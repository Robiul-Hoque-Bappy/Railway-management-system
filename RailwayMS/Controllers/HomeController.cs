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
    public class HomeController : Controller
    {
        private RailwayMSDbEntities db = new RailwayMSDbEntities();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Schedule() 
        {
            var main_Schedule_Details = db.Main_Schedule_Details.Include(m => m.Route);
            return View(main_Schedule_Details.ToList());
        }

        public ActionResult LogIn()
        {
            return View();
        }
             
        public ActionResult LogOut() 
        {
            Session["Active"] = "Not Active";
            ViewBag.error = "Successfully Log Out Done";
            return View();
        }

        [HttpPost]
        public ActionResult LogIn(string UserName, string Password)
        {
            if(UserName == "Admin" && Password == "12345678")
            {
                Session["Active"] = "Active";
                Session["userName"] = "Admin";
                @ViewBag.error = "";
                return RedirectToAction(Session["page"].ToString());
            }
            else
            {
                Session["Active"] = "Not Active";
                ViewBag.error = "Not Matched";
                return View();
            }
            
        }



    }
}