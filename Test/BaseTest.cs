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

        protected Account CreateNewAccountWithOverrideBusinessEntity()
        {
            var businessEntities = BusinessEntities.List();
            var account = new Account(GetUniqueAccountCode());
            account.OverrideBusinessEntityId = businessEntities[0].Id;
            account.Create();
            return account;
        }

        protected Account CreateNewAccountWithWallet()
        {
            var account = new Account(GetUniqueAccountCode());
            account.FirstName = "Winter";
            account.LastName = "Melon";
            account.Create();

            var binfo0 = NewBillingInfo(account);
            binfo0.Create();

            var binfo1 = new BillingInfo();
            binfo1.FirstName = "Pineapple";
            binfo1.LastName = "Berete";
            binfo1.Address1 = "123 Main St";
            binfo1.City = "New Orleans";
            binfo1.State = "LA";
            binfo1.Country = "US";
            binfo1.PostalCode = "70212";
            binfo1.CreditCardNumber = "4111111111111111";
            binfo1.ExpirationMonth = 02;
            binfo1.ExpirationYear = DateTime.Now.Year + 1;
            binfo1.VerificationValue = "123";
            binfo1.PrimaryPaymentMethod = false;
            binfo1.BackupPaymentMethod = true;
            account.CreateBillingInfo(binfo1);

            var binfo2 = new BillingInfo();
            binfo2.FirstName = "Papaya";
            binfo2.LastName = "Berete";
            binfo2.Address1 = "123 Main St";
            binfo2.City = "New Orleans";
            binfo2.State = "LA";
            binfo2.Country = "US";
            binfo2.PostalCode = "70212";
            binfo2.CreditCardNumber = "4111111111111111";
            binfo2.ExpirationMonth = 06;
            binfo2.ExpirationYear = DateTime.Now.Year + 1;
            binfo2.VerificationValue = "456";
            binfo2.PrimaryPaymentMethod = true;
            binfo2.BackupPaymentMethod = false;
            account.CreateBillingInfo(binfo2);

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

        protected InvoiceCollection CreateNewCollection()
        {
            var account = CreateNewAccountWithBillingInfo();
            var currency = "USD";
            var plan = new Plan(GetMockPlanCode(), GetMockPlanName()) { Description = "Plan for Purchase Test" };
            plan.UnitAmountInCents.Add("USD", 580);
            plan.Create();

            var purchase = new Purchase(account.AccountCode, currency);

            var sub = new Subscription(plan.PlanCode);
            purchase.Subscriptions.Add(sub);
            var collection = Purchase.Authorize(purchase);
            return collection;
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

        public string GetMockItemCode(string name = "ic")
        {
            return name.Replace(" ", "") + DateTime.Now.ToString("yyyyMMddhhmmFFFFFFF");
        }

        public string GetMockItemName(string name = "Test Item")
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

        public List<PlanRampInterval> GetMockPlanRampIntervals(int numberOfRamps)
        {
            var rampIntervals = new List<PlanRampInterval>();

            for (int i = 0; i < numberOfRamps; i++)
            {
                var rampInterval = new PlanRampInterval()
                {
                    StartingBillingCycle = (i == 0) ? 1 : i + 2,
                    Currencies = new List<PlanRampPricing>
                    {
                        new PlanRampPricing()
                        {
                            Currency = "USD",
                            UnitAmountInCents = (numberOfRamps * 100) * (i + 1)
                        }
                    }
                };
                rampIntervals.Add(rampInterval);
            }

            return rampIntervals;
        }

        public List<PlanRampInterval> GetMockPlanRampIntervalsMultiCurrency(int numberOfRamps)
        {
            var rampIntervals = new List<PlanRampInterval>();

            for (int i = 0; i < numberOfRamps; i++)
            {
                var currencies = new List<PlanRampPricing>();
                var currency1 = new PlanRampPricing()
                {
                    Currency = "USD",
                    UnitAmountInCents = (numberOfRamps * 100) * (i + 1)
                };

                currencies.Add(currency1);

                var currency2 = new PlanRampPricing()
                {
                    Currency = "EUR",
                    UnitAmountInCents = (numberOfRamps * 200) * (i + 1)
                };

                currencies.Add(currency2);

                var rampInterval = new PlanRampInterval()
                {
                    StartingBillingCycle = (i == 0) ? 1 : i + 2,
                    Currencies = currencies
                };
                rampIntervals.Add(rampInterval);
            }

            return rampIntervals;
        }

        public List<SubscriptionRampInterval> GetMockSubscriptionRampIntervals(int numberOfRamps)
        {
            var rampIntervals = new List<SubscriptionRampInterval>();

            for (int i = 0; i < numberOfRamps; i++)
            {
                var rampInterval = new SubscriptionRampInterval()
                {
                    StartingBillingCycle = (i == 0) ? 1 : i + 2,
                    UnitAmountInCents = (numberOfRamps * 100) * (i + 1)
                };
                rampIntervals.Add(rampInterval);
            }

            return rampIntervals;
        }

        public Subscription CreateNewRampSubscription(int numberOfRamps)
        {
            var plan = new Plan(GetMockPlanCode(), GetMockPlanName()) { Description = "Create Ramp Subscription" };
            plan.SetupFeeInCents.Add("USD", 0);
            plan.PricingModel = PricingModelType.Ramp;
            plan.RampIntervals = GetMockPlanRampIntervals(numberOfRamps);
            plan.Create();
            PlansToDeactivateOnDispose.Add(plan);

            var account = CreateNewAccountWithBillingInfo();

            var sub = new Subscription(account, plan, "USD");
            sub.Create();

            return Subscriptions.Get(sub.Uuid);
        }

        public Plan CreateNewRampPlan(int numberOfRamps)
        {
            var plan = new Plan(GetMockPlanCode(), GetMockPlanName()) { Description = "Create Ramp Plan" };
            plan.TaxExempt = true;
            plan.SetupFeeInCents.Add("USD", 0);
            plan.PricingModel = PricingModelType.Ramp;
            plan.RampIntervals = GetMockPlanRampIntervals(numberOfRamps);
            plan.Create();
            return Plans.Get(plan.PlanCode);
        }

        public string GetMockMeasuredUnitName(string name = "Test Measured Unit")
        {
            return name + " " + DateTime.Now.ToString("yyyyMMddhhmmFFFFFFF");
        }

        public BillingInfo NewBillingInfo(Account account)
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

        public BillingInfo NewBillingInfo(string accountCode)
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
