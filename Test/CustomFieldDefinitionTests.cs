using System;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace Recurly.Test
{
    public class CustomFieldDefinitionTests : BaseTest
    {
        [RecurlyFact(TestEnvironment.Type.Integration)]
        public void ListCustomFieldDefinitionsTest()
        {
            var list = CustomFieldDefinitions.List();
            list.Count().Should().BeGreaterThan(1);
        }

        [RecurlyFact(TestEnvironment.Type.Integration)]
        public void ListCustomFieldDefinitionsByRelatedTypeTest()
        {
            var fullList = CustomFieldDefinitions.List();
            var chargeList = CustomFieldDefinitions.List(CustomFieldDefinition.CustomFieldType.Charge);
            chargeList.Should().NotBeNullOrEmpty();
            fullList.Count().Should().BeGreaterThan(chargeList.Count());
        }

        [RecurlyFact(TestEnvironment.Type.Integration)]
        public void GetCustomFieldDefinitionByIdTest()
        {
            var chargeCustomField = CustomFieldDefinitions.List(CustomFieldDefinition.CustomFieldType.Charge).FirstOrDefault();
            var customFieldDefinition = CustomFieldDefinition.Get(chargeCustomField.Id);
            customFieldDefinition.Should().NotBeNull();
        }
    }
}
