using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Recurly
{
    public class JsonSerializer
    {
        private Newtonsoft.Json.JsonSerializer serializer;

        public JsonSerializer()
        {
            var contractResolver = new DefaultContractResolver
            {
                NamingStrategy = new SnakeCaseNamingStrategy()
            };
            var settings = new JsonSerializerSettings()
            {
                ContractResolver = contractResolver,
                NullValueHandling = NullValueHandling.Ignore,
                MissingMemberHandling = MissingMemberHandling.Ignore,
                DateFormatHandling = DateFormatHandling.IsoDateFormat,
                DateTimeZoneHandling = DateTimeZoneHandling.Utc,
                //Formatting = Formatting.Indented,
            };
            this.serializer = Newtonsoft.Json.JsonSerializer.Create(settings);
        }

        public T Deserialize<T>(string content)
        {
            using (var stringReader = new StringReader(content))
            {
                using (var jsonTextReader = new JsonTextReader(stringReader))
                {
                    var obj = serializer.Deserialize<T>(jsonTextReader);
                    return obj;
                }
            }
        }

        public string Serialize(object obj)
        {
            using (var stringWriter = new StringWriter())
            {
                using (var jsonTextWriter = new JsonTextWriter(stringWriter))
                {
                    serializer.Serialize(jsonTextWriter, obj);
                    return stringWriter.ToString();
                }
            }
        }

        public static Recurly.JsonSerializer Default
        {
            get
            {
                return new Recurly.JsonSerializer();
            }
        }
    }
}
