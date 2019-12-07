using System;
using System.Collections.Generic;
using TopTenMovies.Entities;

namespace TopTenMovies.IBLL
{
    public interface IMovieLogic
    {
        IEnumerable<Movie> GetMovies();
        void AddMovie(Movie movie);
        IEnumerable<Movie> FilterMoviesBy(Func<Movie, bool> filterCondition);
        IEnumerable<Movie> GetOrderedMoviesByRate();
        IEnumerable<Movie> FilterMoviesByGenre(byte genreID);
    }
}