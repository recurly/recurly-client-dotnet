using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using Moq;
using Xunit;

namespace Recurly.Tests
{
    public class BaseClientTest
    {
        public BaseClientTest() { }

        [Fact]
        public void CantInitializeWithoutApiKey()
        {
            Assert.Throws<ArgumentException>(() => new MockClient(null));
            Assert.Throws<ArgumentException>(() => new MockClient(""));
        }

        [Fact]
        public void CanInitializeWithATimeout()
        {
            var client = new Recurly.Client("myapikey") { Timeout = 124 };
            Assert.Equal(124, client.Timeout);
        }

        [Fact]
        public void RespondsWithGivenApiVersion()
        {
            var client = new MockClient("myapikey");
            Assert.Equal("v2018-08-09", client.ApiVersion);
        }

        [Fact]
        public void DefaultsToUSRegionWithoutClientOptions()
        {
            var client = new MockClient("myapikey");
            Assert.Equal("https://v3.recurly.com/", client.BaseUrl.AbsoluteUri);
        }

        [Fact]
        public void CanInitializeWithEUSDataCenter()
        {
            var options = new ClientOptions()
            {
                Region = ClientOptions.Regions.EU
            };
            var client = new MockClient("myapikey", options);
            Assert.Equal("https://v3.eu.recurly.com/", client.BaseUrl.AbsoluteUri);
        }

        [Fact]
        public void CanProperlyFetchAResource()
        {
            var client = MockClient.Build(SuccessResponse(HttpStatusCode.OK));
            MyResource resource = client.GetResource("benjamin", "param1", new DateTime(2020, 01, 01));
            Assert.Equal("benjamin", resource.MyString);
        }

        [Fact]
        public async void CanProperlyFetchAResourceAsync()
        {
            var client = MockClient.Build(SuccessResponse(HttpStatusCode.OK));
            MyResource resource = await client.GetResourceAsync("benjamin", "param1", new DateTime(2020, 01, 01));
            Assert.Equal("benjamin", resource.MyString);
        }

        [Fact]
        public void WillPopulateResponseOnResource()
        {
            var client = MockClient.Build(SuccessResponse(HttpStatusCode.OK));
            MyResource resource = client.GetResource("benjamin", "param1", new DateTime(2020, 01, 01));
            Assert.Equal(HttpStatusCode.OK, resource.GetResponse().StatusCode);
            Assert.NotNull(resource.GetResponse().Headers);
            Assert.Equal("{\"my_string\": \"benjamin\"}", resource.GetResponse().RawResponse);
        }

        [Fact]
        public void CanProperlyCreateAResource()
        {
            var client = MockClient.Build(SuccessResponse(HttpStatusCode.Created));
            var request = new MyResourceCreate()
            {
                MyString = "benjamin"
            };
            MyResource resource = client.CreateResource(request);
            Assert.Equal("benjamin", resource.MyString);
        }

        [Fact]
        public void WillAddQueryStringParameters()
        {
            var options = new RequestOptions();
            options.AddHeader("Accept-Language", "en-US");
            var date = DateTime.Parse("2020-01-01T08:00:00Z");
            var paramsMatcher = MockClient.QueryParameterMatcher(new Dictionary<string, object> {
                { "param_1", "param1" },
                { "param_2", "2020-01-01T08%3A00%3A00.000Z" },
            });

            var client = MockClient.Build(paramsMatcher, SuccessResponse(HttpStatusCode.OK));
            MyResource resource = client.GetResource("benjamin", "param1", date, options);
            Assert.Equal("benjamin", resource.MyString);
        }

        [Fact]
        public void WillValidatePathParams()
        {
            var client = MockClient.Build(SuccessResponse(HttpStatusCode.OK));
            MyResource resource = client.GetResource("benjamin", "param1", new DateTime(2020, 01, 01));
            Assert.Throws<Recurly.RecurlyError>(() => client.GetResource("", "param1", new DateTime(2020, 01, 01)));
        }

        [Fact]
        public void WillIncludeCustomHeaders()
        {
            var options = new RequestOptions();
            options.AddHeader("Accept-Language", "en-US");
            var matcher = MockClient.HeaderMatcher(new Dictionary<string, object> {
                { "Accept-Language", "en-US" },
            });
            var client = MockClient.Build(matcher, NotFoundResponse());
            Assert.Throws<Recurly.Errors.NotFound>(() => client.GetResource("douglas/", "param1", new DateTime(2020, 01, 01), options));
        }

