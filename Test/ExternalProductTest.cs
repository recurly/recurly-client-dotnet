using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace Recurly.Test
{
    public class ExternalProductTest : BaseTest
    {
        [RecurlyFact(TestEnvironment.Type.Integration)]
        public void LookupExternalProduct()
        {
            var uuid = "rv1bgnp0a277";
            var externalProduct = ExternalProducts.Get(uuid);
            externalProduct.Name.Should().Be("An External Product");
        }
    }
}
