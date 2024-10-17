using Microsoft.AspNetCore.Mvc;
using NMDB_BLL.Models.Movie;
using NMDB_BLL.Services;

namespace NMDB_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovieController : Controller
    {
        private readonly MovieService _movieService;

        public MovieController(MovieService movieService)
        {
            _movieService = movieService; 
        }


        [HttpGet("RecentMovies")]
        public async Task<IActionResult> GetRecentMovies()
        {
            List<MovieDAO> movies = await _movieService.GetRecentMovies();
            return Ok(movies);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMovieById(int id)
        {
            MovieDAO movie = await _movieService.GetMovieById(id);
            return Ok(movie);
        }

        [HttpGet("MoviesByName")]
        public async Task<IActionResult> GetMoviesByName(string name)
        {
            List<MovieDAO> movies = await _movieService.GetMoviesByName(name);
            return Ok(movies);
        }

    }
}
