using System;
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
    }
    
}