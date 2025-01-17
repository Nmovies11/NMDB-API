using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NMDB_BLL.Interfaces.Repositories;
using NMDB_BLL.Services;
using NMDB_Common.Entities;
using NMDB_BLL.Helpers;

namespace NMDBTests
{
    [TestClass]
    public class MovieServiceTests
    {
        private Mock<IMovieRepository> _mockMovieRepository;
        private MovieService _movieService;

        [TestInitialize]
        public void TestInitialize()
        {
            _mockMovieRepository = new Mock<IMovieRepository>();
            _movieService = new MovieService(_mockMovieRepository.Object);
        }

        [TestMethod]
        public async Task GetRecentMovies_ShouldReturnListOfMovies()
        {
            // Arrange
            var movies = new List<Movie>
        {
            new Movie { Id = 1, Title = "Movie 1", Director = "Director 1", ImageUrl = "url1", ReleaseDate = DateOnly.FromDateTime(DateTime.Now) },
            new Movie { Id = 2, Title = "Movie 2", Director = "Director 2", ImageUrl = "url2", ReleaseDate = DateOnly.FromDateTime(DateTime.Now) }
        };
            _mockMovieRepository.Setup(repo => repo.GetRecentMovies()).ReturnsAsync(movies);

            // Act
            var result = await _movieService.GetRecentMovies();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count);
            Assert.AreEqual("Movie 1", result[0].Title);
            Assert.AreEqual("Director 2", result[1].Director);
        }

        [TestMethod]
        public async Task GetMovieById_ShouldReturnMovieDetails()
        {
            // Arrange
            var movie = new Movie
            {
                Id = 1,
                Title = "Movie 1",
                Director = "Director 1",
                ImageUrl = "url1",
                BackdropUrl = "backdrop1",
                ReleaseDate = DateOnly.FromDateTime(DateTime.Now),
                Description = "Description 1"
            };

            var actors = new List<MovieActor>
    {
        new MovieActor { Actor = new Actor { Id = 1, Name = "Actor 1", ImageUrl = "actorUrl1" }, Role = "Role 1" },
        new MovieActor { Actor = new Actor { Id = 2, Name = "Actor 2", ImageUrl = "actorUrl2" }, Role = "Role 2" }
    };

            _mockMovieRepository.Setup(repo => repo.GetMovieById(1)).ReturnsAsync(movie);
            _mockMovieRepository.Setup(repo => repo.GetActorsByMovieId(1)).ReturnsAsync(actors);

            // Act
            var result = await _movieService.GetMovieById(1);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Id);
            Assert.AreEqual("Movie 1", result.Title);
            Assert.AreEqual(2, result.Actors.Count);

            // Convert to List for indexing
            var actorList = result.Actors.ToList();

            Assert.AreEqual("Actor 1", actorList[0].Name);
            Assert.AreEqual("Actor 2", actorList[1].Name);
        }

        [TestMethod]
        public async Task GetMoviesByName_ShouldReturnMatchingMovies()
        {
            // Arrange
            var movies = new List<Movie>
        {
            new Movie { Id = 1, Title = "Movie A", Director = "Director A", ImageUrl = "urlA", ReleaseDate = DateOnly.FromDateTime(DateTime.Now) },
            new Movie { Id = 2, Title = "Movie B", Director = "Director B", ImageUrl = "urlB", ReleaseDate = DateOnly.FromDateTime(DateTime.Now) }
        };

            _mockMovieRepository.Setup(repo => repo.GetMoviesByName("Movie")).ReturnsAsync(movies);

            var result = await _movieService.GetMoviesByName("Movie");

            // Assert
            Assert.IsNotNull(result); // Ensure result is not null

            Assert.AreEqual(2, result.Count); // Ensure we have 2 movies

        }


    }
}
