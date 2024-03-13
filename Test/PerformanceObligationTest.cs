using System;
using System.Xml;
using FluentAssertions;

using Recurly.Test.Fixtures;


namespace Recurly.Test
{
    public class PerformanceObligationTest : BaseTest
    {
        [RecurlyFact(TestEnvironment.Type.Integration)]
        public void GetPerformanceObligation()
        {
            var pob = new PerformanceObligation();

            var xmlFixture = FixtureImporter.Get(FixtureType.PerformanceObligations, "show-200").Xml;
            XmlTextReader reader = new XmlTextReader(new System.IO.StringReader(xmlFixture));
            pob.ReadXml(reader);

            pob.Id.Should().Be("6");
            pob.Name.Should().Be("Over Time (Daily)");
            pob.CreatedAt.Should().Be(new DateTime(2024, 1, 29, 23, 2, 30, DateTimeKind.Utc));
            pob.UpdatedAt.Should().Be(new DateTime(2024, 1, 29, 23, 2, 30, DateTimeKind.Utc));
        }
    }
}
