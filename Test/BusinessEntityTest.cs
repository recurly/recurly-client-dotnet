using System.Xml;
using FluentAssertions;

using Recurly.Test.Fixtures;


namespace Recurly.Test
{
    public class BusinessEntityTest : BaseTest
    {
        [RecurlyFact(TestEnvironment.Type.Integration)]
        public void LookupBusinessEntity()
        {
            var uuid = "sh9k0b4b80dg";
            var businessEntity = BusinessEntities.Get(uuid);
            businessEntity.Code.Should().Be("default");
            businessEntity.Name.Should().Be("client-lib-test");
            businessEntity.InvoiceDisplayAddress.Country.Should().Be("US");
            businessEntity.TaxAddress.Country.Should().Be("US");
            businessEntity.GetInvoices().Should().BeOfType<InvoiceList>();
        }

        [RecurlyFact(TestEnvironment.Type.Unit)]
        public void CheckForRevRecData()
        {
            var businessEntity = new BusinessEntity();

            var xmlFixture = FixtureImporter.Get(FixtureType.BusinessEntities, "show-200").Xml;
            XmlTextReader reader = new XmlTextReader(new System.IO.StringReader(xmlFixture));
            businessEntity.ReadXml(reader);

            businessEntity.DefaultLiabilityGlAccountId.Should().Be("twrbsq39zvo5");
            businessEntity.DefaultRevenueGlAccountId.Should().Be("bwrks63lznoi");
        }
    }
}
