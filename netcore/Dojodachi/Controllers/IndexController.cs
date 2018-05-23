using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Dojodachi.Controllers
{
    public class IndexController : Controller
    {
        [HttpGet("")]
        public IActionResult RouteToMain()
        {
            return RedirectToAction("Index");
        }
        [HttpGet("dojodachi")]
        public IActionResult Index(string message, string imageSource)
        {
            //set session fullness to 20 if null
            int? fullness = HttpContext.Session.GetInt32("fullness");
            if (fullness == null)
            {
                fullness = 20;
                HttpContext.Session.SetInt32("fullness", 20);
            }
            HttpContext.Session.SetInt32("fullness", (int)fullness);
            //set session fullness to zero if less than zero
            if (fullness < 0)
            {
                fullness = 0;
                HttpContext.Session.SetInt32("fullness", 0);
            }
            HttpContext.Session.SetInt32("fullness", (int)fullness);
            //set session happiness to 20 if null
            int? happiness = HttpContext.Session.GetInt32("happiness");
            if (happiness == null)
            {
                happiness = 20;
                HttpContext.Session.SetInt32("happiness", 20);
            }
            HttpContext.Session.SetInt32("happiness", (int)happiness);
            //set session happiness to zero if less than zero
            if (happiness < 0)
            {
                happiness = 0;
                HttpContext.Session.SetInt32("happiness", 0);
            }
            HttpContext.Session.SetInt32("happines", (int)happiness);
            //set session meals to 3 if null
            int? meals = HttpContext.Session.GetInt32("meals");
            if (meals == null)
            {
                meals = 3;
                HttpContext.Session.SetInt32("meals", 3);
            }
            HttpContext.Session.SetInt32("meals", (int)meals);
            //set session energy to 50 if null
            int? energy = HttpContext.Session.GetInt32("energy");
            if (energy == null)
            {
                energy = 50;
                HttpContext.Session.SetInt32("energy", 50);
            }
            HttpContext.Session.SetInt32("energy", (int)energy);
            //set message and image source if fullness or happiness drops below 1
            if (fullness < 1 || happiness < 1)
            {
                message = "Your Dojodachi has passed away.";
                imageSource = "death.gif";
            }
            //set message and image source if fullness, happiness, and energy are all above 100
            if (fullness > 100 && happiness > 100 && energy > 100)
            {
                message = "Congrats! You won!";
                imageSource = "win.gif";
            }
            //set default image if no source;
            if (imageSource == null)
            {
                imageSource = "main.gif";
            }
            ViewBag.ImageSource = imageSource;
            ViewBag.Fullness = fullness;
            ViewBag.Happiness = happiness;
            ViewBag.Meals = meals;
            ViewBag.Energy = energy;
            ViewBag.Message = message;
            return View();
        }
        [HttpPost("feed")]
        public IActionResult Feed()
        {
            Random rand = new Random();
            int? fullness = HttpContext.Session.GetInt32("fullness");
            int? meals = HttpContext.Session.GetInt32("meals");
            //if there are meals avaialble 
            if (meals > 0)
            {
                //25% chance the Dojodachi will not like its meal
                int chance = rand.Next(1,5);
                if (chance == 1)
                {
                    meals --;
                    HttpContext.Session.SetInt32("meals", (int)meals);
                    string reaction = "Your Dojodachi did not like its meal. Meals -1";
                    string src = "angry.gif";
                    return RedirectToAction("Index", new {message = reaction, imageSource = src});
                }
                else 
                {
                    //food increased by random quantity 
                    int foodQuantity = rand.Next(5, 11);
                    fullness += foodQuantity;
                    meals --;
                    HttpContext.Session.SetInt32("fullness", (int)fullness);
                    HttpContext.Session.SetInt32("meals", (int)meals);
                    string reaction = $"You fed your Dojodachi! Meals -1, Fullnes +{foodQuantity}";
                    string src = "happy.gif";
                    return RedirectToAction("Index", new {message = reaction, imageSource = src});
                }
            }
            //if there are no meals available
            else 
            {
                string reaction = "You have no meals to feed your Dojodachi!";
                string src = "sad.gif";
                return RedirectToAction("Index", new {message = reaction, imageSource = src});
            }
        }
        [HttpPost("play")]
        public IActionResult Play()
        {
            Random rand = new Random();
            int? energy = HttpContext.Session.GetInt32("energy");
            int? happiness = HttpContext.Session.GetInt32("happiness");
            //if energy is availabe 
            if (energy > 0)
            {
                //25% chance the Dojodachi will not like you playing with it
                int chance = rand.Next(1,5);
                if (chance == 1)
                {
                    energy -= 5;
                    HttpContext.Session.SetInt32("energy", (int)energy);
                    string reaction = "Your Dojodachi did not like you playing with it. Energy -5";
                    string src = "angry.gif";
                    return RedirectToAction("Index", new {message = reaction, imageSource = src});
                }
                else 
                {
                    //happiness increases by random quantity 
                    int happinessQuantity = rand.Next(5, 11);
                    energy -= 5;
                    happiness += happinessQuantity; 
                    HttpContext.Session.SetInt32("energy", (int)energy);
                    HttpContext.Session.SetInt32("happiness", (int)happiness);
                    string reaction = $"You played with your Dojodachi! Energy -5, Happiness +{happinessQuantity}";
                    string src = "happy.gif";
                    return RedirectToAction("Index", new {message = reaction, imageSource = src});
                }
            }
            //if energy is not available 
            else
            {
                string reaction = "You do not have enough energy to play with your Dojodachi!";
                string src = "sad.gif";
                return RedirectToAction("Index", new {message = reaction, imageSource = src});
            }
        }
        [HttpPost("work")]
        public IActionResult Work()
        {
            Random rand = new Random();
            int? energy = HttpContext.Session.GetInt32("energy");
            int? meals = HttpContext.Session.GetInt32("meals");
            //if energy avaialble 
            if (energy > 0)
            {
                //meals increase by random quantity 
                int mealQuantity = rand.Next(1,4);
                energy -= 5;
                meals += mealQuantity;
                HttpContext.Session.SetInt32("energy", (int)energy);
                HttpContext.Session.SetInt32("meals", (int)meals);
                string reaction = $"Worked for meals for your Dojodachi! Energy -5, Meals +{mealQuantity}";
                string src = "working.gif";
                return RedirectToAction("Index", new {message = reaction, imageSource = src});
            }
            //if energy not available 
            else
            {
                string reaction = "Not enough energy to work.";
                string src = "sad.gif";
                return RedirectToAction("Index", new {message = reaction, imageSource = src});
            }
        }
        [HttpPost("sleep")]
        public IActionResult Sleep()
        {
            //sleep increases energy by 15, decreases happiness and fullness by 5
            int? fullness = HttpContext.Session.GetInt32("fullness");
            int? happiness = HttpContext.Session.GetInt32("happiness");
            int? energy = HttpContext.Session.GetInt32("energy");
            energy += 15;
            fullness -= 5;
            happiness -= 5;
            HttpContext.Session.SetInt32("energy", (int)energy);
            HttpContext.Session.SetInt32("happiness", (int)happiness);
            HttpContext.Session.SetInt32("fullness", (int)fullness);
            string reaction = $"You slept. Energy +15, Fullness -5, Happiness -5";
            string src = "sleepy.gif";
            return RedirectToAction("Index", new {message = reaction, imageSource = src});
        }
        [HttpPost("reset")]
        public IActionResult Reset()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }
    }
}