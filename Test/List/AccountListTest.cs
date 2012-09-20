using System;
using System.Collections.Generic;
using System.Text;
using Recurly;
using NUnit.Framework;
using System.Threading;

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

            AccountList accounts = AccountList.List(Account.AccountState.active);
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

            AccountList accounts = AccountList.List(Account.AccountState.closed);
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

            AccountList accounts = AccountList.List(Account.AccountState.past_due);
            Assert.IsTrue(accounts.Count > 0);
        }




    }
}