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
            Account acct = Factories.NewAccount("Update Billing Info");
            acct.Create();

            BillingInfo billingInfo = Factories.NewBillingInfo(acct);
            billingInfo.Update();
        }

        [Test]
        public void LookupBillingInfo()
        {
            Account newAcct = Factories.NewAccount("Lookup Billing Info");
            newAcct.Create();

            BillingInfo billingInfo = Factories.NewBillingInfo(newAcct);
            billingInfo.Update();

            BillingInfo lookupBilling = BillingInfo.Get(newAcct.AccountCode);
            Assert.AreEqual(billingInfo.Address1, lookupBilling.Address1);
            Assert.AreEqual(billingInfo.PostalCode, lookupBilling.PostalCode);
        }

        [Test]
        public void LookupMissingInfo()
        {
            Account newAcct = Factories.NewAccount("Lookup Missing Billing Info");
            newAcct.Create();

            Assert.Throws(typeof(NotFoundException), delegate
            {
                BillingInfo.Get(newAcct.AccountCode);
            });
        }

        [Test]
        public void ClearBillingInfo()
        {
            Account newAcct = Factories.NewAccount("Clear Billing Info");
            newAcct.Create();

            BillingInfo billingInfo = Factories.NewBillingInfo(newAcct);
            billingInfo.Update();

            billingInfo.ClearBillingInfo();
        }

        [Test]
        public void CloseAccount()
        {
            Account acct = Factories.NewAccount("Close Account");
            acct.Create();
            acct.Close();

            // check state
        }
    }
}