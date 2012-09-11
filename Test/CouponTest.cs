using System;
using System.Collections.Generic;
using System.Text;
using Recurly;
using NUnit.Framework;

namespace Recurly.Test
{
    [TestFixture]
    public class CouponTest
    {

        [Test]
        public void ListCoupons()
        {
            string s = Factories.GetMockCouponCode();
            Coupon c = new Coupon(s, Factories.GetMockCouponName(), 1);
            c.Create();
            s = Factories.GetMockCouponCode();
            c = new Coupon(s, Factories.GetMockCouponName(), 2);
            c.Create();

            CouponList list = CouponList.List();
            Assert.IsTrue(list.Count > 1);

        }

        [Test]
        public void ListCouponsRedeemable()
        {
            Assert.Fail("Not tested yet");

            string s = Factories.GetMockCouponCode();
            Coupon c = new Coupon(s, Factories.GetMockCouponName(), 1);
            c.Create();
            s = Factories.GetMockCouponCode();
            c = new Coupon(s, Factories.GetMockCouponName(), 2);
            c.Create();

            CouponList list = CouponList.List();
            Assert.IsTrue(list.Count > 1);

        }

        [Test]
        public void ListCouponsExpired()
        {
            Assert.Fail("Not tested yet");

            string s = Factories.GetMockCouponCode();
            Coupon c = new Coupon(s, Factories.GetMockCouponName(), 1);
            c.Create();
            s = Factories.GetMockCouponCode();
            c = new Coupon(s, Factories.GetMockCouponName(), 2);
            c.Create();

            CouponList list = CouponList.List();
            Assert.IsTrue(list.Count > 1);

        }

        [Test]
        public void ListCouponsMaxedOut()
        {
            Assert.Fail("Not tested yet");

            string s = Factories.GetMockCouponCode();
            Coupon c = new Coupon(s, Factories.GetMockCouponName(), 1);
            c.Create();
            s = Factories.GetMockCouponCode();
            c = new Coupon(s, Factories.GetMockCouponName(), 2);
            c.Create();

            CouponList list = CouponList.List();
            Assert.IsTrue(list.Count > 1);

        }

        [Test]
        public void CreateCouponPercent()
        {
            string s = Factories.GetMockCouponCode();
            Coupon c = new Coupon(s, Factories.GetMockCouponName(), 10);
            c.Create();

            Assert.IsNotNull(c.CreatedAt);

            c = Coupon.Get(s);
            Assert.IsNotNull(s);
            Assert.AreEqual(c.DiscountPercent.Value, 10);
            Assert.AreEqual(c.DiscountType, Coupon.CouponDiscountType.percent);

        }

        [Test]
        public void CreateCouponDollars()
        {
            string s = Factories.GetMockCouponCode();
            Coupon c = new Coupon(s, Factories.GetMockCouponName(), new Dictionary<string,int>());
            c.DiscountInCents.Add("USD", 100);
            c.DiscountInCents.Add("EUR", 50);

            c.Create();

            Assert.IsNotNull(c.CreatedAt);

            c = Coupon.Get(s);
            Assert.IsNotNull(s);
            Assert.AreEqual(c.DiscountInCents["USD"], 100);
            Assert.AreEqual(c.DiscountInCents["EUR"], 50);
            Assert.AreEqual(c.DiscountType, Coupon.CouponDiscountType.dollars);

        }

        [Test]
        public void CreateCouponPlan()
        {
            Assert.Fail("not written");
        }

        [Test]
        public void DeactivateCoupon()
        {
            string s = Factories.GetMockCouponCode();
            Coupon c = new Coupon(s, Factories.GetMockCouponName(), new Dictionary<string, int>());
            c.DiscountInCents.Add("USD", 100);
            c.DiscountInCents.Add("EUR", 50);

            c.Create();

            Assert.IsNotNull(c.CreatedAt);

            c.Deactivate();


            c = Coupon.Get(s);
            Assert.IsNotNull(s);
            Assert.AreEqual(c.State, Coupon.CouponState.inactive);

        }


    }
}
