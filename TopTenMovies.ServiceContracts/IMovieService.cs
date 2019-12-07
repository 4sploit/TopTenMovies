using System;
using System.Collections.Generic;
using TopTenMovies.Entities;
using System.ServiceModel;

namespace TopTenMovies.ServiceContracts
{
    [ServiceContract]
    public interface IMovieService : IService
    {
        [OperationContract]
        IEnumerable<Movie> GetMovies();
        [OperationContract]
        void AddMovie(Movie movie);
        [OperationContract]
        IEnumerable<Movie> FilterMoviesBy(Func<Movie, bool> filterCondition);
        [OperationContract]
        IEnumerable<Movie> GetOrderedMoviesByRate();
        [OperationContract]
        IEnumerable<Movie> FilterMoviesByGenre(byte genreID);
    }
}
