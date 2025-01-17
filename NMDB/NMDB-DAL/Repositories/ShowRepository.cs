using Microsoft.EntityFrameworkCore;
using NMDB_BLL.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NMDB_Common.Entities;
using NMDB_BLL.Helpers;

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

        public async Task<PaginatedList<Show>> GetShows(int pageNumber, int pageSize, string? searchQuery, string? genre)
        {
            var query = _context.Shows.AsQueryable(); // Assuming 'show' is the DbSet for shows

            if (!string.IsNullOrWhiteSpace(searchQuery))
            {
                query = query.Where(show =>
                    show.Title.Contains(searchQuery) || show.Description.Contains(searchQuery));
            }

            if (!string.IsNullOrWhiteSpace(genre))
            {
                query = query.Where(show => show.Genre == genre);
            }

            // Get the total count of filtered records
            var totalCount = await query.CountAsync();

            // Apply pagination
            var shows = await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            // Return the paginated list
            return new PaginatedList<Show>(shows, totalCount, pageNumber, pageSize);
        }


    }
}
