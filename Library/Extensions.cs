using System;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;
using AccountState = Recurly.Account.AccountState;
using SubscriptionState = Recurly.Subscription.SubscriptionState;

namespace Recurly
{
    public static class EnumExtensions
    {
        public static bool Is(this AccountState source, AccountState target)
        {
            return (source & target) == target;
        }

        public static AccountState Remove(this AccountState source, AccountState target)
        {
            return source.Is(target) ? source ^ target : source;
        }

        public static AccountState Add(this AccountState source, AccountState target)
        {
            return source | target;
        }

        public static bool Is(this SubscriptionState source, SubscriptionState target)
        {
            return (source & target) == target;
        }

        public static SubscriptionState Remove(this SubscriptionState source, SubscriptionState target)
        {
            return source.Is(target) ? source ^ target : source;
        }

        public static SubscriptionState Add(this SubscriptionState source, SubscriptionState target)
        {
            return source | target;
        }
    }

    public static class StringExtensions
    {
        public static bool IsNullOrEmpty(this string source)
        {
            return string.IsNullOrEmpty(source);
        }

        public static T ParseAsEnum<T>(this string source)
        {
            var sanitized = source.ToPascalCase();
            if (sanitized.IsNullOrEmpty())
                throw new ArgumentException("Cannot convert a null or empty string to an Enumeration.", "source");

            return (T)Enum.Parse(typeof(T), sanitized, true);
        }

        public static string RemoveUnderscoresAndDashes(this string source)
        {
            return source.IsNullOrEmpty() ? source : source.Replace("_", "").Replace("-", "");
        }

        public static string ToPascalCase(this string source)
        {
            if (source.IsNullOrEmpty()) return source;

            source = source.Replace("_", " "); // so we know where the word breaks are
            var words = source.Split(' '); // break into words (note that in this case 'words' means groups of letters separated by '_' or ' ', not real words)
            var newString = new StringBuilder();

            foreach (var word in words)
            {
                if (word.Length < 1) continue;

                var restOfWord = word.Substring(1);
                if (restOfWord.IsUpperCase())
                    restOfWord = restOfWord.ToLowerInvariant();

                var first = char.ToUpperInvariant(word[0]);
                newString.Append(first).Append(restOfWord);
            }

            return newString.ToString();
        }

        public static bool IsUpperCase(this string source)
        {
            return Regex.IsMatch(source, @"^[A-Z]+$");
        }
    }

    public static class XmlWriterExtensions
    {
        public static void WriteStringIfValid(this XmlWriter writer, string localName, string value)
        {
            if (!value.IsNullOrEmpty())
                writer.WriteElementString(localName, value);
        }
    }

    public static class IntExtensions
    {
        public static string AsString(this int i)
        {
            return i.ToString(CultureInfo.InvariantCulture);
        }
    }
}
