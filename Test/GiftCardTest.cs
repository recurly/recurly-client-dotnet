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

        [RecurlyFact(TestEnvironment.Type.Unit)]
        public void GiftCardWithTaxServiceOptOutTrue()
        {
            var delivery = new Delivery(Delivery.DeliveryMethod.Email)
            {
                EmailAddress = "test@example.com",
                FirstName = "Test",
                LastName = "User"
            };

            var giftCard = new GiftCard("test-account", delivery, "gift_card_product", 5000, "USD")
            {
                TaxServiceOptOut = true
            };

            // Verify the request serializes tax_service_opt_out correctly
            var xmlOutput = new System.Text.StringBuilder();
            using (var xmlWriter = new XmlTextWriter(new System.IO.StringWriter(xmlOutput)))
            {
                giftCard.WriteXml(xmlWriter);
            }
            var xml = xmlOutput.ToString();

            Assert.Contains("<tax_service_opt_out>true</tax_service_opt_out>", xml);
        }

        [RecurlyFact(TestEnvironment.Type.Unit)]
        public void GiftCardWithTaxServiceOptOutFalse()
        {
            var delivery = new Delivery(Delivery.DeliveryMethod.Email)
            {
                EmailAddress = "test@example.com",
                FirstName = "Test",
                LastName = "User"
            };

            var giftCard = new GiftCard("test-account", delivery, "gift_card_product", 5000, "USD")
            {
                TaxServiceOptOut = false
            };

            // Verify the request serializes tax_service_opt_out correctly
            var xmlOutput = new System.Text.StringBuilder();
            using (var xmlWriter = new XmlTextWriter(new System.IO.StringWriter(xmlOutput)))
            {
                giftCard.WriteXml(xmlWriter);
            }
            var xml = xmlOutput.ToString();

            Assert.Contains("<tax_service_opt_out>false</tax_service_opt_out>", xml);
        }

        [RecurlyFact(TestEnvironment.Type.Unit)]
        public void GiftCardWithoutTaxServiceOptOut()
        {
            var delivery = new Delivery(Delivery.DeliveryMethod.Email)
            {
                EmailAddress = "test@example.com",
                FirstName = "Test",
                LastName = "User"
            };

            var giftCard = new GiftCard("test-account", delivery, "gift_card_product", 5000, "USD");
            // TaxServiceOptOut not set (remains null)

            // Verify the request does NOT include tax_service_opt_out
            var xmlOutput = new System.Text.StringBuilder();
            using (var xmlWriter = new XmlTextWriter(new System.IO.StringWriter(xmlOutput)))
            {
                giftCard.WriteXml(xmlWriter);
            }
            var xml = xmlOutput.ToString();

            Assert.DoesNotContain("tax_service_opt_out", xml);
        }
    }
}

