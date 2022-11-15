using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace Recurly.Test
{
    public class ExternalProductsListTest : BaseTest
    {
        [RecurlyFact(TestEnvironment.Type.Integration)]
        public void ListExternalProducts()
        {
            var subs = ExternalProducts.List();
            subs.Should().NotBeEmpty();
        }
    }
}
