using System;
using System.Collections.Generic;
using System.Xml;
using FluentAssertions;
using Recurly.Test.Fixtures;
using Xunit;

namespace Recurly.Test
{
    public class GiftCardTest : BaseTest
    {
        [RecurlyFact(TestEnvironment.Type.Unit)]
        public void CheckForRevRecData()
        {
            var giftCard = new GiftCard();

            var xmlFixture = FixtureImporter.Get(FixtureType.GiftCards, "revrec.show-200").Xml;
            XmlTextReader reader = new XmlTextReader(new System.IO.StringReader(xmlFixture));
            giftCard.ReadXml(reader);

            giftCard.LiabilityGlAccountId.Should().Be("suaz415ebc94");
            giftCard.RevenueGlAccountId.Should().Be("sxo2b1hpjrye");
            giftCard.PerformanceObligationId.Should().Be("7pu");
        }
    }
}
