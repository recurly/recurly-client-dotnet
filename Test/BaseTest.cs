using System;

namespace Recurly.Test
{
    public abstract class BaseTest
    {
        protected const string NullString = null;
        protected const string EmptyString = "";

        protected BaseTest()
        {
            Client.Instance.ApplySettings(SettingsFixture.TestSettings);
        }

        protected Account CreateNewAccount()
        {
            var account = new Account(GetUniqueAccountCode());
            account.Create();
            return account;
        }

        protected Account CreateNewAccountWithBillingInfo()
        {
            var code = GetUniqueAccountCode();
            var account = new Account(code, NewBillingInfo(code));
            account.Create();

            return account;
        }

        protected Coupon CreateNewCoupon(int discountPercent)
        {
            var coupon = new Coupon(GetMockCouponCode(), GetMockCouponName(), discountPercent);
            coupon.Create();
            return coupon;
        }

        public string GetUniqueAccountCode()
        {
            return Guid.NewGuid().ToString();
        }

        public string GetMockAccountName(string name = "Test Account")
        {
            return name + " " + DateTime.Now.ToString("yyyyMMddhhmmFFFFFFF");
        }

        public string GetMockCouponCode(string name = "cc")
        {
            return name + DateTime.Now.ToString("yyyyMMddhhmmFFFFFFF");
        }

        public string GetMockCouponName(string name = "Test Coupon")
        {
            return name + " " + DateTime.Now.ToString("yyyyMMddhhmmFFFFFFF");
        }

        public string GetMockPlanCode(string name = "pc")
        {
            return name.Replace(" ", "") + DateTime.Now.ToString("yyyyMMddhhmmFFFFFFF");
        }

        public string GetMockPlanName(string name = "Test Plan")
        {
            return name + " " + DateTime.Now.ToString("yyyyMMddhhmmFFFFFFF");
        }

        public BillingInfo NewBillingInfo(Account account)
        {
            var billingInfo = new BillingInfo(account)
            {
                FirstName = account.FirstName,
                LastName = account.LastName,
                Address1 = "123 Test St",
                City = "San Francisco",
                State = "CA",
                Country = "US",
                PostalCode = "94105",
                ExpirationMonth = DateTime.Now.Month,
                ExpirationYear = DateTime.Now.Year + 1,
                CreditCardNumber = TestCreditCardNumbers.Visa1,
                VerificationValue = "123"
            };
            return billingInfo;
        }

        public BillingInfo NewBillingInfo(string accountCode)
        {
            return new BillingInfo(accountCode)
            {
                FirstName = "John",
                LastName = "Smith",
                Address1 = "123 Test St",
                City = "San Francisco",
                State = "CA",
                Country = "US",
                PostalCode = "94105",
                ExpirationMonth = DateTime.Now.Month,
                ExpirationYear = DateTime.Now.Year + 1,
                CreditCardNumber = TestCreditCardNumbers.Visa1,
                VerificationValue = "123"
            };
        }
    }
}
