using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace Recurly.Test
{
    public class CouponTest : BaseTest
    {
        [Fact]
        public void ListCoupons()
        {
            CreateNewCoupon(1);
            CreateNewCoupon(2);

            var coupons = Coupons.List();
            coupons.Should().NotBeEmpty();

        }

        [Fact]
        public void ListCouponsRedeemable()
        {
            var coupon1 = CreateNewCoupon(1);
            coupon1.Deactivate();
            CreateNewCoupon(2);

            var coupons = Coupons.List(Coupon.CouponState.Redeemable);
            coupons.Should().NotBeEmpty();
        }

        [Fact]
        public void ListCouponsExpired()
        {
            // Recurly API doesn't allow for creation of expired coupons
            //var coupon = new Coupon(GetMockCouponCode(), GetMockCouponName(), 10)
            //{
            //    RedeemByDate = DateTime.UtcNow.Subtract(TimeSpan.FromDays(5))
            //};
            //coupon.Create();

            //coupon.CreatedAt.Should().NotBe(default(DateTime));

            var expiredCoupons = Coupons.List(Coupon.CouponState.Expired);
            expiredCoupons.Should().NotBeEmpty();
        }

        [Fact]
        public void ListCouponsMaxedOut()
        {
            // Coupons that get maxed out apparently get state Inactive rather than MaxedOut, making this untestable
            //var coupon = new Coupon(GetMockCouponCode(), GetMockCouponName(), 10) {MaxRedemptions = 1};
            //coupon.Create();

            //var account = CreateNewAccount();
            //account.RedeemCoupon(coupon.CouponCode, "USD");

            //var fromService = Coupons.Get(coupon.CouponCode);
            //fromService.MaxRedemptions.Should().Be(1);
            //fromService.State.Should().Be(Coupon.CouponState.MaxedOut); // Actually is Inactive

            var list = Coupons.List(Coupon.CouponState.MaxedOut); // cannot search for Inactive, service returns Bad Request
            list.Should().NotBeEmpty();
        }

        [Fact]
        public void CreateCouponPercent()
        {
            var coupon = new Coupon(GetMockCouponCode(), GetMockCouponName(), 10);
            coupon.Create();

            coupon.CreatedAt.Should().NotBe(default(DateTime));

            coupon = Coupons.Get(coupon.CouponCode);

            coupon.Should().NotBeNull();
            coupon.DiscountPercent.Should().Be(10);
            coupon.DiscountType.Should().Be(Coupon.CouponDiscountType.Percent);
        }

        [Fact]
        public void CreateCouponDollars()
        {
            var discounts = new Dictionary<string, int> {{"USD", 100}, {"EUR", 50}};
            var coupon = new Coupon(GetMockCouponCode(), GetMockCouponName(), discounts);

            coupon.Create();
            coupon.CreatedAt.Should().NotBe(default(DateTime));

            coupon = Coupons.Get(coupon.CouponCode);

            coupon.Should().NotBeNull();
            coupon.DiscountInCents.Should().Equal(discounts);
            coupon.DiscountType.Should().Be(Coupon.CouponDiscountType.Dollars);
        }

        [Fact]
        public void CreateCouponPlan()
        {
            var plan = new Plan(GetMockPlanCode("coupon plan"), "Coupon Test");
            plan.SetupFeeInCents.Add("USD", 500);
            plan.UnitAmountInCents.Add("USD", 5000);
            plan.Create();

            var coupon = new Coupon(GetMockCouponCode(), GetMockCouponName(), new Dictionary<string, int>());
            coupon.DiscountInCents.Add("USD", 100);
            coupon.Plans.Add(plan.PlanCode);

            Action a = coupon.Create;
            a.ShouldNotThrow();

            plan.Deactivate();
        }

        [Fact]
        public void Coupon_plan_must_exist()
        {
            var coupon = new Coupon(GetMockCouponCode(), GetMockCouponName(), 10);
            coupon.Plans.Add("notrealplan");

            Action create = coupon.Create;
            create.ShouldThrow<ValidationException>();
        }

        [Fact]
        public void DeactivateCoupon()
        {
            var discounts = new Dictionary<string, int> { { "USD", 100 }, { "EUR", 50 } };
            var coupon = new Coupon(GetMockCouponCode(), GetMockCouponName(), discounts);
            coupon.Create();
            coupon.CreatedAt.Should().NotBe(default(DateTime));

            coupon.Deactivate();

            coupon = Coupons.Get(coupon.CouponCode);
            coupon.Should().NotBeNull();
            coupon.State.Should().Be(Coupon.CouponState.Inactive);
        }
    }
}
