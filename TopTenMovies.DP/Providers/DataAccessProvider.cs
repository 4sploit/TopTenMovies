using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration.Provider;

namespace TopTenMovies.DP.Providers
{
    public abstract class DataAccessProvider : ProviderBase
    {
        public abstract IList<T> Read<T>() where T : class;
        public abstract void Write<T>(T Data) where T : class;

        public virtual void SetParameters(NameValueCollection config)
        {
        }
    }
}
