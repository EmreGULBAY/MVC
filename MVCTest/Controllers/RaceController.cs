using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        public IActionResult Detail(int id)
        {
            return View(_context.Races.Include(a => a.Address).Where(q => q.Id == id).ToList()[0]);
        }
    }
}
