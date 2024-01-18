using System;
using System.Xml;
using FluentAssertions;
using Recurly.Test.Fixtures;

namespace Recurly.Test
{
    public class GeneralLedgerAccountListTest : BaseTest
    {
        [RecurlyFact(TestEnvironment.Type.Integration)]
        public void List()
        {
            var glas = new GeneralLedgerAccountList();

            var xmlFixture = FixtureImporter.Get(FixtureType.GeneralLedgerAccounts, "index-200").Xml;
            XmlTextReader reader = new XmlTextReader(new System.IO.StringReader(xmlFixture));
            glas.ReadXml(reader);

            glas.Should().HaveCount(2);

            var liabilityGla = glas[0];
            var revenueGla = glas[1];

            liabilityGla.Id.Should().Be("ua8iegmiu2ag");
            liabilityGla.AccountType.Should().Be(GeneralLedgerAccountType.Liability);
            liabilityGla.Code.Should().Be("100");
            liabilityGla.Description.Should().Be("A test description");
            liabilityGla.CreatedAt.Should().Be(new DateTime(2024, 1, 22, 17, 43, 38, DateTimeKind.Utc));
            liabilityGla.UpdatedAt.Should().Be(new DateTime(2024, 1, 22, 17, 43, 38, DateTimeKind.Utc));

            revenueGla.Id.Should().Be("lagie9mxu2ap");
            revenueGla.AccountType.Should().Be(GeneralLedgerAccountType.Revenue);
            revenueGla.Code.Should().Be("200");
            revenueGla.Description.Should().Be("Another test description");
            revenueGla.CreatedAt.Should().Be(new DateTime(2024, 1, 22, 17, 53, 38, DateTimeKind.Utc));
            revenueGla.UpdatedAt.Should().Be(new DateTime(2024, 1, 22, 17, 53, 38, DateTimeKind.Utc));
        }
    }
}
