using System.Collections.Generic;
using TopTenMovies.Entities;
using System.ServiceModel;

namespace TopTenMovies.ServiceContracts
{
    [ServiceContract]
    public interface IGenreService : IService
    {
        [OperationContract]
        IEnumerable<Genre> GetGenres();
    }
}
