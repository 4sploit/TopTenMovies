using System.Collections.Generic;
using TopTenMovies.DP.Providers;
using TopTenMovies.Entities;
using TopTenMovies.IDAL.Repositories;
using System.Linq;

namespace TopTenMovies.DA.Repositories
{
    public class MovieRepository : Repository<Movie>, IMovieRepository
    {
        private DataAccessProvider _provider;

        public MovieRepository(DataAccessProvider dataAccessProvider) : base(dataAccessProvider)
        {
            _provider = dataAccessProvider;
        }
    }
}
