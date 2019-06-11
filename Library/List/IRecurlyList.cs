using System.Collections.Generic;

namespace Recurly
{
    public interface IRecurlyList<out T> : IEnumerable<T> where T : RecurlyEntity
    {
        T this[int i] { get; }

        IEnumerable<T> All { get; }
        int Count { get; }
        IRecurlyList<T> Next { get; }
        IRecurlyList<T> Prev { get; }
        IRecurlyList<T> Start { get; }

        void Clear();
        IEnumerator<T> GetEnumerator();
        void GetItems();
        bool HasNextPage();
        bool HasPrevPage();
        bool HasStartPage();
        bool includeEmptyTag();
        void RemoveAt(int i);
    }
}