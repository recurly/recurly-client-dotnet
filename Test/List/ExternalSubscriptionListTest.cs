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
            var account = Accounts.Get("2fd694e1-81b6-4b38-8ade-abc8220afaaf");

            var list = account.GetExternalSubscriptions();
            list.Should().NotBeEmpty();
        }
    }
}
