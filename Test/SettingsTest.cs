using System;
using System.Collections.Generic;
using FluentAssertions;
using Recurly.Configuration;
using Xunit;

namespace Recurly.Test
{
    public class SettingsTest : BaseTest
    {
        [RecurlyFact(TestEnvironment.Type.Unit)]
        public void ValidDomainTest()
        {
            Settings.ValidDomain.Should().Be(".recurly.com");
        }

        [RecurlyFact(TestEnvironment.Type.Unit)]
        public void ImplicitRecurlyServerUriTest()
        {
            // Implicitly tests that RecurlyServerUri == "https://{0}.recurly.com/v2{1}"
            var uri = Settings.Instance.GetServerUri("/test");
            uri.Should().Be($"https://{Settings.Instance.Subdomain}.recurly.com/v2/test");
        }
    }
}
