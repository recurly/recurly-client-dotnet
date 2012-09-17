using System;
using System.Collections.Generic;
using System.Text;
using Recurly;
using NUnit.Framework;

namespace Recurly.Test
{
    [TestFixture]
    public class SubscriptionTest
    {

        [Test]
        public void LookupSubscription()
        {
            Assert.Fail("Not written");
        }

        [Test]
        public void LookupSubscriptionPendingChanges()
        {
            Assert.Fail("Not written");
        }

        [Test]
        public void CreateSubscription()
        {
            String s = Factories.GetMockPlanCode();
            Plan p = new Plan(s, Factories.GetMockPlanName());
            p.Description = "Create Subscription Test";
            p.UnitAmountInCents.Add("USD", 100);
            p.Create();

            String a = Factories.GetMockAccountName();
            Account acct = new Account(a, "New Txn", "User",
                "4111111111111111", DateTime.Now.Month, DateTime.Now.Year + 1);

            Subscription sub = new Subscription(acct, p, "USD");
            sub.Create();

            Assert.IsNotNull(sub.ActivatedAt);
            Assert.AreEqual(sub.State, Subscription.SubstriptionState.Live);
        }

        [Test]
        public void CreateSubscriptionWithCoupon()
        {
            Assert.Fail("Not written");
        }

        [Test]
        public void UpdateSubscription()
        {
            Assert.Fail("Not written");
        }


        [Test]
        public void CancelSubscription()
        {
            String s = Factories.GetMockPlanCode();
            Plan p = new Plan(s, Factories.GetMockPlanName());
            p.Description = "Create Subscription Test";
            p.UnitAmountInCents.Add("USD", 100);
            p.Create();

            String a = Factories.GetMockAccountName();
            Account acct = new Account(a, "New Txn", "User",
                "4111111111111111", DateTime.Now.Month, DateTime.Now.Year + 1);

            Subscription sub = new Subscription(acct, p, "USD");
            sub.Create();

            sub.Cancel();

            Assert.IsNotNull(sub.CanceledAt);
            Assert.AreEqual(sub.State, Subscription.SubstriptionState.Canceled);
        }


        [Test]
        public void ReactivateSubscription()
        {
            String s = Factories.GetMockPlanCode();
            Plan p = new Plan(s, Factories.GetMockPlanName());
            p.Description = "Create Subscription Test";
            p.UnitAmountInCents.Add("USD", 100);
            p.Create();

            String a = Factories.GetMockAccountName();
            Account acct = new Account(a, "New Txn", "User",
                "4111111111111111", DateTime.Now.Month, DateTime.Now.Year + 1);

            Subscription sub = new Subscription(acct, p, "USD");
            sub.Create();

            sub.Cancel();

            sub.Reactivate();

            Assert.AreEqual(sub.State, Subscription.SubstriptionState.Active);
        }

        [Test]
        public void TerminateSubscriptionNoRefund()
        {
            Assert.Fail("Not written");
        }

        [Test]
        public void TerminateSubscriptionPartialRefund()
        {
            Assert.Fail("Not written");
        }

        [Test]
        public void TerminateSubscriptionFullRefund()
        {
            Assert.Fail("Not written");
        }

        [Test]
        public void PostponeSubscription()
        {
            String s = Factories.GetMockPlanCode();
            Plan p = new Plan(s, Factories.GetMockPlanName());
            p.Description = "Create Subscription Test";
            p.UnitAmountInCents.Add("USD", 100);
            p.Create();

            String a = Factories.GetMockAccountName();
            Account acct = new Account(a, "New Txn", "User",
                "4111111111111111", DateTime.Now.Month, DateTime.Now.Year + 1);

            Subscription sub = new Subscription(acct, p, "USD");
            sub.Create();
            DateTime renewal = DateTime.Now.AddMonths(3);

            sub.Postpone(renewal);
            int diff = renewal.Date.Subtract(sub.CurrentPeriodEndsAt.Value.Date).Days;
            Assert.AreEqual(diff, 1);
        }




    }
}
