using System;
using System.Collections.Generic;
using NUnit.Framework;
using System.Threading;

namespace Recurly.Test
{
    [TestFixture]
    public class CouponRedemptionTest : BaseTest
    {

        [Test]
        public void RedeemCoupon()
        {
            string s = GetMockCouponCode();
            Coupon c = new Coupon(s, GetMockCouponName(), 10);
            c.Create();

            string act = GetMockAccountName();
            Account acct = new Account(act);
            acct.Create();
            Assert.IsNotNull(acct.CreatedAt);

            CouponRedemption cr = acct.RedeemCoupon(s, "USD");
            Thread.Sleep(2000);
            Assert.IsNotNull(cr);
            Assert.AreEqual(cr.Currency, "USD");
            Assert.AreEqual(cr.AccountCode, act);
        }

        [Test]
        public void LookupRedemption()
        {
            string s = GetMockCouponCode();
            Coupon c = new Coupon(s, GetMockCouponName(), 10);
            c.Create();

            string act = GetMockAccountName();
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
            string s = GetMockCouponCode();
            Coupon c = new Coupon(s, GetMockCouponName(), 10);
            c.Create();

            string act = GetMockAccountName();
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
            
            string s = GetMockCouponCode();
            Dictionary<string, int> discounts = new Dictionary<string,int>();
            discounts.Add("USD",1000);
            Coupon c = new Coupon(s, GetMockCouponName(), discounts);
            c.Create();

            string act = GetMockAccountName();
            Account acct = new Account(s, "John", "Doe", "4111111111111111", DateTime.Now.Month, DateTime.Now.Year + 2);
            acct.Create();

            CouponRedemption cr = acct.RedeemCoupon(s, "USD");

            Transaction t = new Transaction(acct, 5000, "USD");
            t.Create();


            CouponRedemption cr2 = Invoice.Get(t.Invoice.Value).GetCoupon();

            Assert.AreEqual(cr, cr2);
        }

    }
}
