﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace cs330215MIS4200_1045_sp20.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Some Fun Facts ";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Casey Lynn Shows";

            return View();
        }
    }
}