using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace Recurly.Test
{
    public class ExternalSubscriptionTest : BaseTest
    {
        [RecurlyFact(TestEnvironment.Type.Integration)]
        public void LookupExternalSubscription()
        {
            var uuid = "rv1loyqlf6si";
            var externalSubscription = ExternalSubscriptions.Get(uuid);
            externalSubscription.Quantity.Should().Be(14);
            externalSubscription.State.Should().Be("");
            externalSubscription.ExternalId.Should().Be("");
        }
    }
}
