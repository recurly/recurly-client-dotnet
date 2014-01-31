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
        /// <summary>
        /// Checks if the <paramref name="source"/> <see cref="Account.AccountState"/> contains the flag for the <paramref name="target"/> <see cref="Account.AccountState"/>.
        /// </summary>
        /// <param name="source">The <see cref="Account.AccountState"/> to question for the given <paramref name="target"/> flag.</param>
        /// <param name="target">The <see cref="Account.AccountState"/> flag to question for.</param>
        /// <returns>true if the <paramref name="source"/> flags contain the <paramref name="target"/> flags, false otherwise.</returns>
        public static bool Is(this AccountState source, AccountState target)
        {
            return (source & target) == target;
        }

        /// <summary>
        /// Removes the <paramref name="target"/> <see cref="Account.AccountState"/> flag from the <paramref name="source"/> <see cref="Account.AccountState"/> (if it exists).
        /// </summary>
        /// <param name="source">The <see cref="Account.AccountState"/> to remove the <paramref name="target"/> from.</param>
        /// <param name="target">The <see cref="Account.AccountState"/> flag to attempt to remove from <paramref name="source"/>.</param>
        /// <returns><paramref name="source"/> with <paramref name="target"/> removed if <paramref name="target"/> was present, merely <paramref name="source"/> otherwise.</returns>
        public static AccountState Remove(this AccountState source, AccountState target)
        {
            return source.Is(target) ? source ^ target : source;
        }

        /// <summary>
        /// Adds the <paramref name="target"/> <see cref="Account.AccountState"/> to the given <paramref name="source"/> <see cref="Account.AccountState"/>.
        /// </summary>
        /// <param name="source">The <see cref="Account.AccountState"/> flags to be added to.</param>
        /// <param name="target">The <see cref="Account.AccountState"/> flags to add to <paramref name="source"/>.</param>
        /// <returns>The result of the bitwise OR of the two <see cref="Account.AccountState"/> flags.</returns>
        public static AccountState Add(this AccountState source, AccountState target)
        {
            return source | target;
        }

        /// <summary>
        /// Checks if the <paramref name="source"/> <see cref="Subscription.SubscriptionState"/> contains the flag for the <paramref name="target"/> <see cref="Subscription.SubscriptionState"/>.
        /// </summary>
        /// <param name="source">The <see cref="Subscription.SubscriptionState"/> to question for the given <paramref name="target"/> flag.</param>
        /// <param name="target">The <see cref="Subscription.SubscriptionState"/> flag to question for.</param>
        /// <returns>true if the <paramref name="source"/> flags contain the <paramref name="target"/> flags, false otherwise.</returns>
        public static bool Is(this SubscriptionState source, SubscriptionState target)
        {
            return (source & target) == target;
        }

        /// <summary>
        /// Removes the <paramref name="target"/> <see cref="Subscription.SubscriptionState"/> flag from the <paramref name="source"/> <see cref="Subscription.SubscriptionState"/> (if it exists).
        /// </summary>
        /// <param name="source">The <see cref="Subscription.SubscriptionState"/> to remove the <paramref name="target"/> from.</param>
        /// <param name="target">The <see cref="Subscription.SubscriptionState"/> flag to attempt to remove from <paramref name="source"/>.</param>
        /// <returns><paramref name="source"/> with <paramref name="target"/> removed if <paramref name="target"/> was present, merely <paramref name="source"/> otherwise.</returns>
        public static SubscriptionState Remove(this SubscriptionState source, SubscriptionState target)
        {
            return source.Is(target) ? source ^ target : source;
        }

        /// <summary>
        /// Adds the <paramref name="target"/> <see cref="Subscription.SubscriptionState"/> to the given <paramref name="source"/> <see cref="Subscription.SubscriptionState"/>.
        /// </summary>
        /// <param name="source">The <see cref="Subscription.SubscriptionState"/> flags to be added to.</param>
        /// <param name="target">The <see cref="Subscription.SubscriptionState"/> flags to add to <paramref name="source"/>.</param>
        /// <returns>The result of the bitwise OR of the two <see cref="Subscription.SubscriptionState"/> flags.</returns>
        public static SubscriptionState Add(this SubscriptionState source, SubscriptionState target)
        {
            return source | target;
        }
    }

    public static class StringExtensions
    {
        /// <summary>
        /// Convenience implementation of the built-in <see cref="String.IsNullOrEmpty(string)"/> method. Tests if the given <see cref="System.String"/> <paramref name="source"/> is null or empty.
        /// </summary>
        /// <param name="source">The <see cref="System.String"/> to test.</param>
        /// <returns>true if the <see cref="System.String"/> <paramref name="source"/> is null or empty, false otherwise.</returns>
        public static bool IsNullOrEmpty(this string source)
        {
            return string.IsNullOrEmpty(source);
        }

        /// <summary>
        /// Determines if the given <see cref="System.String"/> is null or contains only whitespace.
        /// </summary>
        /// <param name="source">The <see cref="System.String"/> to test.</param>
        /// <returns>true if the <see cref="System.String"/> <paramref name="source"/> is null or contains only whitespace, false otherwise.</returns>
        public static bool IsNullOrWhiteSpace(this string source)
        {
            return source.SafeTrim().IsNullOrEmpty();
        }

        /// <summary>
        /// Convenience overload of <see cref="String.Trim()"/> that protects against <see cref="NullReferenceException"/>s by returning null if <paramref name="source"/> is null.
        /// </summary>
        /// <param name="source">The <see cref="System.String"/> to trim leading and trailing whitespace from.</param>
        /// <returns>null if <paramref name="source"/> is null, the results of <see cref="String.Trim()"/> on <paramref name="source"/> otherwise.</returns>
        public static string SafeTrim(this string source)
        {
            return source == null ? null : source.Trim();
        }

        /// <summary>
        /// Attempts to parse the <see cref="System.String"/> <paramref name="source"/> to the given Enumeration <typeparamref name="T"/>, after converting the string to PascalCase.
        /// </summary>
        /// <typeparam name="T">The enum to attempt to parse to.</typeparam>
        /// <param name="source">The string that will be transformed then parsed.</param>
        /// <returns>The results of attempting to parse the transformed string to the given enum.</returns>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="source"/> is null or empty.</exception>
        /// <exception cref="T:System.ArgumentException"><typeparamref name="T"/> is not an <see cref="T:System.Enum"/>. -or- the sanitized name is empty, whitespace, or does not match a member of the given enumeration.</exception>
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

        /// <summary>
        /// Converts a string with Recurly's enum conventions (lowercase, words separated by underscores) to PascalCase (no underscores, first char in words in uppercase), so they match the enum naming style in .NET
        /// </summary>
        /// <param name="source">The <see cref="T:System.String"/> to convert.</param>
        /// <returns><paramref name="source"/> if it is null or empty, or converted to PascalCase otherwise.</returns>
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

        /// <summary>
        /// Performs a regex match on <paramref name="source"/> to determine if it is completely upper case.
        /// </summary>
        /// <param name="source">The <see cref="T:System.String"/> to test.</param>
        /// <returns>The results of checking if <paramref name="source"/> is all upper case, or false if <paramref name="source"/> is null.</returns>
        public static bool IsUpperCase(this string source)
        {
            return source != null && Regex.IsMatch(source, @"^[A-Z]+$");
        }

        /// <summary>
        /// Converts the given <see cref="T:System.String"/> as if it were the name of an enumeration member to the syntax Recurly's API expects (lowercase, words separated by underscores).
        /// </summary>
        /// <param name="enumName">The <see cref="T:System.String"/> that is to be converted.</param>
        /// <returns>The result of the attempted conversion.</returns>
        public static string EnumNameToTransportCase(this string enumName)
        {
            if(enumName.IsNullOrWhiteSpace())
                throw new ArgumentException("enumName cannot be null or whitespace!", "enumName");

            var words = enumName.Split(' ');
            var result = new StringBuilder();

            foreach (var name in words)
            {
                var word = new StringBuilder();
                if (name.IsUpperCase())
                {
                    word.Append(name.ToLowerInvariant());
                }
                else
                {
                    foreach (var c in name)
                    {
                        if (char.IsUpper(c))
                            word.Append('_').Append(char.ToLowerInvariant(c));
                        else
                            word.Append(c);
                    }
                }
                result.Append(word.ToString().Trim('_'));
            }

            return result.ToString();
        }
    }

    public static class XmlWriterExtensions
    {
        /// <summary>
        /// Convenience implementation of <see cref="T:System.Xml.XmlWriter.WriteElementString(string, string)"/> that guards it with
        /// a check if <paramref name="value"/> is null or empty, writing the value if it is not null or empty.
        /// </summary>
        /// <param name="writer">The <see cref="T:System.Xml.XmlWriter"/> that will be written to.</param>
        /// <param name="localName"></param>
        /// <param name="value"></param>
        public static void WriteStringIfValid(this XmlWriter writer, string localName, string value)
        {
            if (!value.IsNullOrEmpty())
                writer.WriteElementString(localName, value);
        }
    }

    public static class IntExtensions
    {
        /// <summary>
        /// Convenience method to convert an <see cref="int"/> to a <see cref="T:System.String"/> using the Invariant Culture.
        /// </summary>
        /// <param name="i">The int to convert to a <see cref="T:System.String"/>.</param>
        /// <returns>The results of converting <paramref name="i"/> using the Invariant Culture.</returns>
        public static string AsString(this int i)
        {
            return i.ToString(CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Attempts to parse the <see cref="System.Int32"/> <paramref name="i"/> to the given Enumeration <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The enum to attempt to parse to.</typeparam>
        /// <param name="i">The int to attempt to parse.</param>
        /// <returns>The results of attempting to parse the transformed string to the given enum.</returns>
        /// <exception cref="T:System.ArgumentException"><typeparamref name="T"/> is not an <see cref="T:System.Enum"/>. -or- <paramref name="i"/> does not match a member of the enum.</exception>
        public static T ParseAsEnum<T>(this int i)
        {
            return (T)Enum.ToObject(typeof(T), i);
        }
    }
}
