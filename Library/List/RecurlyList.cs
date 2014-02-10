using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using Recurly.Configuration;
using HttpRequestMethod = Recurly.Client.HttpRequestMethod;

namespace Recurly
{
    public abstract class RecurlyList<T> : IEnumerable<T>
    {
        protected List<T> Items;
        internal HttpRequestMethod Method;
        protected string BaseUrl;

        private string _startUrl;
        public string StartUrl
        {
            get
            {
                if(_startUrl.IsNullOrEmpty())
                    throw new NotSupportedException("No Start page available.");
                return _startUrl;
            }
        }

        private string _nextUrl;
        public string NextUrl
        {
            get
            {
                if(_nextUrl.IsNullOrEmpty())
                    throw new NotSupportedException("No Next page available.");
                return _nextUrl;
            }
        }

        private string _prevUrl;
        public string PrevUrl
        {
            get
            {
                if (_prevUrl.IsNullOrEmpty())
                    throw new NotSupportedException("No Previous page available.");
                return _prevUrl;
            }
        }

        public int Count
        {
            get { return Items.Count; }
        }

        private int _capacity = -1;
        public int Capacity
        {
            get { return _capacity < 0 ? Items.Count : _capacity; }
        }

        public abstract RecurlyList<T> Start { get; }
        public abstract RecurlyList<T> Next { get; }
        public abstract RecurlyList<T> Prev { get; }

        public bool HasStartPage()
        {
            return _startUrl.IsNullOrEmpty();
        }

        public bool HasNextPage()
        {
            return _nextUrl.IsNullOrEmpty();
        }

        public bool HasPrevPage()
        {
            return _prevUrl.IsNullOrEmpty();
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
            _startUrl = start;
            _nextUrl = next;
            _prevUrl = prev;
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
}
