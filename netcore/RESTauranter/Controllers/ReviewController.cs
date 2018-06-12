using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RESTauranter.Models;

namespace RESTauranter.Controllers
{
    public class ReviewController : Controller
    {
        private readonly ReviewContext _context;
        public ReviewController(ReviewContext context)
        {
            _context = context;
        }
        // GET: /
        [HttpGet("")]
        public IActionResult Index()
        {
            return View();
        }
        // GET: /reviews 
        [HttpGet("reviews")]
        public IActionResult Reviews()
        {
            ViewBag.allReviews = _context.Reviews.OrderByDescending(review => review.CreatedAt).ToList();
            return View();
        }
        // POST: /create
        [HttpPost("create")]
        public IActionResult Create(Review review)
        {
            if(ModelState.IsValid)
            {
                _context.Reviews.Add(review);
                _context.SaveChanges();
                return RedirectToAction("Reviews");
            }
            return View("Index");
        }
    }
}
