using Microsoft.AspNetCore.Mvc;
using NMDB_BLL.Services;
using NMDB_Common.DTO;

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
            List<MovieDTO> movies = await _movieService.GetRecentMovies();
            return Ok(movies);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMovieById(int id)
        {
            MovieDTODetails movie = await _movieService.GetMovieById(id);
            if(movie == null)
            {
                return NotFound();
            }
            return Ok(movie);
        }

        [HttpGet("MoviesByName")]
        public async Task<IActionResult> GetMoviesByName(string name)
        {
            List<MovieDTO> movies = await _movieService.GetMoviesByName(name);
            return Ok(movies);
        }

        [HttpGet]
        public async Task<IActionResult> Index(
            int pageNumber = 1,
            int pageSize = 10,
            string? searchQuery = null,
            string? genre = null)
        {
            // Fetch paginated movies from the service layer
            var paginatedMovies = await _movieService.GetMovies(pageNumber, pageSize, searchQuery, genre);

            // Return the paginated data
            return Ok(paginatedMovies);
        }
    }
}
