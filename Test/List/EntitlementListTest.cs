using System.Linq;
using FluentAssertions;
using Xunit;

namespace Recurly.Test
{
    public class EntitlementListTest : BaseTest
    {
        [RecurlyFact(TestEnvironment.Type.Integration)]
        public void List()
        {
            //var account = CreateNewAccountWithBillingInfo();
            var account = Accounts.Get("V2TestEntitlement1");

            var list = account.GetEntitlements();
            list.Should().NotBeEmpty();
        }
    }
}
