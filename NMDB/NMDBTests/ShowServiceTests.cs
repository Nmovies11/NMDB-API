using Moq;
using NMDB_BLL.Interfaces.Repositories;
using NMDB_BLL.Services;
using NMDB_Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NMDBTests
{
        [TestClass]
        public class ShowServiceTests
        {
            private Mock<IShowRepository> _mockShowRepository;
            private ShowService _showService;

            [TestInitialize]
            public void SetUp()
            {
                _mockShowRepository = new Mock<IShowRepository>();
                _showService = new ShowService(_mockShowRepository.Object);
            }

            [TestMethod]
            public async Task GetRecentShows_ShouldReturnShows()
            {
                // Arrange
                var shows = new List<Show>
            {
                new Show { Id = 1, Title = "Show 1", ReleaseDate = DateOnly.FromDateTime(DateTime.Now), Description = "Description 1", ImageUrl = "url1", BackdropUrl = "backdrop1" },
                new Show { Id = 2, Title = "Show 2", ReleaseDate = DateOnly.FromDateTime(DateTime.Now), Description = "Description 2", ImageUrl = "url2", BackdropUrl = "backdrop2" }
            };

                _mockShowRepository.Setup(repo => repo.GetRecentShows()).ReturnsAsync(shows);

                // Act
                var result = await _showService.GetRecentShows();

                // Assert
                Assert.IsNotNull(result);
                Assert.AreEqual(2, result.Count);
                Assert.AreEqual("Show 1", result[0].Title);
                Assert.AreEqual("Show 2", result[1].Title);
            }

            [TestMethod]
            public async Task GetShowById_ShouldReturnShowDetails()
            {
                // Arrange
                var show = new Show
                {
                    Id = 1,
                    Title = "Show 1",
                    ReleaseDate = DateOnly.FromDateTime(DateTime.Now),
                    Description = "Description 1",
                    ImageUrl = "url1",
                    BackdropUrl = "backdrop1",
                    Seasons = new List<Season>
                {
                    new Season
                    {
                        Id = 1,
                        SeasonNumber = 1,
                        Episodes = new List<Episode>
                        {
                            new Episode { Id = 1, Title = "Episode 1", EpisodeNumber = 1, Description = "Episode Description 1", ReleaseDate = DateOnly.FromDateTime(DateTime.Now) }
                        }
                    }
                }
                };

                _mockShowRepository.Setup(repo => repo.GetShowById(1)).ReturnsAsync(show);

                // Act
                var result = await _showService.GetShowById(1);

                // Assert
                Assert.IsNotNull(result);
                Assert.AreEqual(1, result.Id);
                Assert.AreEqual("Show 1", result.Title);
            }

            [TestMethod]
            public async Task GetShowById_ShouldReturnEmptySeasons_WhenNoSeasons()
            {
                // Arrange
                var show = new Show
                {
                    Id = 1,
                    Title = "Show 1",
                    ReleaseDate = DateOnly.FromDateTime(DateTime.Now),
                    Description = "Description 1",
                    ImageUrl = "url1",
                    BackdropUrl = "backdrop1",
                    Seasons = null // No seasons in this show
                };

                _mockShowRepository.Setup(repo => repo.GetShowById(1)).ReturnsAsync(show);

                // Act
                var result = await _showService.GetShowById(1);

                // Assert
                Assert.IsNotNull(result);
                Assert.AreEqual(0, result.Seasons.Count); // Should return an empty list
            }
        }

    }

