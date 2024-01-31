using System;
using System.Xml;
using FluentAssertions;
using Recurly.Test.Fixtures;

namespace Recurly.Test
{
    public class PerformanceObligationListTest : BaseTest
    {
        [RecurlyFact(TestEnvironment.Type.Integration)]
        public void List()
        {
            var pobs = new PerformanceObligationList();

            var xmlFixture = FixtureImporter.Get(FixtureType.PerformanceObligations, "index-200").Xml;
            XmlTextReader reader = new XmlTextReader(new System.IO.StringReader(xmlFixture));
            pobs.ReadXml(reader);

            pobs.Should().HaveCount(6);

            var firstPob = pobs[0];
            var secondPob = pobs[1];

            firstPob.Id.Should().Be("1");
            firstPob.Name.Should().Be("Material Right");
            firstPob.CreatedAt.Should().Be(new DateTime(2024, 1, 29, 23, 2, 30, DateTimeKind.Utc));
            firstPob.UpdatedAt.Should().Be(new DateTime(2024, 1, 29, 23, 2, 30, DateTimeKind.Utc));

            secondPob.Id.Should().Be("2");
            secondPob.Name.Should().Be("Manual Journal");
            secondPob.CreatedAt.Should().Be(new DateTime(2024, 1, 29, 23, 2, 30, DateTimeKind.Utc));
            secondPob.UpdatedAt.Should().Be(new DateTime(2024, 1, 29, 23, 2, 30, DateTimeKind.Utc));
        }
    }
}
