using NMDB_BLL.Interfaces.Repositories;
using NMDB_BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NMDB_BLL.Services
{
    public class MovieService
    {
        public readonly IMovieRepository _movieRepository;

        public MovieService(IMovieRepository movieRepository) 
        { 
            _movieRepository = movieRepository;
        }

        public async Task<List<MovieDAO>> GetRecentMovies()
        {
            List<MovieDTO> movieDTOs = await _movieRepository.GetRecentMovies();
            
            List<MovieDAO> movies = new List<MovieDAO>();

            foreach (MovieDTO movieDTO in movieDTOs)
            {
                MovieDAO movie = new MovieDAO
                {
                    Id = movieDTO.Id,
                    Title = movieDTO.Title,
                    Director = movieDTO.Director,
                    ReleaseDate = movieDTO.ReleaseDate,
                    Description = movieDTO.Description,
                    ImageUrl = movieDTO.ImageUrl
                };

                movies.Add(movie);
            }


            return movies;
        }

        public async Task<MovieDAO> GetMovieById(int id)
        {
            MovieDTO movieDTO = await _movieRepository.GetMovieById(id);

            MovieDAO movie = new MovieDAO
            {
                Id = movieDTO.Id,
                Title = movieDTO.Title,
                Director = movieDTO.Director,
                ReleaseDate = movieDTO.ReleaseDate,
                Description = movieDTO.Description,
                ImageUrl = movieDTO.ImageUrl
            };

            return movie;
        }

        public async Task<List<MovieDAO>> GetMoviesByName()
        {
            List<MovieDTO> movieDTOs = await _movieRepository.GetMoviesByName();

            List<MovieDAO> movies = new List<MovieDAO>();

            foreach (MovieDTO movieDTO in movieDTOs)
            {
                MovieDAO movie = new MovieDAO
                {
                    Id = movieDTO.Id,
                    Title = movieDTO.Title,
                    Director = movieDTO.Director,
                    ReleaseDate = movieDTO.ReleaseDate,
                    Description = movieDTO.Description,
                    ImageUrl = movieDTO.ImageUrl
                };

                movies.Add(movie);
            }

            return movies;
        }

        public void GetMovieByDirector(string director)
        {

        }

        public void GetMovieByGenre(string genre)
        {

        }
    }
}
