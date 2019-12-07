using System;
using System.Collections.Generic;
using TopTenMovies.Entities;

namespace TopTenMovies.IBLL
{
    public interface IGenreLogic
    {
        IEnumerable<Genre> GetGenres();
    }
}