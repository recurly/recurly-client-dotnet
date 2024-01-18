using System;
using System.Xml;
using FluentAssertions;

using Recurly.Test.Fixtures;


namespace Recurly.Test
{
    public class GeneralLedgerAccountTest : BaseTest
    {
        [RecurlyFact(TestEnvironment.Type.Integration)]
        public void GetGeneralLedgerAccount()
        {
            var gla = new GeneralLedgerAccount();

            var xmlFixture = FixtureImporter.Get(FixtureType.GeneralLedgerAccounts, "show-200").Xml;
            XmlTextReader reader = new XmlTextReader(new System.IO.StringReader(xmlFixture));
            gla.ReadXml(reader);

            gla.Id.Should().Be("ua8iegmiu2ag");
            gla.AccountType.Should().Be(GeneralLedgerAccountType.Liability);
            gla.Code.Should().Be("100");
            gla.Description.Should().Be("A test description");
            gla.CreatedAt.Should().Be(new DateTime(2024, 1, 22, 17, 43, 38, DateTimeKind.Utc));
            gla.UpdatedAt.Should().Be(new DateTime(2024, 1, 22, 17, 43, 38, DateTimeKind.Utc));
        }
    }
}
