using System;
using System.Collections.Generic;
using System.Text;
using Recurly;
using NUnit.Framework;

namespace Recurly.Test
{
    [TestFixture]
    public class CouponRedemptionTest
    {

        [Test]
        public void RedeemCoupon()
        {
            string s = Factories.GetMockCouponCode();
            Coupon c = new Coupon(s, Factories.GetMockCouponName(), 10);
            c.Create();

            string act = Factories.GetMockAccountName();
            Account acct = new Account(act);
            acct.Create();
            Assert.IsNotNull(acct.CreatedAt);

            CouponRedemption cr = acct.RedeemCoupon(s, "USD");

            Assert.IsNotNull(cr);
            Assert.AreEqual(cr.Currency, "USD");
            Assert.AreEqual(cr.AccountCode, act);
        }

        [Test]
        public void LookupRedemption()
        {
            string s = Factories.GetMockCouponCode();
            Coupon c = new Coupon(s, Factories.GetMockCouponName(), 10);
            c.Create();

            string act = Factories.GetMockAccountName();
            Account acct = new Account(act);
            acct.Create();
            Assert.IsNotNull(acct.CreatedAt);

            CouponRedemption cr = acct.RedeemCoupon(s, "USD");

            Assert.IsNotNull(cr);

            cr = acct.GetActiveCoupon();
            Assert.AreEqual(cr.CouponCode, s);
            Assert.AreEqual(cr.AccountCode, act);
            
        }

        [Test]
        [ExpectedException(typeof(NotFoundException))]
        public void RemoveCoupon()
        {
            string s = Factories.GetMockCouponCode();
            Coupon c = new Coupon(s, Factories.GetMockCouponName(), 10);
            c.Create();

            string act = Factories.GetMockAccountName();
            Account acct = new Account(act);
            acct.Create();
            Assert.IsNotNull(acct.CreatedAt);

            CouponRedemption cr = acct.RedeemCoupon(s, "USD");

            Assert.IsNotNull(cr);

            cr.Delete();

            cr = acct.GetActiveCoupon();
            Assert.IsNull(cr);
        }

        [Test]
        public void LookupCouponInvoice()
        {
            Assert.Fail("not written");
        }

    }
}
