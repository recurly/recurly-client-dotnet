using System;
using System.Collections.Generic;
using Moq;
using RestSharp;
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

        /*
         * Assert that Timeout can be set and retrieved. Take on faith for now
         * that RestSharp timeouts are well-behaved.
         */
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
        public void CanProperlyFetchAResource()
        {
            var client = MockClient.Build(SuccessResponse(System.Net.HttpStatusCode.OK));
            MyResource resource = client.GetResource("benjamin", "param1", new DateTime(2020, 01, 01));
            Assert.Equal("benjamin", resource.MyString);
        }

        [Fact]
        public async void CanProperlyFetchAResourceAsync()
        {
            var client = MockClient.Build(SuccessResponse(System.Net.HttpStatusCode.OK));
            MyResource resource = await client.GetResourceAsync("benjamin", "param1", new DateTime(2020, 01, 01));
            Assert.Equal("benjamin", resource.MyString);
        }

        [Fact]
        public void WillPopulateResponseOnResource()
        {
            var client = MockClient.Build(SuccessResponse(System.Net.HttpStatusCode.OK));
            MyResource resource = client.GetResource("benjamin", "param1", new DateTime(2020, 01, 01));
            Assert.Equal(System.Net.HttpStatusCode.OK, resource.GetResponse().StatusCode);
            Assert.Empty(resource.GetResponse().Headers);
            Assert.Equal("{\"my_string\": \"benjamin\"}", resource.GetResponse().RawResponse);
        }

        [Fact]
        public void CanProperlyCreateAResource()
        {
            var client = MockClient.Build(SuccessResponse(System.Net.HttpStatusCode.Created));
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
            var date = new DateTime(2020, 01, 01);
            var paramsMatcher = MockClient.QueryParameterMatcher(new Dictionary<string, object> {
                { "param_1", "param1" },
                { "param_2", Recurly.Utils.ISO8601(date) },
            });

            var client = MockClient.Build(paramsMatcher, SuccessResponse(System.Net.HttpStatusCode.OK));
            MyResource resource = client.GetResource("benjamin", "param1", date, options);
            Assert.Equal("benjamin", resource.MyString);
        }

        [Fact]
        public void WillValidatePathParams()
        {
            var client = MockClient.Build(SuccessResponse(System.Net.HttpStatusCode.OK));
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
            Func<IRestRequest, bool> matcher = delegate (IRestRequest request)
            {
                Assert.Equal("/my_resources/douglas%2F", request.Resource);
                return true;
            };
            var client = MockClient.Build(matcher, NotFoundResponse());
            Assert.Throws<Recurly.Errors.NotFound>(() => client.GetResource("douglas/", "param1", new DateTime(2020, 01, 01)));
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
            var client = MockClient.Build(ErrorResponse((System.Net.HttpStatusCode)999));
            Assert.Throws<Recurly.RecurlyError>(() => client.GetResource("benjamin", "param1", new DateTime(2020, 01, 01)));
        }

        [Fact]
        public void WillThrowAnApiErrorForUnknownErrorType()
        {
            var client = MockClient.Build(UnknownTypeResponse());
            // Instead of disabling strict mode, test with ArgumentException as proxy
            var exception = Assert.Throws<System.ArgumentException>(() => client.GetResource("benjamin", "param1", new DateTime(2020, 01, 01)));
            Assert.Matches("no valid exception class", exception.Message);
        }

        [Fact]
        public void WillThrowABadRequestError()
        {
            var client = MockClient.Build(ErrorResponse(System.Net.HttpStatusCode.BadRequest));
            Assert.Throws<Recurly.Errors.BadRequest>(() => client.GetResource("benjamin", "param1", new DateTime(2020, 01, 01)));
        }

        [Fact]
        public void WillTriggerHookIfAvailable()
        {
            var client = MockClient.Build(SuccessResponse(System.Net.HttpStatusCode.OK));
            var mockHandler = new Mock<IEventHandler>();
            mockHandler
              .Setup(x => x.OnRequest(It.IsAny<Recurly.Http.Request>()));
            mockHandler
              .Setup(x => x.OnResponse(It.IsAny<Recurly.Http.Response>()));
            client.AddEventHandler(mockHandler.Object);
            MyResource resource = client.GetResource("benjamin", "param1", new DateTime());
            Assert.Equal("benjamin", resource.MyString);
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

        private Mock<IRestResponse<MyResource>> ErrorResponse(System.Net.HttpStatusCode statusCode)
        {
            var response = new Mock<IRestResponse<MyResource>>();
            response.Setup(_ => _.StatusCode).Returns(statusCode);
            response.Setup(_ => _.Content).Returns("<html>parsing error</html>");
            response.Setup(_ => _.Headers).Returns(new List<Parameter> { });
            response.Setup(_ => _.ContentType).Returns("text/html");
            response.Setup(_ => _.ErrorException).Returns(new Exception("parsing error"));
            response.Setup(_ => _.ErrorMessage).Returns("parsing error");

            return response;
        }

        private Mock<IRestResponse<MyResource>> InvalidContentTypeResponse()
        {
            var response = new Mock<IRestResponse<MyResource>>();
            response.Setup(_ => _.StatusCode).Returns(System.Net.HttpStatusCode.BadRequest);
            response.Setup(_ => _.Content).Returns("{\"error\":{ \"type\": \"invalid_content_type\", \"message\": \"MyResource not found\"}}");
            response.Setup(_ => _.Headers).Returns(new List<Parameter> { });

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

        private Mock<IRestResponse<MyResource>> UnknownTypeResponse()
        {
            var response = new Mock<IRestResponse<MyResource>>();
            response.Setup(_ => _.StatusCode).Returns(System.Net.HttpStatusCode.BadRequest);
            response.Setup(_ => _.Content).Returns("{\"error\":{ \"type\": \"not_in_spec\", \"message\": \"MyResource not found\"}}");
            response.Setup(_ => _.Headers).Returns(new List<Parameter> { });

            return response;
        }
    }
}
