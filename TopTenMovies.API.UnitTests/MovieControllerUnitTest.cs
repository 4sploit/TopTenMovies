using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using TopTenMovies.API.Controllers;
using TopTenMovies.Entities;
using System.Web.Http.Results;
using TopTenMovies.API.MovieService;

namespace TopTenMovies.API.UnitTests
{
    [TestClass]
    public class MovieControllerUnitTest
    {
        private MovieController movieController;
        private Mock<IMovieService> mockMovieService;
        private Movie[] movies;

        [TestInitialize]
        public void Init()
        {
            movies = new Movie[]
            {
                new Movie(){ Title = "testMovie", Rating = 1, Genre = 2, _Genre = "action" },
                new Movie(){ Title = "testMovie2", Rating = 5, Genre = 1, _Genre = "comedy" }
            };

            mockMovieService = new Mock<IMovieService>();

            mockMovieService
                .Setup(l => l.GetOrderedMoviesByRate())
                .Returns(movies);

            movieController = new MovieController(mockMovieService.Object);
        }

        [TestMethod]
        public void FetchMovies()
        {
            var actionResult = movieController.FetchMovies();
            var contentResult = actionResult as OkNegotiatedContentResult<Movie[]>;

            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            Assert.AreEqual(contentResult.Content, movies);
        }
    }
}
