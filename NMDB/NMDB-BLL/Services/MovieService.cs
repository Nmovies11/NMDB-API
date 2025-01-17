using NMDB_BLL.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using NMDB_Common.Entities;
using NMDB_Common.DTO;
using NMDB_BLL.Helpers;

namespace NMDB_BLL.Services
{
    public class MovieService
    {
        public readonly IMovieRepository _movieRepository;

        public MovieService(IMovieRepository movieRepository) 
        { 
            _movieRepository = movieRepository;
        }

        public async Task<List<MovieDTO>> GetRecentMovies()
        {
            List<Movie> movieDTOs = await _movieRepository.GetRecentMovies();
            
            List<MovieDTO> movies = new List<MovieDTO>();

            foreach (Movie movieDTO in movieDTOs)
            {
                MovieDTO movie = new MovieDTO
                {
                    Id = movieDTO.Id,
                    Title = movieDTO.Title,
                    Director = movieDTO.Director,
                    ImageUrl = movieDTO.ImageUrl,
                    ReleaseDate = movieDTO.ReleaseDate  
                };

                movies.Add(movie);
            }


            return movies;
        }

        public async Task<MovieDTODetails> GetMovieById(int id)
        {
            Movie movieDTO = await _movieRepository.GetMovieById(id);

            if(movieDTO == null)
            {
                return null;
            }

            MovieDTODetails movie = new MovieDTODetails
            {
                Id = movieDTO.Id,
                Title = movieDTO.Title,
                Director = movieDTO.Director,
                ReleaseDate = movieDTO.ReleaseDate,
                Description = movieDTO.Description,
                ImageUrl = movieDTO.ImageUrl,
                BackdropUrl = movieDTO.BackdropUrl

            };


            var movieActors = await _movieRepository.GetActorsByMovieId(id);
            foreach (var movieActor in movieActors)
            {
                movie.Actors.Add(new ActorDTO
                {
                    Id = movieActor.Actor.Id,
                    Name = movieActor.Actor.Name,
                    ImageUrl = movieActor.Actor.ImageUrl,
                    Role = movieActor.Role 
                });
            }

            return movie;

        }

        public async Task<List<MovieDTO>> GetMoviesByName(string name)
        {
            List<Movie> movieDTOs = await _movieRepository.GetMoviesByName(name);

            List<MovieDTO> movies = new List<MovieDTO>();

            foreach (Movie movieDTO in movieDTOs)
            {
                MovieDTO movie = new MovieDTO
                {
                    Id = movieDTO.Id,
                    Title = movieDTO.Title,
                    Director = movieDTO.Director,
                    ReleaseDate = movieDTO.ReleaseDate,
                    ImageUrl = movieDTO.ImageUrl,
                };

                movies.Add(movie);
            }

            return movies;
        }

        public async Task<PaginatedList<MovieDTO>> GetMovies(int pageNumber, int pageSize, string? searchQuery, string? genre)
        {
            var paginatedMovies = await _movieRepository.GetMovies(pageNumber, pageSize, searchQuery, genre);

            var movieDTOs = paginatedMovies.Items.Select(movie => new MovieDTO
            {
                Id = movie.Id,
                Title = movie.Title,
                Director = movie.Director,
                ImageUrl = movie.ImageUrl,
                Genre = movie.Genre,
                ReleaseDate = movie.ReleaseDate
            }).ToList();

            return new PaginatedList<MovieDTO>(movieDTOs, paginatedMovies.TotalCount, pageNumber, pageSize);
        }

    }
}
