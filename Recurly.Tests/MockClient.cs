using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Moq;
using Moq.Protected;
using Recurly;
using Xunit;

namespace Recurly.Tests
{
    public class MockClient : BaseClient
    {
        public override string ApiVersion => "v2018-08-09";

        public MockClient(string apiKey, ClientOptions options) : base(apiKey, options) { }
        public MockClient(string apiKey) : base(apiKey) { }

        // Build with a single canned response (matches all requests)
        internal static MockClient Build(HttpResponseMessage response, string apiKey = "myapikey")
        {
            return Build(_ => true, response, apiKey);
        }

        // Build with a matcher-keyed response
        internal static MockClient Build(Func<HttpRequestMessage, bool> matcher, HttpResponseMessage response, string apiKey = "myapikey")
        {
            return Build(new Dictionary<Func<HttpRequestMessage, bool>, HttpResponseMessage>
            {
                { matcher, response }
            }, apiKey);
        }

        // Build with a multi-route response map
        internal static MockClient Build(Dictionary<Func<HttpRequestMessage, bool>, HttpResponseMessage> routes, string apiKey = "myapikey")
        {
            var mockHandler = new Mock<HttpMessageHandler>();

            mockHandler.Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>())
                .Returns((HttpRequestMessage req, CancellationToken ct) =>
                {
                    foreach (var route in routes)
                    {
                        if (route.Key(req))
                            return Task.FromResult(route.Value);
                    }
                    throw new InvalidOperationException($"No mock route matched: {req.RequestUri}");
                });

            var client = new MockClient(apiKey);
            client.HttpClient = new HttpClient(mockHandler.Object);
            return client;
        }

        // Matcher helpers
        internal static Func<HttpRequestMessage, bool> HeaderMatcher(Dictionary<string, object> expectedHeaders)
        {
            return request =>
            {
                foreach (var expected in expectedHeaders)
                {
                    Assert.True(
                        request.Headers.TryGetValues(expected.Key, out var values),
                        $"Expected header '{expected.Key}' was not present");
                    Assert.Contains(expected.Value.ToString(), values);
                }
                return true;
            };
        }

        internal static Func<HttpRequestMessage, bool> QueryParameterMatcher(Dictionary<string, object> expectedParams)
        {
            return request =>
            {
                var query = ParseQueryString(request.RequestUri.Query);
                Assert.Equal(expectedParams.Count, query.Count);
                foreach (var expected in expectedParams)
                {
                    Assert.True(query.ContainsKey(expected.Key), $"Expected query param '{expected.Key}' not found");
                    Assert.Equal(expected.Value.ToString(), query[expected.Key]);
                }
                return true;
            };
        }

        private static Dictionary<string, string> ParseQueryString(string query)
        {
            var result = new Dictionary<string, string>();
            if (string.IsNullOrEmpty(query)) return result;
            var q = query.TrimStart('?');
            foreach (var pair in q.Split('&'))
            {
                var idx = pair.IndexOf('=');
                if (idx >= 0)
                    result[pair.Substring(0, idx)] = pair.Substring(idx + 1);
            }
            return result;
        }

        // Test resource methods used by test cases
        public MyResource CreateResource(MyResourceCreate body, RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { };
            var url = this.InterpolatePath("/my_resources", urlParams);
            return MakeRequest<MyResource>(HttpMethod.Post, url, body, null, options);
        }

        public MyResource GetResource(string resourceId, string param1, DateTime param2, RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "resource_id", resourceId } };
            var queryParams = new Dictionary<string, object> { { "param_1", param1 }, { "param_2", param2 } };
            var url = this.InterpolatePath("/my_resources/{resource_id}", urlParams);
            return MakeRequest<MyResource>(HttpMethod.Get, url, null, queryParams, options);
        }

        public Task<MyResource> GetResourceAsync(string resourceId, string param1, DateTime param2, RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "resource_id", resourceId } };
            var queryParams = new Dictionary<string, object> { { "param_1", param1 }, { "param_2", param2 } };
            var url = this.InterpolatePath("/my_resources/{resource_id}", urlParams);
            return MakeRequestAsync<MyResource>(HttpMethod.Get, url, null, queryParams, options);
        }
    }
}
