using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCTest.Data;
using MVCTest.Models;

namespace MVCTest.Controllers
{
    public class ClubController : Controller
    {
        private ApplicationDbContext _context;
        public ClubController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<Club> clubs = _context.Clubs.ToList();
            return View(clubs);
        }

        public IActionResult Detail(int id)
        {
            return View(_context.Clubs.Include(q => q.Address).Where(q => q.Id == id).ToList()[0]);
        }
    }
}
