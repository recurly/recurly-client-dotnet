using System;
using Xunit;

namespace Recurly.Test
{
    public class AccountTest : BaseTest
    {
        [Fact]
        public void CreateAccount()
        {
            Account acct = new Account(Factories.GetMockAccountName());
            acct.Create();
            //Assert.IsNotNull(acct.CreatedAt); // I don't know what this was testing, a non-nullable DateTime can never be null!
        }

        //[Test]
        //public void CreateAccountWithParameters()
        //{
        //    Account acct = new Account(Factories.GetMockAccountName());
        //    acct.Username = "testuser1";
        //    acct.Email = "testemail@recurly.com";
        //    acct.FirstName = "Test";
        //    acct.LastName = "User";
        //    acct.CompanyName = "Test Company";
        //    acct.AcceptLanguage = "en";

        //    acct.Create();

        //    Assert.AreEqual(acct.Username, "testuser1");
        //    Assert.AreEqual(acct.Email, "testemail@recurly.com");
        //    Assert.AreEqual(acct.FirstName, "Test");
        //    Assert.AreEqual(acct.LastName, "User");
        //    Assert.AreEqual(acct.CompanyName, "Test Company");
        //    Assert.AreEqual(acct.AcceptLanguage, "en");

        //}

        //[Test]
        //public void CreateAccountWithBillingInfo()
        //{
        //    String a = Factories.GetMockAccountName();

        //    Account acct = new Account(a, "BI", "User",
        //        "4111111111111111", DateTime.Now.Month, DateTime.Now.Year + 1);

        //    acct.Create();

        //    BillingInfo t = BillingInfo.Get(a);
        //    Assert.AreEqual(t, acct.BillingInfo);

        //}

        //[Test]
        //public void LookupAccount()
        //{
        //    string a = Factories.GetMockAccountName();

        //    Account newAcct = new Account(a);
        //    newAcct.Email = "testemail@recurly.com";
        //    newAcct.Create();

        //    Account acct = Account.Get(newAcct.AccountCode);
        //    Assert.IsNotNull(acct);
        //    Assert.AreEqual(acct.AccountCode, newAcct.AccountCode);
        //    Assert.IsNotNullOrEmpty(acct.Email);
        //}

        //[Test]
        //[ExpectedException(typeof(NotFoundException))]
        //public void FindNonExistentAccount()
        //{
        //    Account acct = Account.Get("totallynotfound!@#$");
        //}

        //[Test]
        //public void UpdateAccount()
        //{
        //    Account acct = new Account(Factories.GetMockAccountName());
        //    acct.Create();

        //    acct.LastName = "UpdateTest123";
        //    acct.Update();

        //    Account getAcct = Account.Get(acct.AccountCode);
        //    Assert.AreEqual(acct.LastName, getAcct.LastName);
        //}

        //[Test]
        //public void CloseAccount()
        //{
        //    string s = Factories.GetMockAccountName();
        //    Account acct = new Account(s);
        //    acct.Create();

        //    acct.Close();

        //    Account getAcct = Account.Get(s);
        //    Assert.AreEqual(getAcct.State, Account.AccountState.Closed);
        //}

        //[Test]
        //public void ReopenAccount()
        //{
        //    string s = Factories.GetMockAccountName();
        //    Account acct = new Account(s);
        //    acct.Create();
        //    acct.Close();

        //    acct.Reopen();

        //    Account test = Account.Get(s);
        //    Assert.AreEqual(acct.State, Account.AccountState.Active);
        //    Assert.AreEqual(test.State, Account.AccountState.Active);
        //}

        
    }
}