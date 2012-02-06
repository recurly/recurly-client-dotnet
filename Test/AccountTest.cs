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
            acct.Create("haro-test");
        }

        [Test]
        public void LookupAccount()
        {
            RecurlyAccount newAcct = Factories.NewAccount("Lookup Account");
            newAcct.Create("haro-test");

            RecurlyAccount acct = RecurlyAccount.Get("haro-test", newAcct.AccountCode);
            Assert.IsNotNull(acct);
            Assert.AreEqual(acct.AccountCode, newAcct.AccountCode);
            Assert.IsNotNullOrEmpty(acct.Email);
        }

        [Test]
        [ExpectedException(typeof(NotFoundException))]
        public void FindNonExistantAccount()
        {
            RecurlyAccount acct = RecurlyAccount.Get("haro-test", "totallynotfound!@#$");
        }

        [Test]
        public void UpdateAccount()
        {
            RecurlyAccount acct = Factories.NewAccount("Update Account");
            acct.Create("haro-test");

            acct.LastName = "UpdateTest123";
            acct.Update("haro-test");

            RecurlyAccount getAcct = RecurlyAccount.Get("haro-test",acct.AccountCode);
            Assert.AreEqual(acct.LastName, getAcct.LastName);
        }

        [Test]
        public void CloseAccount()
        {
            RecurlyAccount acct = Factories.NewAccount("Close Account");
            acct.Create("haro-test");

            acct.CloseAccount("haro-test");
        }
    }
}