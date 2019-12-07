using System.Configuration.Provider;
using TopTenMovies.DP.Providers;

namespace TopTenMovies.DP
{
    public class DataAccessProviderCollection : ProviderCollection
    {
        new public DataAccessProvider this[string name]
        {
            get { return (DataAccessProvider)base[name]; }
        }
    }
}
