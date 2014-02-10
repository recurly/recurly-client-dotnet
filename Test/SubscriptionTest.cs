using System;
using FluentAssertions;
using Xunit;

namespace Recurly.Test
{
    public class SubscriptionTest : BaseTest
    {
        [Fact]
        public void LookupSubscription()
        {
            var plan = new Plan(GetMockPlanCode(), GetMockPlanName()) {Description = "Lookup Subscription Test"};
            plan.UnitAmountInCents.Add("USD", 1500);
            plan.Create();

            var account = CreateNewAccountWithBillingInfo();

            var sub = new Subscription(account, plan, "USD");
            sub.Create();

            sub.ActivatedAt.Should().HaveValue().And.NotBe(default(DateTime));
            sub.State.Should().Be(Subscription.SubscriptionState.Active);

            var fromService = Subscriptions.Get(sub.Uuid);

            fromService.Should().Be(sub);

            plan.Deactivate();
        }

        [Fact]
        public void LookupSubscriptionPendingChanges()
        {
            var plan = new Plan(GetMockPlanCode(), GetMockPlanName())
            {
                Description = "Lookup Subscription With Pending Changes Test"
            };
            plan.UnitAmountInCents.Add("USD", 1500);
            plan.Create();

            var account = CreateNewAccountWithBillingInfo();

            var sub = new Subscription(account, plan, "USD");
            sub.Create();
            sub.UnitAmountInCents = 3000;
            
            sub.ChangeSubscription(Subscription.ChangeTimeframe.Renewal);

            var newSubscription = Subscriptions.Get(sub.Uuid);
            newSubscription.PendingSubscription.Should().NotBeNull();
            newSubscription.PendingSubscription.UnitAmountInCents.Should().Be(3000);

            plan.Deactivate();
        }

        [Fact]
        public void CreateSubscription()
        {
            var plan = new Plan(GetMockPlanCode(), GetMockPlanName())
            {
                Description = "Create Subscription Test"
            };
            plan.UnitAmountInCents.Add("USD", 100);
            plan.Create();

            var account = CreateNewAccountWithBillingInfo();

            var sub = new Subscription(account, plan, "USD");
            sub.Create();

            sub.ActivatedAt.Should().HaveValue().And.NotBe(default(DateTime));
            sub.State.Should().Be(Subscription.SubscriptionState.Active);

            plan.Deactivate();
        }

        [Fact]
        public void CreateSubscriptionWithCoupon()
        {
            var plan = new Plan(GetMockPlanCode(), GetMockPlanName())
            {
                Description = "Create Subscription With Coupon Test"
            };
            plan.UnitAmountInCents.Add("USD", 100);
            plan.Create();

            var coupon = new Coupon(GetMockCouponCode(), "Sub Test " + GetMockCouponName(), 10);
            coupon.Create();

            var account = CreateNewAccountWithBillingInfo();

            var sub = new Subscription(account, plan, "USD", coupon.CouponCode);
            sub.Create();

            sub.ActivatedAt.Should().HaveValue().And.NotBe(default(DateTime));
            sub.State.Should().Be(Subscription.SubscriptionState.Active);

            plan.Deactivate();
        }

        [Fact]
        public void UpdateSubscription()
        {
            var plan = new Plan(GetMockPlanCode(), GetMockPlanName())
            {
                Description = "Update Subscription Plan 1"
            };
            plan.UnitAmountInCents.Add("USD", 1500);
            plan.Create();

            var plan2 = new Plan(GetMockPlanCode(), GetMockPlanName())
            {
                Description = "Update Subscription Plan 2"
            };
            plan2.UnitAmountInCents.Add("USD", 750);
            plan2.Create();

            var account = CreateNewAccountWithBillingInfo();

            var sub = new Subscription(account, plan, "USD");
            sub.Create();
            sub.Plan = plan2;

            sub.ChangeSubscription(Subscription.ChangeTimeframe.Now);

            var newSubscription = Subscriptions.Get(sub.Uuid);

            newSubscription.PendingSubscription.Should().BeNull();
            newSubscription.Plan.Should().Be(plan2);

            plan.Deactivate();
            plan2.Deactivate();
        }

