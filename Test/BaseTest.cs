using System;

namespace Recurly.Test
{
    public abstract class BaseTest
    {
        protected const string NullString = null;
        protected const string EmptyString = "";

        //internal readonly TestClient ClientInstance;
        protected BaseTest()
        {
            //ClientInstance = new TestClient(SettingsFixture.TestSettings);
            //Client.ChangeInstance(ClientInstance);

            Client.Instance.ApplySettings(SettingsFixture.TestSettings);
        }

        protected Account CreateNewAccount()
        {
            var account = new Account(GetUniqueAccountCode());
            account.Create();
            return account;
        }

        public static string GetUniqueAccountCode()
        {
            return Guid.NewGuid().ToString();
        }

        public static string GetMockAccountName(string name = "Test Account")
        {
            return name + " " + DateTime.Now.ToString("yyyyMMddhhmmFFFFFFF");
        }

        public static string GetMockCouponCode(string name = "cc")
        {
            return name + DateTime.Now.ToString("yyyyMMddhhmmFFFFFFF");
        }

        public static string GetMockCouponName(string name = "Test Coupon")
        {
            return name + " " + DateTime.Now.ToString("yyyyMMddhhmmFFFFFFF");
        }

        public static string GetMockPlanCode(string name = "pc")
        {
            return name.Replace(" ", "") + DateTime.Now.ToString("yyyyMMddhhmmFFFFFFF");
        }

        public static string GetMockPlanName(string name = "Test Plan")
        {
            return name + " " + DateTime.Now.ToString("yyyyMMddhhmmFFFFFFF");
        }

        public static BillingInfo NewBillingInfo(Account account)
        {
            BillingInfo billingInfo = new BillingInfo(account);
            billingInfo.FirstName = account.FirstName;
            billingInfo.LastName = account.LastName;
            billingInfo.Address1 = "123 Test St";
            billingInfo.City = "San Francsico";
            billingInfo.State = "CA";
            billingInfo.Country = "US";
            billingInfo.PostalCode = "94105";
            billingInfo.ExpirationMonth = DateTime.Now.Month;
            billingInfo.ExpirationYear = DateTime.Now.Year + 1;
            billingInfo.CreditCardNumber = "4111-1111-1111-1111";
            billingInfo.VerificationValue = "123";

            return billingInfo;
        }
    }
}
