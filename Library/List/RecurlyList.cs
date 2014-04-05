using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using HttpRequestMethod = Recurly.Client.HttpRequestMethod;

namespace Recurly
{
    public abstract class RecurlyList<T> : IEnumerable<T> where T : RecurlyEntity
    {
        protected List<T> Items;
        internal HttpRequestMethod Method;
        protected string BaseUrl;

        protected string StartUrl { get; set; }
        protected string NextUrl { get; set; }
        protected string PrevUrl { get; set; }

        public int Count
        {
            get {
                return null == Items
                    ? 0
                    : Items.Count;
            }
        }

        private int _capacity = -1;
        public int Capacity
        {
            get { return _capacity < 0 ? Count : _capacity; }
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

        internal RecurlyList()
        {
        }

        internal RecurlyList(HttpRequestMethod method, string url)
        {
            Method = method;
            BaseUrl = url;

            GetItems();
        }

        protected void GetItems()
        {
            Client.Instance.PerformRequest(Method,
                ApplyPaging(BaseUrl),
                ReadXmlList);
        }

        protected string ApplyPaging(string baseUrl)
        {
            var divider = baseUrl.Contains("?") ? "&" : "?";
            return baseUrl + divider + "per_page=" + Client.Instance.Settings.PageSize;
        }

        internal void ReadXmlList(XmlTextReader xmlReader, int records, string start, string next, string prev)
        {
            if (Items == null)
            {
                Items = records > 0 ? new List<T>(records) : new List<T>();
            }
            _capacity = records;
            StartUrl = start;
            NextUrl = next;
            PrevUrl = prev;
            ReadXml(xmlReader);
        }

        internal abstract void ReadXml(XmlTextReader reader);

        protected void Add(T item)
        {
            if (Items == null)
            {
                Items = new List<T>();
            }

            Items.Add(item);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return Items == null ? RecurlyList.Empty<T>().GetEnumerator() : Items.GetEnumerator();
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
