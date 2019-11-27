using System;
using System.Diagnostics.CodeAnalysis;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Recurly.Constants;

namespace Recurly
{
    [ExcludeFromCodeCoverage]
    public class RecurlyStringEnumConverter : StringEnumConverter
    {
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, Newtonsoft.Json.JsonSerializer serializer)
        {
            try
            {
                return base.ReadJson(reader, objectType, existingValue, serializer);
            }
            catch
            {
                return Enum.Parse(objectType, "Undefined");
            }
        }
    }
}
