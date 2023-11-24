using System;
using System.Xml;
using FluentAssertions;
using Recurly.Test.Fixtures;

namespace Recurly.Test
{
    public class ExternalInvoiceTest : BaseTest
    {
        [RecurlyFact(TestEnvironment.Type.Integration)]
        public void LookupExternalInvoice()
        {
            var xmlFixture = FixtureImporter.Get(FixtureType.ExternalInvoices, "show-200").Xml;
            XmlTextReader reader = new XmlTextReader(new System.IO.StringReader(xmlFixture));
            var externalInvoice = new ExternalInvoice();
            externalInvoice.ReadXml(reader);
            externalInvoice.ExternalId.Should().Be("2000000458276005");
            externalInvoice.State.Should().Be(ExternalInvoice.ExternalInvoiceState.Paid);
            externalInvoice.Total.Should().Be(new decimal(10.45));
            externalInvoice.Currency.Should().Be("USD");
            externalInvoice.ExternalSubscriptionUuid.Should().Be("tsfnx2vn5wh6");
            externalInvoice.ExternalPaymentPhaseUuid.Should().Be("twqswp627ri3");
            externalInvoice.PurchasedAt.Should().NotBe(default(DateTime));
            externalInvoice.CreatedAt.Should().NotBe(default(DateTime));
            externalInvoice.UpdatedAt.Should().NotBe(default(DateTime));
        }
    }
}
