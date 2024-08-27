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
            var uuid = "sv3fm556opc8";
            var externalSubscription = ExternalSubscriptions.Get(uuid);
            externalSubscription.Quantity.Should().Be(14);
            externalSubscription.State.Should().Be("expired");
            externalSubscription.ExternalId.Should().Be("cool-string");
            externalSubscription.InGracePeriod.Should().Be(false);
            externalSubscription.CanceledAt.Should().Be(null);
            externalSubscription.TrialStartedAt.Should().Be(null);
            externalSubscription.TrialEndsAt.Should().Be(null);
            externalSubscription.Imported.Should().Be(false);
            externalSubscription.Test.Should().Be(false);
            // externalSubscription.Uuid.Should().Be("fill this in after backfill"); id = 3799097350953132104
        }
    }
}