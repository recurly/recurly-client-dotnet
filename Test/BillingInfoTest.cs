using System;
using System.Collections.Generic;
using System.Text;
using Recurly;
using NUnit.Framework;

namespace Recurly.Test
{
    [TestFixture]
    public class BillingInfoTest
    {
        [Test]
        public void UpdateBillingInfo()
        {
            string s = Factories.GetMockAccountName("Update Billing Info");
            Account acct = new Account(s,
                "John","Doe", "4111111111111111", DateTime.Now.Month, DateTime.Now.Year+2);
            acct.Create();

            BillingInfo billingInfo = new BillingInfo(acct);
            billingInfo.FirstName = "Jane";
            billingInfo.LastName = "Smith";
            billingInfo.CreditCardNumber = "4111111111111111";
            billingInfo.ExpirationMonth = DateTime.Now.AddMonths(3).Month;
            billingInfo.ExpirationYear = DateTime.Now.AddYears(3).Year;
            billingInfo.Update();

            Account a = Account.Get(s);

            Assert.AreEqual(a.BillingInfo.FirstName, "Jane");
            Assert.AreEqual(a.BillingInfo.LastName, "Smith");
            Assert.AreEqual(a.BillingInfo.ExpirationMonth, DateTime.Now.AddMonths(3).Month);
            Assert.AreEqual(a.BillingInfo.ExpirationYear, DateTime.Now.AddYears(3).Year);

        }

        [Test]
        public void LookupBillingInfo()
        {
            string s = Factories.GetMockAccountName("Update Billing Info");
            Account acct = new Account(s,
                "John", "Doe", "4111111111111111", DateTime.Now.Month, DateTime.Now.Year + 2);
            acct.Create();

            Account a = Account.Get(s);

            Assert.AreEqual(a.BillingInfo.FirstName, "John");
            Assert.AreEqual(a.BillingInfo.LastName, "Doe");
            Assert.AreEqual(a.BillingInfo.ExpirationMonth, DateTime.Now.Month);
            Assert.AreEqual(a.BillingInfo.ExpirationYear, DateTime.Now.Year+2);
        }

        [Test]
        public void LookupMissingInfo()
        {
            Account newAcct = new Account(Factories.GetMockAccountName("Lookup Missing Billing Info"));
            newAcct.Create();

            Assert.Throws(typeof(NotFoundException), delegate
            {
                BillingInfo.Get(newAcct.AccountCode);
            });
        }

        [Test]
        
        public void ClearBillingInfo()
        {
            string s = Factories.GetMockAccountName("Clear Billing Info");

            Account newAcct = new Account(s,
                "George", "Jefferson", "4111111111111111", DateTime.Now.Month, DateTime.Now.Year + 2);
            newAcct.Create();

            newAcct.ClearBillingInfo();

            Assert.IsNull(newAcct.BillingInfo);
            Account t = Account.Get(s);
            Assert.IsNull(t.BillingInfo);

        }

      
    }
}