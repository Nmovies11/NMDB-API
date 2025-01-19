using Microsoft.EntityFrameworkCore;
using NMDB_BLL.Helpers;
using NMDB_BLL.Interfaces.Repositories;
using NMDB_Common.DTO;
using NMDB_Common.DTO.Actor;
using NMDB_Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NMDB_DAL.Repositories
{
    public class ActorRepository : IActorRepository
    {
        private AppDbContext _context;
        public ActorRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<PaginatedList<ActorDTO>> GetActors(int pageNumber, int pageSize, string? searchQuery )
        {
            var query = _context.actors.AsQueryable();

            if (!string.IsNullOrWhiteSpace(searchQuery))
            {
                query = query.Where(actor =>
                    actor.Name.Contains(searchQuery) || actor.Bio.Contains(searchQuery));
            }



            var totalCount = await query.CountAsync();

            var actors = await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            var actorDTOs = new List<ActorDTO>();
            foreach (var actor in actors)
            {
                actorDTOs.Add(new ActorDTO
                {
                    Id = actor.Id,
                    ImageUrl = actor.ImageUrl,
                    Name = actor.Name,
                });
            }


            return new PaginatedList<ActorDTO>(actorDTOs, totalCount, pageNumber, pageSize);
        }

        public async Task<ActorDTODetails> GetActorById(int id)
        {
            var actor = await _context.actors
                .Where(a => a.Id == id)
                .FirstOrDefaultAsync();

            if (actor == null)
            {
                throw new InvalidOperationException($"Actor with ID {id} not found.");
            }

            return new ActorDTODetails
            {
                Id = actor.Id,
                ImageUrl = actor.ImageUrl,
                Name = actor.Name,
                Bio = actor.Bio,
            };
        }
    }


}
