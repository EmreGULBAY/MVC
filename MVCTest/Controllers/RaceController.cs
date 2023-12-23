using Microsoft.AspNetCore.Mvc;

namespace MVCTest.Controllers
{
    public class RaceController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
