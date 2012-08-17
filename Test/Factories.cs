using System;
using System.Collections.Generic;
using System.Text;
using Recurly;

namespace Recurly.Test
{
     //<summary>
     //Helper factories for the tests
     //</summary>
    class Factories
    {
        
        public static string GetMockAccountName()
        {
            return "Test Account " + DateTime.Now.ToString("yyyyMMddhhmmFFFFFFF");
        }


        //public static Account NewAccount(string testName)
        //{
        //    Account acct = new Account(DateTime.Now.Millisecond.ToString() + "-acct");
        //    acct.FirstName = "Verena";
        //    acct.LastName = "Test";
        //    acct.CompanyName = testName;
        //    acct.Email = "verena@test.net";
        //    return acct;
        //}

        //public static BillingInfo NewBillingInfo(Account account)
        //{
        //    BillingInfo billingInfo = new BillingInfo(account);
        //    billingInfo.FirstName = account.FirstName;
        //    billingInfo.LastName = account.LastName;
        //    billingInfo.Address1 = "123 Test St";
        //    billingInfo.City = "San Francsico";
        //    billingInfo.State = "CA";
        //    billingInfo.Country = "US";
        //    billingInfo.PostalCode = "94105";
        //    billingInfo.ExpirationMonth = DateTime.Now.Month;
        //    billingInfo.ExpirationYear = DateTime.Now.Year + 1;
        //    billingInfo.CreditCardNumber = "4111-1111-1111-1111";
        //    billingInfo.VerificationValue = "123";

        //    return billingInfo;
        //}
    }
}
