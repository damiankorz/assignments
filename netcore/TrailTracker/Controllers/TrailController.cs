using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TrailTracker.Models;
using TrailTracker.Factories;

namespace TrailTracker.Controllers
{
    public class TrailController : Controller
    {
        private readonly TrailFactory trailFactory;
        public TrailController()
        {
            trailFactory = new TrailFactory();
        }
        [HttpGet("")]
        public IActionResult Index()
        {
            ViewBag.AllTrails = trailFactory.GetAllTrails();
            return View();
        }
        [HttpGet("trails/{id}")]
        public IActionResult Trail(int id)
        {
            ViewBag.SingleTrail = trailFactory.GetSingleTrail(id);
            return View();
        }
        [HttpGet("trails/new")]
        public IActionResult NewTrail()
        {
            return View();
        }
        [HttpPost("trails/add")]
        public IActionResult AddTrail(Trail trail)
        {
            if(ModelState.IsValid)
            {
                trailFactory.AddTrail(trail);
                return RedirectToAction("Index");
            }
            return View("NewTrail");
        }
    }
}
