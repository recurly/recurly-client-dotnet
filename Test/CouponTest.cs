using System.Collections.Generic;
using NUnit.Framework;
using System.Threading;

namespace Recurly.Test
{
    [TestFixture]
    public class CouponTest : BaseTest
    {

        [Test]
        public void ListCoupons()
        {
            string s = GetMockCouponCode();
            Coupon c = new Coupon(s, GetMockCouponName(), 1);
            c.Create();
            s = GetMockCouponCode();
            c = new Coupon(s, GetMockCouponName(), 2);
            c.Create();

            CouponList list = CouponList.List();
            Assert.IsTrue(list.Count > 1);

        }

        [Test]
        public void ListCouponsRedeemable()
        {

            string s = GetMockCouponCode();
            Coupon c = new Coupon(s, GetMockCouponName(), 1);
            c.Create();
            c.Deactivate();
            Thread.Sleep(1000);
            s = GetMockCouponCode();
            c = new Coupon(s, GetMockCouponName(), 2);
            c.Create();

            CouponList list = CouponList.List(Coupon.CouponState.Redeemable);
            Assert.IsTrue(list.Count > 1);

        }

        [Test]
        public void ListCouponsExpired()
        {

            string s = GetMockCouponCode();
            Coupon c = new Coupon(s, GetMockCouponName(), 1);
            c.Create();
            s = GetMockCouponCode();
            c = new Coupon(s, GetMockCouponName(), 2);
            c.Create();

            CouponList list = CouponList.List();
            Assert.IsTrue(list.Count > 1);

        }

        [Test]
        public void ListCouponsMaxedOut()
        {

            string s = GetMockCouponCode();
            Coupon c = new Coupon(s, GetMockCouponName(), 1);
            c.MaxRedemptions = 1;
            c.Create();

            Account t = new Account(GetMockAccountName("Coupon Redemption Max"));
            t.Create();
            t.RedeemCoupon(s, "USD");


            CouponList list = CouponList.List();
            Assert.IsTrue(list.Count > 1);

        }

        [Test]
        public void CreateCouponPercent()
        {
            string s = GetMockCouponCode();
            Coupon c = new Coupon(s, GetMockCouponName(), 10);
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
            string s = GetMockCouponCode();
            Coupon c = new Coupon(s, GetMockCouponName(), new Dictionary<string,int>());
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
            Plan p = new Plan(GetMockPlanCode("coupon plan"), "Coupon Test");
            p.SetupFeeInCents.Add("USD", 500);
            p.UnitAmountInCents.Add("USD", 5000);
            p.Create();


            string s = GetMockCouponCode();
            Coupon c = new Coupon(s, GetMockCouponName(), new Dictionary<string, int>());
            c.DiscountInCents.Add("USD", 100);
            c.Plans.Add(p.PlanCode);

            p.Deactivate();
        }

        [Test]
        public void DeactivateCoupon()
        {
            string s = GetMockCouponCode();
            Coupon c = new Coupon(s, GetMockCouponName(), new Dictionary<string, int>());
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
