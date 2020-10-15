using System;
using System.Collections.Generic;
using System.Reflection;
using Newtonsoft.Json;

namespace Recurly
{
    public class OptionalParams
    {
        public Dictionary<string, object> ToDictionary()
        {
            var queryParams = new Dictionary<string, object>();
            foreach (var x in this.GetType().GetProperties())
            {
                var name = x.Name;
                object[] attrs = x.GetCustomAttributes(true);
                foreach (object attr in attrs)
                {
                    JsonPropertyAttribute jsonAttr = attr as JsonPropertyAttribute;
                    if (jsonAttr != null)
                    {
                        name = jsonAttr.PropertyName;
                    }
                }
                var value = x.GetValue(this, null);
                if (x.PropertyType.IsGenericType && x.PropertyType.GetGenericTypeDefinition() == typeof(IList<>))
                    value = ConvertList(x.PropertyType, value);
                queryParams.Add(name, value);
            }
            return queryParams;
        }

        private Object ConvertList(Type type, Object value)
        {
            if (value is null)
                return value;
            if (type.GenericTypeArguments.Length > 0)
            {
                var genericType = type.GenericTypeArguments[0];
                if (genericType == typeof(string))
                    return string.Join(",", (IList<string>)value);
                // More types can be added over time as necessary
            }

            // Return the original value if the type is now known
            return value;
        }
    }
}
