using System;
using System.Collections.Generic;
using Moq;
using Recurly;
using RestSharp;
using Xunit;

namespace Recurly.Tests
{
    public class ResponseTest
    {
        private IList<Header> TestHeaders = new List<Header>()
        {
            new Header("Content-Type", "application/value"),
            new Header("X-Request-Id", "the-request-id"),
            new Header("X-RateLimit-Limit", "4000"),
            new Header("X-RateLimit-Remaining", "42"),
            new Header("X-RateLimit-Reset", "1595451960"),
            new Header("Recurly-Total-Records", "42"),
        };

        public ResponseTest() { }

        [Fact]
        public void CanGetStatusCode()
        {
            var response = BuildResponse();
            Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public void CanGetRawResponse()
        {
            var response = BuildResponse();
            Assert.Equal("raw-response", response.RawResponse);
        }

        [Fact]
        public void CanGetRequestId()
        {
            var response = BuildResponse();
            Assert.Equal("the-request-id", response.RequestId);
        }

        [Fact]
        public void CanGetRateLimit()
        {
            var response = BuildResponse();
            Assert.Equal(4000, response.RateLimit);
        }

        [Fact]
        public void CanGetRateLimitRemaining()
        {
            var response = BuildResponse();
            Assert.Equal(42, response.RateLimitRemaining);
        }

        [Fact]
        public void CanGetRateLimitReset()
        {
            var response = BuildResponse();
            Assert.Equal(1595451960, response.RateLimitReset);
        }

        [Fact]
        public void CanGetRecordCount()
        {
            var response = BuildResponse();
            Assert.Equal(42, response.RecordCount);
        }

        [Fact]
        public void CanGetRecordCountUnset()
        {
            var response = new Response()
            {
                Headers = new List<Header>()
            };
            Assert.Null(response.RecordCount);
        }

        [Fact]
        public void CanGetRecordCountInvalid()
        {
            var response = new Response()
            {
                Headers = new List<Header>()
                {
                    new Header("Recurly-Total-Records", "banana"),
                }
            };
            Assert.Null(response.RecordCount);
        }

        [Fact]
        public void CanGetContentType()
        {
            var response = BuildResponse();
            Assert.Equal("application/value", response.ContentType);
        }

        private Response BuildResponse()
        {
            var response = new Response()
            {
                StatusCode = System.Net.HttpStatusCode.OK,
                RawResponse = "raw-response",
                Headers = TestHeaders
            };
            return response;
        }
    }
}
