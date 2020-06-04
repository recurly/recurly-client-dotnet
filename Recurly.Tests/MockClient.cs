using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Moq;
using RestSharp;
using Xunit;

namespace Recurly.Tests
{
    public class MockClient : BaseClient
    {
        public override string ApiVersion => "v2018-08-09";

        public MockClient(string apiKey) : base(apiKey) { }

        internal static MockClient Build<T>(Mock<IRestResponse<T>> response, string apiKey = "myapikey")
        {
            Func<IRestRequest, bool> matcher = delegate (IRestRequest request)
            {
                return true;
            };
            var collection = new Dictionary<Func<IRestRequest, bool>, Mock<IRestResponse<T>>> {
                { matcher, response }
            };
            return Build<T>(collection, apiKey);
        }

        internal static MockClient Build<T>(Func<IRestRequest, bool> matcher, Mock<IRestResponse<T>> response, string apiKey = "myapikey")
        {
            var collection = new Dictionary<Func<IRestRequest, bool>, Mock<IRestResponse<T>>> {
                { matcher, response }
            };
            return Build<T>(collection, apiKey);
        }

        internal static MockClient Build<T>(Dictionary<Func<IRestRequest, bool>, Mock<IRestResponse<T>>> collection, string apiKey = "myapikey")
        {
            var mockIRestClient = new Mock<IRestClient>();
            foreach (KeyValuePair<Func<IRestRequest, bool>, Mock<IRestResponse<T>>> item in collection)
            {
                mockIRestClient
                    .Setup(x => x.Execute<T>(It.Is<RestRequest>(r => item.Key(r))))
                    .Returns(item.Value.Object);

                mockIRestClient
                    .Setup(x => x.ExecuteTaskAsync<T>(It.Is<IRestRequest>(r => item.Key(r)), It.IsAny<CancellationToken>()))
                    .Returns(Task.FromResult(item.Value.Object));
            }

            return new MockClient(apiKey)
            {
                RestClient = mockIRestClient.Object
            };
        }

        internal static Func<IRestRequest, bool> ParameterMatcher(Dictionary<string, object> expectedParams)
        {
            return delegate (IRestRequest request)
            {
                Assert.Equal(request.Parameters.Count, expectedParams.Count);
                foreach (Parameter p in request.Parameters)
                {
                    Assert.True(expectedParams.ContainsKey(p.Name));
                    Assert.Equal(expectedParams[p.Name], p.Value);
                }
                return true;
            };
        }

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
}
