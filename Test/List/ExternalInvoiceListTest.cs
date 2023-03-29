using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace Recurly.Test
{
    public class ExternalInvoiceListTest : BaseTest
    {
        [RecurlyFact(TestEnvironment.Type.Integration)]
        public void ListExternalInvoices()
        {
            var externalInvoices = ExternalInvoices.List();
            externalInvoices.Should().NotBeEmpty();
        }
    }
}
