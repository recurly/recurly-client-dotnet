using System;
using System.Collections.Generic;

namespace Recurly.Test
{
    public abstract class BaseTest : IDisposable
    {
        protected const string NullString = null;
        protected const string EmptyString = "";

        protected readonly List<Plan> PlansToDeactivateOnDispose;

        protected BaseTest()
        {
            Client.Instance.ApplySettings(SettingsFixture.TestSettings);
            PlansToDeactivateOnDispose = new List<Plan>();
        }

        protected Account CreateNewAccount()
        {
            var account = new Account(GetUniqueAccountCode());
            account.Create();
            return account;
        }

        protected Account CreateNewAccountWithBillingInfo()
        {
            var account = NewAccountWithBillingInfo();
            account.Create();

            return account;
        }

        protected Account CreateNewAccountWithACHBillingInfo()
        {
            var code = GetUniqueAccountCode();
            var account = new Account(code, NewACHBillingInfo(code));
            account.Create();
            return account;
        }

        protected Account NewAccountWithBillingInfo()
        {
            var code = GetUniqueAccountCode();
            var account = new Account(code, NewBillingInfo(code));
            return account;
        }

        protected BillingInfo NewACHBillingInfo(string accountCode)
        {
            //test account #'s at https://docs.recurly.com/docs/test
            var info = new BillingInfo(accountCode)
            {
                NameOnAccount = "Acme, Inc.",
                RoutingNumber = "123456780",
                //Transaction was cancelled by the bank.
                //An invoice will immediately be open then switch to processing state
                AccountNumber = "111111113",
                AccountType = BillingInfo.BankAccountType.Checking,
                Address1 = "123 Main St.",
                City = "San Francisco",
                State = "CA",
                Country = "US",
                PostalCode = "94105"
            };
            return info;
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

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposing) return;
            if (!PlansToDeactivateOnDispose.HasAny()) return;

            foreach (var plan in PlansToDeactivateOnDispose)
            {
                try
                {
                    plan.Deactivate();
                }
                catch (RecurlyException)
                {
                }
            }
        }
    }
}
