using System.Web.Http;
using System.Web.Http.Cors;
using TopTenMovies.API.GenreService;

namespace TopTenMovies.API.Controllers
{
    [EnableCors(origins: "http://localhost:1234", headers: "*", methods: "*")]
    [RoutePrefix("api/Genre")]
    public class GenreController : ApiController
    {
        private IGenreService _genreWCFService;

        public GenreController(IGenreService genreWCFService)
        {
            _genreWCFService = genreWCFService;
        }

        [Route("FetchGenres"), HttpGet]
        public IHttpActionResult FetchGenres()
        {
            var genres = _genreWCFService.GetGenres();

            if (genres == null)
            {
                return NotFound();
            }

            return Ok(genres);
        }
    }
}
