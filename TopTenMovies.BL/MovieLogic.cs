using TopTenMovies.IBLL;
using TopTenMovies.Entities;
using System;
using System.Collections.Generic;
using TopTenMovies.IDAL.Repositories;
using System.Linq;

namespace TopTenMovies.BL
{
    public class MovieLogic : IMovieLogic
    {
        private IMovieRepository _movieRepository;
        private IGenreRepository _genreRepository;

        public MovieLogic(IMovieRepository movieRepository, IGenreRepository genreRepository)
        {
            _movieRepository = movieRepository;
            _genreRepository = genreRepository;
        }

        public void AddMovie(Movie movie)
        {
            var genres = _genreRepository.GetAll();
            var movies = _movieRepository.GetAll();

            if(
                (movies != null) && 
                (genres != null) && 
                genres.Any(genre => genre.ID == movie.Genre) &&
                (movies.Count > 0) &&
                !IsExistingMovie(movie, movies)
            )
            {
                var sortedMovies = movies.OrderByDescending(curMovie => curMovie.Rating).ToList();

                sortedMovies[sortedMovies.Count - 1] = movie;

                _movieRepository.Add(sortedMovies);
            }
        }

        public IEnumerable<Movie> FilterMoviesBy(Func<Movie, bool> filterCondition)
        {
            return _movieRepository.Find(filterCondition);
        }

        public IEnumerable<Movie> GetMovies()
        {
            return _movieRepository.GetAll();
        }

        public IEnumerable<Movie> GetOrderedMoviesByRate()
        {
            var movies = _movieRepository.GetAll();
            var genres = _genreRepository.GetAll();

            if (movies != null && genres != null)
            {
                var moviesWithGenres = from movie in movies
                                       join genre in genres on movie.Genre equals genre.ID
                                              orderby movie.Rating descending
                                              select new Movie
                                              {
                                                  Cover = movie.Cover,
                                                  _Genre = genre.Name,
                                                  Title = movie.Title,
                                                  Rating = movie.Rating,
                                                  Genre = movie.Genre,
                                              };

                return moviesWithGenres.AsEnumerable();
            }

            return null;
        }

        public IEnumerable<Movie> FilterMoviesByGenre(byte genreID)
        {
            return FilterMoviesBy(movie => movie.Genre == genreID);
        }

        #region helper methods
        private bool IsExistingMovie(Movie movie, IList<Movie> movies)
        {
            foreach (var curMovie in movies)
            {
                if (curMovie.Title.Equals(movie.Title) && curMovie.Genre.Equals(movie.Genre))
                {
                    return true;
                }
            }

            return false;
        }
        #endregion
    }
}
