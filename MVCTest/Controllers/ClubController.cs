using Microsoft.AspNetCore.Mvc;

namespace MVCTest.Controllers
{
    public class ClubController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
