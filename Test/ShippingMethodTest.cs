using System;
using System.Collections.Generic;
using System.Xml;
using FluentAssertions;
using Recurly.Test.Fixtures;
using Xunit;

namespace Recurly.Test
{
    public class ShippingMethodTest : BaseTest
    {
        [RecurlyFact(TestEnvironment.Type.Unit)]
        public void CheckForRevRecData()
        {
            var shippingMethod = new ShippingMethod();

            var xmlFixture = FixtureImporter.Get(FixtureType.ShippingMethods, "revrec.show-200").Xml;
            XmlTextReader reader = new XmlTextReader(new System.IO.StringReader(xmlFixture));
            shippingMethod.ReadXml(reader);

            shippingMethod.LiabilityGlAccountId.Should().Be("suaz415ebc94");
            shippingMethod.RevenueGlAccountId.Should().Be("sxo2b1hpjrye");
            shippingMethod.PerformanceObligationId.Should().Be("7pu");
        }
    }
}
