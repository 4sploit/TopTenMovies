using TopTenMovies.IBLL;
using TopTenMovies.Entities;
using System;
using System.Collections.Generic;
using TopTenMovies.IDAL.Repositories;

namespace TopTenMovies.BL
{
    public class GenreLogic : IGenreLogic
    {
        private IGenreRepository _genreRepository;

        public GenreLogic(IGenreRepository genreRepository)
        {
            _genreRepository = genreRepository;
        }

        public IEnumerable<Genre> GetGenres()
        {
            return _genreRepository.GetAll();
        }
    }
}