using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using WeddingPlanner.Models;

namespace WeddingPlanner.Controllers
{
    public class PlannerController : Controller
    {
        private PlannerContext _context;
        public PlannerController(PlannerContext context)
        {
            _context = context;
        }
        // GET: /
        [HttpGet("/dashboard")]
        public IActionResult Dashboard()
        {
            if(HttpContext.Session.GetInt32("id") != null)
            {
                DashViewModels data = new DashViewModels 
                {
                    AllWeddings = _context.Weddings.Include(w => w.Attendees).ToList(),
                    User = _context.Users
                        .Where(u => u.ID == HttpContext.Session.GetInt32("id"))
                        .SingleOrDefault()
                };
                return View(data);
            }
            return View("Index", "User");
        }
        // GET: /new
        [HttpGet("new")]
        public IActionResult New()
        {
            return View();
        }
        // GET: /weddings/id
        [HttpGet("weddings/{id}")]
        public IActionResult Wedding(int id)
        {
            return View(_context.Weddings
                            .Include(w => w.Attendees)
                            .ThenInclude(a => a.User)
                            .Where(w => w.ID == id)
                            .SingleOrDefault());
        }
        // GET: /weddings/id/delete
        [HttpGet("weddings/{id}/delete")]
        public IActionResult Delete(int id)
        {
            Wedding retrievedWedding = _context.Weddings.SingleOrDefault(w => w.ID == id);
            _context.Remove(retrievedWedding);
            _context.SaveChanges();
            return RedirectToAction("Dashboard");
        }
        // GET: /weddings/id/rsvp
        [HttpGet("weddings/{id}/rsvp")]
        public IActionResult RSVP(int id)
        {
            RSVP rsvp = new RSVP
            {
                WeddingID = id,
                UserID = (int)HttpContext.Session.GetInt32("id")
            };
            _context.RSVPs.Add(rsvp);
            _context.SaveChanges();
            return RedirectToAction("Dashboard");
        }
        // GET: /weddings/id/un-rsvp
        [HttpGet("weddings/{id}/un-rsvp")]
        public IActionResult UnRSVP(int id)
        {
            RSVP retrievedRSVP = _context.RSVPs.SingleOrDefault(r => r.UserID == HttpContext.Session.GetInt32("id") && r.WeddingID == id);
            _context.Remove(retrievedRSVP);
            _context.SaveChanges();
            return RedirectToAction("Dashboard");
        }
        // POST: /create
        [HttpPost("create")]
        public IActionResult Create(WeddingCreation model)
        {
            if(ModelState.IsValid)
            {
                Wedding wedding = new Wedding 
                {
                    UserID = (int)HttpContext.Session.GetInt32("id"),
                    Groom = model.Groom,
                    Bride = model.Bride,
                    Date = model.Date,
                    Address = model.Address,
                };
                _context.Add(wedding);
                _context.SaveChanges();
                return RedirectToAction("Dashboard");
            }
            return View("New", model);
        }
        // GET: /logout
        [HttpGet("logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "User");
        }
    }
}
