using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using TopTenMovies.API.Controllers;
using TopTenMovies.Entities;
using System.Web.Http.Results;
using TopTenMovies.API.GenreService;

namespace TopTenMovies.API.UnitTests
{
    [TestClass]
    public class GenreControllerUnitTest
    {
        private GenreController genreController;
        private Mock<IGenreService> mockGenreService;
        private Genre[] genres;

        [TestInitialize]
        public void Init()
        {
            genres = new Genre[]
            {
                new Genre(){ ID = 1, Name = "action" },
                new Genre(){ ID = 2, Name = "adventure"  }
            };

            mockGenreService = new Mock<IGenreService>();

            mockGenreService
                .Setup(l => l.GetGenres())
                .Returns(genres);

            genreController = new GenreController(mockGenreService.Object);
        }

        [TestMethod]
        public void FetchGenres()
        {
            var actionResult = genreController.FetchGenres();
            var contentResult = actionResult as OkNegotiatedContentResult<Genre[]>;

            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            Assert.AreEqual(contentResult.Content, genres);
        }
    }
}
