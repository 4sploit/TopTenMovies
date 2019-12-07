using System.Configuration;

namespace TopTenMovies.DP
{
    public class DataAccessProviderConfiguration : ConfigurationSection
    {
        [ConfigurationProperty("providers")]
        public ProviderSettingsCollection Providers
        {
            get
            {
                return (ProviderSettingsCollection)base["providers"];
            }
        }

        [ConfigurationProperty("default", DefaultValue = "JsonDataAccessProvider")]
        public string DefaultProviderName
        {
            get
            {
                return base["default"] as string;
            }
        }
    }
}
