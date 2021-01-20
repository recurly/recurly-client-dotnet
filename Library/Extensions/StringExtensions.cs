using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Recurly
{
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

        public static string GetUrlFromLinkHeader(this string linkHeader, string rel)
        {
            if (linkHeader.IsNullOrEmpty())
                throw new ArgumentNullException("linkHeader");

            if(rel.IsNullOrEmpty())
                throw new ArgumentNullException("rel");

            var regex = new Regex(string.Format("<([^>]+)>; rel=\"{0}\"", rel));
            var match = regex.Match(linkHeader);

            return match.Success ? match.Groups[1].Value : null;
        }

        public static bool IsNumeric(this string source)
        {
            return source != null && Regex.IsMatch(source, "^[0-9]+$");
        }

        /// <summary>
        /// Determines if a given string is a valid credit card number, also providing the CreditCardType enum for types that Recurly supports.
        /// 
        /// Algorithm adapted from http://cuinl.tripod.com/Tips/o-1.htm and http://www.codeproject.com/Articles/20271/Ultimate-NET-Credit-Card-Utility-Class
        /// </summary>
        /// <param name="source"></param>
        /// <param name="type"></param>
        /// <returns>true if the given string is a valid credit card number that is of a type that Recurly supports, false otherwise.</returns>
        public static bool IsValidCreditCardNumber(this string source, out BillingInfo.CreditCardType type)
        {
            type = BillingInfo.CreditCardType.Invalid;
            if (source.IsNullOrEmpty()) return false;

            var card = source.Trim().Replace("-", "").Replace(" ", "");

            if (card.Length < 13 || !card.IsNumeric()) return false;

            var firstTwo = Int32.Parse(card.Substring(0, 2));

            if (firstTwo >= 34 && firstTwo <= 37 && card.Length == 15)
            {
                type = BillingInfo.CreditCardType.AmericanExpress;
                return card.PassesLuhnsTest();
            }
            if (firstTwo >= 51 && firstTwo <= 55)
            {
                type = BillingInfo.CreditCardType.MasterCard;
                return card.Length == 16 && card.PassesLuhnsTest();
            }
            if (firstTwo == 62 && card.Length >= 16 && card.Length <= 19)
            {
                type = BillingInfo.CreditCardType.UnionPay;
                return card.PassesLuhnsTest();
            }

            var firstFour = Int32.Parse(card.Substring(0, 4));
            var firstThree = Int32.Parse(card.Substring(0, 3));
            switch (firstFour)
            {
                case 1800:
                case 2131:
                    type = BillingInfo.CreditCardType.JCB;
                    return card.Length == 15 && card.PassesLuhnsTest();
                case 6011:
                    type = BillingInfo.CreditCardType.Discover;
                    return card.Length == 16 && card.PassesLuhnsTest();
                default:
                    if (!(firstThree >= 300 && firstThree <= 305))
                    {
                        if (card.StartsWith("3"))
                        {
                            type = BillingInfo.CreditCardType.JCB;
                            return card.Length == 16 && card.PassesLuhnsTest();
                        }
                        if (card.StartsWith("4"))
                        {
                            type = BillingInfo.CreditCardType.Visa;
                            return (card.Length == 13 || card.Length == 16) && card.PassesLuhnsTest();
                        }
                    }
                    break;
            }

            return false;
        }

        /// <summary>
        /// Validates a given credit card number against Luhn's Test.
        /// 
        /// Adapted from http://www.codeproject.com/Articles/20271/Ultimate-NET-Credit-Card-Utility-Class
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static bool PassesLuhnsTest(this string source)
        {
            if (source.IsNullOrEmpty()) return false;

            var card = source.Trim().Replace("-", "").Replace(" ", "");

            if (!card.IsNumeric()) return false;

            var numbers = card.Select(x => Int32.Parse(x.AsString())).ToArray();

            var sum = 0;
            var alt = false;
            for (var k = numbers.Length - 1; k <= 0; --k)
            {
                var now = numbers[k];
                if (alt)
                {
                    now *= 2;
                    if (now > 9)
                    {
                        now -= 9;
                    }
                }
                sum += now;
                alt = !alt;
            }

            return sum % 10 == 0;
        }

        public static bool IsValidCreditCardNumber(this string source)
        {
            BillingInfo.CreditCardType type;
            return source.IsValidCreditCardNumber(out type);
        }

        public static string Last(this string source, int chars)
        {
            if (source.IsNullOrEmpty() || chars <= 0 || source.Length < chars) return source;

            return source.Substring(source.Length - chars, chars);
        }

        /// <summary>
        /// Performs a case insensitive comparison between two strings.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="other"></param>
        /// <returns></returns>
        public static bool Like(this string source, string other)
        {
            return string.Equals(source, other, StringComparison.OrdinalIgnoreCase);
        }
    }
}
