using System;
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
        public class MyResource : Recurly.Resource {
            [JsonProperty("my_string")]
            public string MyString { get; set; }
        }

        [Fact]
        public void EnumerableTest()
        {
            var pager = Pager<MyResource>.Build("/next", new Dictionary<string, object>{}, GetPagerSuccessClient());

            var i = 0;
            foreach(MyResource r in pager) {
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
            Assert.Throws<NotImplementedException>(() => {
                pager.Reset();
            });

            // should do nothing
            pager.Dispose();
        }

        private Recurly.Client GetPagerSuccessClient() {
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
            var page1Response =  new Mock<IRestResponse<Pager<MyResource>>>();
            page1Response.Setup(_ => _.StatusCode).Returns(System.Net.HttpStatusCode.OK);
            page1Response.Setup(_ => _.Headers).Returns(new List<Parameter> {});
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
            var page2Response =  new Mock<IRestResponse<Pager<MyResource>>>();
            page2Response.Setup(_ => _.StatusCode).Returns(System.Net.HttpStatusCode.OK);
            page2Response.Setup(_ => _.Headers).Returns(new List<Parameter> {});
            page2Response.Setup(_ => _.Data).Returns(page2);

            var mockIRestClient = new Mock<IRestClient>();
            mockIRestClient
                .SetupSequence(x => x.Execute<Pager<MyResource>>(It.IsAny<IRestRequest>()))
                .Returns(page1Response.Object)
                .Returns(page2Response.Object);

            return new Recurly.Client("subdomain", "myapikey")
            {
                RestClient = mockIRestClient.Object
            };
        }
    }
}
