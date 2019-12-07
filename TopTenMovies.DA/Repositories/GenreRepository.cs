using TopTenMovies.DP.Providers;
using TopTenMovies.Entities;
using TopTenMovies.IDAL.Repositories;

namespace TopTenMovies.DA.Repositories
{
    public class GenreRepository : Repository<Genre>, IGenreRepository
    {
        public GenreRepository(DataAccessProvider dataAccessProvider) : base(dataAccessProvider)
        {
        }
    }
}
