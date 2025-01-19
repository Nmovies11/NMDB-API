using NMDB_BLL.Helpers;
using NMDB_Common.DTO;
using NMDB_Common.DTO.Actor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NMDB_BLL.Interfaces.Repositories
{
    public interface IActorRepository
    {
        public  Task<PaginatedList<ActorDTO>> GetActors(int pageNumber, int pageSize, string? searchQuery);
        public  Task<ActorDTODetails> GetActorById(int id);

    }
}
