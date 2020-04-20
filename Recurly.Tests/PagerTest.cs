using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using Xunit;
using Recurly;
using Recurly.Resources;
using Newtonsoft.Json;
using RestSharp;
using Moq;

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
            var pager = Pager<MyResource>.Build("/next", new Dictionary<string, object> { }, GetEmptyPagerClient());

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
            var pager = Pager<MyResource>.Build("/next", new Dictionary<string, object> { }, GetPagerSuccessClient());

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
            var pager = Pager<MyResource>.Build("/next", new Dictionary<string, object> { }, GetPagerSuccessClient());

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
            var queryParams = new Dictionary<string, object> {
                { "limit", "200" },
                { "a", "1" },
            };
            var clientMock = GetPagerFirstClient();

            var pager = Pager<MyResource>.Build("/resources", queryParams, clientMock);

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

        private Recurly.Client GetPagerSuccessClient()
        {
            var page1 = new Pager<MyResource>()
            {
                HasMore = true,
                Data = new List<MyResource>()
                {
                    new MyResource() { MyString = "A page 1 String" },
                    new MyResource() { MyString = "A page 1 String" },
                    new MyResource() { MyString = "A page 1 String" },
                }
            };
            var page1Response = new Mock<IRestResponse<Pager<MyResource>>>();
            page1Response.Setup(_ => _.StatusCode).Returns(System.Net.HttpStatusCode.OK);
            page1Response.Setup(_ => _.Headers).Returns(new List<Parameter> { });
            page1Response.Setup(_ => _.Data).Returns(page1);

            var page2 = new Pager<MyResource>()

            {
                HasMore = false,
                Data = new List<MyResource>()
                {
                    new MyResource() { MyString = "A page 2 String" },
                    new MyResource() { MyString = "A page 2 String" },
                }
            };
            var page2Response = new Mock<IRestResponse<Pager<MyResource>>>();
            page2Response.Setup(_ => _.StatusCode).Returns(System.Net.HttpStatusCode.OK);
            page2Response.Setup(_ => _.Headers).Returns(new List<Parameter> { });
            page2Response.Setup(_ => _.Data).Returns(page2);

            var mockIRestClient = new Mock<IRestClient>();
            mockIRestClient
                .SetupSequence(x => x.Execute<Pager<MyResource>>(It.IsAny<IRestRequest>()))
                .Returns(page1Response.Object)
                .Returns(page2Response.Object);

            return new Recurly.Client("myapikey")
            {
                RestClient = mockIRestClient.Object
            };
        }

        private Recurly.Client GetEmptyPagerClient()
        {
            // When there are no results, the server returns
            // an empty array with HasMore == false
            var page = new Pager<MyResource>()
            {
                HasMore = false,
                Data = new List<MyResource>() { }
            };
            var pageResponse = new Mock<IRestResponse<Pager<MyResource>>>();
            pageResponse.Setup(_ => _.StatusCode).Returns(System.Net.HttpStatusCode.OK);
            pageResponse.Setup(_ => _.Headers).Returns(new List<Parameter> { });
            pageResponse.Setup(_ => _.Data).Returns(page);
            var mockIRestClient = new Mock<IRestClient>();
            mockIRestClient
                .Setup(x => x.Execute<Pager<MyResource>>(It.IsAny<IRestRequest>()))
                .Returns(pageResponse.Object);

            return new Recurly.Client("myapikey")
            {
                RestClient = mockIRestClient.Object
            };
        }

        private Recurly.Client GetPagerFirstClient()
        {
            var page = new Pager<MyResource>()
            {
                HasMore = true,
                Data = new List<MyResource>()
                {
                    new MyResource() { MyString = "First Resource" }
                }
            };
            var pageResponse = new Mock<IRestResponse<Pager<MyResource>>>();
            pageResponse.Setup(_ => _.StatusCode).Returns(System.Net.HttpStatusCode.OK);
            pageResponse.Setup(_ => _.Headers).Returns(new List<Parameter> { });
            pageResponse.Setup(_ => _.Data).Returns(page);

            var mockIRestClient = new Mock<IRestClient>();
            var myParams = new List<Parameter> {
                new RestSharp.Parameter("limit", "1", ParameterType.QueryString),
                new RestSharp.Parameter("a", "1", ParameterType.QueryString),
            };

            // TODO: Find a better way to handle this specifically and the concept at a whole
            Func<List<Parameter>, List<Parameter>, bool> sameParams = delegate (List<Parameter> a, List<Parameter> b)
            {
                var sortedA = a.OrderBy(x => x.Name).ToList();
                var sortedB = b.OrderBy(x => x.Name).ToList();
                int index = 0;
                foreach (Parameter p in sortedA)
                {
                    var pB = sortedB.ElementAt(index);
                    if (p.Name != pB.Name || String.Compare(p.Value.ToString(), pB.Value.ToString()) != 0)
                    {
                        return false;
                    }
                    index++;
                }
                return true;
            };


            mockIRestClient
                .Setup(x => x.Execute<Pager<MyResource>>(It.Is<RestRequest>(r => sameParams(r.Parameters, myParams) && r.Resource == "/resources")))
                .Returns(pageResponse.Object);

            return new Recurly.Client("myapikey")
            {
                RestClient = mockIRestClient.Object
            };
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
