using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace Recurly.Test
{
    public class SubscriptionListTest : BaseTest
    {
        [RecurlyFact(TestEnvironment.Type.Integration)]
        public void ListLiveSubscriptions()
        {
            var p = new Plan(GetMockPlanCode(), GetMockPlanName()) {Description = "Subscription Test"};
            p.UnitAmountInCents.Add("USD", 200);
            p.Create();
            PlansToDeactivateOnDispose.Add(p);

            for (var x = 0; x < 2; x++)
            {
                var account = CreateNewAccountWithBillingInfo();

                var sub = new Subscription(account, p, "USD");
                sub.Create();
            }

            var subs = Subscriptions.List(Subscription.SubscriptionState.Live);
            subs.Should().NotBeEmpty();
        }

        [RecurlyFact(TestEnvironment.Type.Integration)]
        public void ListActiveSubscriptions()
        {
            var p = new Plan(GetMockPlanCode(), GetMockPlanName()) { Description = "Subscription Test" };
            p.UnitAmountInCents.Add("USD", 300);
            p.Create();
            PlansToDeactivateOnDispose.Add(p);

            for (var x = 0; x < 2; x++)
            {
                var account = CreateNewAccountWithBillingInfo();

                var sub = new Subscription(account, p, "USD");
                sub.Create();
            }

            var subs = Subscriptions.List(Subscription.SubscriptionState.Active);
            subs.Should().NotBeEmpty();
        }

        [RecurlyFact(TestEnvironment.Type.Integration)]
        public void ListCanceledSubscriptions()
        {
            var p = new Plan(GetMockPlanCode(), GetMockPlanName()) { Description = "Subscription Test" };
            p.UnitAmountInCents.Add("USD", 400);
            p.Create();
            PlansToDeactivateOnDispose.Add(p);

            for (var x = 0; x < 2; x++)
            {
                var account = CreateNewAccountWithBillingInfo();

                var sub = new Subscription(account, p, "USD");
                sub.Create();

                sub.Cancel();
            }

            var subs = Subscriptions.List(Subscription.SubscriptionState.Canceled);
            subs.Should().NotBeEmpty();
        }

        [RecurlyFact(TestEnvironment.Type.Integration)]
        public void ListExpiredSubscriptions()
        {
            var plan = new Plan(GetMockPlanCode(), GetMockPlanName())
            {
                Description = "Subscription Test",
                PlanIntervalLength = 1,
                PlanIntervalUnit = Plan.IntervalUnit.Months
            };
            plan.UnitAmountInCents.Add("USD", 400);
            plan.Create();
            PlansToDeactivateOnDispose.Add(plan);

            for (var x = 0; x < 2; x++)
            {
                var account = CreateNewAccountWithBillingInfo();
                var sub = new Subscription(account, plan, "USD")
                {
                    StartsAt = DateTime.Now.AddMonths(-5)
                };

                sub.Create();
            }

            var subs = Subscriptions.List(Subscription.SubscriptionState.Expired);
            subs.Should().NotBeEmpty();
        }

        [RecurlyFact(TestEnvironment.Type.Integration)]
        public void ListFutureSubscriptions()
        {
            var plan = new Plan(GetMockPlanCode(), GetMockPlanName())
            {
                Description = "Subscription Test",
                PlanIntervalLength = 1,
                PlanIntervalUnit = Plan.IntervalUnit.Months
            };
            plan.UnitAmountInCents.Add("USD", 400);
            plan.Create();
            PlansToDeactivateOnDispose.Add(plan);

            for (var x = 0; x < 2; x++)
            {
                var account = CreateNewAccountWithBillingInfo();
                var sub = new Subscription(account, plan, "USD")
                {
                    StartsAt = DateTime.Now.AddMonths(1)
                };

                sub.Create();
            }

            var subs = Subscriptions.List(Subscription.SubscriptionState.Future);
            subs.Should().NotBeEmpty();
        }

        [RecurlyFact(TestEnvironment.Type.Integration)]
        public void ListInTrialSubscriptions()
        {
            var plan = new Plan(GetMockPlanCode(), GetMockPlanName())
            {
                Description = "Subscription Test",
                PlanIntervalLength = 1,
                PlanIntervalUnit = Plan.IntervalUnit.Months,
                TrialIntervalLength = 2,
                TrialIntervalUnit = Plan.IntervalUnit.Months
            };
            plan.UnitAmountInCents.Add("USD", 400);
            plan.Create();
            PlansToDeactivateOnDispose.Add(plan);

            for (var x = 0; x < 2; x++)
            {
                var account = CreateNewAccountWithBillingInfo();
                var sub = new Subscription(account, plan, "USD")
                {
                    TrialPeriodEndsAt = DateTime.UtcNow.AddMonths(2)
                };
                sub.Create();
            }

            var subs = Subscriptions.List(Subscription.SubscriptionState.InTrial);
            subs.Should().NotBeEmpty();
        }

        /// <summary>
        /// This test isn't constructed as expected, as there doesn't appear to be a way to
        /// programmatically make a subscription past due.
        /// </summary>
        [RecurlyFact(TestEnvironment.Type.Integration)]
        public void ListPastDueSubscriptions()
        {
            var plan = new Plan(GetMockPlanCode(), GetMockPlanName())
            {
                Description = "Subscription Test",
                PlanIntervalLength = 1,
                PlanIntervalUnit = Plan.IntervalUnit.Months
            };
            plan.UnitAmountInCents.Add("USD", 200100);
            plan.Create();
            PlansToDeactivateOnDispose.Add(plan);

            var subs = new List<Subscription>();
            for (var x = 0; x < 2; x++)
            {
                var account = CreateNewAccountWithBillingInfo();
                var sub = new Subscription(account, plan, "USD");
                sub.Create();
                subs.Add(sub);
            }

            var list = Subscriptions.List(Subscription.SubscriptionState.PastDue);
            list.Should().NotContain(subs);
        }

        [RecurlyFact(TestEnvironment.Type.Integration)]
        public void ListForAccount()
        {
            var plan1 = new Plan(GetMockPlanCode(), GetMockPlanName()) {Description = "Subscription Test"};
            plan1.UnitAmountInCents.Add("USD", 400);
            plan1.Create();
            PlansToDeactivateOnDispose.Add(plan1);

            var plan2 = new Plan(GetMockPlanCode(), GetMockPlanName()) {Description = "Subscription Test"};
            plan2.UnitAmountInCents.Add("USD", 500);
            plan2.Create();
            PlansToDeactivateOnDispose.Add(plan2);

            var account = CreateNewAccountWithBillingInfo();

            var sub = new Subscription(account, plan1, "USD");
            sub.Create();

            var sub2 = new Subscription(account, plan2, "USD");
            sub2.Create();

            var list = account.GetSubscriptions(Subscription.SubscriptionState.All);
            list.Should().NotBeEmpty();
        }
    }
}
