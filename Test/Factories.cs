using System;
using System.Collections.Generic;
using System.Text;
using Recurly;

namespace Recurly.Test
{
    /// <summary>
    /// Helper factories for the tests
    /// </summary>
    class Factories
    {
        public static RecurlyAccount NewAccount(string testName)
        {
            RecurlyAccount acct = new RecurlyAccount(DateTime.Now.Millisecond.ToString() + "-acct");
            acct.FirstName = "Verena";
            acct.LastName = "Test";
            acct.CompanyName = testName;
            acct.Email = "verena@test.net";
            return acct;
        }

        public static RecurlyBillingInfo NewBillingInfo(RecurlyAccount account)
        {
            RecurlyBillingInfo billingInfo = new RecurlyBillingInfo(account);
            billingInfo.FirstName = account.FirstName;
            billingInfo.LastName = account.LastName;
            billingInfo.Address1 = "123 Test St";
            billingInfo.City = "San Francsico";
            billingInfo.State = "CA";
            billingInfo.Country = "US";
            billingInfo.PostalCode = "94105";
            billingInfo.CreditCard.ExpirationMonth = DateTime.Now.Month;
            billingInfo.CreditCard.ExpirationYear = DateTime.Now.Year + 1;
            billingInfo.CreditCard.Number = "1";
            billingInfo.CreditCard.VerificationValue = "123";

            return billingInfo;
        }
    }
}
