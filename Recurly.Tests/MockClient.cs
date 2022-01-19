using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Moq;
using Recurly;
using RestSharp;
using Xunit;

namespace Recurly.Tests
{
    public class MockClient : BaseClient
    {
        public override string ApiVersion => "v2018-08-09";

        public MockClient(string apiKey, ClientOptions clientOptions = null) : base(apiKey, clientOptions) { }

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
                    .Setup(x => x.ExecuteAsync<T>(It.Is<IRestRequest>(r => item.Key(r)), It.IsAny<CancellationToken>()))
                    .Returns(Task.FromResult(item.Value.Object));
            }

            return new MockClient(apiKey)
            {
                RestClient = mockIRestClient.Object
            };
        }

        internal static Func<IRestRequest, bool> HeaderMatcher(Dictionary<string, object> expectedHeaders)
        {
            Predicate<Parameter> filter = delegate (Parameter p)
            {
                return p.Type == ParameterType.HttpHeader;
            };
            return ParameterMatcher(expectedHeaders, filter);
        }

        internal static Func<IRestRequest, bool> QueryParameterMatcher(Dictionary<string, object> expectedParams)
        {
            Predicate<Parameter> filter = delegate (Parameter p)
            {
                return p.Type == ParameterType.QueryString || p.Type == ParameterType.QueryStringWithoutEncode;
            };
            return ParameterMatcher(expectedParams, filter);
        }

        internal static Func<IRestRequest, bool> ParameterMatcher(Dictionary<string, object> expectedParams, Predicate<Parameter> filter)
        {

            return delegate (IRestRequest request)
            {
                var filteredParams = request.Parameters.FindAll(filter);
                Assert.Equal(filteredParams.Count, expectedParams.Count);
                foreach (Parameter p in filteredParams)
                {
                    Assert.True(expectedParams.ContainsKey(p.Name));
                    Assert.Equal(expectedParams[p.Name], p.Value);
                }
                return true;
            };
        }

        public MyResource CreateResource(MyResourceCreate body, RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { };
            var url = this.InterpolatePath("/my_resources", urlParams);
            return MakeRequest<MyResource>(Method.POST, url, body, null, options);
        }

        public MyResource GetResource(string resourceId, string param1, DateTime param2, RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "resource_id", resourceId } };
            var queryParams = new Dictionary<string, object> { { "param_1", param1 }, { "param_2", param2 } };
            var url = this.InterpolatePath("/my_resources/{resource_id}", urlParams);
            return MakeRequest<MyResource>(Method.GET, url, null, queryParams, options);
        }

        public Task<MyResource> GetResourceAsync(string resourceId, string param1, DateTime param2, RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "resource_id", resourceId } };
            var queryParams = new Dictionary<string, object> { { "param_1", param1 }, { "param_2", param2 } };
            var url = this.InterpolatePath("/my_resources/{resource_id}", urlParams);
            return MakeRequestAsync<MyResource>(Method.GET, url, null, queryParams, options);
        }
    }
}
