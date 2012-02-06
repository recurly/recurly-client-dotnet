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
            RecurlyAccount acct = Factories.NewAccount("Update Billing Info");
            acct.Create("haro-test");

            RecurlyBillingInfo billingInfo = Factories.NewBillingInfo(acct);
            billingInfo.Update("haro-test");
        }

        [Test]
        public void LookupBillingInfo()
        {
            RecurlyAccount newAcct = Factories.NewAccount("Lookup Billing Info");
            newAcct.Create("haro-test");

            RecurlyBillingInfo billingInfo = Factories.NewBillingInfo(newAcct);
            billingInfo.Create("haro-test");

            RecurlyBillingInfo lookupBilling = RecurlyBillingInfo.Get("haro-test", newAcct.AccountCode);
            Assert.AreEqual(billingInfo.Address1, lookupBilling.Address1);
            Assert.AreEqual(billingInfo.PostalCode, lookupBilling.PostalCode);
            Assert.IsNotNullOrEmpty(billingInfo.CreditCard.Number);
        }

        [Test]
        [ExpectedException(typeof(NotFoundException))]
        public void LookupMissingInfo()
        {
            RecurlyAccount newAcct = Factories.NewAccount("Lookup Missing Billing Info");
            newAcct.Create("haro-test");

            RecurlyBillingInfo billingInfo = RecurlyBillingInfo.Get("haro-test", newAcct.AccountCode);

            Assert.IsNull(billingInfo);
        }

        [Test]
        public void ClearBillingInfo()
        {
            RecurlyAccount newAcct = Factories.NewAccount("Clear Billing Info");
            newAcct.Create("haro-test");

            RecurlyBillingInfo billingInfo = Factories.NewBillingInfo(newAcct);
            billingInfo.Update("haro-test");

            billingInfo.ClearBillingInfo("haro-test");
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