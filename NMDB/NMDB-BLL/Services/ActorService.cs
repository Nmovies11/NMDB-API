using NMDB_BLL.Helpers;
using NMDB_BLL.Interfaces.Repositories;
using NMDB_Common.DTO;
using NMDB_Common.DTO.Actor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NMDB_BLL.Services
{
    public class ActorService
    {
        public readonly IActorRepository _actorRepository;

        public ActorService(IActorRepository actorRepository)
        {
            _actorRepository = actorRepository;
        }

        public async Task<PaginatedList<ActorDTO>> GetActors(int pageNumber, int pageSize, string? searchQuery)
        {
            PaginatedList<ActorDTO> actorDTOs = await _actorRepository.GetActors(pageNumber, pageSize, searchQuery);

            return actorDTOs;
        }

        public async Task<ActorDTODetails> GetActorById(int id)
        {
            ActorDTODetails actorDTO = await _actorRepository.GetActorById(id);

            return actorDTO;
        }

    }
}
