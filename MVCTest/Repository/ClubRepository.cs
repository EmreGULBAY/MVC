using Microsoft.EntityFrameworkCore;
using MVCTest.Data;
using MVCTest.Interfaces;
using MVCTest.Models;

namespace MVCTest.Repository
{
    public class ClubRepository : IClubRepository
    {
        private ApplicationDbContext _context;
        public ClubRepository(ApplicationDbContext context) {
            _context = context;
        }
        public bool Add(Club club)
        {
            _context.Add(club);
            return Save();
        }

        public bool Delete(Club club)
        {
            _context.Remove(club);
            return Save();
        }

        public async Task<IEnumerable<Club>> GetAll()
        {
            return await _context.Clubs.ToListAsync();
        }

        public async Task<Club> GetByIdAsync(int id)
        {
            return await _context.Clubs.Include(q => q.Address).FirstOrDefaultAsync(q => q.Id == id);
        }

        public async Task<IEnumerable<Club>> GetClubByCity(string city)
        {
            return await _context.Clubs.Where(q => q.Address.City.Contains(city)).ToListAsync();
        }

        public bool Save()
        {
            return _context.SaveChanges() > 0 ? 1 == 1 : 1 == 0;
        }

        public bool Update(Club club)
        {
            _context.Update(club);
            return Save();
        }
    }
}
