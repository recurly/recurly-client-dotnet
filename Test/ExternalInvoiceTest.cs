using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace Recurly.Test
{
    public class ExternalInvoiceTest : BaseTest
    {
        [RecurlyFact(TestEnvironment.Type.Integration)]
        public void LookupExternalInvoice()
        {
            var uuid = "sl7984v66da8";
            var externalInvoice = ExternalInvoices.Get(uuid);
            externalInvoice.ExternalId.Should().Be("external_id");
            externalInvoice.State.Should().Be(ExternalInvoice.ExternalInvoiceState.Paid);
            externalInvoice.Total.Should().Be(123);
            externalInvoice.Currency.Should().Be("USD");
            externalInvoice.PurchasedAt.Should().NotBe(default(DateTime));
            externalInvoice.CreatedAt.Should().NotBe(default(DateTime));
            externalInvoice.UpdatedAt.Should().NotBe(default(DateTime));
        }
    }
}
