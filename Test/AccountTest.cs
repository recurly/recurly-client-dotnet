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
            RecurlyAccount acct = Factories.NewAccount("Create Account");
            acct.Create();
        }

        [Test]
        public void LookupAccount()
        {
            RecurlyAccount newAcct = Factories.NewAccount("Lookup Account");
            newAcct.Create();

            RecurlyAccount acct = RecurlyAccount.Get(newAcct.AccountCode);
            Assert.IsNotNull(acct);
            Assert.AreEqual(acct.AccountCode, newAcct.AccountCode);
            Assert.IsNotNullOrEmpty(acct.Email);
        }

        [Test]
        [ExpectedException(typeof(NotFoundException))]
        public void FindNonExistantAccount()
        {
            RecurlyAccount acct = RecurlyAccount.Get("totallynotfound!@#$");
        }

        [Test]
        public void UpdateAccount()
        {
            RecurlyAccount acct = Factories.NewAccount("Update Account");
            acct.Create();

            acct.LastName = "UpdateTest123";
            acct.Update();

            RecurlyAccount getAcct = RecurlyAccount.Get(acct.AccountCode);
            Assert.AreEqual(acct.LastName, getAcct.LastName);
        }

        [Test]
        public void CloseAccount()
        {
            RecurlyAccount acct = Factories.NewAccount("Close Account");
            acct.Create();

            acct.CloseAccount();
        }
    }
}