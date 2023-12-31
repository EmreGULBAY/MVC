using Microsoft.EntityFrameworkCore;
using MVCTest.Data;
using MVCTest.Interfaces;
using MVCTest.Models;

namespace MVCTest.Repository
{
    public class RaceRepository : IRaceRepository
    {
        ApplicationDbContext _context;
        public RaceRepository(ApplicationDbContext context) {
            _context = context;
        }
        public bool Add(Race race)
        {
            _context.Add(race);
            return Save();
        }

        public bool Delete(Race race)
        {
            _context.Remove(race);
            return Save();
        }

        public async Task<IEnumerable<Race>> GetAll()
        {
            return await _context.Races.ToListAsync();
        }

        public async Task<IEnumerable<Race>> GetAllRacesByCity(string city)
        {
            return await _context.Races.Where(q => q.Address.City.Contains(city)).ToListAsync();
        }

        public async Task<Race> GetByIdAsync(int id)
        {
            return await _context.Races.Include(q => q.Address).FirstOrDefaultAsync(q => q.Id == id);
        }
        public async Task<Race> GetByIdAsyncNT(int id)
        {
            return await _context.Races.Include(q => q.Address).AsNoTracking().FirstOrDefaultAsync(q => q.Id == id);
        }

        public bool Save()
        {
         return  _context.SaveChanges() > 0 ? 1 == 1 : 1 == 0;
        }

        public bool Update(Race race)
        {
            _context.Update(race);
            return Save();
        }
    }
}
