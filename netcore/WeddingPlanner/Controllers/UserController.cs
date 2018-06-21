using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using WeddingPlanner.Models;

namespace WeddingPlanner.Controllers
{
    public class UserController : Controller
    {
        private PlannerContext _context;
        public UserController(PlannerContext context)
        {
            _context = context;
        }
        // GET: /
        [HttpGet("")]
        public IActionResult Index()
        {
            if(HttpContext.Session.GetInt32("id") == null)
            {
                return View();
            }
            return RedirectToAction("Dashboard", "Planner");
        }
        // POST: /login 
        [HttpPost("login")]
        public IActionResult Login(UserViewModels model)
        {
            if(ModelState.IsValid)
            {
                List<User> users = _context.Users.Where(u => u.Email == model.Login.LoginEmail).ToList();
                if(users.Count == 0)
                {
                    ModelState.AddModelError("LoginEmail", "Incorrect email/password");
                    return View("Index", model);
                }
                else 
                {
                    PasswordHasher<UserViewModels> hasher = new PasswordHasher<UserViewModels>();
                    string hashedPassword = users[0].Password;
                    PasswordVerificationResult result = hasher.VerifyHashedPassword(model, hashedPassword, model.Login.LoginPassword);
                    Console.WriteLine(hashedPassword);
                    Console.WriteLine(users[0].Email);
                    Console.WriteLine(result);
                    if(result == PasswordVerificationResult.Failed)
                    {
                        ModelState.AddModelError("LoginPassword", "Incorrect email/password");
                        return View("Index", model);
                    }
                    else
                    {
                        HttpContext.Session.SetInt32("id", users[0].ID);
                        return RedirectToAction("Dashboard", "Planner");
                    }
                }
            }
            return View("Index", model);
        }

        // POST: /register
        [HttpPost("register")]
        public IActionResult Register(UserViewModels model)
        {
            if(ModelState.IsValid)
            {
                List<User> users = _context.Users.Where(u => u.Email == model.Registration.Email).ToList();
                if(users.Count > 0)
                {
                    ModelState.AddModelError("Email", "Email already exists");
                    return View("Index", model);
                }
                PasswordHasher<UserViewModels> hasher = new PasswordHasher<UserViewModels>();
                string hashedPassword = hasher.HashPassword(model, model.Registration.Password);
                User user = new User
                {
                    FirstName = model.Registration.FirstName,
                    LastName = model.Registration.LastName,
                    Email = model.Registration.Email,
                    Password = hashedPassword
                };
                _context.Add(user);
                _context.SaveChanges();
                HttpContext.Session.SetInt32("id", user.ID);
                return RedirectToAction("Dashboard", "Planner");
            }
            return View("Index", model);
        }

    }
}
