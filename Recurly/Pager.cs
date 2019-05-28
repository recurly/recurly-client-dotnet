using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using RestSharp;
using RestSharp.Deserializers;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Threading;

namespace Recurly {
    public class Pager<T> : IEnumerator<T>, IEnumerable<T> {
        [JsonProperty("has_more")]
        public bool HasMore { get; set; }

        [JsonProperty("data")]
        public List<T> Data { get; set; }

        [JsonProperty("next")]
        public string Next { get; set; }

        internal Recurly.Client RecurlyClient { get; set; }

        private int _index = 0;

        public Pager() { }

        internal static Pager<T> Build(string url, Dictionary<string, object> queryParams, Client client)
        {
            if (queryParams != null)
            {
                url += Utils.QueryString(queryParams);
            }

            return new Pager<T>()
            {
                HasMore = true,
                Data = new List<T>(),
                Next = url,
                RecurlyClient = client
            };
        }

        public Pager<T> FetchNextPage() {
            var pager = RecurlyClient.MakeRequest<Pager<T>>(Method.GET, Next);
            this.Clone(pager);
            return this;
        }

        public async Task<Pager<T>> FetchNextPageAsync(CancellationToken cancellationToken = default(CancellationToken)) {
            var task = RecurlyClient.MakeRequestAsync<Pager<T>>(Method.GET, Next, null, null, cancellationToken);
            return await task.ContinueWith(t => {
                var pager = t.Result;
                this.Clone(pager);
                return this;
            });
        }

        private void Clone(Pager<T> pager) {
            this.Next = pager.Next;
            this.Data = pager.Data;
            this.HasMore = pager.HasMore;
        }

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
