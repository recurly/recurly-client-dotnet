using System;
using System.Collections.Generic;
using System.Text;
using Recurly;
using NUnit.Framework;
using System.Threading;

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
            Thread.Sleep(2);
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
            string s = Factories.GetMockCouponCode();
            Dictionary<string, int> discounts = new Dictionary<string,int>();
            discounts.Add("USD",1000);
            Coupon c = new Coupon(s, Factories.GetMockCouponName(), discounts);
            c.Create();

            string act = Factories.GetMockAccountName();
            Account acct = new Account(s, "John", "Doe", "4111111111111111", DateTime.Now.Month, DateTime.Now.Year + 2);
            acct.Create();

            Transaction t = new Transaction(acct, 5000, "USD");
            t.Create();

            CouponRedemption cr = acct.RedeemCoupon(s, "USD");

            Invoice i1 = acct.InvoicePendingCharges();
            Thread.Sleep(2);
            CouponRedemption cr2 = i1.GetCoupon();

            Assert.AreEqual(cr, cr2);
        }

    }
}
