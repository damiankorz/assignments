using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PokeInfo;


namespace PokeInfo.Controllers
{
    public class MainController : Controller 
    {
        [HttpGet("")]
        public IActionResult ReturnMain()
        {
            return RedirectToAction("Index");
        }
        [HttpGet("pokemon")]
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet("pokemon/{pokeId}")]
        public IActionResult QueryPoke(int pokeid)
        {
            var PokeInfo = new Dictionary<string, object>();
            WebRequest.GetPokemonDataAsync(pokeid, ApiReponse =>
            {
                PokeInfo = ApiReponse;
            }
            ).Wait();
            ViewBag.Info = PokeInfo;
            return View("Pokemon");
        }
    }
}