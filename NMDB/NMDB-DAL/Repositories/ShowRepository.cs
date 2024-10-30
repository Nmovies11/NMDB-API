using Microsoft.EntityFrameworkCore;
using NMDB_BLL.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NMDB_Common.Entities;

namespace NMDB_DAL.Repositories
{
    public class ShowRepository : IShowRepository
    {
        private AppDbContext _context;
        public ShowRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Show>> GetRecentShows()
        {
            return await _context.Shows
                .OrderByDescending(s => s.ReleaseDate)
                .Take(10)
                .ToListAsync();

        }

        public async Task<Show> GetShowById(int id)
        {
            return _context.Shows.Include(s => s.Seasons).ThenInclude(s => s.Episodes).FirstOrDefault(s => s.Id == id);
        }
    }
}