        [Fact]
        public void WillEncodeForwardSlashesInURL()
        {
            bool matcherCalled = false;
            bool pathCorrect = false;

            Func<HttpRequestMessage, bool> matcher = delegate (HttpRequestMessage request)
            {
                matcherCalled = true;
                pathCorrect = request.RequestUri.AbsolutePath.Contains("douglas%2F") ||
                              request.RequestUri.AbsolutePath.Contains("douglas%252F");
                return true;
            };
            var client = MockClient.Build(matcher, NotFoundResponse());
            Assert.Throws<Recurly.Errors.NotFound>(() => client.GetResource("douglas/", "param1", new DateTime(2020, 01, 01)));
            Assert.True(matcherCalled, "Matcher was never called");
            Assert.True(pathCorrect, $"URL did not contain encoded slash");
        }

        [Fact]
        public void WillThrowNotFoundExceptionForNon200()
        {
            var client = MockClient.Build(NotFoundResponse());
            Assert.Throws<Recurly.Errors.NotFound>(() => client.GetResource("benjamin", "param1", new DateTime(2020, 01, 01)));
        }

        [Fact]
        public void WillThrowARecurlyErrorForUnknownErrors()
        {
            var client = MockClient.Build(ErrorResponse((HttpStatusCode)999));
            Assert.Throws<Recurly.RecurlyError>(() => client.GetResource("benjamin", "param1", new DateTime(2020, 01, 01)));
        }

        [Fact]
        public void WillThrowAnApiErrorForUnknownErrorType()
        {
            // Force RECURLY_STRICT_MODE for this test
            Environment.SetEnvironmentVariable("RECURLY_STRICT_MODE", "TRUE");

            var client = MockClient.Build(UnknownTypeResponse());
            var exception = Assert.Throws<System.ArgumentException>(() => client.GetResource("benjamin", "param1", new DateTime(2020, 01, 01)));
            Assert.Matches("no valid exception class", exception.Message);

            Environment.SetEnvironmentVariable("RECURLY_STRICT_MODE", null);
        }

        [Fact]
        public void WillThrowABadRequestError()
        {
            var client = MockClient.Build(ErrorResponse(HttpStatusCode.BadRequest));
            Assert.Throws<Recurly.Errors.BadRequest>(() => client.GetResource("benjamin", "param1", new DateTime(2020, 01, 01)));
        }

        [Fact]
        public void WillTriggerHookIfAvailable()
        {
            var client = MockClient.Build(SuccessResponse(HttpStatusCode.OK));
            var mockHandler = new Mock<IEventHandler>();
            mockHandler
              .Setup(x => x.OnRequest(It.IsAny<Recurly.Http.Request>()));
            mockHandler
              .Setup(x => x.OnResponse(It.IsAny<Recurly.Http.Response>()));
            client.AddEventHandler(mockHandler.Object);
            MyResource resource = client.GetResource("benjamin", "param1", new DateTime());
            Assert.Equal("benjamin", resource.MyString);
        }

        [Fact]
        public async void WillTriggerHookIfAvailableAsync()
        {
            var client = MockClient.Build(SuccessResponse(HttpStatusCode.OK));
            var mockHandler = new Mock<IEventHandler>();
            mockHandler
              .Setup(x => x.OnRequest(It.IsAny<Recurly.Http.Request>()));
            mockHandler
              .Setup(x => x.OnResponse(It.IsAny<Recurly.Http.Response>()));
            client.AddEventHandler(mockHandler.Object);
            MyResource resource = await client.GetResourceAsync("benjamin", "param1", new DateTime());

            Assert.Equal("benjamin", resource.MyString);
            mockHandler.Verify(v => v.OnRequest(It.IsAny<Recurly.Http.Request>()), Times.Once());
            mockHandler.Verify(v => v.OnResponse(It.IsAny<Recurly.Http.Response>()), Times.Once());
        }

        private HttpResponseMessage SuccessResponse(HttpStatusCode status)
        {
            var response = new HttpResponseMessage(status);
            response.Content = new StringContent("{\"my_string\": \"benjamin\"}", Encoding.UTF8, "application/json");
            return response;
        }

        private HttpResponseMessage ErrorResponse(HttpStatusCode statusCode)
        {
            var response = new HttpResponseMessage(statusCode);
            response.Content = new StringContent("<html>parsing error</html>", Encoding.UTF8, "text/html");
            return response;
        }

        private HttpResponseMessage NotFoundResponse()
        {
            var response = new HttpResponseMessage(HttpStatusCode.NotFound);
            response.Content = new StringContent(
                "{\"error\":{ \"type\": \"not_found\", \"message\": \"MyResource not found\"}}",
                Encoding.UTF8, "application/json");
            return response;
        }

        private HttpResponseMessage UnknownTypeResponse()
        {
            var response = new HttpResponseMessage(HttpStatusCode.BadRequest);
            response.Content = new StringContent(
                "{\"error\":{ \"type\": \"not_in_spec\", \"message\": \"MyResource not found\"}}",
                Encoding.UTF8, "application/json");
            return response;
        }
    }
}
