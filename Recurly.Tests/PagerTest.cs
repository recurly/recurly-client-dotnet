using System;
using System.Collections.Generic;
using System.Linq;
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
            var pager = Pager<MyResource>.Build("/resources", new Dictionary<string, object> { }, client);

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
            var client = GetPagerSuccessClient();
            var pager = Pager<MyResource>.Build("/resources", new Dictionary<string, object> { }, client);

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
            var client = GetPagerSuccessClient();
            var pager = Pager<MyResource>.Build("/resources", new Dictionary<string, object> { }, client);

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
            var paramsMatcher = MockClient.ParameterMatcher(new Dictionary<string, object> {
                { "limit", "1" },
                { "a", "1" },
            });
            var client = MockClient.Build(paramsMatcher, PagerFirstResponse());

            var queryParams = new Dictionary<string, object> {
                { "limit", "200" },
                { "a", "1" },
            };
            var pager = Pager<MyResource>.Build("/resources", queryParams, client);

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
            var clientMock = GetPagerCountClient();

            var pager = Pager<MyResource>.Build("/resources", queryParams, clientMock);

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

        private MockClient GetPagerSuccessClient()
        {
            var page1Response = PagerSuccessPage1Response();
            Func<IRestRequest, bool> page1Matcher = delegate (IRestRequest request)
            {
                if (request.Resource == "/resources")
                {
                    return true;
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

        private Mock<IRestResponse> PagerCountResponse()
        {
            var response = new Mock<IRestResponse>();
            response.Setup(_ => _.StatusCode).Returns(System.Net.HttpStatusCode.OK);
            response.Setup(_ => _.Headers).Returns(new List<Parameter> {
                new RestSharp.Parameter("Recurly-Total-Records", "42", ParameterType.HttpHeader),
            });

            return response;
        }

        private Recurly.Client GetPagerCountClient()
        {
            var pageResponse = new Mock<IRestResponse>();
            pageResponse.Setup(_ => _.StatusCode).Returns(System.Net.HttpStatusCode.OK);
            pageResponse.Setup(_ => _.Headers).Returns(new List<Parameter> {
                new RestSharp.Parameter("Recurly-Total-Records", "42", ParameterType.HttpHeader),
            });
            var mockIRestClient = new Mock<IRestClient>();

            mockIRestClient
                .Setup(x => x.Execute(It.Is<RestRequest>(r => r.Method == Method.HEAD)))
                .Returns(pageResponse.Object);

            return new Recurly.Client("myapikey")
            {
                RestClient = mockIRestClient.Object
            };
        }
    }
}
