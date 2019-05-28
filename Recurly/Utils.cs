using System;
using System.Collections.Generic;
using System.Text;

namespace Recurly {
    public class Utils {
        public static string Camelize(string source) {
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

        public static string QueryString(Dictionary<string, object> queryParams) {
            var qString = new List<string>();

            foreach (var param in queryParams)
            {
                if (param.Value != null)
                {
                    string stringRepr;
                    if (param.Value.GetType() == typeof(DateTime))
                    {
                        stringRepr = ((DateTime)param.Value).ToString("o");
                    }
                    else
                    {
                        stringRepr = param.Value.ToString();
                    }
                    qString.Add($"{param.Key}={Uri.EscapeUriString(stringRepr)}");
                }
            }

            if (qString.Count > 0) {
                return "?" + String.Join("&", qString);
            } else {
                return String.Empty;
            }
        }

    }
    
}