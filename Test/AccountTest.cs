using System;
using System.Collections.Generic;
using System.Text;
using Recurly;
using NUnit.Framework;

namespace Recurly.Test
{
    [TestFixture]
    public class AccountTest
    {

        [Test]
        public void CreateAccount()
        {
            Account acct = Factories.NewAccount("Test Active Account");
            acct.Create();

            acct = Factories.NewAccount("Test Closed Account");
            acct.Create();
            acct.Close();

            acct = Factories.NewAccount("Test Past Due Account");
            acct.Create();

            //TODO: add subscription that is past due
        }

        [Test]
        public void List()
        {
            Account.List();
            // todo: assert size
        }

        [Test]
        public void ListActive()
        {
            List<Account> accounts = Account.List(Account.AccountState.Active);
            Assert.IsTrue(accounts.Count > 0);
        }

        [Test]
        public void ListClosed()
        {
            Account.List(Account.AccountState.Closed);
            //TODO: assert size
        }

      
        [Test]
        public void ListPastDue()
        {
            Account.List(Account.AccountState.Past_Due);
            //TODO: assert size
        }


        [Test]
        public void LookupAccount()
        {
            Account newAcct = Factories.NewAccount("Lookup Account");
            newAcct.Create();

            Account acct = Account.Get(newAcct.AccountCode);
            Assert.IsNotNull(acct);
            Assert.AreEqual(acct.AccountCode, newAcct.AccountCode);
            Assert.IsNotNullOrEmpty(acct.Email);
        }

        [Test]
        [ExpectedException(typeof(NotFoundException))]
        public void FindNonExistantAccount()
        {
            Account acct = Account.Get("totallynotfound!@#$");
        }

        [Test]
        public void UpdateAccount()
        {
            Account acct = Factories.NewAccount("Update Account");
            acct.Create();

            acct.LastName = "UpdateTest123";
            acct.Update();

            Account getAcct = Account.Get(acct.AccountCode);
            Assert.AreEqual(acct.LastName, getAcct.LastName);
        }

        [Test]
        public void CloseAccount()
        {
            Account acct = Factories.NewAccount("Close Account");
            acct.Create();

            acct.Close();

            Account getAcct = Account.Get("Close Account");
            Assert.AreEqual(getAcct.State, Recurly.Account.AccountState.Closed);
        }

        
    }
}