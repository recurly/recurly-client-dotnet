using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace Recurly.Test
{
    public class CouponRedemptionTest : BaseTest
    {
        [Fact]
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

        [Fact]
        public void LookupRedemption()
        {
            var coupon = new Coupon(GetMockCouponCode(), GetMockCouponName(), 10);
            coupon.Create();

            var account = CreateNewAccount();
            account.CreatedAt.Should().NotBe(default(DateTime));

            var redemption = account.RedeemCoupon(coupon.CouponCode, "USD");
            redemption.Should().NotBeNull();

            redemption = account.GetActiveCoupon();
            redemption.CouponCode.Should().Be(coupon.CouponCode);
            redemption.AccountCode.Should().Be(account.AccountCode);
            redemption.CreatedAt.Should().NotBe(default(DateTime));

        }

        [Fact]
        public void RemoveCoupon()
        {
            var coupon = new Coupon(GetMockCouponCode(), GetMockCouponName(), 10);
            coupon.Create();

            var account = CreateNewAccount();
            account.CreatedAt.Should().NotBe(default(DateTime));

            var redemption = account.RedeemCoupon(coupon.CouponCode, "USD");
            redemption.Should().NotBeNull();
            
            redemption.Delete();

            Action getCoupon = () => account.GetActiveCoupon();
            getCoupon.ShouldThrow<NotFoundException>();
        }

        [Fact]
        public void LookupCouponInvoice()
        {
            var discounts = new Dictionary<string,int> {{"USD", 1000}};
            var coupon = new Coupon(GetMockCouponCode(), GetMockCouponName(), discounts);
            coupon.Create();

            var account = CreateNewAccountWithBillingInfo();

            var redemption = account.RedeemCoupon(coupon.CouponCode, "USD");

            var transaction = new Transaction(account, 5000, "USD");
            transaction.Create();

            transaction.Invoice.Should().HaveValue();
            var invoice = Invoices.Get(transaction.Invoice.Value);
            var fromInvoice = invoice.GetCoupon();

            redemption.Should().Be(fromInvoice);
        }

    }
}
