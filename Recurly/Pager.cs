using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;

namespace Recurly
{
    [JsonObject]
    public class Pager<T> : Resource, IEnumerator<T>, IEnumerable<T>
    {
        [JsonProperty("has_more")]
        public bool HasMore { get; set; }

        [JsonProperty("data")]
        public List<T> Data { get; set; }

        [JsonProperty("next")]
        public string Next { get; set; }

        internal Recurly.BaseClient RecurlyClient { get; set; }

        internal Dictionary<string, object> QueryParams { get; set; }

        internal RequestOptions Options { get; set; }

        public string Url { get; set; }

        private int _index = 0;

        private bool _pristine = true;

        public Pager() { }

        internal static Pager<T> Build(string url, Dictionary<string, object> queryParams, RequestOptions options, BaseClient client)
        {
            return new Pager<T>()
            {
                HasMore = true,
                Data = null,
                Next = url,
                Url = url,
                QueryParams = queryParams,
                Options = options,
                RecurlyClient = client,
            };
        }

        public T First()
        {
            Dictionary<string, object> firstParams = new Dictionary<string, object>(QueryParams);
            firstParams["limit"] = 1;
            var pager = RecurlyClient.MakeRequest<Pager<T>>(Method.GET, Url, null, firstParams, Options);
            return pager.Data.FirstOrDefault();
        }

        public int Count()
        {
            var empty = RecurlyClient.MakeRequest<EmptyResource>(Method.HEAD, Url, null, QueryParams, Options);

            var meta = empty.GetResponse();
            if (meta.RecordCount is null)
                throw new RecurlyError($"Invalid value for recurly-total-records header: {meta.GetHeader("recurly-total-records")}");

            return (int)meta.RecordCount;
        }

        public Pager<T> FetchNextPage()
        {
            Dictionary<string, object> NextParams = _pristine ? QueryParams : null;
            var pager = RecurlyClient.MakeRequest<Pager<T>>(Method.GET, Next, null, NextParams, Options);
            this.Clone(pager);
            return this;
        }

        public async Task<Pager<T>> FetchNextPageAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            Dictionary<string, object> NextParams = _pristine ? QueryParams : null;
            var task = RecurlyClient.MakeRequestAsync<Pager<T>>(Method.GET, Next, null, NextParams, Options, cancellationToken);
            return await task.ContinueWith(t =>
            {
                var pager = t.Result;
                this.Clone(pager);
                return this;
            });
        }

        private void Clone(Pager<T> pager)
        {
            this.Next = pager.Next;
            this.Data = pager.Data;
            this.HasMore = pager.HasMore;
            this.Url = pager.Url;
            this.QueryParams = pager.QueryParams;
            this.Options = pager.Options;
            this.SetResponse(pager.GetResponse());
            this._pristine = false;
        }

        public T Current
        {
            get
            {
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
            // HasMore == true on init and when the server says there are more pages of data
            // HasMore == false only when the server says this is the last page of data
            // Data == null before we've fetched any pages
            // _index >= Data.Count when we've reached the end of the current page of data
            if (HasMore && (Data == null || _index >= Data.Count))
            {
                FetchNextPage();
                _index = 0;
            }

            // _index < Data.Count when we are still iterating the current page of data
            // _index == 0 && Data.Count == 0 if the page was empty
            return _index < Data.Count;
        }

        public void Reset()
        {
            throw new NotImplementedException("Pagers cannot currently be re-used");
        }
    }
}
