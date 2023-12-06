using System;

using System.Xml;

using FluentAssertions;

using Recurly.Test.Fixtures;

namespace Recurly.Test
{
    public class ExternalPaymentPhaseListTest : BaseTest
    {
        [RecurlyFact(TestEnvironment.Type.Integration)]
        public void ListExternalPaymentPhase()
        {
            var xmlFixture = FixtureImporter.Get(FixtureType.ExternalPaymentPhases, "index-200").Xml;
            var externalPaymentPhases = new ExternalPaymentPhaseList();
            XmlTextReader reader = new XmlTextReader(new System.IO.StringReader(xmlFixture));
            externalPaymentPhases.ReadXml(reader);
            externalPaymentPhases.Should().HaveCount(1);
            var externalPaymentPhase = externalPaymentPhases[0];
            externalPaymentPhase.StartedAt.Should().Be(new DateTime(2023, 11, 15, 0, 0, 0, DateTimeKind.Utc));
            externalPaymentPhase.EndsAt.Should().Be(new DateTime(2023, 11, 17, 21, 27, 10, DateTimeKind.Utc));
            externalPaymentPhase.StartingBillingPeriodIndex.Should().Be(1);
            externalPaymentPhase.EndingBillingPeriodIndex.Should().Be(2);
            externalPaymentPhase.OfferType.Should().Be("FREE_TRIAL");
            externalPaymentPhase.OfferName.Should().Be("introductory");
            externalPaymentPhase.PeriodCount.Should().Be(2);
            externalPaymentPhase.PeriodLength.Should().Be("TWO WEEKS");
            externalPaymentPhase.Amount.Should().Be(new decimal(1.99));
            externalPaymentPhase.Currency.Should().Be("USD");
            externalPaymentPhase.CreatedAt.Should().Be(new DateTime(2023, 11, 15, 16, 16, 43, DateTimeKind.Utc));
            externalPaymentPhase.UpdatedAt.Should().Be(new DateTime(2023, 11, 15, 16, 16, 43, DateTimeKind.Utc));

        }
    }
}
