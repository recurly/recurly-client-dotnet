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
        private string apiKey = "myapikey";

        internal class MyClient : BaseClient
        {
            public override string ApiVersion => "v2018-08-09";

            public MyClient(string apiKey) : base(apiKey) { }

            public MyResource CreateResource(MyResourceCreate body)
            {
                var urlParams = new Dictionary<string, object> { };
                var url = this.InterpolatePath("/my_resources", urlParams);
                return MakeRequest<MyResource>(Method.POST, url, body, null);
            }

            public MyResource GetResource(string resourceId, string param1, DateTime param2)
            {
                var urlParams = new Dictionary<string, object> { { "resource_id", resourceId } };
                var queryParams = new Dictionary<string, object> { { "param_1", param1 }, { "param_2", param2 } };
                var url = this.InterpolatePath("/my_resources/{resource_id}", urlParams);
                return MakeRequest<MyResource>(Method.GET, url, null, queryParams);
            }

            public Task<MyResource> GetResourceAsync(string resourceId, string param1, DateTime param2)
            {
                var urlParams = new Dictionary<string, object> { { "resource_id", resourceId } };
                var queryParams = new Dictionary<string, object> { { "param_1", param1 }, { "param_2", param2 } };
                var url = this.InterpolatePath("/my_resources/{resource_id}", urlParams);
                return MakeRequestAsync<MyResource>(Method.GET, url, null, queryParams);
            }
        }

        public BaseClientTest() { }

        [Fact]
        public void CantInitializeWithoutApiKey()
        {
            Assert.Throws<ArgumentException>(() => new MyClient(null));
            Assert.Throws<ArgumentException>(() => new MyClient(""));
        }

        [Fact]
        public void RespondsWithGivenApiVersion()
        {
            var client = new MyClient(apiKey);
            Assert.Equal("v2018-08-09", client.ApiVersion);
        }

        [Fact]
        public void CanProperlyFetchAResource()
        {
            var client = this.MockResourceClient(SuccessResponse(System.Net.HttpStatusCode.OK));
            MyResource resource = client.GetResource("benjamin", "param1", new DateTime(2020, 01, 01));
            Assert.Equal("benjamin", resource.MyString);
        }

        [Fact]
        public async void CanProperlyFetchAResourceAsync()
        {
            var client = this.MockResourceClient(SuccessResponse(System.Net.HttpStatusCode.OK));
            MyResource resource = await client.GetResourceAsync("benjamin", "param1", new DateTime(2020, 01, 01));
            Assert.Equal("benjamin", resource.MyString);
        }

        [Fact]
        public void CanProperlyCreateAResource()
        {
            var client = this.MockResourceClient(SuccessResponse(System.Net.HttpStatusCode.Created));
            var request = new MyResourceCreate()
            {
                MyString = "benjamin"
            };
            MyResource resource = client.CreateResource(request);
            Assert.Equal("benjamin", resource.MyString);
        }

        [Fact]
        public void WillValidatePathParams()
        {
            var client = this.MockResourceClient(SuccessResponse(System.Net.HttpStatusCode.OK));
            MyResource resource = client.GetResource("benjamin", "param1", new DateTime(2020, 01, 01));
            Assert.Throws<Recurly.RecurlyError>(() => client.GetResource("", "param1", new DateTime(2020, 01, 01)));
        }

        [Fact]
        public void WillEncodeForwardSlashesInURL()
        {
            Func<IRestRequest, bool> matcher = delegate (IRestRequest request)
            {
                Assert.Equal("/my_resources/douglas%2F", request.Resource);
                return true;
            };
            var client = this.MockResourceClient(matcher, NotFoundResponse());
            Assert.Throws<Recurly.Errors.NotFound>(() => client.GetResource("douglas/", "param1", new DateTime(2020, 01, 01)));
        }

        [Fact]
        public void WillThrowNotFoundExceptionForNon200()
        {
            var client = this.MockResourceClient(NotFoundResponse());
            Assert.Throws<Recurly.Errors.NotFound>(() => client.GetResource("benjamin", "param1", new DateTime(2020, 01, 01)));
        }

        [Fact]
        public void WillThrowAnExceptionWhenResponseHasErrorException()
        {
            var client = this.MockResourceClient(ErroredResponse());
            Assert.Throws<Recurly.RecurlyError>(() => client.GetResource("benjamin", "param1", new DateTime(2020, 01, 01)));
        }

        private Mock<IRestResponse<MyResource>> SuccessResponse(System.Net.HttpStatusCode status)
        {
            var data = new MyResource()
            {
                MyString = "benjamin"
            };
            var response = new Mock<IRestResponse<MyResource>>();
            response.Setup(_ => _.StatusCode).Returns(status);
            response.Setup(_ => _.Content).Returns("{\"my_string\": \"benjamin\"}");
            response.Setup(_ => _.Headers).Returns(new List<Parameter> { });
            response.Setup(_ => _.Data).Returns(data);

            return response;
        }

        private Mock<IRestResponse<MyResource>> ErroredResponse()
        {
            var response = new Mock<IRestResponse<MyResource>>();
            response.Setup(_ => _.StatusCode).Returns(System.Net.HttpStatusCode.Created);
            response.Setup(_ => _.Content).Returns("{\"code\": 123}");
            response.Setup(_ => _.Headers).Returns(new List<Parameter> { });
            response.Setup(_ => _.ErrorException).Returns(new Exception("parsing error"));
            response.Setup(_ => _.ErrorMessage).Returns("parsing error");

            return response;
        }

        private Mock<IRestResponse<MyResource>> NotFoundResponse()
        {
            var response = new Mock<IRestResponse<MyResource>>();
            response.Setup(_ => _.StatusCode).Returns(System.Net.HttpStatusCode.NotFound);
            response.Setup(_ => _.Content).Returns("{\"error\":{ \"type\": \"not_found\", \"message\": \"MyResource not found\"}}");
            response.Setup(_ => _.Headers).Returns(new List<Parameter> { });

            return response;
        }

        private MyClient MockResourceClient(Mock<IRestResponse<MyResource>> response)
        {
            Func<IRestRequest, bool> matcher = delegate (IRestRequest request)
            {
                return true;
            };
            return MockResourceClient(matcher, response);
        }

        private MyClient MockResourceClient(Func<IRestRequest, bool> matcher, Mock<IRestResponse<MyResource>> response)
        {
            var mockIRestClient = new Mock<IRestClient>();
            mockIRestClient
                .Setup(x => x.Execute<MyResource>(It.Is<RestRequest>(r => matcher(r))))
                .Returns(response.Object);

            mockIRestClient
                .Setup(x => x.ExecuteTaskAsync<MyResource>(It.Is<IRestRequest>(r => matcher(r)), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(response.Object));

            return new MyClient(apiKey)
            {
                RestClient = mockIRestClient.Object
            };
        }
    }
}
