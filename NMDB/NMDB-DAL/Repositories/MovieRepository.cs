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
    public class MovieRepository : IMovieRepository
    {
        private AppDbContext _context;
        public MovieRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<Movie>> GetRecentMovies()
        {
                 return await _context.movie
                .OrderByDescending(m => m.ReleaseDate)
                .Take(10)
                .ToListAsync();
        }

        public async Task<Movie> GetMovieById(int id)
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

        public async Task<List<Actor>> GetActorsByMovieId(int movieId)
        {
            return await _context.actors
                .Where(a => a.Movies.Any(m => m.Id == movieId))
                .ToListAsync();
        }



        public async Task<List<Movie>> GetMoviesByName(string name)
        {
            return await _context.movie
                .Where(m => m.Title.Contains(name))
                .ToListAsync();

        }
    }
}
