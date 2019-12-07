using System;
using System.Collections.Generic;
using TopTenMovies.Entities;
using TopTenMovies.ServiceContracts;
using TopTenMovies.IBLL;

namespace TopTenMovies.Orchestration
{
    public class MovieService : IMovieService
    {
        private IMovieLogic _movieLogic;
        private IGenreLogic _genreLogic;

        public MovieService(IMovieLogic movieLogic, IGenreLogic genreLogic)
        {
            _movieLogic = movieLogic;
            _genreLogic = genreLogic;
        }

        public void AddMovie(Movie movie)
        {
            _movieLogic.AddMovie(movie);
        }

        public IEnumerable<Movie> FilterMoviesBy(Func<Movie, bool> filterCondition)
        {
            return _movieLogic.FilterMoviesBy(filterCondition);
        }

        public IEnumerable<Movie> FilterMoviesByGenre(byte genreID)
        {
            return _movieLogic.FilterMoviesByGenre(genreID);
        }

        public IEnumerable<Movie> GetMovies()
        {
            return _movieLogic.GetMovies();
        }

        public IEnumerable<Movie> GetOrderedMoviesByRate()
        {
            return _movieLogic.GetOrderedMoviesByRate();
        }
    }
}
