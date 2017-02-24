﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MrFixIt.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace MrFixIt.Controllers
{
    public class HomeController : Controller
    {
        private MrFixItContext db = new MrFixItContext();

        // ### For Controller Test ### //
        public HomeController()
        {
        }
        public IActionResult Index()
        {
            return View();
        }

        // GET: /<controller>/

        //public IActionResult Index()
        //{
        //    if (User.Identity.IsAuthenticated)
        //    {
        //        var thisWorker = db.Workers.FirstOrDefault(item => item.UserName == User.Identity.Name);
        //        return View(thisWorker);
        //    } else
        //    {
        //        return View();
        //    }
        //}
    }
}
