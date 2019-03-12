using System;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json.Converters;
using RestSharp.Serializers;
using RestSharp.Deserializers;
using RestSharp;
using System.IO;

namespace Recurly {
    public class JsonSerializer : ISerializer, IDeserializer
    {
        private Newtonsoft.Json.JsonSerializer serializer;
        private List<string> _errors;
        public List<string> Errors {
            get {
                if (this._errors == null)
                    this._errors = new List<string>();
                return this._errors;
            }
        }
        
        public string RootElement { get; set; }
        public string Namespace { get; set; }
        public string DateFormat { get; set; }
        public string ContentType { get; set; }

        public JsonSerializer() {
            ContentType = "application/json";
            var contractResolver = new DefaultContractResolver
            {
                NamingStrategy = new SnakeCaseNamingStrategy()
            };
            var settings = new JsonSerializerSettings() {
                ContractResolver = contractResolver,
                NullValueHandling = NullValueHandling.Ignore,
                MissingMemberHandling = MissingMemberHandling.Ignore,
                DateFormatHandling = DateFormatHandling.IsoDateFormat,
                DateTimeZoneHandling = DateTimeZoneHandling.Utc,
                Error = delegate(object sender, Newtonsoft.Json.Serialization.ErrorEventArgs args)
                {
                    Errors.Add(args.ErrorContext.Error.Message);
                    args.ErrorContext.Handled = true;
                },
                //Formatting = Formatting.Indented,
            };
            this.serializer = Newtonsoft.Json.JsonSerializer.Create(settings);
        }

        public T Deserialize<T>(IRestResponse response)
        {
            var content = response.Content;
            using (var stringReader = new StringReader(content))
            {
                using (var jsonTextReader = new JsonTextReader(stringReader))
                {
                    var obj = serializer.Deserialize<T>(jsonTextReader);
                    if (Errors.Any())
                    {
                        Debug.WriteLine("WARNING: Serialization errors");
                        foreach (string err in Errors)
                        {
                            Debug.WriteLine(err);
                        }
                    }
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
