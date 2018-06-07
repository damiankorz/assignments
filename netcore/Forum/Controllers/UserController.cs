using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using Forum.Models;

namespace Forum
{
    public class UserController : Controller
    {
        private readonly DbConnector _dbConnector;
        public UserController(DbConnector connect)
        {
            _dbConnector = connect;
        }
        // Check session 
        public IActionResult CheckSession(string view)
        {
            // Check if user ID is in session, if true redirect to main page
            int? userID = HttpContext.Session.GetInt32("userID");
            if(userID != null)
            {
                return RedirectToAction("Index", "Forum");
            }
            return View(view);
        }
        // GET: /
        [HttpGet("")]
        public IActionResult Index() => CheckSession("Index");
        // GET: /login 
        [HttpGet("login")]
        public IActionResult Login() => CheckSession("Login");
        // GET: /register
        [HttpGet("register")]
        public IActionResult Register() => CheckSession("Register");
        // GET: /logout 
        [HttpGet("logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }
        // POST: /login 
        [HttpPost("login")]
        public IActionResult Login(UserLogin user)
        {
            if(ModelState.IsValid)
            {
                // Check if user is returned based on email 
                var users = _dbConnector.Query($"SELECT id, password FROM users WHERE email = '{user.LoginEmail}'");
                if(users.Count == 0)
                {
                    ModelState.AddModelError("LoginEmail", "Incorrect email/password");
                    return View(user);
                }
                else
                {
                    PasswordHasher<UserLogin> hasher = new PasswordHasher<UserLogin>();
                    string hashedPassword = (string)users[0]["password"];
                    PasswordVerificationResult result = hasher.VerifyHashedPassword(user, hashedPassword, user.LoginPassword);
                    if(result == PasswordVerificationResult.Failed)
                    {
                        ModelState.AddModelError("LoginPassword", "Incorrect email/password");
                        return View(user);
                    }
                    else
                    {
                        int? userID = (int)users[0]["id"];
                        HttpContext.Session.SetInt32("userID", (int)userID);
                        return RedirectToAction("Index", "Forum");
                    }
                }
            }
            return View(user);
        }
        // POST: /register
        [HttpPost("register")]
        public IActionResult Register(UserRegister user)
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
                    PasswordHasher<UserRegister> hasher = new PasswordHasher<UserRegister>();
                    string hashedPassword = hasher.HashPassword(user, user.Password);
                    string query = $"INSERT INTO users (first_name, last_name, email, password, created_at, updated_at) VALUES('{user.FirstName}','{user.LastName}','{user.Email}','{hashedPassword}', NOW(), NOW());";
                    _dbConnector.Execute(query);
                    int? userID = (int)_dbConnector.Query("SELECT id FROM users ORDER BY created_at DESC LIMIT 1;")[0]["id"];
                    HttpContext.Session.SetInt32("userID", (int)userID);
                    return RedirectToAction("Index", "Forum");
                }
            }
            return View(user);
        }
    }
}