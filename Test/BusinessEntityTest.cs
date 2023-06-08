using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace Recurly.Test
{
    public class BusinessEntityTest : BaseTest
    {
        [RecurlyFact(TestEnvironment.Type.Integration)]
        public void LookupBusinessEntity()
        {
            var uuid = "sh9k0b4b80dg";
            var businessEntity = BusinessEntities.Get(uuid);
            businessEntity.Code.Should().Be("default");
            businessEntity.Name.Should().Be("client-lib-test");
            businessEntity.InvoiceDisplayAddress.Country.Should().Be("US");
            businessEntity.TaxAddress.Country.Should().Be("US");
            businessEntity.GetInvoices().Should().BeOfType<InvoiceList>();
        }
    }
}
