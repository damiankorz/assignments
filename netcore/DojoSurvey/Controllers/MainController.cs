using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DojoSurvey.Controllers
{
    public class MainController : Controller
    {
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [Route("results")]
        public IActionResult Results(string NameField, string DojoLocation, string FavoriteLanguage, string CommentsField)
        {
            ViewBag.Name = NameField;
            ViewBag.Location = DojoLocation;
            ViewBag.Language = FavoriteLanguage;
            ViewBag.Comment = CommentsField;
            return View();
        }
    }
}