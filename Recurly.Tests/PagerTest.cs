using System;
using System.Collections.Generic;
using Moq;
using Newtonsoft.Json;
using RestSharp;
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

        private Mock<IRestResponse<Pager<MyResource>>> PagerSuccessPage1Response()
        {
            // When there are no results, the server returns
            // an empty array with HasMore == false
            var page = new Pager<MyResource>()
            {
                HasMore = true,
                Next = "/next-page",
                Data = new List<MyResource>()
                {
                    new MyResource() { MyString = "A page 1 String" },
                    new MyResource() { MyString = "A page 1 String" },
                    new MyResource() { MyString = "A page 1 String" },
                }
            };
            var response = new Mock<IRestResponse<Pager<MyResource>>>();
            response.Setup(_ => _.StatusCode).Returns(System.Net.HttpStatusCode.OK);
            response.Setup(_ => _.Headers).Returns(new List<Parameter> { });
            response.Setup(_ => _.Data).Returns(page);

            return response;
        }

        private Mock<IRestResponse<Pager<MyResource>>> PagerSuccessPage2Response()
        {
            // When there are no results, the server returns
            // an empty array with HasMore == false
            var page = new Pager<MyResource>()
            {
                HasMore = false,
                Data = new List<MyResource>()
                {
                    new MyResource() { MyString = "A page 2 String" },
                    new MyResource() { MyString = "A page 2 String" },
                }
            };
            var response = new Mock<IRestResponse<Pager<MyResource>>>();
            response.Setup(_ => _.StatusCode).Returns(System.Net.HttpStatusCode.OK);
            response.Setup(_ => _.Headers).Returns(new List<Parameter> { });
            response.Setup(_ => _.Data).Returns(page);

            return response;
        }

        private MockClient GetPagerSuccessClient(Dictionary<string, object> expectedParams)
        {
            var paramsMatcher = MockClient.QueryParameterMatcher(expectedParams);
            var page1Response = PagerSuccessPage1Response();
            Func<IRestRequest, bool> page1Matcher = delegate (IRestRequest request)
            {
                if (request.Resource == "/resources")
                {
                    return paramsMatcher(request);
                }
                return false;
            };
            var page2Response = PagerSuccessPage2Response();
            Func<IRestRequest, bool> page2Matcher = delegate (IRestRequest request)
            {
                if (request.Resource == "/next-page")
                {
                    return true;
                }
                return false;
            };
            var mockCollection = new Dictionary<Func<IRestRequest, bool>, Mock<IRestResponse<Pager<MyResource>>>> {
                { page1Matcher, page1Response },
                { page2Matcher, page2Response },
            };
            return MockClient.Build(mockCollection);
        }

        private Mock<IRestResponse<Pager<MyResource>>> PagerEmptyResponse()
        {
            // When there are no results, the server returns
            // an empty array with HasMore == false
            var page = new Pager<MyResource>()
            {
                HasMore = false,
                Data = new List<MyResource>() { }
            };
            var response = new Mock<IRestResponse<Pager<MyResource>>>();
            response.Setup(_ => _.StatusCode).Returns(System.Net.HttpStatusCode.OK);
            response.Setup(_ => _.Headers).Returns(new List<Parameter> { });
            response.Setup(_ => _.Data).Returns(page);

            return response;
        }

        private Mock<IRestResponse<Pager<MyResource>>> PagerFirstResponse()
        {
            // When there are no results, the server returns
            // an empty array with HasMore == false
            var page = new Pager<MyResource>()
            {
                HasMore = true,
                Data = new List<MyResource>()
                {
                    new MyResource() { MyString = "First Resource" }
                }
            };
            var response = new Mock<IRestResponse<Pager<MyResource>>>();
            response.Setup(_ => _.StatusCode).Returns(System.Net.HttpStatusCode.OK);
            response.Setup(_ => _.Headers).Returns(new List<Parameter> { });
            response.Setup(_ => _.Data).Returns(page);

            return response;
        }

        private Mock<IRestResponse<EmptyResource>> PagerCountResponse()
        {
            var response = new Mock<IRestResponse<EmptyResource>>();
            response.Setup(_ => _.StatusCode).Returns(System.Net.HttpStatusCode.OK);
            response.Setup(_ => _.Headers).Returns(new List<Parameter> {
                new RestSharp.Parameter("Recurly-Total-Records", "42", ParameterType.HttpHeader),
            });

            return response;
        }
    }
}
