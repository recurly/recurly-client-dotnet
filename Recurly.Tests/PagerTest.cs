using System;
using System.Collections;
using System.Collections.Generic;
using Xunit;
using Recurly;
using Recurly.Resources;
using Newtonsoft.Json;
using RestSharp;
using Moq;

namespace Recurly.UnitTests
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
            var pager = new Pager<MyResource>();
            pager.HasMore = false;
            pager.Data = new List<MyResource>() {
                new MyResource() {
                    MyString = "A String"
                },
                new MyResource() {
                    MyString = "A String"
                },
                new MyResource() {
                    MyString = "A String"
                }
            };

            var i = 0;
            foreach(MyResource r in pager) {
                Assert.Equal("A String", r.MyString);
                i++;
            }
            Assert.Equal(3, i);

            // We don't allow resetting pager states right now
            Assert.Throws<NotImplementedException>(() => {
                pager.Reset();
            });

            // should do nothing
            pager.Dispose();
        }

        [Fact]
        public void FetchNextPage()
        {
            var pager = new Pager<MyResource>();
            pager.HasMore = true;
            pager.Next = "/my_resources?cursor=123456";
            pager.RecurlyClient = GetPagerSuccessClient();
            pager.Data = new List<MyResource>() {
                new MyResource() {
                    MyString = "A String"
                },
                new MyResource() {
                    MyString = "A String"
                },
                new MyResource() {
                    MyString = "A String"
                }
            };

            var i = 0;
            foreach(MyResource r in pager) {
                Assert.Equal("A String", r.MyString);
                i++;
            }
            // There should be 5 resources since
            // there is a second page
            Assert.Equal(5, i);
        }

        private Recurly.Client GetPagerSuccessClient() {
            var data = new Pager<MyResource>()
            {
                HasMore = false,
                Data = new List<MyResource>()
                {
                    new MyResource() { MyString = "A String" },
                    new MyResource() { MyString = "A String" },
                }
            };
            var response =  new Mock<IRestResponse<Pager<MyResource>>>();
            response.Setup(_ => _.StatusCode).Returns(System.Net.HttpStatusCode.OK);
            response.Setup(_ => _.Headers).Returns(new List<Parameter> {});
            response.Setup(_ => _.Data).Returns(data);

            var mockIRestClient = new Mock<IRestClient>();
            mockIRestClient
                .Setup(x => x.Execute<Pager<MyResource>>(It.IsAny<IRestRequest>()))
                .Returns(response.Object);

            var client = new Recurly.Client("subdomain", "myapikey")
            {
                RestClient = mockIRestClient.Object
            };
        
            return client;

        }
    }
}