        [Fact]
        public void CancelSubscription()
        {
            var plan = new Plan(GetMockPlanCode(), GetMockPlanName())
            {
                Description = "Cancel Subscription Test"
            };
            plan.UnitAmountInCents.Add("USD", 100);
            plan.Create();

            var account = CreateNewAccountWithBillingInfo();

            var sub = new Subscription(account, plan, "USD");
            sub.Create();

            sub.Cancel();

            sub.CanceledAt.Should().HaveValue().And.NotBe(default(DateTime));
            sub.State.Should().Be(Subscription.SubscriptionState.Canceled);

            plan.Deactivate();
        }

        [Fact]
        public void ReactivateSubscription()
        {
            var plan = new Plan(GetMockPlanCode(), GetMockPlanName())
            {
                Description = "Reactivate Subscription Test"
            };
            plan.UnitAmountInCents.Add("USD", 100);
            plan.Create();

            var account = CreateNewAccountWithBillingInfo();

            var sub = new Subscription(account, plan, "USD");
            sub.Create();

            sub.Cancel();
            sub.State.Should().Be(Subscription.SubscriptionState.Canceled);

            sub.Reactivate();

            sub.State.Should().Be(Subscription.SubscriptionState.Active);

            plan.Deactivate();
        }

        [Fact]
        public void TerminateSubscriptionNoRefund()
        {
            var plan = new Plan(GetMockPlanCode(), GetMockPlanName())
            {
                Description = "Terminate No Refund Subscription Test"
            };
            plan.UnitAmountInCents.Add("USD", 200);
            plan.Create();

            var account = CreateNewAccountWithBillingInfo();

            var sub = new Subscription(account, plan, "USD");
            sub.Create();

            sub.Terminate(Subscription.RefundType.None);
            sub.State.Should().Be(Subscription.SubscriptionState.Expired);

            plan.Deactivate();
        }

        [Fact]
        public void TerminateSubscriptionPartialRefund()
        {
            var plan = new Plan(GetMockPlanCode(), GetMockPlanName())
            {
                Description = "Terminate Partial Refund Subscription Test"
            };
            plan.UnitAmountInCents.Add("USD", 2000);
            plan.Create();

            var account = CreateNewAccountWithBillingInfo();

            var sub = new Subscription(account, plan, "USD");
            sub.Create();

            sub.Terminate(Subscription.RefundType.Partial);
            sub.State.Should().Be(Subscription.SubscriptionState.Expired);

            plan.Deactivate();
        }

        [Fact]
        public void TerminateSubscriptionFullRefund()
        {
            var plan = new Plan(GetMockPlanCode(), GetMockPlanName())
            {
                Description = "Terminate Full Refund Subscription Test"
            };
            plan.UnitAmountInCents.Add("USD", 20000);
            plan.Create();

            var account = CreateNewAccountWithBillingInfo();

            var sub = new Subscription(account, plan, "USD");
            sub.Create();

            sub.Terminate(Subscription.RefundType.Full);

            sub.State.Should().Be(Subscription.SubscriptionState.Expired);

            plan.Deactivate();
        }

        [Fact]
        public void PostponeSubscription()
        {
            var plan = new Plan(GetMockPlanCode(), GetMockPlanName())
            {
                Description = "Postpone Subscription Test"
            };
            plan.UnitAmountInCents.Add("USD", 100);
            plan.Create();

            var account = CreateNewAccountWithBillingInfo();

            var sub = new Subscription(account, plan, "USD");
            sub.Create();
            var renewal = DateTime.Now.AddMonths(3);

            sub.Postpone(renewal);

            var diff = renewal.Date.Subtract(sub.CurrentPeriodEndsAt.Value.Date).Days;
            diff.Should().Be(1);

            plan.Deactivate();
        }
    }
}
