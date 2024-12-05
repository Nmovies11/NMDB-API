using Microsoft.EntityFrameworkCore;
using NMDB_BLL.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NMDB_Common.Entities;
using NMDB_BLL.Helpers;
using NMDB_Common.DTO;

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

        public async Task<List<MovieActor>> GetActorsByMovieId(int movieId)
        {
            return await _context.MovieActors
                .Include(ma => ma.Actor) // Include Actor to get actor details
                .Where(ma => ma.MovieId == movieId)
                .ToListAsync();
        }



        public async Task<List<Movie>> GetMoviesByName(string name)
        {
            return await _context.movie
                .Where(m => m.Title.Contains(name))
                .ToListAsync();

        }


        public async Task<PaginatedList<Movie>> GetMovies(int pageNumber, int pageSize)
        {
            var totalCount = await _context.movie.CountAsync();

            // Get the paginated list of Movie entities
            var movies = await _context.movie
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            // Return the paginated list
            return new PaginatedList<Movie>(movies, totalCount, pageNumber, pageSize);


        }
    }
}
