﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CoreProject.Models;
using Microsoft.AspNetCore.Cors;

namespace CoreProject.Controllers
{
   
    public class HomeController : Controller
    {
        public IActionResult Index(MyModel myModel)
        {
           myModel = myModel.IsChecked==null ? new MyModel() { IsChecked="True"}:myModel;
            return View(myModel);
        }



        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        [Route("/[controller]/[action]/hello")]
        public IActionResult Json()
        {
            return Json(new { Message = "hi" });

            
        }
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
