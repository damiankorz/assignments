using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FormSubmission.Models;

namespace FormSubmission.Controllers
{
    public class UserController : Controller
    {
        private readonly DbConnector _dbConnector;
        public UserController(DbConnector connect)
        {
            _dbConnector = connect;
        }
        [HttpGet("")]
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet("success")]
        public IActionResult Success()
        {
            return View();
        }
        [HttpPost("register")]
        public IActionResult Register(string FirstName, string LastName, int? Age, string Email, string Password)
        {
            User NewUser = new User
            {
                FirstName = FirstName,
                LastName = LastName,
                Age = Age,
                Email = Email,
                Password = Password, 
            };
            // if validation fails, redirect back to form
            if (TryValidateModel(NewUser) == false)
            {
                ViewBag.errors = ModelState.Values;
                return View();
            }
            // if validation passes, add user to database and redirect to success 
            else 
            {
                string query = $"INSERT INTO Users (FirstName, LastName, Age, Email, Password) VALUES ('{FirstName}', '{LastName}', '{Age}', '{Email}', '{Password}');";
                _dbConnector.Query(query);
                return RedirectToAction("Success");
            }
        }
    }
}
