﻿using AAO_App.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AAO_App.Controllers
{
    [Route("login")]

     public class LoginController : Controller
     {

         //dependency Injection
         private readonly ApplicationDbContext _db;

         public LoginController(ApplicationDbContext db)
         {
             _db = db;
         }


         [Route("")]
         [Route("index")]
         [Route("~/")]
         // GET: /<controller>/
         public IActionResult Index()
         {
             return View();
         }
         [Route("index")]
         [HttpPost]
         public IActionResult Login(string phone, string password)
         {
             if (phone != null && password != null && phone.Equals("acc1") && password.Equals("123"))
             {
                 HttpContext.Session.SetString("phone", phone);
                 return View("~/Views/Homepage/Index.cshtml");
             }
             else
             {
                 ViewBag.error = "Invalid Account";
                 return View("Index");
             }
         }
         [Route("logout")]
         [HttpGet]
         public IActionResult Logout()
         {
             HttpContext.Session.Remove("phone");
             return RedirectToAction("Index");
         }
     }
 
}