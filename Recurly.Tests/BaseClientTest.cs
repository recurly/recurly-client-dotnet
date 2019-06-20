using System;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
using Xunit;
using Recurly;
using Recurly.Resources;
using RestSharp;
using RestSharp.Authenticators;
using Moq;
using System.Threading;

namespace Recurly.Tests
{
    public class BaseClientTest
    {
        private string siteId = "subdomain-mysubdomain";
        private string apiKey = "myapikey";

        internal class MyClient : BaseClient
        {
            public override string ApiVersion => "v2018-08-09";

            public MyClient(string apiKey, string siteId) : base(apiKey, siteId) { }

            public MyResource CreateResource(MyResourceCreate body)
            {
                var urlParams = new Dictionary<string, object> { };
                var url = this.InterpolatePath("/sites/{site_id}/my_resources", urlParams);
                return MakeRequest<MyResource>(Method.POST, url, body, null);
            }

            public MyResource GetResource(string resourceId, string param1, DateTime param2)
            {
                var urlParams = new Dictionary<string, object> { { "resource_id", resourceId } };
                var queryParams = new Dictionary<string, object> { { "param_1", param1 }, { "param_2", param2 } };
                var url = this.InterpolatePath("/sites/{site_id}/my_resources/{resource_id}", urlParams);
                return MakeRequest<MyResource>(Method.GET, url, null, queryParams);
            }

            public Task<MyResource> GetResourceAsync(string resourceId, string param1, DateTime param2)
            {
                var urlParams = new Dictionary<string, object> { { "resource_id", resourceId } };
                var queryParams = new Dictionary<string, object> { { "param_1", param1 }, { "param_2", param2 } };
                var url = this.InterpolatePath("/sites/{site_id}/my_resources/{resource_id}", urlParams);
                return MakeRequestAsync<MyResource>(Method.GET, url, null, queryParams);
            }
        }

        public BaseClientTest() { }

        [Fact]
        public void CantInitializeWithoutSiteIdAndApiKey()
        {
            Assert.Throws<ArgumentException>(() => new MyClient(null, siteId));
            Assert.Throws<ArgumentException>(() => new MyClient("", siteId));
            Assert.Throws<ArgumentException>(() => new MyClient(apiKey, null));
            Assert.Throws<ArgumentException>(() => new MyClient(apiKey, ""));
        }

        [Fact]
        public void SetsTheSiteId()
        {
            var client = new MyClient(apiKey, siteId);
            Assert.Equal("subdomain-mysubdomain", client.SiteId);
        }

        [Fact]
        public void RespondsWithGivenApiVersion()
        {
            var client = new MyClient(apiKey, siteId);
            Assert.Equal("v2018-08-09", client.ApiVersion);
        }

        [Fact]
        public void CanProperlyFetchAResource()
        {
            var client = this.GetResourceSuccessClient();
            MyResource resource = client.GetResource("benjamin", "param1", new DateTime(2020, 01, 01));
            Assert.Equal("benjamin", resource.MyString);
        }

        [Fact]
        public async void CanProperlyFetchAResourceAsync()
        {
            var client = this.GetResourceSuccessClient();
            MyResource resource = await client.GetResourceAsync("benjamin", "param1", new DateTime(2020, 01, 01));
            Assert.Equal("benjamin", resource.MyString);
        }

        [Fact]
        public void CanProperlyCreateAResource()
        {
            var client = this.CreateResourceSuccessClient();
            var request = new MyResourceCreate()
            {
                MyString = "benjamin"
            };
            MyResource resource = client.CreateResource(request);
            Assert.Equal("benjamin", resource.MyString);
        }

        [Fact]
        public void WillThrowNotFoundExceptionForNon200()
        {
            var client = this.GetResourceFailureClient();
            Assert.Throws<Recurly.Errors.NotFound>(() => client.GetResource("benjamin", "param1", new DateTime(2020, 01, 01)));
        }

        [Fact]
        public void WillThrowAnExceptionWhenResponseHasErrorException()
        {
            var client = this.GetErroredResponseClient();
            Assert.Throws<Recurly.RecurlyError>(() => client.GetResource("benjamin", "param1", new DateTime(2020, 01, 01)));
        }

        private MyClient GetResourceSuccessClient()
        {
            var data = new MyResource()
            {
                MyString = "benjamin"
            };
            var response = new Mock<IRestResponse<MyResource>>();
            response.Setup(_ => _.StatusCode).Returns(System.Net.HttpStatusCode.OK);
            response.Setup(_ => _.Content).Returns("{\"my_string\": \"benjamin\"}");
            response.Setup(_ => _.Headers).Returns(new List<Parameter> { });
            response.Setup(_ => _.Data).Returns(data);

            var mockIRestClient = new Mock<IRestClient>();
            mockIRestClient
                .Setup(x => x.Execute<MyResource>(It.IsAny<IRestRequest>()))
                .Returns(response.Object);

            mockIRestClient
                .Setup(x => x.ExecuteTaskAsync<MyResource>(It.IsAny<IRestRequest>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(response.Object));

            return new MyClient(siteId, apiKey)
            {
                RestClient = mockIRestClient.Object
            };
        }

        private MyClient GetErroredResponseClient()
        {
            var response = new Mock<IRestResponse<MyResource>>();
            response.Setup(_ => _.StatusCode).Returns(System.Net.HttpStatusCode.Created);
            response.Setup(_ => _.Content).Returns("{\"code\": 123}");
            response.Setup(_ => _.Headers).Returns(new List<Parameter> { });
            response.Setup(_ => _.ErrorException).Returns(new Exception("parsing error"));
            response.Setup(_ => _.ErrorMessage).Returns("parsing error");

            var mockIRestClient = new Mock<IRestClient>();
            mockIRestClient
                .Setup(x => x.Execute<MyResource>(It.IsAny<IRestRequest>()))
                .Returns(response.Object);

            return new MyClient(siteId, apiKey)
            {
                RestClient = mockIRestClient.Object
            };
        }

        private MyClient CreateResourceSuccessClient()
        {
            var data = new MyResource()
            {
                MyString = "benjamin"
            };
            var response = new Mock<IRestResponse<MyResource>>();
            response.Setup(_ => _.StatusCode).Returns(System.Net.HttpStatusCode.Created);
            response.Setup(_ => _.Content).Returns("{\"my_string\": \"benjamin\"}");
            response.Setup(_ => _.Headers).Returns(new List<Parameter> { });
            response.Setup(_ => _.Data).Returns(data);

            var mockIRestClient = new Mock<IRestClient>();
            mockIRestClient
                .Setup(x => x.Execute<MyResource>(It.IsAny<IRestRequest>()))
                .Returns(response.Object);

            return new MyClient(siteId, apiKey)
            {
                RestClient = mockIRestClient.Object
            };
        }

        private MyClient GetResourceFailureClient()
        {
            var response = new Mock<IRestResponse<MyResource>>();
            response.Setup(_ => _.StatusCode).Returns(System.Net.HttpStatusCode.NotFound);
            response.Setup(_ => _.Content).Returns("{\"error\":{ \"type\": \"not_found\", \"message\": \"MyResource not found\"}}");
            response.Setup(_ => _.Headers).Returns(new List<Parameter> { });

            var mockIRestClient = new Mock<IRestClient>();
            mockIRestClient
                .Setup(x => x.Execute<MyResource>(It.IsAny<IRestRequest>()))
                .Returns(response.Object);

            return new MyClient(siteId, apiKey)
            {
                RestClient = mockIRestClient.Object
            };
        }
    }
}
