using System;
using NUnit.Framework;

namespace Recurly.Test
{
    [TestFixture]
    public class SubscriptionTest : BaseTest
    {

        [Test]
        public void LookupSubscription()
        {
            String s = GetMockPlanCode();
            Plan p = new Plan(s, GetMockPlanName());
            p.Description = "Lookup Subscription Test";
            p.UnitAmountInCents.Add("USD", 1500);
            p.Create();

            String a = GetMockAccountName();
            Account acct = new Account(a, "New Txn", "User",
                "4111111111111111", DateTime.Now.Month, DateTime.Now.Year + 1);

            Subscription sub = new Subscription(acct, p, "USD");
            sub.Create();

            Assert.IsNotNull(sub.ActivatedAt);
            Assert.AreEqual(sub.State, Subscription.SubscriptionState.Active);

            string id = sub.Uuid;

            Subscription t = Subscription.Get(id);

            Assert.AreEqual(sub, t);

            p.Deactivate();

        }

        [Test]
        public void LookupSubscriptionPendingChanges()
        {
            String s = GetMockPlanCode();
            Plan p = new Plan(s, GetMockPlanName());
            p.Description = "Lookup Subscription With Pending Changes Test";
            p.UnitAmountInCents.Add("USD", 1500);
            p.Create();

            String a = GetMockAccountName();
            Account acct = new Account(a, "New Txn", "User",
                "4111111111111111", DateTime.Now.Month, DateTime.Now.Year + 1);

            Subscription sub = new Subscription(acct, p, "USD");
            sub.Create();
            String id = sub.Uuid;
            sub.UnitAmountInCents = 3000;
            
            sub.ChangeSubscription(Subscription.ChangeTimeframe.Renewal);


            Subscription newSubscription = Subscription.Get(id);
            Assert.IsNotNull(newSubscription.PendingSubscription);
            Assert.AreEqual(newSubscription.PendingSubscription.UnitAmountInCents, 3000);

            p.Deactivate();


        }

        [Test]
        public void CreateSubscription()
        {
            String s = GetMockPlanCode();
            Plan p = new Plan(s, GetMockPlanName());
            p.Description = "Create Subscription Test";
            p.UnitAmountInCents.Add("USD", 100);
            p.Create();

            String a = GetMockAccountName();
            Account acct = new Account(a, "New Txn", "User",
                "4111111111111111", DateTime.Now.Month, DateTime.Now.Year + 1);

            Subscription sub = new Subscription(acct, p, "USD");
            sub.Create();

            Assert.IsNotNull(sub.ActivatedAt);
            Assert.AreEqual(sub.State, Subscription.SubscriptionState.Active);

            p.Deactivate();

        }

        [Test]
        public void CreateSubscriptionWithCoupon()
        {
            String s = GetMockPlanCode();
            Plan p = new Plan(s, GetMockPlanName());
            p.Description = "Create Subscription With Coupon Test";
            p.UnitAmountInCents.Add("USD", 100);
            p.Create();

            String code = GetMockCouponCode();
            Coupon c = new Coupon(code, "Sub Test " + GetMockCouponName(), 10);
            c.Create();

            String a = GetMockAccountName();
            Account acct = new Account(a, "New Txn", "User",
                "4111111111111111", DateTime.Now.Month, DateTime.Now.Year + 1);

            Subscription sub = new Subscription(acct, p, "USD", code);
            sub.Create();

            Assert.IsNotNull(sub.ActivatedAt);
            Assert.AreEqual(sub.State, Subscription.SubscriptionState.Active);

            p.Deactivate();
        }

        [Test]
        public void UpdateSubscription()
        {
            String s = GetMockPlanCode();
            Plan p = new Plan(s, GetMockPlanName());
            p.Description = "Update Subscription Plan 1";
            p.UnitAmountInCents.Add("USD", 1500);
            p.Create();

            String s2 = GetMockPlanCode();

            Plan p2 = new Plan(s2, GetMockPlanName());
            p2.Description = "Update Subscription Plan 2";
            p2.UnitAmountInCents.Add("USD", 750);
            p2.Create();

            String a = GetMockAccountName();
            Account acct = new Account(a, "New Txn", "User",
                "4111111111111111", DateTime.Now.Month, DateTime.Now.Year + 1);

            Subscription sub = new Subscription(acct, p, "USD");
            sub.Create();
            String id = sub.Uuid;
            sub.Plan = p2;

            sub.ChangeSubscription(Subscription.ChangeTimeframe.Now);

            Subscription newSubscription = Subscription.Get(id);
            Assert.IsNull(newSubscription.PendingSubscription);
            Assert.AreEqual(newSubscription.Plan, p2);

            p.Deactivate();
            p2.Deactivate();
        }


