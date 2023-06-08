using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace Recurly.Test
{
    public class BusinessEntitiesListTest : BaseTest
    {
        [RecurlyFact(TestEnvironment.Type.Integration)]
        public void ListBusinessEntities()
        {
            var businessEntities = BusinessEntities.List();
            businessEntities[0].Should().BeOfType(typeof(BusinessEntity));
        }
    }
}
