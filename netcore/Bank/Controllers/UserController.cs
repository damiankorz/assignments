using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Bank.Models;

namespace Bank.Controllers
{
    public class UserController : Controller
    {
        private AccountContext _context;
        public UserController(AccountContext context)
        {
            _context = context;
        }
        // GET: / 
        [HttpGet("")]
        public IActionResult Index()
        {
            // check if user id is in session
            if(HttpContext.Session.GetInt32("userID") != null)
            {
                return RedirectToAction("Index", "Transaction", new{id = HttpContext.Session.GetInt32("userID")});
            }
            return View();
        }
        // POST /register/process
        [HttpPost("register/process")]
        public IActionResult ProcessReg(UserRegister model)
        {
            if(ModelState.IsValid)
            {
                // Check for unique email 
                List<User> users = _context.Users.Where(user => user.Email == model.Email).ToList();
                if(users.Count > 0)
                {
                    ModelState.AddModelError("Email", "Email already exists");
                    return View("Index");
                }
                else 
                {
                    // Hash password and add to db
                    PasswordHasher<UserRegister> hasher = new PasswordHasher<UserRegister>();
                    string hashedPassword = hasher.HashPassword(model, model.Password);
                    User user = new User
                    {
                        FirstName = model.FirstName,
                        LastName = model.LastName,
                        Email = model.Email,
                        Password = hashedPassword
                    };
                    _context.Add(user);
                    _context.SaveChanges();
                    HttpContext.Session.SetInt32("userID", (int)user.ID);
                    return RedirectToAction("Index", "Transaction", new{id = user.ID});
                }
            }
            return View("Index");
        }
        // GET: /login 
        [HttpGet("login")]
        public IActionResult Login()
        {
            if(HttpContext.Session.GetInt32("userID") != null)
            {
                return RedirectToAction("Index", "Transaction", new{id = HttpContext.Session.GetInt32("userID")});
            }
            return View();
        }
        // POST: /login/process
        [HttpPost("login/process")]
        public IActionResult ProcessLog(UserLogin model)
        {
            if(ModelState.IsValid)
            {
                // Check if user(s) is returned based on email input
                List<User> users = _context.Users.Where(user => user.Email == model.Email).ToList();
                if(users.Count == 0)
                {
                    ModelState.AddModelError("Password", "Invalid email/password");
                }
                else
                {
                    // Grab hashed password from db and match it against users input
                    PasswordHasher<UserLogin> hasher = new PasswordHasher<UserLogin>();
                    string hashedPassword = users[0].Password;
                    PasswordVerificationResult result = hasher.VerifyHashedPassword(model, hashedPassword, model.Password);
                    if(result == PasswordVerificationResult.Failed)
                    {
                        ModelState.AddModelError("Password", "Invalid email/password");
                    }
                    else 
                    {
                        HttpContext.Session.SetInt32("userID", (int)users[0].ID);
                        return RedirectToAction("Index", "Transaction", new{id = users[0].ID});
                    }
                }
            }
            return View("Login");
        }
    }
}
