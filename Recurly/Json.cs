using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json.Converters;

namespace Recurly {

    public static class Json {

        private static DefaultContractResolver contractResolver = new DefaultContractResolver
            {
                NamingStrategy = new SnakeCaseNamingStrategy()
            };

        private static JsonSerializerSettings SerializerSettings = new JsonSerializerSettings
            {
                ContractResolver = contractResolver,
                NullValueHandling = NullValueHandling.Ignore,
                //Formatting = Formatting.Indented,
            };

        public static T Deserialize<T>(string json) {
            return JsonConvert.DeserializeObject<T>(json);
        }

        public static string Serialize(object obj) {
            return JsonConvert.SerializeObject(obj, SerializerSettings);
        }
    }

    // public class RecurlyErrorTypeConverter : JsonConverter {
    //     public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) {
    //         ApiErrorType type = (ApiErrorType)value;
    //         var words = Regex
    //             .Split(type.ToString(), "[A-Z]")
    //             .Select(x => x.First().ToString().ToLower() + x.Substring(1));
    //         var enumString = string.Join("_", words);
    //         writer.WriteValue(enumString);
    //     }
    //
    //     public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    //     {
    //         var jsonString = (string)reader.Value;
    //         var words = Regex
    //             .Split(jsonString, "_")
    //             .Select(x => x.First().ToString().ToUpper() + x.Substring(1));
    //         var enumString = string.Join("", words);
    //         return Enum.Parse(typeof(ApiErrorType), enumString, true);
    //     }
    //
    //     public override bool CanConvert(Type objectType)
    //     {
    //         return objectType == typeof(string);
    //     }
    // }
}