        [Test]
        public void CancelSubscription()
        {
            String s = GetMockPlanCode();
            Plan p = new Plan(s, GetMockPlanName());
            p.Description = "Cancel Subscription Test";
            p.UnitAmountInCents.Add("USD", 100);
            p.Create();

            String a = GetMockAccountName();
            Account acct = new Account(a, "New Txn", "User",
                "4111111111111111", DateTime.Now.Month, DateTime.Now.Year + 1);

            Subscription sub = new Subscription(acct, p, "USD");
            sub.Create();

            sub.Cancel();

            Assert.IsNotNull(sub.CanceledAt);
            Assert.AreEqual(sub.State, Subscription.SubscriptionState.Canceled);
            p.Deactivate();

        }


        [Test]
        public void ReactivateSubscription()
        {
            String s = GetMockPlanCode();
            Plan p = new Plan(s, GetMockPlanName());
            p.Description = "Reactivate Subscription Test";
            p.UnitAmountInCents.Add("USD", 100);
            p.Create();

            String a = GetMockAccountName();
            Account acct = new Account(a, "New Txn", "User",
                "4111111111111111", DateTime.Now.Month, DateTime.Now.Year + 1);

            Subscription sub = new Subscription(acct, p, "USD");
            sub.Create();

            sub.Cancel();
            Assert.AreEqual(sub.State, Subscription.SubscriptionState.Canceled);

            sub.Reactivate();

            Assert.AreEqual(sub.State, Subscription.SubscriptionState.Active);
            p.Deactivate();

        }

        [Test]
        public void TerminateSubscriptionNoRefund()
        {
            String s = GetMockPlanCode();
            Plan p = new Plan(s, GetMockPlanName());
            p.Description = "Terminate No Refund Subscription Test";
            p.UnitAmountInCents.Add("USD", 200);
            p.Create();

            String a = GetMockAccountName();
            Account acct = new Account(a, "New Txn", "User",
                "4111111111111111", DateTime.Now.Month, DateTime.Now.Year + 1);

            Subscription sub = new Subscription(acct, p, "USD");
            sub.Create();

            sub.Terminate(Subscription.RefundType.None);

            Assert.AreEqual(sub.State, Subscription.SubscriptionState.Expired);
            p.Deactivate();

        }

        [Test]
        public void TerminateSubscriptionPartialRefund()
        {
            String s = GetMockPlanCode();
            Plan p = new Plan(s, GetMockPlanName());
            p.Description = "Terminate Partial Refund Subscription Test";
            p.UnitAmountInCents.Add("USD", 2000);
            p.Create();

            String a = GetMockAccountName();
            Account acct = new Account(a, "New Txn", "User",
                "4111111111111111", DateTime.Now.Month, DateTime.Now.Year + 1);

            Subscription sub = new Subscription(acct, p, "USD");
            sub.Create();

            sub.Terminate(Subscription.RefundType.Partial);

            Assert.AreEqual(sub.State, Subscription.SubscriptionState.Expired);
            p.Deactivate();

        }

        [Test]
        public void TerminateSubscriptionFullRefund()
        {
            String s = GetMockPlanCode();
            Plan p = new Plan(s, GetMockPlanName());
            p.Description = "Terminate Full Refund Subscription Test";
            p.UnitAmountInCents.Add("USD", 20000);
            p.Create();

            String a = GetMockAccountName();
            Account acct = new Account(a, "New Txn", "User",
                "4111111111111111", DateTime.Now.Month, DateTime.Now.Year + 1);

            Subscription sub = new Subscription(acct, p, "USD");
            sub.Create();

            sub.Terminate(Subscription.RefundType.Full);

            Assert.AreEqual(sub.State, Subscription.SubscriptionState.Expired);
            p.Deactivate();

        }

        [Test]
        public void PostponeSubscription()
        {
            String s = GetMockPlanCode();
            Plan p = new Plan(s, GetMockPlanName());
            p.Description = "Postpone Subscription Test";
            p.UnitAmountInCents.Add("USD", 100);
            p.Create();

            String a = GetMockAccountName();
            Account acct = new Account(a, "New Txn", "User",
                "4111111111111111", DateTime.Now.Month, DateTime.Now.Year + 1);

            Subscription sub = new Subscription(acct, p, "USD");
            sub.Create();
            DateTime renewal = DateTime.Now.AddMonths(3);

            sub.Postpone(renewal);
            int diff = renewal.Date.Subtract(sub.CurrentPeriodEndsAt.Value.Date).Days;
            Assert.AreEqual(diff, 1);
            p.Deactivate();

        }




    }
}
