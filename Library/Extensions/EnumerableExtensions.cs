using System.Collections.Generic;
using System.Linq;

namespace Recurly.Extensions
{
    public static class EnumerableExtensions
    {
        /// <summary>
        /// Convenience wrapper for LINQ's Any call that performs a null check before calling Any(), preventing a NullReferenceException.
        /// </summary>
        /// <typeparam name="T">The type of the collection.</typeparam>
        /// <param name="items">The collection to evaluated.</param>
        /// <returns></returns>
        public static bool HasAny<T>(this IEnumerable<T> items)
        {
            return items != null && items.Any();
        }
    }
}
