using NMDB_BLL.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using NMDB_Common.Entities;
using NMDB_Common.DTO;

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
                    ImageUrl = movieDTO.ImageUrl
                };

                movies.Add(movie);
            }


            return movies;
        }

        public async Task<MovieDTODetails> GetMovieById(int id)
        {
            Movie movieDTO = await _movieRepository.GetMovieById(id);

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

            var actors = await _movieRepository.GetActorsByMovieId(id);
            foreach (var actor in actors)
            {
                movie.Actors.Add(new ActorDTO
                {
                    Id = actor.Id,
                    Name = actor.Name,
                    ImageUrl = actor.ImageUrl
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



        public void GetMovieByDirector(string director)
        {
            //TODO
        }

        public void GetMovieByGenre(string genre)
        {
            //TODO
        }
    }
}
