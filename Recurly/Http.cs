using System;
using System.Collections.Generic;
using System.Net;
using RestSharp;

namespace Recurly.Http
{
    public class Request
    {
        public Method Method { get; set; }

        public string Url { get; set; }

        public Recurly.Request Body { get; set; }
    }

    public class Response
    {
        public Request Request { get; set; }

        public string RawResponse { get; set; }

        public HttpStatusCode StatusCode { get; set; }

        public IList<Header> Headers { get; set; }

        public string RequestId { get { return GetHeader("x-request-id"); } }

        public int? RateLimit { get { return GetIntHeader("x-ratelimit-limit"); } }

        public int? RateLimitRemaining { get { return GetIntHeader("x-ratelimit-remaining"); } }

        public int? RateLimitReset { get { return GetIntHeader("x-ratelimit-reset"); } }

        public string ContentType { get { return GetHeader("content-type"); } }

        public int? RecordCount { get { return GetIntHeader("recurly-total-records"); } }

        public Response() { }

        internal static Response Build(IRestResponse resp, Request request)
        {
            // Map List<Parameter> to List<Header>
            var headers = new List<Header>();
            foreach (var header in resp.Headers)
            {
                headers.Add(new Header(header.Name, (string)header.Value));
            }
            return new Response()
            {
                Request = request,
                RawResponse = resp.Content,
                StatusCode = resp.StatusCode,
                Headers = headers,
            };
        }

        public string GetHeader(string name)
        {
            foreach (var header in Headers)
                if (header.Name == name.ToLower())
                    return header.Value;
            return null;
        }

        private int? GetIntHeader(string name)
        {
            var header = GetHeader(name);
            if (header is null)
                return null;
            try
            {
                return Int32.Parse(header);
            }
            catch (Exception)
            {
                return null;
            }
        }

    }

    public class Header
    {
        public string Name { get; set; }
        public string Value { get; set; }

        public Header(string name, string value)
        {
            Name = name.ToLower();
            Value = value;
        }
    }
}
