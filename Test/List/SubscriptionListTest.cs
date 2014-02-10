using System;
using System.Threading;
using FluentAssertions;
using Xunit;

namespace Recurly.Test
{
    public class SubscriptionListTest : BaseTest
    {
        [Fact]
        public void ListLiveSubscriptions()
        {
            var p = new Plan(GetMockPlanCode(), GetMockPlanName()) {Description = "Subscription Test"};
            p.UnitAmountInCents.Add("USD", 200);
            p.Create();

            for (var x = 0; x < 2; x++)
            {
                var account = CreateNewAccountWithBillingInfo();

                var sub = new Subscription(account, p, "USD");
                sub.Create();
            }

            var subs = Subscriptions.List(Subscription.SubscriptionState.Live);
            subs.Should().NotBeEmpty();
            p.Deactivate();
        }

        [Fact]
        public void ListActiveSubscriptions()
        {
            var p = new Plan(GetMockPlanCode(), GetMockPlanName()) { Description = "Subscription Test" };
            p.UnitAmountInCents.Add("USD", 300);
            p.Create();

            for (var x = 0; x < 2; x++)
            {
                var account = CreateNewAccountWithBillingInfo();

                var sub = new Subscription(account, p, "USD");
                sub.Create();
            }

            var subs = Subscriptions.List(Subscription.SubscriptionState.Active);
            subs.Should().NotBeEmpty();
            p.Deactivate();
        }

        [Fact]
        public void ListCanceledSubscriptions()
        {
            var p = new Plan(GetMockPlanCode(), GetMockPlanName()) { Description = "Subscription Test" };
            p.UnitAmountInCents.Add("USD", 400);
            p.Create();

            for (var x = 0; x < 2; x++)
            {
                var account = CreateNewAccountWithBillingInfo();

                var sub = new Subscription(account, p, "USD");
                sub.Create();

                sub.Cancel();
            }

            var subs = Subscriptions.List(Subscription.SubscriptionState.Canceled);
            subs.Should().NotBeEmpty();
            p.Deactivate();
        }

        [Fact]
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

            plan.Deactivate();
        }

        [Fact]
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

            plan.Deactivate();
        }

        [Fact]
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

            for (var x = 0; x < 2; x++)
            {
                var account = CreateNewAccountWithBillingInfo();
                var sub = new Subscription(account, plan, "USD")
                {
                    StartsAt = DateTime.Now.AddMonths(1)
                };

                sub.Create();
            }

            var subs = Subscriptions.List(Subscription.SubscriptionState.InTrial);
            subs.Should().NotBeEmpty();

            plan.Deactivate();
        }

        [Fact]
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

            for (var x = 0; x < 2; x++)
            {
                var account = CreateNewAccountWithBillingInfo();
                var sub = new Subscription(account, plan, "USD");
                sub.Create();
            }

            var list = Subscriptions.List(Subscription.SubscriptionState.PastDue);
            list.Should().NotBeEmpty();

            plan.Deactivate();
        }

        [Fact]
        public void ListForAccount()
        {
            var plan1 = new Plan(GetMockPlanCode(), GetMockPlanName()) {Description = "Subscription Test"};
            plan1.UnitAmountInCents.Add("USD", 400);
            plan1.Create();

            var plan2 = new Plan(GetMockPlanCode(), GetMockPlanName()) {Description = "Subscription Test"};
            plan2.UnitAmountInCents.Add("USD", 500);
            plan2.Create();

            var account = CreateNewAccountWithBillingInfo();

            var sub = new Subscription(account, plan1, "USD");
            sub.Create();

            var sub2 = new Subscription(account, plan2, "USD");
            sub2.Create();

            SubscriptionList list = account.GetSubscriptions(Subscription.SubscriptionState.All);
            list.Should().NotBeEmpty();

            plan1.Deactivate();
            plan2.Deactivate();
        }

    }
}
