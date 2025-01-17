using Microsoft.AspNetCore.Mvc;
using NMDB_BLL.Helpers;
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
            List<ShowDTO> shows = await _showService.GetRecentShows();
            return Ok(shows);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetShowById(int id)
        {
            ShowDTO show = await _showService.GetShowById(id);
            return Ok(show);
        }

        [HttpGet]
        public async Task<IActionResult> Index(
            int pageNumber = 1,
            int pageSize = 10,
            string? searchQuery = null,
            string? genre = null)
        {
            // Fetch paginated shows from the service layer
            var paginatedShows = await _showService.GetShows(pageNumber, pageSize, searchQuery, genre);

            // Return the paginated data
            return Ok(paginatedShows);
        }

    }
}
