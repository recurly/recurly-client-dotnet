using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Moq;
using Recurly;
using Recurly.Resources;
using RestSharp;
using RestSharp.Authenticators;
using Xunit;

namespace Recurly.Tests
{
    public class ClientTest
    {
        private string apiKey = "myapikey";

        public ClientTest() { }

        [Fact]
        public void CantInitializeWithoutApiKey()
        {
            Assert.Throws<ArgumentException>(() => new Recurly.Client(null));
            Assert.Throws<ArgumentException>(() => new Recurly.Client(""));
            new Recurly.Client(apiKey);
        }

        [Fact]
        public void RespondsWithAValidApiVersion()
        {
            var client = new Recurly.Client(apiKey);
            Assert.Matches(new Regex("v\\d{4}-\\d{2}-\\d{2}"), client.ApiVersion);
        }
    }
}
