using Microsoft.AspNetCore.Mvc;

namespace SolarPayAPI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return Content("Welcome to SolarPayAPI!");
        }
    }
}
