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
            acct.Create("instance1");

            RecurlyBillingInfo billingInfo = Factories.NewBillingInfo(acct);
            billingInfo.Update("instance1");
        }

        [Test]
        public void LookupBillingInfo()
        {
            RecurlyAccount newAcct = Factories.NewAccount("Lookup Billing Info");
            newAcct.Create("instance1");

            RecurlyBillingInfo billingInfo = Factories.NewBillingInfo(newAcct);
            billingInfo.Create("instance1");

            RecurlyBillingInfo lookupBilling = RecurlyBillingInfo.Get("instance1", newAcct.AccountCode);
            Assert.AreEqual(billingInfo.Address1, lookupBilling.Address1);
            Assert.AreEqual(billingInfo.PostalCode, lookupBilling.PostalCode);
            Assert.IsNotNullOrEmpty(billingInfo.CreditCard.Number);
        }

        [Test]
        [ExpectedException(typeof(NotFoundException))]
        public void LookupMissingInfo()
        {
            RecurlyAccount newAcct = Factories.NewAccount("Lookup Missing Billing Info");
            newAcct.Create("instance1");

            RecurlyBillingInfo billingInfo = RecurlyBillingInfo.Get("instance1", newAcct.AccountCode);
        }

        [Test]
        public void ClearBillingInfo()
        {
            RecurlyAccount newAcct = Factories.NewAccount("Clear Billing Info");
            newAcct.Create("instance1");

            RecurlyBillingInfo billingInfo = Factories.NewBillingInfo(newAcct);
            billingInfo.Update("instance1");

            billingInfo.ClearBillingInfo("instance1");
        }

        [Test]
        public void CloseAccount()
        {
            RecurlyAccount acct = Factories.NewAccount("Close Account");
            acct.Create("instance1");
            acct.CloseAccount("instance1");
        }
    }
}