﻿using MvcCases.Models;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCases.Controllers
{
    public class Demo1Controller : Controller
    {
        CustomerDb db = new CustomerDb();
        // GET: Demo1
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult PageData(int currentPage=1,int pageSize=10)
        {
            
            List<Customer> customers = db.Customers.OrderBy(c => c.CustomerID).Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();

            return Json(new {totalPage= Math.Ceiling(1.0*db.Customers.Count()/pageSize),data = customers },JsonRequestBehavior.AllowGet);
        }
        public ActionResult PageDataShow()
        {
            return View("PageData");
        }
        public  ActionResult DropDown()
        {
            ViewData["items"] = new List<SelectListItem> {
                new SelectListItem{Text=Color.Red.ToString(),Value= Convert.ToInt32(Color.Red).ToString() },
                 new SelectListItem{Text=Color.Green.ToString(),Value= Convert.ToInt32(Color.Green).ToString(),Selected=true },
                  new SelectListItem{Text=Color.Yellow.ToString(),Value= Convert.ToInt32(Color.Yellow).ToString() }
            };
          List<SelectListItem> items =  ViewData["items"] as List<SelectListItem>;
         
            return View();
        }
        public ActionResult BindSelect()
        {

           
            return View("BindSelect",null, JsonConvert.SerializeObject(new ArrayList
          {
              new {Text=Color.Red.ToString(),Value= Convert.ToInt32(Color.Red).ToString() },
              new {Text=Color.Green.ToString(),Value= Convert.ToInt32(Color.Green).ToString()},
              new {Text=Color.Yellow.ToString(),Value= Convert.ToInt32(Color.Yellow).ToString()}
          }));
        }

       
    }
    public enum Color
    {
        Red,
        Green,
        Yellow
    }
}