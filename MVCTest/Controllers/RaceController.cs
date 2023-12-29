using Microsoft.AspNetCore.Mvc;
using MVCTest.Data;
using MVCTest.Models;

namespace MVCTest.Controllers
{
    public class RaceController : Controller
    {
        ApplicationDbContext _context;
        public RaceController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Race> races = _context.Races.ToList();
            return View(races);
        }
    }
}
