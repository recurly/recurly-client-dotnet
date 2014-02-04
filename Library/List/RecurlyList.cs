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
        protected string StartUrl;
        protected string NextUrl;
        protected string PrevUrl;

        public int Count
        {
            get { return Items.Count; }
        }

        public int Capacity { get; protected set; }

        internal RecurlyList(HttpRequestMethod method, string url)
        {
            Method = method;
            BaseUrl = url;

            GetItems();
        }

        protected void GetItems()
        {
            Client.Instance.PerformRequest(Method,
                BaseUrl + "&per_page=" + Settings.Instance.PageSize,
                ReadXmlListDelegate);
        }

        protected void ReadXmlListDelegate(XmlTextReader xmlReader, int records, string start, string next, string prev)
        {
            if (Items == null)
            {
                Items = records > 0 ? new List<T>(records) : new List<T>();
            }
            Capacity = records;
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
            return Items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public abstract RecurlyList<T> Start { get; }
        public abstract RecurlyList<T> Next { get; }
        public abstract RecurlyList<T> Prev { get; }
    }
}
