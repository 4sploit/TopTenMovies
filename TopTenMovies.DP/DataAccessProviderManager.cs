using System.Configuration;
using TopTenMovies.DP.Providers;
using System.Web.Configuration;
using System.Collections.Generic;

namespace TopTenMovies.DP
{
    public class DataAccessProviderManager
    {
        static DataAccessProviderManager()
        {
            Initialize();
        }

        private static DataAccessProvider _default;
        /// <summary>
        /// Returns the default configured data provider
        /// </summary>
        public static DataAccessProvider Default
        {
            get { return _default; }
        }

        private static DataAccessProviderCollection _providerCollection;
        /// <summary>
        /// .Returns the provider collection
        /// </summary>
        public static DataAccessProviderCollection Providers
        {
            get { return _providerCollection; }
        }

        private static ProviderSettingsCollection _providerSettings;
        public static ProviderSettingsCollection ProviderSettings
        {
            get { return _providerSettings; }
        }

        /// <summary>
        /// Reads the configuration related to the set of configured 
        /// providers and sets the default and collection of providers and settings.
        /// </summary>
        private static void Initialize()
        {
            DataAccessProviderConfiguration configSection = (DataAccessProviderConfiguration)ConfigurationManager.GetSection("DataAccessProviders");

            if (configSection == null)
                throw new ConfigurationErrorsException("Data provider section is not set.");

            _providerCollection = new DataAccessProviderCollection();
            ProvidersHelper.InstantiateProviders(configSection.Providers, _providerCollection, typeof(DataAccessProvider));

            _providerSettings = configSection.Providers;

            if (_providerCollection[configSection.DefaultProviderName] == null)
                throw new ConfigurationErrorsException("Default data provider is not set.");

            _default = _providerCollection[configSection.DefaultProviderName];
            var defaultSettings = _providerSettings[configSection.DefaultProviderName];

            _default.SetParameters(defaultSettings.Parameters);

            // set other providers's parameters
            for (int i = 0; i < _providerSettings.Count; ++i)
            {
                var providerName = _providerSettings[i].Name;

                if(providerName != configSection.DefaultProviderName)
                {
                    var curProvider = _providerCollection[providerName];
                    var curProviderSettings = _providerSettings[i];

                    curProvider.SetParameters(curProviderSettings.Parameters);
                }
            }
        }
    }
}
