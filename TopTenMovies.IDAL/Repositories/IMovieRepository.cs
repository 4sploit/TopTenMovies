using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using TopTenMovies.Entities;

namespace TopTenMovies.IDAL.Repositories
{
    public interface IMovieRepository : IRepository<Movie>
    {
    }
}
