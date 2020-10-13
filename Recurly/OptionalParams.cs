using System.Collections.Generic;
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
                queryParams.Add(name, x.GetValue(this, null));
            }
            return queryParams;
        }
    }
}
