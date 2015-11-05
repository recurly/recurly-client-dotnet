using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace Recurly.Test
{
    public class CouponRedemptionTest : BaseTest
    {
        [RecurlyFact(TestEnvironment.Type.Integration)]
        public void RedeemCoupon()
        {
            var coupon = new Coupon(GetMockCouponCode(), GetMockCouponName(), 10);
            coupon.Create();

            var account = CreateNewAccount();
            account.CreatedAt.Should().NotBe(default(DateTime));

            var redemption = account.RedeemCoupon(coupon.CouponCode, "USD");

            redemption.Should().NotBeNull();
            redemption.Currency.Should().Be("USD");
            redemption.AccountCode.Should().Be(account.AccountCode);
            redemption.CreatedAt.Should().NotBe(default(DateTime));
        }

        [RecurlyFact(TestEnvironment.Type.Integration)]
        public void LookupRedemption()
        {
            var coupon = new Coupon(GetMockCouponCode(), GetMockCouponName(), 10);
            coupon.Create();

            var account = CreateNewAccount();
            account.CreatedAt.Should().NotBe(default(DateTime));

            var redemption = account.RedeemCoupon(coupon.CouponCode, "USD");
            redemption.Should().NotBeNull();

            redemption = account.GetActiveRedemption();
            redemption.CouponCode.Should().Be(coupon.CouponCode);
            redemption.AccountCode.Should().Be(account.AccountCode);
            redemption.CreatedAt.Should().NotBe(default(DateTime));

        }

        [RecurlyFact(TestEnvironment.Type.Integration)]
        public void RemoveCoupon()
        {
            var coupon = new Coupon(GetMockCouponCode(), GetMockCouponName(), 10);
            coupon.Create();

            var account = CreateNewAccount();
            account.CreatedAt.Should().NotBe(default(DateTime));

            var redemption = account.RedeemCoupon(coupon.CouponCode, "USD");
            redemption.Should().NotBeNull();

            redemption.Delete();

            var activeRedemption = account.GetActiveRedemption();
            activeRedemption.Should().Be(null);
        }

        [RecurlyFact(TestEnvironment.Type.Integration)]
        public void LookupCouponInvoice()
        {
            var discounts = new Dictionary<string, int> { { "USD", 1000 } };
            var coupon = new Coupon(GetMockCouponCode(), GetMockCouponName(), discounts);
            coupon.Create();

            var plan = new Plan(GetMockPlanCode(), GetMockPlanCode())
            {
                Description = "Test Lookup Coupon Invoice"
            };
            plan.UnitAmountInCents.Add("USD", 1500);
            plan.Create();
            PlansToDeactivateOnDispose.Add(plan);

            var account = CreateNewAccountWithBillingInfo();

            var redemption = account.RedeemCoupon(coupon.CouponCode, "USD");

            var sub = new Subscription(account, plan, "USD", coupon.CouponCode);
            sub.Create();

            // TODO complete this test

            var invoices = account.GetInvoices();

            invoices.Should().NotBeEmpty();

            var invoice = Invoices.Get(invoices.First().InvoiceNumber);
            var fromInvoice = invoice.GetRedemption();

            redemption.Should().Be(fromInvoice);
        }

    }
}
