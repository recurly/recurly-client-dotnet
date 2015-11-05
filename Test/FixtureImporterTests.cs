using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using FluentAssertions;
using Recurly.Test.Fixtures;
using Xunit;
using Xunit.Extensions;

namespace Recurly.Test
{
    public class FixtureImporterTests
    {
        private const string NullString = null;
        private const string EmptyString = "";

        private const FixtureType ValidFixtureType = FixtureType.Accounts;
        private const string ValidFixtureName = "create-201";

        private const string FixtureNameThatDoesNotExist = "some name";

        [Theory,
        InlineData(NullString),
        InlineData(EmptyString)]
        public void Get_throws_ArgumentException_when_passed_invalid_name(string name)
        {
            Action a = () => FixtureImporter.Get(0, name);
            a.ShouldThrow<ArgumentException>();
        }

        [Fact]
        public void Get_throws_InvalidEnumArgumentException_when_passed_invalid_FixtureType()
        {
            Action a = () => FixtureImporter.Get((FixtureType) 100, ValidFixtureName);
            a.ShouldThrow<InvalidEnumArgumentException>();
        }

        [Fact]
        public void Get_throws_FileNotFoundException_when_no_fixture_exists_for_otherwise_valid_input()
        {
            Action a = () => FixtureImporter.Get(ValidFixtureType, FixtureNameThatDoesNotExist);
            a.ShouldThrow<FileNotFoundException>();
        }

        //[Fact]
        //public void Get_does_not_throw_FileNotFoundException_when_a_fixture_exists()
        //{
        //    Action a = () => FixtureImporter.Get(ValidFixtureType, ValidFixtureName);
        //    a.ShouldNotThrow<FileNotFoundException>();
        //}

        //[Fact]
        //public void Get_can_parse_a_valid_fixture()
        //{
        //    var response = FixtureImporter.Get(FixtureType.Accounts, ValidFixtureName);

        //    response.StatusCode.Should().Be(HttpStatusCode.Created);
        //    response.Headers.Should().ContainKeys("Content-Type", "Location");
        //    response.Xml.Should().NotBeNullOrWhiteSpace();
        //}
    }
}
