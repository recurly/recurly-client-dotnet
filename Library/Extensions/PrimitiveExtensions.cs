using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Recurly
{
    public static class PrimitiveExtensions
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

        public static string AsString(this char c)
        {
            return c.ToString(CultureInfo.InvariantCulture);
        }

        public static string AsString(this IEnumerable<char> chars)
        {
            return new string(chars.ToArray());
        }

        public static string AsString(this bool b)
        {
            return b.ToString().ToLowerInvariant();
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
