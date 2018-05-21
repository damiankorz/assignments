using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Portfolio.Controllers
{
    public class MainController : Controller
    {
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
           return View();
        }
        [HttpGet]
        [Route("projects")]
        public IActionResult Project()
        {
            return View();
        }
        [HttpGet]
        [Route("contact")]
        public IActionResult Contact()
        {
            return View();
        }
    }
}