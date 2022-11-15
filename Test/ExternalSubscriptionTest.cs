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
            externalSubscription.ExternalResource.ExternalObjectReference.Should().Be("36d2313d-5663-49f6-80e1-0cd6ed69b792");
        }
    }
}
