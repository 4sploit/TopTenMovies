using System.Collections.Generic;
using TopTenMovies.Entities;
using TopTenMovies.ServiceContracts;
using TopTenMovies.IBLL;

namespace TopTenMovies.Orchestration
{
    public class GenreService : IGenreService
    {
        private IGenreLogic _genreLogic;

        public GenreService(IGenreLogic genreLogic)
        {
            _genreLogic = genreLogic;
        }

        public IEnumerable<Genre> GetGenres()
        {
            return _genreLogic.GetGenres();
        }
    }
}
