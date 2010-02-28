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
            acct.Create();

            RecurlyBillingInfo billingInfo = Factories.NewBillingInfo(acct);
            billingInfo.Update();
        }

        [Test]
        public void LookupBillingInfo()
        {
            RecurlyAccount newAcct = Factories.NewAccount("Lookup Billing Info");
            newAcct.Create();

            RecurlyBillingInfo billingInfo = Factories.NewBillingInfo(newAcct);
            billingInfo.Update();

            RecurlyBillingInfo lookupBilling = RecurlyBillingInfo.Get(newAcct.AccountCode);
            Assert.AreEqual(billingInfo.Address1, lookupBilling.Address1);
            Assert.AreEqual(billingInfo.PostalCode, lookupBilling.PostalCode);
            Assert.IsNotNullOrEmpty(billingInfo.CreditCard.CreditCardType);
        }

        [Test]
        public void LookupMissingInfo()
        {
            RecurlyAccount newAcct = Factories.NewAccount("Lookup Missing Billing Info");
            newAcct.Create();

            RecurlyBillingInfo billingInfo = RecurlyBillingInfo.Get(newAcct.AccountCode);
            Assert.IsNull(billingInfo);
        }

        [Test]
        public void ClearBillingInfo()
        {
            RecurlyAccount newAcct = Factories.NewAccount("Clear Billing Info");
            newAcct.Create();

            RecurlyBillingInfo billingInfo = Factories.NewBillingInfo(newAcct);
            billingInfo.Update();

            billingInfo.ClearBillingInfo();
        }

        [Test]
        public void CloseAccount()
        {
            RecurlyAccount acct = Factories.NewAccount("Close Account");
            acct.CloseAccount();
        }
    }
}