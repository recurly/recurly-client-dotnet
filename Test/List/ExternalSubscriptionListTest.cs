using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace Recurly.Test
{
    public class ExternalSubscriptionListTest : BaseTest
    {
        [RecurlyFact(TestEnvironment.Type.Integration)]
        public void ListExternalSubscriptions()
        {
            var subs = ExternalSubscriptions.List();
            subs.Should().NotBeEmpty();
        }

        [RecurlyFact(TestEnvironment.Type.Integration)]
        public void ListForAccount()
        {
            var account = Accounts.Get("external-resources");

            var list = account.GetExternalSubscriptions();
            list.Should().NotBeEmpty();
        }
    }
}
