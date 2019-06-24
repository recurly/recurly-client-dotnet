using System;
using System.Collections.Generic;

namespace Recurly.Test
{
    public abstract class BaseTest : IDisposable
    {
        protected const string NullString = null;
        protected const string EmptyString = "";

        protected readonly List<IPlan> PlansToDeactivateOnDispose;

        protected BaseTest()
        {
            Client.Instance.ApplySettings(SettingsFixture.TestSettings);
            PlansToDeactivateOnDispose = new List<IPlan>();
        }

        protected IAccount CreateNewAccount()
        {
            var account = new Account(GetUniqueAccountCode());
            account.Create();
            return account;
        }

        protected IAccount CreateNewAccountWithBillingInfo()
        {
            var account = NewAccountWithBillingInfo();
            account.Create();

            return account;
        }

        protected IAccount CreateNewAccountWithACHBillingInfo()
        {
            var code = GetUniqueAccountCode();
            var account = new Account(code, NewACHBillingInfo(code));
            account.Create();
            return account;
        }

        protected IAccount NewAccountWithBillingInfo()
        {
            var code = GetUniqueAccountCode();
            var account = new Account(code, NewBillingInfo(code));
            return account;
        }

        protected IBillingInfo NewACHBillingInfo(string accountCode)
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

        protected ICoupon CreateNewCoupon(int discountPercent)
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

        public IBillingInfo NewBillingInfo(IAccount account)
        {
            var billingInfo = new BillingInfo(account)
            {
                FirstName = account.FirstName,
                LastName = account.LastName,
                Company = "Acme Software",
                PhoneNumber = "916-555-0101",
                VatNumber = "12345",
                Address1 = "123 Test St",
                Address2 = "The Test Cut",
                City = "San Francisco",
                PostalCode = "94105",
                State = "CA",
                Country = "US",
                Currency = "USD",   // Should really be a different currency for testing but test environment doesn't seem set up for multi-currency
                IpAddress = "93.184.216.34",    // Address currently hosting example.com domain
                CreditCardNumber = TestCreditCardNumbers.Visa1,
                VerificationValue = "123",
                ExpirationMonth = DateTime.Now.Month,
                ExpirationYear = DateTime.Now.Year + 1
            };
            return billingInfo;
        }

        public IBillingInfo NewBillingInfo(string accountCode)
        {
            return new BillingInfo(accountCode)
            {
                FirstName = "John",
                LastName = "Smith",
                Company = "Acme Software",
                PhoneNumber = "916-555-0101",
                VatNumber = "12345",
                Address1 = "123 Test St",
                Address2 = "The Test Cut",
                City = "San Francisco",
                PostalCode = "94105",
                State = "CA",
                Country = "US",
                Currency = "USD",   // Should really be a different currency for testing but test environment doesn't seem set up for multi-currency
                IpAddress = "93.184.216.34",    // Address currently hosting example.com domain
                CreditCardNumber = TestCreditCardNumbers.Visa1,
                VerificationValue = "123",
                ExpirationMonth = DateTime.Now.Month,
                ExpirationYear = DateTime.Now.Year + 1
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
