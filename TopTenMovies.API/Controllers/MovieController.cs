using System.Web.Http;
using System.Web.Http.Cors;
using TopTenMovies.Entities;
using TopTenMovies.API.MovieService;

namespace TopTenMovies.API.Controllers
{
    [EnableCors(origins: "http://localhost:1234", headers: "*", methods: "*")]
    [RoutePrefix("api/Movie")]
    public class MovieController : ApiController
    {
        private IMovieService _movieWCFService;

        public MovieController(IMovieService movieWCFService)
        {
            _movieWCFService = movieWCFService;
        }

        [Route("FetchMovies"), HttpGet]
        public IHttpActionResult FetchMovies()
        {
            var movies = _movieWCFService.GetOrderedMoviesByRate();

            if (movies == null)
            {
                return NotFound();
            }

            return Ok(movies);
        }

        [Route("Add"), HttpPost]
        public IHttpActionResult AddMovie([FromBody]Movie movie)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            _movieWCFService.AddMovie(movie);

            return Ok(movie);
        }
    }
}
