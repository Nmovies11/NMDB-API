using Microsoft.AspNetCore.Mvc;
using NMDB_BLL.Services;
using NMDB_Common.DTO;

namespace NMDB_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ShowController : Controller
    {
        private readonly ShowService _showService;

        public ShowController(ShowService showService)
        {
            _showService = showService;
        }


        [HttpGet("RecentShows")]
        public async Task<IActionResult> GetRecentShows()
        {
            List<ShowDTO> movies = await _showService.GetRecentShows();
            return Ok(movies);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetShowById(int id)
        {
            ShowDTO movie = await _showService.GetShowById(id);
            return Ok(movie);
        }

    }
}
