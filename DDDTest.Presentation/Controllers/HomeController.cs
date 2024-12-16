using Microsoft.AspNetCore.Mvc;

namespace DDDTest.Presentation.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
