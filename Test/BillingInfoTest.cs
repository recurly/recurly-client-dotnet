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
            Account acct = new Account("Update Billing Info");
            acct.Create();

            BillingInfo billingInfo = new BillingInfo(acct);
            billingInfo.Update();
        }

        [Test]
        public void LookupBillingInfo()
        {
            Account newAcct = new Account("Lookup Billing Info");
            newAcct.Create();

            BillingInfo billingInfo = new BillingInfo(newAcct);
            billingInfo.Update();

            BillingInfo lookupBilling = BillingInfo.Get(newAcct.AccountCode);
            Assert.AreEqual(billingInfo.Address1, lookupBilling.Address1);
            Assert.AreEqual(billingInfo.PostalCode, lookupBilling.PostalCode);
        }

        [Test]
        public void LookupMissingInfo()
        {
            Account newAcct = new Account("Lookup Missing Billing Info");
            newAcct.Create();

            Assert.Throws(typeof(NotFoundException), delegate
            {
                BillingInfo.Get(newAcct.AccountCode);
            });
        }

        [Test]
        public void ClearBillingInfo()
        {
            Account newAcct = new Account("Clear Billing Info");
            newAcct.Create();

            BillingInfo billingInfo = new BillingInfo(newAcct);
            billingInfo.Update();

            billingInfo.Delete();
        }

        [Test]
        public void CloseAccount()
        {
            Account acct = new Account("Close Account");
            acct.Create();
            acct.Close();

            // check state
        }
    }
}