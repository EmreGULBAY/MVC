using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCTest.Data;
using MVCTest.Interfaces;
using MVCTest.Models;
using MVCTest.Repository;

namespace MVCTest.Controllers
{
    public class RaceController : Controller
    {
        IRaceRepository _raceRepository;
        public RaceController(IRaceRepository ir)
        {
           _raceRepository = ir;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<Race> races = await _raceRepository.GetAll();
            return View(races);
        }
        public async Task<IActionResult> Detail(int id)
        {
            Race race = await _raceRepository.GetByIdAsync(id);

            return View(race);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Race race)
        {
            if (!ModelState.IsValid)
            {
                return View(race);
            }
            _raceRepository.Add(race);

            return RedirectToAction("Index");
        }
    }
}
