using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NMDB_BLL.Helpers;
using NMDB_Common.DTO;
using NMDB_Common.Entities;

namespace NMDB_BLL.Interfaces.Repositories
{
    public interface IMovieRepository
    {
        public  Task<List<Movie>> GetRecentMovies();
        public Task<Movie> GetMovieById(int id);
        public Task<List<Movie>> GetMoviesByName(string name);
        public Task<List<MovieActor>> GetActorsByMovieId(int movieId);
        public Task<PaginatedList<Movie>> GetMovies(int pageNumber, int pageSize);

    }
}
