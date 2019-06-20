using System;
using System.Text.RegularExpressions;
using Xunit;
using Recurly;

namespace Recurly.Tests
{
    public class RecurlyClientFactoryTest
    {
        private string siteId = "subdomain-mysubdomain";
        private string apiKey = "myapikey";

        public RecurlyClientFactoryTest() { }

        [Fact]
        public void CantInitializeWithoutSiteIdAndApiKey()
        {
            Assert.Throws<ArgumentException>(() => RecurlyClientFactory.Build(null, siteId));
            Assert.Throws<ArgumentException>(() => RecurlyClientFactory.Build("", siteId));
            Assert.Throws<ArgumentException>(() => RecurlyClientFactory.Build(apiKey, null));
            Assert.Throws<ArgumentException>(() => RecurlyClientFactory.Build(apiKey, ""));
        }

        [Fact]
        public void SetsTheSiteId()
        {
            var client = RecurlyClientFactory.Build(apiKey, siteId);
            Assert.Equal("subdomain-mysubdomain", client.SiteId);
        }

        [Fact]
        public void RespondsWithAValidApiVersion()
        {
            var client = RecurlyClientFactory.Build(apiKey, siteId);
            Assert.Matches(new Regex("v\\d{4}-\\d{2}-\\d{2}"), client.ApiVersion);
        }
    }
}
