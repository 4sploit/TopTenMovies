using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System;

namespace TopTenMovies.DP.Providers
{
    public class JsonDataAccessProvider : DataAccessProvider
    {
        private string _filePath = string.Empty;

        public override void SetParameters(System.Collections.Specialized.NameValueCollection config)
        {
            _filePath = Path.Combine(AppContext.BaseDirectory, @"..\\TopTenMovies.DB\Json", config["db"]);
        }

        public override IList<T> Read<T>()
        {
            try
            {
                string fileContent = File.ReadAllText(_filePath);

                return JsonConvert.DeserializeObject<IList<T>>(fileContent);
            }
            catch { } // Log to external file or event viewer in case something goes wrong

            return null;
        }

        public override void Write<T>(T Data)
        {
            try
            {
                string dataAsString = JsonConvert.SerializeObject(Data, Formatting.Indented);

                File.WriteAllText(_filePath, dataAsString);
            }
            catch { } // Log to external file or event viewer in case something goes wrong
        }
    }
}
