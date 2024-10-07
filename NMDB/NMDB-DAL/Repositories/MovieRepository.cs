using Microsoft.EntityFrameworkCore;
using NMDB_BLL.Interfaces.Repositories;
using NMDB_BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NMDB_DAL.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private AppDbContext _context;
        public MovieRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<MovieDTO>> GetRecentMovies()
        {
                 return await _context.movie
                .OrderByDescending(m => m.ReleaseDate)
                .Take(10)
                .ToListAsync();
        }

        public async Task<MovieDTO> GetMovieById(int id)
        {
            var movie = await _context.movie
                .Where(m => m.Id == id)
                .FirstOrDefaultAsync();

            if(movie == null)
            {
                throw new InvalidOperationException($"Movie with ID {id} not found.");
            }
            return movie;
        }

        public async Task<List<MovieDTO>> GetMoviesByName()
        {
            var movies = await _context.movie
                .OrderBy(m => m.Title)
                .ToListAsync();
            if(movies == null)
            {
                throw new InvalidOperationException("No movies found.");
            }
            return movies;
        }

    }
}
