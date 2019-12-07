using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace TopTenMovies.DP.Providers
{
    class XMLDataAccessProvider : DataAccessProvider
    {
        private string _filePath = string.Empty;

        public override void SetParameters(System.Collections.Specialized.NameValueCollection config)
        {
            _filePath = Path.Combine(AppContext.BaseDirectory, @"..\\TopTenMovies.DB\Xml", config["db"]);
        }

        public override IList<T> Read<T>()
        {
            try
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<T>));

                using (StreamReader xmlStream = new StreamReader(_filePath))
                {
                    return (IList<T>)xmlSerializer.Deserialize(xmlStream);
                }
            }
            catch {} // Log to external file or event viewer in case something goes wrong

            return null;
        }

        public override void Write<T>(T Data)
        {
            try
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));

                using (StreamWriter xmlStream = new StreamWriter(_filePath))
                {
                    xmlSerializer.Serialize(xmlStream, Data);
                }
            }
            catch {} // Log to external file or event viewer in case something goes wrong
        }
    }
}
