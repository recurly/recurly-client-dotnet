using System;
using System.Collections.Generic;
using Moq;
using Recurly;
using Xunit;

namespace Recurly.Tests
{
    public class RequestOptionsTest
    {
        public RequestOptionsTest() { }

        [Fact]
        public void CanAddHeaders()
        {
            var options = new RequestOptions();
            options.AddHeader("Custom-Header", "tchoupitoulas");
            Assert.True(options.Headers.ContainsKey("Custom-Header"));
            Assert.Equal("tchoupitoulas", options.Headers["Custom-Header"]);
        }

        [Fact]
        public void CanSetAcceptLanguageViaProperty()
        {
            var options = new RequestOptions
            {
                AcceptLanguage = "tchoupitoulas"
            };
            Assert.True(options.Headers.ContainsKey("Accept-Language"));
            Assert.Equal("tchoupitoulas", options.Headers["Accept-Language"]);
        }

        [Fact]
        public void CanGetAcceptLanguageViaProperty()
        {
            var options = new RequestOptions();
            options.AddHeader("Accept-Language", "tchoupitoulas");
            Assert.Equal("tchoupitoulas", options.AcceptLanguage);
        }

        [Fact]
        public void CanNotAddUserAgent()
        {
            var options = new RequestOptions();
            Assert.Throws<ArgumentException>(() => options.AddHeader("User-Agent", "tchoupitoulas"));
        }

        [Fact]
        public void CanNotAddContentType()
        {
            var options = new RequestOptions();
            Assert.Throws<ArgumentException>(() => options.AddHeader("Content-Type", "tchoupitoulas"));
        }

        [Fact]
        public void CanNotAddAccept()
        {
            var options = new RequestOptions();
            Assert.Throws<ArgumentException>(() => options.AddHeader("Accept", "tchoupitoulas"));
        }

        [Fact]
        public void CanNotAddAuthorization()
        {
            var options = new RequestOptions();
            Assert.Throws<ArgumentException>(() => options.AddHeader("Authorization", "tchoupitoulas"));
        }

        [Fact]
        public void CanNotAddIdempotencyKey()
        {
            var options = new RequestOptions();
            Assert.Throws<ArgumentException>(() => options.AddHeader("Idempotency-Key", "tchoupitoulas"));
        }
    }
}
