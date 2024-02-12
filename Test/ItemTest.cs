using System;
using System.Collections.Generic;
using System.Xml;
using FluentAssertions;
using Recurly.Test.Fixtures;
using Xunit;

namespace Recurly.Test
{
    public class ItemTest : BaseTest
    {
        [RecurlyFact(TestEnvironment.Type.Integration)]
        public void LookupItem()
        {
            var item = new Item(GetMockItemCode(), GetMockItemName()) { Description = "Test Lookup" };
            item.Description = "A test description";

            item.Create();
            item.CreatedAt.Should().NotBe(default(DateTime));
            item.Description.Should().Be("A test description");
        }

        [RecurlyFact(TestEnvironment.Type.Integration)]
        public void UpdateItem()
        {
            var item = new Item(GetMockItemCode(), GetMockItemName()) { Description = "Test Lookup" };
            item.Description = "A test description";
            item.Create();
            item.Description = "A new description";
            item.Update();

            Assert.Equal(item.Description, "A new description");
        }

        [RecurlyFact(TestEnvironment.Type.Integration)]
        public void DeactivateItem()
        {
            var item = new Item(GetMockItemCode(), GetMockItemName()) { Description = "Test Lookup" };
            item.Description = "A test description";

            item.Create();
            item.Deactivate();

            Assert.Equal(item.State, null);
        }

        [RecurlyFact(TestEnvironment.Type.Unit)]
        public void CheckForRevRecData()
        {
            var item = new Item();

            var xmlFixture = FixtureImporter.Get(FixtureType.Items, "revrec.show-200").Xml;
            XmlTextReader reader = new XmlTextReader(new System.IO.StringReader(xmlFixture));
            item.ReadXml(reader);

            item.LiabilityGlAccountId.Should().Be("suaz415ebc94");
            item.RevenueGlAccountId.Should().Be("sxo2b1hpjrye");
            item.PerformanceObligationId.Should().Be("7pu");
        }
    }
}
