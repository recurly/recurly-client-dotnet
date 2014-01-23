using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Collections;

namespace Recurly
{
    /// <summary>
    /// A base class that handles paged results from Recurly's API.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class RecurlyList<T> : IEnumerator<T>
    {

       
        protected List<T> _items;
        protected string _cursor;
        protected int _records;
        protected int _currentPosition = 0;
        protected T _current;
        protected string _baseUrl;

        internal Client.HttpRequestMethod _method;

        internal RecurlyList() {}

        internal RecurlyList(Client.HttpRequestMethod method, String baseUrl)
        {
            this._baseUrl = baseUrl;
            this._method = method;

            this.readItems();
        }

        internal abstract void ReadXml(XmlTextReader reader);

        internal void readItems()
        {
            Client.Instance.PerformRequest(_method, _baseUrl + "&per_page=" + Configuration.Section.Current.PageSize +
                    (_cursor != null ? "&cursor=" + _cursor : ""), new Client.ReadXmlListDelegate(this.ReadXmlList));
        }

        internal void ReadXmlList(XmlTextReader reader, int records, string cursor)
        {
            if (null == _items)
            {
                if (records > 0)
                    _items = new List<T>(records);
                else
                    _items = new List<T>();
                this._records = records;
            }
            this._cursor = cursor;
            this.ReadXml(reader);
        }

        void IDisposable.Dispose() { }


        internal void Add(T item)
        {
            if (null == _items)
            {

                _items = new List<T>();
            }

            _items.Add(item);
        }

        public void Reset()
        {
            _currentPosition = 0;
        }

        public bool MoveNext()
        {
            if (++_currentPosition >= _records)
            {
                return false;
            }
            else
            {
                while (_currentPosition > _items.Count)
                {
                    readItems();
                }
                _current = _items[_currentPosition];
            }
            return true;
        }

        public int Count
        {
            get { return _records; }
        }

        public int Capacity
        {
            get { return Configuration.Section.Current.PageSize; }
        }

        public T this[int i]
        {
            get
            {
                while (i > _items.Count)
                {
                    readItems();
                }
                return _items[i];
            }
            set
            {
                throw new NotSupportedException("This list is read only.");
            }

        }

        public T Current
        {
            get { return _current; }
        }

        object IEnumerator.Current
        {
            get { return _current; }
        }

        public IEnumerator<T> GetEnumerator()
        {
            while (_currentPosition < _records)
            {
                if (_currentPosition > _items.Count)
                {
                    readItems();
                }
                yield return _items[_currentPosition];
                _currentPosition++;
            }
        }

    }
}
