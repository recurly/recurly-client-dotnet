using System;
using System.Collections.Generic;
using System.Text;
using Recurly;
using NUnit.Framework;
using System.Threading;

namespace Recurly.Test
{
    [TestFixture]
    public class CouponTest
    {

        [Test]
        public void ListCoupons()
        {
            string s = BaseTest.GetMockCouponCode();
            Coupon c = new Coupon(s, BaseTest.GetMockCouponName(), 1);
            c.Create();
            s = BaseTest.GetMockCouponCode();
            c = new Coupon(s, BaseTest.GetMockCouponName(), 2);
            c.Create();

            CouponList list = CouponList.List();
            Assert.IsTrue(list.Count > 1);

        }

        [Test]
        public void ListCouponsRedeemable()
        {

            string s = BaseTest.GetMockCouponCode();
            Coupon c = new Coupon(s, BaseTest.GetMockCouponName(), 1);
            c.Create();
            c.Deactivate();
            Thread.Sleep(1000);
            s = BaseTest.GetMockCouponCode();
            c = new Coupon(s, BaseTest.GetMockCouponName(), 2);
            c.Create();

            CouponList list = CouponList.List(Coupon.CouponState.Redeemable);
            Assert.IsTrue(list.Count > 1);

        }

        [Test]
        public void ListCouponsExpired()
        {

            string s = BaseTest.GetMockCouponCode();
            Coupon c = new Coupon(s, BaseTest.GetMockCouponName(), 1);
            c.Create();
            s = BaseTest.GetMockCouponCode();
            c = new Coupon(s, BaseTest.GetMockCouponName(), 2);
            c.Create();

            CouponList list = CouponList.List();
            Assert.IsTrue(list.Count > 1);

        }

        [Test]
        public void ListCouponsMaxedOut()
        {

            string s = BaseTest.GetMockCouponCode();
            Coupon c = new Coupon(s, BaseTest.GetMockCouponName(), 1);
            c.MaxRedemptions = 1;
            c.Create();

            Account t = new Account(BaseTest.GetMockAccountName("Coupon Redemption Max"));
            t.Create();
            t.RedeemCoupon(s, "USD");


            CouponList list = CouponList.List();
            Assert.IsTrue(list.Count > 1);

        }

        [Test]
        public void CreateCouponPercent()
        {
            string s = BaseTest.GetMockCouponCode();
            Coupon c = new Coupon(s, BaseTest.GetMockCouponName(), 10);
            c.Create();

            Assert.IsNotNull(c.CreatedAt);

            c = Coupon.Get(s);
            Assert.IsNotNull(s);
            Assert.AreEqual(c.DiscountPercent.Value, 10);
            Assert.AreEqual(c.DiscountType, Coupon.CouponDiscountType.Percent);

        }

        [Test]
        public void CreateCouponDollars()
        {
            string s = BaseTest.GetMockCouponCode();
            Coupon c = new Coupon(s, BaseTest.GetMockCouponName(), new Dictionary<string,int>());
            c.DiscountInCents.Add("USD", 100);
            c.DiscountInCents.Add("EUR", 50);

            c.Create();

            Assert.IsNotNull(c.CreatedAt);

            c = Coupon.Get(s);
            Assert.IsNotNull(s);
            Assert.AreEqual(c.DiscountInCents["USD"], 100);
            Assert.AreEqual(c.DiscountInCents["EUR"], 50);
            Assert.AreEqual(c.DiscountType, Coupon.CouponDiscountType.Dollars);

        }

        [Test]
        public void CreateCouponPlan()
        {
            Plan p = new Plan(BaseTest.GetMockPlanCode("coupon plan"), "Coupon Test");
            p.SetupFeeInCents.Add("USD", 500);
            p.UnitAmountInCents.Add("USD", 5000);
            p.Create();


            string s = BaseTest.GetMockCouponCode();
            Coupon c = new Coupon(s, BaseTest.GetMockCouponName(), new Dictionary<string, int>());
            c.DiscountInCents.Add("USD", 100);
            c.Plans.Add(p.PlanCode);

            p.Deactivate();
        }

        [Test]
        public void DeactivateCoupon()
        {
            string s = BaseTest.GetMockCouponCode();
            Coupon c = new Coupon(s, BaseTest.GetMockCouponName(), new Dictionary<string, int>());
            c.DiscountInCents.Add("USD", 100);
            c.DiscountInCents.Add("EUR", 50);

            c.Create();

            Assert.IsNotNull(c.CreatedAt);

            c.Deactivate();

            c = Coupon.Get(s);
            Assert.IsNotNull(s);
            Assert.AreEqual(c.State, Coupon.CouponState.Inactive);

        }


    }
}
