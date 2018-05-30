using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QuotingDojo.Models;
using DbConnection;

namespace QuotingDojo.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("")]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost("create")]
        public IActionResult CreateEntry(string NameField, string QuoteField)
        {
            if (NameField == null || QuoteField == null)
            {
                ViewBag.Error = "Cannot leave name nor quote blank";
                return View("Error");
            }
            else
            {
                string query = $"INSERT INTO quotes (quote, name, created_at, updated_at) VALUES('{QuoteField}', '{NameField}', NOW(), NOW());";
                DbConnector.Execute(query);
                return RedirectToAction("Quotes");
            }
        }
        [HttpGet("quotes")]
        public IActionResult Quotes()
        {
            string query = "SELECT * FROM quotes ORDER BY created_at desc;";
            ViewBag.AllQuotes = DbConnector.Query(query);
            return View();
        }
    }
}
