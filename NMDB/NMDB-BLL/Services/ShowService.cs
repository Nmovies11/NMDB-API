﻿using NMDB_BLL.Interfaces.Repositories;
using NMDB_Common.Entities;
using NMDB_Common.DTO;
using NMDB_BLL.Helpers;

namespace NMDB_BLL.Services
{
    public class ShowService
    {
        public readonly IShowRepository _showRepository;

        public ShowService(IShowRepository showRepository)
        {
            _showRepository = showRepository;
        }

        public async Task<List<ShowDTO>> GetRecentShows()
        {
            List<Show> showDTOs = await _showRepository.GetRecentShows();

            List<ShowDTO> shows = new List<ShowDTO>();

            foreach (Show showDTO in showDTOs)
            {
                ShowDTO show = new ShowDTO
                {
                    Id = showDTO.Id,
                    Title = showDTO.Title,
                    ReleaseDate = showDTO.ReleaseDate,
                    Description = showDTO.Description,
                    ImageUrl = showDTO.ImageUrl,
                    BackdropUrl = showDTO.BackdropUrl
                };

                shows.Add(show);
            }
            return shows;
        }

        public async Task<ShowDTO> GetShowById(int id)
        {
            Show showDTO = await _showRepository.GetShowById(id);

            ShowDTO show = new ShowDTO
            {
                Id = showDTO.Id,
                Title = showDTO.Title,
                ReleaseDate = showDTO.ReleaseDate,
                Description = showDTO.Description,
                ImageUrl = showDTO.ImageUrl,
                BackdropUrl = showDTO.BackdropUrl,
                Seasons = showDTO.Seasons?.Select(s => new SeasonDTO
                {
                    Id = s.Id,
                    SeasonNumber = s.SeasonNumber,
                    Episodes = s.Episodes?.Select(e => new EpisodeDTO
                    {
                        Id = e.Id,
                        Title = e.Title,
                        EpisodeNumber = e.EpisodeNumber,
                        Description = e.Description,
                        ReleaseDate = e.ReleaseDate
                    }).ToList() ?? new List<EpisodeDTO>() 
                }).ToList() ?? new List<SeasonDTO>() 
            };

            return show;
        }

        public async Task<PaginatedList<ShowDTO>> GetShows(int pageNumber, int pageSize, string? searchQuery, string? genre)
        {
            var paginatedMovies = await _showRepository.GetShows(pageNumber, pageSize, searchQuery, genre);

            var movieDTOs = paginatedMovies.Items.Select(movie => new ShowDTO
            {
                Id = movie.Id,
                Title = movie.Title,
                ImageUrl = movie.ImageUrl,
                Genre = movie.Genre,
                ReleaseDate = movie.ReleaseDate
            }).ToList();

            return new PaginatedList<ShowDTO>(movieDTOs, paginatedMovies.TotalCount, pageNumber, pageSize);
        }

    }
}
