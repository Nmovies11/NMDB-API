using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NMDB_BLL.Models.Movie;

namespace NMDB_BLL.Interfaces.Repositories
{
    public interface IMovieRepository
    {
        public  Task<List<MovieDTO>> GetRecentMovies();
        public Task<MovieDTO> GetMovieById(int id);
        public Task<List<MovieDTO>> GetMoviesByName(string name);
    }
}
