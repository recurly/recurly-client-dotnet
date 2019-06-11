using System;
using System.Collections.Generic;

namespace Recurly
{
    public interface IRecurlyList<T> : IEnumerable<T> where T : class, IRecurlyEntity
    {
        T this[int i] { get; }

        IEnumerable<T> All { get; }
        int Count { get; }
        IRecurlyList<T> Next { get; }
        IRecurlyList<T> Prev { get; }
        IRecurlyList<T> Start { get; }

        void Clear();
        void GetItems();
        bool HasNextPage();
        bool HasPrevPage();
        bool HasStartPage();
        bool includeEmptyTag();
        void RemoveAt(int i);


        bool Contains(T item);
        bool Contains(T value, IEqualityComparer<T> comparer);
        bool Exists(Predicate<T> match);
        T Find(Predicate<T> match);
        IEnumerable<T> FindAll(Predicate<T> match);
        T FindLast(Predicate<T> match);

        T[] ToArray();
    }
}