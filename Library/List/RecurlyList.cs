using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Xml;
using HttpRequestMethod = Recurly.Client.HttpRequestMethod;

namespace Recurly
{
    public abstract class RecurlyList<T> : IEnumerable<T> where T : RecurlyEntity
    {
        protected List<T> Items = new List<T>();
        internal HttpRequestMethod Method;
        protected string BaseUrl;

        protected string StartUrl { get; set; }
        protected string NextUrl { get; set; }
        protected string PrevUrl { get; set; }
        protected int PerPage { get; set; }
        public string ContinuationToken { get { return NextUrl; } }

        public int Count
        {
            get {
                return Items.Count;
            }
        }

        public abstract RecurlyList<T> Start { get; }
        public abstract RecurlyList<T> Next { get; }
        public abstract RecurlyList<T> Prev { get; }

        public IList<T> All
        {
            get
            {
                var that = HasStartPage() ? Start : this;
                var list = new List<T>();
                while (that.Any())
                {
                    list.AddRange(that);
                    that = that.Next;
                }
                return list;
            }
        }

        public bool HasStartPage()
        {
            return !StartUrl.IsNullOrEmpty();
        }

        public bool HasNextPage()
        {
            return !NextUrl.IsNullOrEmpty();
        }

        public bool HasPrevPage()
        {
            return !PrevUrl.IsNullOrEmpty();
        }

        public virtual bool includeEmptyTag()
        {
            return false;
        }

        internal RecurlyList()
        {
            PerPage = Client.Instance.Settings.PageSize;
        }

        internal RecurlyList(HttpRequestMethod method, string url)
        {
            PerPage = Client.Instance.Settings.PageSize;
            Method = method;
            BaseUrl = url;

            GetItems();
        }

        public void GetItems()
        {
            Client.Instance.PerformRequest(Method,
                ApplyPaging(BaseUrl),
                ReadXmlList);
        }

        protected string ApplyPaging(string baseUrl)
        {
            var divider = baseUrl.Contains("?") ? "&" : "?";
            return baseUrl + divider + "per_page=" + PerPage;
        }

        internal void ReadXmlList(XmlTextReader xmlReader, string start, string next, string prev)
        {
            Items = new List<T>();
            StartUrl = start;
            NextUrl = next;
            PrevUrl = prev;
            ReadXml(xmlReader);
        }

        internal abstract void ReadXml(XmlTextReader reader);

        #region List methods

        internal virtual void Add(T item)
        {
            Items.Add(item);
        }
        internal void AddRange(IEnumerable<T> items)
        {
            foreach (var item in items) Add(item);
        }
        public void Clear()
        {
            Items.Clear();
        }
        internal System.Collections.ObjectModel.ReadOnlyCollection<T> AsReadOnly()
        {
            return Items.AsReadOnly();
        }
        internal bool Contains(T item)
        {
            return Items.Contains(item);
        }
        internal bool Contains(T value, IEqualityComparer<T> comparer)
        {
            return Items.Contains(value, comparer);
        }
        internal bool Exists(Predicate <T> match)
        {
            return Items.Exists(match);
        }
        internal T Find(Predicate<T> match)
        {
            return Items.Find(match);
        }
        internal List<T> FindAll(Predicate<T> match)
        {
            return Items.FindAll(match);
        }
        internal T FindLast(Predicate<T> match)
        {
            return Items.FindLast(match);
        }
        internal void ForEach(Action<T> action)
        {
            Items.ForEach(action);
        }
        internal int IndexOf(T item)
        {
            return Items.IndexOf(item);
        }
        internal int IndexOf(T item, int index)
        {
            return Items.IndexOf(item, index);
        }
        internal int IndexOf(T item, int index, int count)
        {
            return Items.IndexOf(item, index, count);
        }
        public void RemoveAt(int i)
        {
            Items.RemoveAt(i);
        }
        internal bool Remove(T item)
        {
            return Items.Remove(item);
        }
        internal int RemoveAll(Predicate<T> match)
        {
            return Items.RemoveAll(match);
        }
        internal void Reverse()
        {
            Items.Reverse();
        }
        internal void Reverse(int index, int count)
        {
            Items.Reverse(index, count);
        }
        internal void Sort()
        {
            Items.Sort();
        }
        internal void Sort(Comparison<T> comparison)
        {
            Items.Sort(comparison);
        }
        internal void Sort(IComparer<T> comparer)
        {
            Items.Sort(comparer);
        }
        internal void Sort(int index, int count, IComparer<T> comparer)
        {
            Items.Sort(index, count, comparer);
        }
        internal T[] ToArray()
        {
            return Items.ToArray();
        }

        #endregion List methods

        public IEnumerator<T> GetEnumerator()
        {
            return Items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public T this[int i]
        {
            get { return Items[i]; }
            set { throw new NotSupportedException("RecurlyLists are readonly!"); }
        }
    }

    public class RecurlyList
    {
        public enum Sort
        {
            CreatedAt,
            UpdatedAt
        }

        public enum Order
        {
            Asc,
            Desc
        }

        public static RecurlyList<T> Empty<T>() where T : RecurlyEntity
        {
            return EmptyRecurlyList<T>.Instance;
        }
    }

    internal class EmptyRecurlyList<T> where T : RecurlyEntity
    {
        private static volatile EmptyRecurlyListImpl<T> _instance;

        public static RecurlyList<T> Instance
        {
            get { return _instance ?? (_instance = new EmptyRecurlyListImpl<T>()); }
        } 
    }

    internal class EmptyRecurlyListImpl<T> : RecurlyList<T> where T : RecurlyEntity
    {
        public EmptyRecurlyListImpl()
        {
            Items = new List<T>();
        }

        public override RecurlyList<T> Start
        {
            get { return new EmptyRecurlyListImpl<T>(); }
        }

        public override RecurlyList<T> Next
        {
            get { return new EmptyRecurlyListImpl<T>(); }
        }

        public override RecurlyList<T> Prev
        {
            get { return new EmptyRecurlyListImpl<T>(); }
        }

        internal override void ReadXml(XmlTextReader reader)
        {
            throw new NotSupportedException("Empty Recurly Lists are read only!");
        }
    }
}
