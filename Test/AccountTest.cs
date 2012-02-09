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
            acct.Create("instance1");
        }

        [Test]
        public void LookupAccount()
        {
            RecurlyAccount newAcct = Factories.NewAccount("Lookup Account");
            newAcct.Create("instance1");

            RecurlyAccount acct = RecurlyAccount.Get("instance1", newAcct.AccountCode);
            Assert.IsNotNull(acct);
            Assert.AreEqual(acct.AccountCode, newAcct.AccountCode);
            Assert.IsNotNullOrEmpty(acct.Email);
        }

        [Test]
        [ExpectedException(typeof(NotFoundException))]
        public void FindNonExistantAccount()
        {
            RecurlyAccount acct = RecurlyAccount.Get("instance1", "totallynotfound!@#$");
        }

        [Test]
        public void UpdateAccount()
        {
            RecurlyAccount acct = Factories.NewAccount("Update Account");
            acct.Create("instance1");

            acct.LastName = "UpdateTest123";
            acct.Update("instance1");

            RecurlyAccount getAcct = RecurlyAccount.Get("instance1", acct.AccountCode);
            Assert.AreEqual(acct.LastName, getAcct.LastName);
        }

        [Test]
        public void CloseAccount()
        {
            RecurlyAccount acct = Factories.NewAccount("Close Account");
            acct.Create("instance1");

            acct.CloseAccount("instance1");
        }

        [Test]
        public void CreateMultipleAccounts()
        {
            RecurlyAccount acct1 = Factories.NewAccount("Multiple Create Account - Instance 1");
            acct1.Create("instance1");

            RecurlyAccount acct2 = Factories.NewAccount("Multiple Create Account - Instance 2");
            acct2.Create("instance2");
        }

        [Test]
        public void LookupMultipleAccounts()
        {
            RecurlyAccount newAcct1 = Factories.NewAccount("Multiple Lookup Account - Instance 1");
            newAcct1.Create("instance1");

            RecurlyAccount newAcct2 = Factories.NewAccount("Multiple Lookup Account - Instance 2");
            newAcct2.Create("instance2");

            RecurlyAccount acct1 = RecurlyAccount.Get("instance1", newAcct1.AccountCode);
            RecurlyAccount acct2 = RecurlyAccount.Get("instance2", newAcct2.AccountCode);

            Assert.IsNotNull(acct1);
            Assert.IsNotNull(acct2);
        }

        [Test]
        public void CloseInstance1()
        {
            RecurlyAccount newAcct1 = Factories.NewAccount("CloseInstance1 Account - Instance 1");
            newAcct1.Create("instance1");

            RecurlyAccount newAcct2 = Factories.NewAccount("CloseInstance1 Account - Instance 2");
            newAcct2.Create("instance2");

            newAcct1.CloseAccount("instance1");

            RecurlyAccount acct2 = RecurlyAccount.Get("instance2", newAcct2.AccountCode);

            Assert.IsNotNull(acct2);
        }
    }
}