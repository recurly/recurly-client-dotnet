using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace Recurly.Test
{
    public class ExternalChargeTest : BaseTest
    {
        [RecurlyFact(TestEnvironment.Type.Integration)]
        public void GetExternalCharge()
        {
            var uuid = "sl7984v66da8";
            var externalInvoice = ExternalInvoices.Get(uuid);
            var externalCharge = externalInvoice.ExternalCharges[0];
            externalCharge.Description.Should().Be("");
            externalCharge.UnitAmount.Should().Be(123);
            externalCharge.Currency.Should().Be("USD");
            externalCharge.Quantity.Should().Be(123);
            externalCharge.CreatedAt.Should().NotBe(default(DateTime));
            externalCharge.UpdatedAt.Should().NotBe(default(DateTime));
        }
    }
}
