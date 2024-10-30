using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NMDB_Common.Entities;

namespace NMDB_BLL.Interfaces.Repositories
{
    public interface IMovieRepository
    {
        public  Task<List<Movie>> GetRecentMovies();
        public Task<Movie> GetMovieById(int id);
        public Task<List<Movie>> GetMoviesByName(string name);
        public Task<List<Actor>> GetActorsByMovieId(int movieId);
    }
}
