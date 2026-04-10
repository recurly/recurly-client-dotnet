using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using Xunit;

namespace Recurly.Tests
{
    public class PagerTest
    {
        public class MyResource : Recurly.Resource
        {
            [JsonProperty("my_string")]
            public string MyString { get; set; }
        }

        [Fact]
        public void EmptyEnumerableTest()
        {
            var client = MockClient.Build(PagerEmptyResponse());
            var pager = Pager<MyResource>.Build("/resources", new Dictionary<string, object> { }, null, client);

            var i = 0;
            foreach (MyResource r in pager)
            {
                Assert.True(false, "Should not be iterating anything if response is empty");
            }

            // There should be 0 resources
            Assert.Equal(0, i);
        }

        [Fact]
        public void EnumerableTest()
        {
            var queryParams = new Dictionary<string, object> {
                { "limit", "200" },
            };
            var client = GetPagerSuccessClient(queryParams);
            var pager = Pager<MyResource>.Build("/resources", queryParams, null, client);

            var i = 0;
            foreach (MyResource r in pager)
            {
                if (i < 3)
                {
                    Assert.Equal("A page 1 String", r.MyString);
                }
                else
                {
                    Assert.Equal("A page 2 String", r.MyString);
                }
                i++;
            }

            // There should be 5 resources since
            // there is a second page
            Assert.Equal(5, i);

            // We don't allow resetting pager states right now
            Assert.Throws<NotImplementedException>(() =>
            {
                pager.Reset();
            });

            // should do nothing
            pager.Dispose();
        }

        [Fact]
        public void EnumerablePagesTest()
        {
            var queryParams = new Dictionary<string, object> {
                { "limit", "200" },
            };
            var client = GetPagerSuccessClient(queryParams);
            var pager = Pager<MyResource>.Build("/resources", queryParams, null, client);

            var total = 0;
            var page = 0;
            while (pager.HasMore)
            {
                pager.FetchNextPage();
                var count = 0;
                page++;
                foreach (MyResource r in pager.Data)
                {
                    count++;
                    total++;
                }
                if (page == 1)
                {
                    Assert.Equal(3, count);
                }
                else if (page == 2)
                {
                    Assert.Equal(2, count);
                }
                else
                {
                    Assert.True(false, $"Should not have reached this page: {page}");
                }
            }

            // There should be 5 resources since
            // there is a second page
            Assert.Equal(5, total);
        }

        [Fact]
        public void EnumerablePagesUrlTest()
        {
            var queryParams = new Dictionary<string, object> {
                { "limit", "200" },
            };
            var client = GetPagerSuccessClient(queryParams);
            var pager = Pager<MyResource>.Build("/resources", queryParams, null, client);
            var originalUrl = pager.Url;
            pager.FetchNextPage();
            Assert.Equal(originalUrl, pager.Url);
        }

        [Fact]
        public void PagerFirstTest()
        {
            var paramsMatcher = MockClient.QueryParameterMatcher(new Dictionary<string, object> {
                { "limit", "1" },
                { "a", "1" },
            });
            var client = MockClient.Build(paramsMatcher, PagerFirstResponse());

            var queryParams = new Dictionary<string, object> {
                { "limit", "200" },
                { "a", "1" },
            };
            var pager = Pager<MyResource>.Build("/resources", queryParams, null, client);

            var resource = pager.First();
            Assert.Equal("First Resource", resource.MyString);
        }

        [Fact]
        public void PagerCountTest()
        {
            var queryParams = new Dictionary<string, object> {
                { "limit", 200 },
                { "a", 1 },
            };
            var client = MockClient.Build(PagerCountResponse());

            var pager = Pager<MyResource>.Build("/resources", queryParams, null, client);

            var count = pager.Count();
            Assert.Equal(42, count);
        }

        private HttpResponseMessage PagerSuccessPage1Response()
        {
            var json = "{\"has_more\":true,\"next\":\"/next-page\",\"data\":[{\"my_string\":\"A page 1 String\"},{\"my_string\":\"A page 1 String\"},{\"my_string\":\"A page 1 String\"}]}";
            var response = new HttpResponseMessage(HttpStatusCode.OK);
            response.Content = new StringContent(json, Encoding.UTF8, "application/json");
            return response;
        }

        private HttpResponseMessage PagerSuccessPage2Response()
        {
            var json = "{\"has_more\":false,\"data\":[{\"my_string\":\"A page 2 String\"},{\"my_string\":\"A page 2 String\"}]}";
            var response = new HttpResponseMessage(HttpStatusCode.OK);
            response.Content = new StringContent(json, Encoding.UTF8, "application/json");
            return response;
        }

        private MockClient GetPagerSuccessClient(Dictionary<string, object> expectedParams)
        {
            var paramsMatcher = MockClient.QueryParameterMatcher(expectedParams);

            Func<HttpRequestMessage, bool> page1Matcher = request =>
            {
                var path = request.RequestUri.AbsolutePath.TrimEnd('/');
                if (path.EndsWith("/resources"))
                    return paramsMatcher(request);
                return false;
            };

            Func<HttpRequestMessage, bool> page2Matcher = request =>
            {
                var path = request.RequestUri.AbsolutePath.TrimEnd('/');
                return path.EndsWith("/next-page");
            };

            var routes = new Dictionary<Func<HttpRequestMessage, bool>, HttpResponseMessage>
            {
                { page1Matcher, PagerSuccessPage1Response() },
                { page2Matcher, PagerSuccessPage2Response() },
            };
            return MockClient.Build(routes);
        }

        private HttpResponseMessage PagerEmptyResponse()
        {
            var json = "{\"has_more\":false,\"data\":[]}";
            var response = new HttpResponseMessage(HttpStatusCode.OK);
            response.Content = new StringContent(json, Encoding.UTF8, "application/json");
            return response;
        }

        private HttpResponseMessage PagerFirstResponse()
        {
            var json = "{\"has_more\":true,\"data\":[{\"my_string\":\"First Resource\"}]}";
            var response = new HttpResponseMessage(HttpStatusCode.OK);
            response.Content = new StringContent(json, Encoding.UTF8, "application/json");
            return response;
        }

        private HttpResponseMessage PagerCountResponse()
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK);
            response.Headers.Add("Recurly-Total-Records", "42");
            response.Content = new StringContent("", Encoding.UTF8, "application/json");
            return response;
        }
    }
}
