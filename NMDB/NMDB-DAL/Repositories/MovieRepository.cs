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
            var t =  await _context.MovieActors
                .Include(ma => ma.Actor) 
                .Where(ma => ma.MovieId == movieId)
                .ToListAsync();
            Console.WriteLine("Hello");

            if(t == null)
            {
                return null;
            }

            return t;
        }



        public async Task<List<Movie>> GetMoviesByName(string name)
        {
            return await _context.movie
                .Where(m => m.Title.Contains(name))
                .ToListAsync();

        }


        public async Task<PaginatedList<Movie>> GetMovies(int pageNumber, int pageSize, string? searchQuery, string? genre)
        {
            var query = _context.movie.AsQueryable();

            if (!string.IsNullOrWhiteSpace(searchQuery))
            {
                query = query.Where(movie =>
                    movie.Title.Contains(searchQuery) || movie.Description.Contains(searchQuery));
            }

            if (!string.IsNullOrWhiteSpace(genre))
            {
                query = query.Where(movie => movie.Genre == genre);
            }

            // Get the total count of filtered records
            var totalCount = await query.CountAsync();

            // Apply pagination
            var movies = await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            // Return the paginated list
            return new PaginatedList<Movie>(movies, totalCount, pageNumber, pageSize);

        }
    }
}
