using System;
using System.Collections.Generic;
using System.Text;
using Recurly;
using NUnit.Framework;
using System.Threading;

namespace Recurly.Test
{
    [TestFixture]
    public class SubscriptionListTest
    {

        [Test]
        public void ListLiveSubscriptions()
        {
            String s = Factories.GetMockPlanCode();
            Plan p = new Plan(s, Factories.GetMockPlanName());
            p.Description = "Subscription Test";
            p.UnitAmountInCents.Add("USD", 200);
            p.Create();

            for (int x = 0; x < 2; x++)
            {
                String a = Factories.GetMockAccountName();
                Account acct = new Account(a, "New Txn", "User",
                    "4111111111111111", DateTime.Now.Month, DateTime.Now.Year + 1);

                Subscription sub = new Subscription(acct, p, "USD");
                sub.Create();

                Thread.Sleep(1);
            }

            SubscriptionList list = SubscriptionList.GetSubscriptions(Subscription.SubstriptionState.live);
            Assert.IsTrue(list.Count > 0);
            p.Deactivate();
        }

        [Test]
        public void ListActiveSubscriptions()
        {
            String s = Factories.GetMockPlanCode();
            Plan p = new Plan(s, Factories.GetMockPlanName());
            p.Description = "Subscription Test";
            p.UnitAmountInCents.Add("USD", 300);
            p.Create();

            for (int x = 0; x < 2; x++)
            {
                String a = Factories.GetMockAccountName();
                Account acct = new Account(a, "New Txn", "User",
                    "4111111111111111", DateTime.Now.Month, DateTime.Now.Year + 1);

                Subscription sub = new Subscription(acct, p, "USD");
                sub.Create();

                Thread.Sleep(1);
            }

            SubscriptionList list = SubscriptionList.GetSubscriptions(Subscription.SubstriptionState.active);
            Assert.IsTrue(list.Count > 0);
            p.Deactivate();
        }

        [Test]
        public void ListCanceledSubscriptions()
        {
            String s = Factories.GetMockPlanCode();
            Plan p = new Plan(s, Factories.GetMockPlanName());
            p.Description = "Subscription Test";
            p.UnitAmountInCents.Add("USD", 400);
            p.Create();

            for (int x = 0; x < 2; x++)
            {
                String a = Factories.GetMockAccountName();
                Account acct = new Account(a, "New Txn", "User",
                    "4111111111111111", DateTime.Now.Month, DateTime.Now.Year + 1);

                Subscription sub = new Subscription(acct, p, "USD");
                sub.Create();

                sub.Cancel();
                Thread.Sleep(1);
            }

            SubscriptionList list = SubscriptionList.GetSubscriptions(Subscription.SubstriptionState.canceled);
            Assert.IsTrue(list.Count > 0);
            p.Deactivate();
        }

        [Test]
        public void ListExpiredSubscriptions()
        {
            String s = Factories.GetMockPlanCode();
            Plan p = new Plan(s, Factories.GetMockPlanName());
            p.Description = "Subscription Test";
            p.PlanIntervalLength = 1;
            p.PlanIntervalUnit = Plan.IntervalUnit.Months;
            p.UnitAmountInCents.Add("USD", 400);
            p.Create();

            for (int x = 0; x < 2; x++)
            {
                String a = Factories.GetMockAccountName();
                Account acct = new Account(a, "New Txn", "User",
                    "4111111111111111", DateTime.Now.Month, DateTime.Now.Year + 1);

                Subscription sub = new Subscription(acct, p, "USD");
                sub.StartsAt = DateTime.Now.AddMonths(-5);
                
                sub.Create();

                Thread.Sleep(1);
            }

            SubscriptionList list = SubscriptionList.GetSubscriptions(Subscription.SubstriptionState.canceled);
            Assert.IsTrue(list.Count > 0);

            p.Deactivate();
        }

