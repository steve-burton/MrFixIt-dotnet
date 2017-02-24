﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MrFixIt.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace MrFixIt.Controllers
{
    public class JobsController : Controller
    {
        private MrFixItContext db = new MrFixItContext();

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View(db.Jobs.Include(i => i.Worker).ToList());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Job job)
        {
            db.Jobs.Add(job);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Claim(int id)
        {
            var thisItem = db.Jobs.FirstOrDefault(items => items.JobId == id);
            return View(thisItem);
        }

        [HttpPost]
        public IActionResult Claim(Job job)
        {
            job.Worker = db.Workers.FirstOrDefault(i => i.UserName == User.Identity.Name);
            db.Entry(job).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult WorkingJob(bool WorkingJob)
        {          
            var thisJob = db.Jobs.FirstOrDefault(job => job.Pending == WorkingJob);
            thisJob.Pending = true;
            db.Jobs.Add(thisJob);
            db.SaveChanges();
            return Json(thisJob);
        }

        [HttpPost]
        public IActionResult CompletedJob(bool CompletedJob)
        {
            var thisJob = db.Jobs.FirstOrDefault(job => job.Completed == CompletedJob);
            thisJob.Completed = true;
            db.Jobs.Add(thisJob);
            db.SaveChanges();
            return Json(thisJob);
        }
    }
}
