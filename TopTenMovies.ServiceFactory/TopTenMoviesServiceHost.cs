using System;
using System.ServiceModel;
using System.ServiceModel.Description;

namespace TopTenMovies.ServiceFactory
{
    public class TopTenMoviesServiceHost : ServiceHost
    {
        public TopTenMoviesServiceHost(Type t, params Uri[] baseAddresses) :
               base(t, baseAddresses) { }
    }
}
