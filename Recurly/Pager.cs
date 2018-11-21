using System;
using System.Collections;
using System.Collections.Generic;
using RestSharp;
using RestSharp.Deserializers;
using Newtonsoft.Json;

namespace Recurly {
    public class Pager<T> : IEnumerator<T>, IEnumerable<T> {
        [JsonProperty("has_more")]
        public bool HasMore { get; set; }

        [JsonProperty("data")]
        public List<T> Data { get; set; }

        [JsonProperty("next")]
        public string Next { get; set; }

        public Recurly.Client RecurlyClient { get; set; }

        private int _index = 0;

        public Pager() {}

        public T Current
        {
            get
            {
                if (_index >= Data.Count && HasMore) {
                    FetchNextPage();
                    _index = 0;
                }
                return Data[_index++];
            }
        }

        private void FetchNextPage()
        {
            var response = RecurlyClient.MakeRequest<Pager<T>>(Method.GET, Next);
            var pager = response.Data;
            // this is brittle
            this.Next = pager.Next;
            this.Data = pager.Data;
            this.HasMore = pager.HasMore;
        }

        object IEnumerator.Current => Current;

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return this;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this;
        }

        public void Dispose() { }

        public bool MoveNext()
        {
            return _index < Data.Count || HasMore;
        }

        public void Reset()
        {
            throw new NotImplementedException("Pagers cannot currently be re-used");
        }
    }
}
