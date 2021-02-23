using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.Serialization;
using System.Text;

namespace Recurly
{
    public class Utils
    {
        private static bool? strictMode = null;
        public static bool StrictMode
        {
            get
            {
                if (!strictMode.HasValue)
                {
                    lock (typeof(bool?))
                    {
                        if (!strictMode.HasValue)
                        {
                            strictMode = Environment.GetEnvironmentVariable("RECURLY_STRICT_MODE").ToUpper() == "TRUE";
                        }
                    }
                }
                return strictMode.Value;
            }
        }

        public static string ISO8601(DateTime dt)
        {
            return dt.ToUniversalTime().ToString("yyyy-MM-dd'T'HH:mm:ss.fffK", CultureInfo.InvariantCulture);
        }

        public static string Camelize(string source)
        {
            var words = source.Split('_');
            var newString = new StringBuilder();
            foreach (var word in words)
            {
                if (word.Length < 1) continue;
                var restOfWord = word.Substring(1);
                var first = char.ToUpperInvariant(word[0]);
                newString.Append(first).Append(restOfWord);
            }

            return newString.ToString();
        }

        public static string QueryString(Dictionary<string, object> queryParams)
        {
            var qString = new List<string>();

            foreach (var param in queryParams)
            {
                if (param.Value != null)
                {
                    string stringRepr;
                    if (param.Value.GetType() == typeof(DateTime))
                    {
                        stringRepr = ISO8601((DateTime)param.Value);
                    }
                    else if (param.Value is Enum)
                    {
                        // Use the string value by default
                        stringRepr = param.Value.ToString();

                        var type = param.Value.GetType();
                        Console.WriteLine($"TYPE {type}");
                        var memInfos = type.GetMember(param.Value.ToString());
                        foreach (var memInfo in memInfos)
                            foreach (var attr in memInfo.GetCustomAttributes(true))
                            {
                                EnumMemberAttribute enumAttr = attr as EnumMemberAttribute;
                                if (enumAttr != null)
                                {
                                    // Use the EnumMember Value if it exists
                                    stringRepr = enumAttr.Value;
                                }
                            }

                    }
                    else if (param.Value is bool)
                    {
                        stringRepr = ((bool)param.Value) ? "true" : "false";
                    }
                    else
                    {
                        stringRepr = param.Value.ToString();
                    }
                    qString.Add($"{param.Key}={Uri.EscapeUriString(stringRepr)}");
                }
            }

            if (qString.Count > 0)
            {
                return "?" + String.Join("&", qString);
            }
            else
            {
                return String.Empty;
            }
        }

    }
}
