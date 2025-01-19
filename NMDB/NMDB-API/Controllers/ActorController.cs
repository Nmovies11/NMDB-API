using Microsoft.AspNetCore.Mvc;
using NMDB_BLL.Services;
using NMDB_Common.DTO.Actor;

namespace NMDB_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ActorController : Controller
    {

        private readonly ActorService _actorService;

        public ActorController(ActorService actorService)
        {
            _actorService = actorService;
        }

        [HttpGet]
        public async Task<IActionResult> Index(
             int pageNumber = 1,
            int pageSize = 10,
            string? searchQuery = null)
        {
            // Fetch paginated actors from the service layer
            var paginatedActors = await _actorService.GetActors(pageNumber, pageSize, searchQuery);

            // Return the paginated data
            return Ok(paginatedActors);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetActorById(int id)
        {
            ActorDTODetails actor = await _actorService.GetActorById(id);
            return Ok(actor);
        }

    }
}
