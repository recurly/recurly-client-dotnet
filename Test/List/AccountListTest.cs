using FluentAssertions;
using Recurly.Configuration;
using Xunit;
using AccountState = Recurly.Account.AccountState;

namespace Recurly.Test
{
    public class AccountListTest : BaseTest
    {
        [RecurlyFact(TestEnvironment.Type.Integration)]
        public void List()
        {
            var accounts = Accounts.List();
            accounts.Should().NotBeEmpty();
        }

        [RecurlyFact(TestEnvironment.Type.Integration)]
        public void ListActive()
        {
            CreateNewAccount();
            CreateNewAccount();

            var accounts = Accounts.List(AccountState.Active);
            accounts.Should().HaveCount(x => x >= 2);
        }

        [RecurlyFact(TestEnvironment.Type.Integration)]
        public void ListClosed()
        {
            CreateNewAccount().Close();
            CreateNewAccount().Close();

            var accounts = Accounts.List(AccountState.Closed);
            accounts.Should().HaveCount(x => x >= 2);
        }

        [RecurlyFact(TestEnvironment.Type.Integration)]
        public void ListPastDue()
        {
            var acct = CreateNewAccount();

            var adjustment = acct.NewAdjustment("USD", 5000, "Past Due", 1);
            adjustment.Create();

            acct.InvoicePendingCharges();

            var accounts = Accounts.List(AccountState.PastDue);
            accounts.Should().NotBeEmpty();
        }

        [RecurlyFact(TestEnvironment.Type.Integration)]
        public void AccountList_supports_paging()
        {
            var testSettings = SettingsFixture.TestSettings;
            var moddedSettings = new Settings(testSettings.ApiKey, testSettings.Subdomain,
                testSettings.PrivateKey, 5);
            Client.Instance.ApplySettings(moddedSettings);

            var accounts = Accounts.List();
            accounts.Should().HaveCount(5);
            accounts.Capacity.Should().BeGreaterOrEqualTo(5);

            accounts.Next.Should().NotBeEmpty();
        }
    }
}