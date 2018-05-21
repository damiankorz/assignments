using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace PasscodeGenerator.Controllers 
{
    public class IndexController : Controller
    {
        [HttpGet]
        [Route("")]
        public IActionResult Index(string passcode)
        {
            int? count = HttpContext.Session.GetInt32("count");
            if (count == null)
            {
                count = 0;
                HttpContext.Session.SetInt32("count", 0);
            }
            HttpContext.Session.SetInt32("count", (int)count);
            ViewBag.Count = count;
            ViewBag.Passcode = passcode;
            return View();
        }
        [HttpPost]
        [Route("generate")]
        public IActionResult Generate()
        {
            //Generate random passcode 
            Random rand = new Random();
            string[] pool = new string[] {"A","B","C","D","E","F","G","H","I","J","K","L","M","N","O","P","Q","R","S","T","U","V","W","X","Y","Z","0","1","2","3","4","5","6","7","8","9"};
            string randomPasscode = "";
            string[] setChar = new string[14];
            for (int i = 0; i < setChar.Length; i++)
            {
                setChar[i] = pool[rand.Next(0, pool.Length)];
            }
            foreach (string j in setChar)
            {
                randomPasscode += j;
            }
            //Increment session count for each passcode generation
            int? count = HttpContext.Session.GetInt32("count");
            count ++;
            HttpContext.Session.SetInt32("count", (int)count);
            return RedirectToAction("Index", new {passcode = randomPasscode});
        }
    }
}