        [Test]
        public void ListFutureSubscriptions()
        {
            String s = Factories.GetMockPlanCode();
            Plan p = new Plan(s, Factories.GetMockPlanName());
            p.Description = "Subscription Test";
            p.PlanIntervalLength = 1;
            p.PlanIntervalUnit = Plan.IntervalUnit.Months;
            p.UnitAmountInCents.Add("USD", 400);
            p.Create();

            for (int x = 0; x < 2; x++)
            {
                String a = Factories.GetMockAccountName();
                Account acct = new Account(a, "New Txn", "User",
                    "4111111111111111", DateTime.Now.Month, DateTime.Now.Year + 1);

                Subscription sub = new Subscription(acct, p, "USD");
                sub.StartsAt = DateTime.Now.AddMonths(1);

                sub.Create();

                Thread.Sleep(1);
            }

            SubscriptionList list = SubscriptionList.GetSubscriptions(Subscription.SubstriptionState.canceled);
            Assert.IsTrue(list.Count > 0);

            p.Deactivate();
        }

        [Test]
        public void ListInTrialSubscriptions()
        {
            String s = Factories.GetMockPlanCode();
            Plan p = new Plan(s, Factories.GetMockPlanName());
            p.Description = "Subscription Test";
            p.PlanIntervalLength = 1;
            p.PlanIntervalUnit = Plan.IntervalUnit.Months;
            p.TrialIntervalLength = 1;
            p.TrialIntervalUnit = Plan.IntervalUnit.Months;
            p.UnitAmountInCents.Add("USD", 400);
            p.Create();

            for (int x = 0; x < 2; x++)
            {
                String a = Factories.GetMockAccountName();
                Account acct = new Account(a, "New Txn", "User",
                    "4111111111111111", DateTime.Now.Month, DateTime.Now.Year + 1);

                Subscription sub = new Subscription(acct, p, "USD");
                sub.StartsAt = DateTime.Now.AddMonths(1);

                sub.Create();

                Thread.Sleep(1);
            }

            SubscriptionList list = SubscriptionList.GetSubscriptions(Subscription.SubstriptionState.canceled);
            Assert.IsTrue(list.Count > 0);

            p.Deactivate();
        }

        [Test]
        public void ListPastDueSubscriptions()
        {
            String s = Factories.GetMockPlanCode();
            Plan p = new Plan(s, Factories.GetMockPlanName());
            p.Description = "Subscription Test";
            p.PlanIntervalLength = 1;
            p.PlanIntervalUnit = Plan.IntervalUnit.Months;
            p.UnitAmountInCents.Add("USD", 200100);
            p.Create();

            for (int x = 0; x < 2; x++)
            {
                String a = Factories.GetMockAccountName();
                Account acct = new Account(a, "New Txn", "User",
                "4111111111111111", DateTime.Now.Month, DateTime.Now.Year + 1);

                Subscription sub = new Subscription(acct, p, "USD");
                sub.Create();

                Thread.Sleep(1);
            }

            SubscriptionList list = SubscriptionList.GetSubscriptions(Subscription.SubstriptionState.past_due);
            Assert.IsTrue(list.Count > 0);

            p.Deactivate();
        }

        [Test]
        public void ListForAccount()
        {
            String s = Factories.GetMockPlanCode();
            Plan p = new Plan(s, Factories.GetMockPlanName());
            p.Description = "Subscription Test";

            p.UnitAmountInCents.Add("USD", 400);
            p.Create();

            String s2 = Factories.GetMockPlanCode();
            Plan p2 = new Plan(s2, Factories.GetMockPlanName());
            p2.Description = "Subscription Test";

            p2.UnitAmountInCents.Add("USD", 500);
            p2.Create();

            String a = Factories.GetMockAccountName();
            Account acct = new Account(a, "New Txn", "User",
                "4111111111111111", DateTime.Now.Month, DateTime.Now.Year + 1);

            Subscription sub = new Subscription(acct, p, "USD");
            sub.Create();

            Subscription sub2 = new Subscription(acct, p2, "USD");
            sub2.Create();

            SubscriptionList list = acct.GetSubscriptions(Subscription.SubstriptionState.all);
            Assert.IsTrue(list.Count > 0);

            p.Deactivate();
            p2.Deactivate();
        }

    }
}
