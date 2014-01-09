using NUnit.Framework;

namespace Recurly.Test
{
    [TestFixture]
    public class AccountListTest
    {

        [Test]
        public void List()
        {
            Account acct = new Account(Factories.GetMockAccountName());
            acct.Create();
            acct = new Account(Factories.GetMockAccountName());
            acct.Create();

            AccountList accounts = AccountList.List();
            Assert.IsTrue(accounts.Count >= 2);
        }

        [Test]
        public void ListActive()
        {
            Account acct = new Account(Factories.GetMockAccountName());
            acct.Create();
            acct = new Account(Factories.GetMockAccountName());
            acct.Create();

            AccountList accounts = AccountList.List(Account.AccountState.Active);
            Assert.IsTrue(accounts.Count >= 2);
        }

        [Test]
        public void ListClosed()
        {
            Account acct = new Account(Factories.GetMockAccountName());
            acct.Create();
            acct.Close();
            acct = new Account(Factories.GetMockAccountName());
            acct.Create();
            acct.Close();

            AccountList accounts = AccountList.List(Account.AccountState.Closed);
            Assert.IsTrue(accounts.Count >= 2);
        }

        [Test]
        public void ListPastDue()
        {
            Account acct = new Account(Factories.GetMockAccountName());
            acct.Create();

            Adjustment a = acct.CreateAdjustment("Past Due", 5000, "USD", 1);
            a.Create();

            acct.InvoicePendingCharges();

            AccountList accounts = AccountList.List(Account.AccountState.PastDue);
            Assert.IsTrue(accounts.Count > 0);
        }




    }
}