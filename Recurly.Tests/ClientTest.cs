using System;
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

namespace Recurly.Tests
{
    public class ClientTest
    {
        private string siteId = "subdomain-mysubdomain";
        private string apiKey = "myapikey";

        public ClientTest() { }

        [Fact]
        public void CantInitializeWithoutSiteIdAndApiKey()
        {
            Assert.Throws<ArgumentException>(() => new Recurly.Client(null, apiKey));
            Assert.Throws<ArgumentException>(() => new Recurly.Client("", apiKey));
            Assert.Throws<ArgumentException>(() => new Recurly.Client(siteId, null));
            Assert.Throws<ArgumentException>(() => new Recurly.Client(siteId, ""));
        }

        [Fact]
        public void SetsTheSiteId()
        {
            var client = new Recurly.Client(siteId, apiKey);
            Assert.Equal("subdomain-mysubdomain", client.SiteId);
        }

        [Fact]
        public void RespondsWithAValidApiVersion()
        {
            var client = new Recurly.Client(siteId, apiKey);
            Assert.Matches(new Regex("v\\d{4}-\\d{2}-\\d{2}"), client.ApiVersion);
        }
    }
}
