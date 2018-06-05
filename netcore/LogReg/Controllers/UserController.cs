using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using LogReg.Models;

namespace LogReg.Controllers
{
    public class UserController : Controller
    {
        private readonly DbConnector _dbConnector;
        public UserController(DbConnector connect)
        {
            _dbConnector = connect;
        }
        // GET: /
        [HttpGet("")]
        public IActionResult Index()
        {
            // Check if userID in session, if true, redirect to dashboard
            int? userID = HttpContext.Session.GetInt32("userID");
            if(userID != null)
            {
                return RedirectToAction("Dashboard");
            }
            return View();
        }
        // GET: /dashboard 
        [HttpGet("dashboard")]
        public IActionResult Dashboard()
        {
            // Check if userID is not in session, if true, redirect to home 
            int? userID = HttpContext.Session.GetInt32("userID");
            if(userID == null)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        // GET: /register 
        [HttpGet("register")]
        public IActionResult Register()
        {
            // Check if userID in session, if true, redirect to dashboard
            int? userID = HttpContext.Session.GetInt32("userID");
            if(userID != null)
            {
                return RedirectToAction("Dashboard");
            }
            return View();
        }
        // POST: /register
        [HttpPost("register")]
        public IActionResult Register(UserReg user)
        {
            if(ModelState.IsValid)
            {
                // Check for unique email 
                var users = _dbConnector.Query($"SELECT * FROM users WHERE email = '{user.Email}';");
                if(users.Count > 0)
                {
                    ModelState.AddModelError("Email", "Email already exists");
                    return View(user);
                }
                else
                {   
                    // Hash password and add user to database, store user id in session 
                    PasswordHasher<UserReg> hasher = new PasswordHasher<UserReg>();
                    string hashed = hasher.HashPassword(user, user.Password);
                    string query = $"INSERT INTO users (first_name, last_name, email, password, created_at, updated_at) VALUES('{user.FirstName}', '{user.LastName}', '{user.Email}', '{hashed}', NOW(), NOW());";
                    _dbConnector.Execute(query);
                    int? userID = (int)_dbConnector.Query("SELECT id FROM users ORDER BY created_at DESC LIMIT 1;")[0]["id"];
                    HttpContext.Session.SetInt32("userID", (int)userID);
                    return RedirectToAction("Dashboard");
                }
            }
            return View(user);
        }
        // GET: /login 
        [HttpGet("login")]
        public IActionResult Login()
        {
            // Check if userID in session, if true, redirect to dashboard
            int? userID = HttpContext.Session.GetInt32("userID");
            if(userID != null)
            {
                return RedirectToAction("Dashboard");
            }
            return View();
        }
        // POST: /login 
        [HttpPost("login")]
        public IActionResult Login(UserLog user)
        {
            if(ModelState.IsValid)
            {
                // Check if a user is returned based on email, return error if false
                var users = _dbConnector.Query($"SELECT id, password FROM users WHERE email = '{user.LogEmail}';");
                if(users.Count == 0)
                {
                    ModelState.AddModelError("LogEmail", "Incorrect email/password");
                    return View(user);
                }
                else 
                {
                    // Verify password, if failed return error, if succeed redirec to dashboard and store user id in session 
                    PasswordHasher<UserLog> hasher = new PasswordHasher<UserLog>();
                    string hashedPass = (string)users[0]["password"];
                    PasswordVerificationResult result = hasher.VerifyHashedPassword(user, hashedPass, user.LogPassword);
                    if(result == PasswordVerificationResult.Failed)
                    {
                        ModelState.AddModelError("LogPassword", "Incorrect email/password");
                        return View(user);
                    }
                    else
                    {
                        int? userID = (int)users[0]["id"];
                        HttpContext.Session.SetInt32("userID", (int)userID);
                        return RedirectToAction("Dashboard");
                    }
                }
            }
            return View(user);
        }
        // GET: /logout , clear session, redirect to home 
        [HttpGet("logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }
    }
}
