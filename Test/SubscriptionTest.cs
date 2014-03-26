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
            PlansToDeactivateOnDispose.Add(plan);

            var account = CreateNewAccountWithBillingInfo();

            var sub = new Subscription(account, plan, "USD");
            sub.Create();

            sub.ActivatedAt.Should().HaveValue().And.NotBe(default(DateTime));
            sub.State.Should().Be(Subscription.SubscriptionState.Active);

            var fromService = Subscriptions.Get(sub.Uuid);

            fromService.Should().Be(sub);
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
            PlansToDeactivateOnDispose.Add(plan);

            var account = CreateNewAccountWithBillingInfo();

            var sub = new Subscription(account, plan, "USD");
            sub.Create();
            sub.UnitAmountInCents = 3000;
            
            sub.ChangeSubscription(Subscription.ChangeTimeframe.Renewal);

            var newSubscription = Subscriptions.Get(sub.Uuid);
            newSubscription.PendingSubscription.Should().NotBeNull();
            newSubscription.PendingSubscription.UnitAmountInCents.Should().Be(3000);
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
            PlansToDeactivateOnDispose.Add(plan);

            var account = CreateNewAccountWithBillingInfo();

            var sub = new Subscription(account, plan, "USD");
            sub.Create();

            sub.ActivatedAt.Should().HaveValue().And.NotBe(default(DateTime));
            sub.State.Should().Be(Subscription.SubscriptionState.Active);
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
            PlansToDeactivateOnDispose.Add(plan);

            var coupon = new Coupon(GetMockCouponCode(), "Sub Test " + GetMockCouponName(), 10);
            coupon.Create();

            var account = CreateNewAccountWithBillingInfo();

            var sub = new Subscription(account, plan, "USD", coupon.CouponCode);
            sub.Create();

            sub.ActivatedAt.Should().HaveValue().And.NotBe(default(DateTime));
            sub.State.Should().Be(Subscription.SubscriptionState.Active);
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
            PlansToDeactivateOnDispose.Add(plan);

            var plan2 = new Plan(GetMockPlanCode(), GetMockPlanName())
            {
                Description = "Update Subscription Plan 2"
            };
            plan2.UnitAmountInCents.Add("USD", 750);
            plan2.Create();
            PlansToDeactivateOnDispose.Add(plan2);

            var account = CreateNewAccountWithBillingInfo();

            var sub = new Subscription(account, plan, "USD");
            sub.Create();
            sub.Plan = plan2;

            sub.ChangeSubscription(Subscription.ChangeTimeframe.Now);

            var newSubscription = Subscriptions.Get(sub.Uuid);

            newSubscription.PendingSubscription.Should().BeNull();
            newSubscription.Plan.Should().Be(plan2);
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
            PlansToDeactivateOnDispose.Add(plan);

            var account = CreateNewAccountWithBillingInfo();

            var sub = new Subscription(account, plan, "USD");
            sub.Create();

            sub.Cancel();

            sub.CanceledAt.Should().HaveValue().And.NotBe(default(DateTime));
            sub.State.Should().Be(Subscription.SubscriptionState.Canceled);
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
            PlansToDeactivateOnDispose.Add(plan);

            var account = CreateNewAccountWithBillingInfo();

            var sub = new Subscription(account, plan, "USD");
            sub.Create();

            sub.Cancel();
            sub.State.Should().Be(Subscription.SubscriptionState.Canceled);

            sub.Reactivate();

            sub.State.Should().Be(Subscription.SubscriptionState.Active);
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
            PlansToDeactivateOnDispose.Add(plan);

            var account = CreateNewAccountWithBillingInfo();

            var sub = new Subscription(account, plan, "USD");
            sub.Create();

            sub.Terminate(Subscription.RefundType.None);
            sub.State.Should().Be(Subscription.SubscriptionState.Expired);
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
            PlansToDeactivateOnDispose.Add(plan);

            var account = CreateNewAccountWithBillingInfo();

            var sub = new Subscription(account, plan, "USD");
            sub.Create();

            sub.Terminate(Subscription.RefundType.Partial);
            sub.State.Should().Be(Subscription.SubscriptionState.Expired);
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
            PlansToDeactivateOnDispose.Add(plan);

            var account = CreateNewAccountWithBillingInfo();

            var sub = new Subscription(account, plan, "USD");
            sub.Create();

            sub.Terminate(Subscription.RefundType.Full);

            sub.State.Should().Be(Subscription.SubscriptionState.Expired);
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
            PlansToDeactivateOnDispose.Add(plan);

            var account = CreateNewAccountWithBillingInfo();

            var sub = new Subscription(account, plan, "USD");
            sub.Create();
            var renewal = DateTime.Now.AddMonths(3);

            sub.Postpone(renewal);

            var diff = renewal.Date.Subtract(sub.CurrentPeriodEndsAt.Value.Date).Days;
            diff.Should().Be(1);
        }

        [Fact]
        [Trait("include","y")]
        public void CreateSubscriptionPlanWithAddons()
        {
            Plan plan = null;
            Plan plan2 = null;
            AddOn addon1 = null;
            AddOn addon2 = null;
            Account account = null;
            Subscription sub = null;
            Subscription sub2 = null;
            Subscription sub3 = null;

            try
            {
                plan = new Plan(GetMockPlanCode(), "aarons test plan")
                {
                    Description = "Create Subscription Plan With Addons Test"
                };
                plan.UnitAmountInCents.Add("USD", 100);
                plan.Create();

                addon1 = plan.CreateAddOn("addon1", "addon1");
                addon1.DisplayQuantityOnHostedPage = true;
                addon1.UnitAmountInCents.Add("USD", 100);
                addon1.DefaultQuantity = 1;
                addon1.Create();

                addon2 = plan.CreateAddOn("addon2", "addon2");
                addon2.DisplayQuantityOnHostedPage = true;
                addon2.UnitAmountInCents.Add("USD", 200);
                addon2.DefaultQuantity = 1;
                addon2.Create();

                plan = Plans.Get(plan.PlanCode);

                var addon_test_1 = plan.GetAddOn("addon1");
                Assert.Equal(addon1.UnitAmountInCents["USD"], addon_test_1.UnitAmountInCents["USD"]);

                var addon_test_2 = plan.GetAddOn("addon2");
                Assert.Equal(addon2.UnitAmountInCents["USD"], addon_test_2.UnitAmountInCents["USD"]);

                account = CreateNewAccountWithBillingInfo();

                sub = new Subscription(account, plan, "USD");
                sub.AddOns.Add(new SubscriptionAddOn("addon1", 100, 1));
                sub.AddOns.Add(new SubscriptionAddOn("addon2", 200, 2));
                sub.Create();

                sub.ActivatedAt.Should().HaveValue().And.NotBe(default(DateTime));
                sub.State.Should().Be(Subscription.SubscriptionState.Active);

                sub = Subscriptions.Get(sub.Uuid);
                Assert.Equal(2, sub.AddOns.Count);

                // test changing the plan of a subscription
                plan2 = new Plan(GetMockPlanCode(), "aarons test plan 2")
                {
                    Description = "Create Subscription Plan With Addons Test 2"
                };
                plan2.UnitAmountInCents.Add("USD", 1900);
                plan2.Create();

                sub2 = Subscriptions.Get(sub.Uuid);
                sub2.UnitAmountInCents = plan2.UnitAmountInCents["USD"];
                sub2.Plan = plan2;

                foreach (var addOn in sub2.AddOns)
                {
                    addOn.UnitAmountInCents = plan2.UnitAmountInCents["USD"];
                }
                sub2.ChangeSubscription(Subscription.ChangeTimeframe.Now);

                // check if the changes were saved
                sub3 = Subscriptions.Get(sub2.Uuid);
                sub3.UnitAmountInCents.Should().Equals(plan2.UnitAmountInCents["USD"]);
                foreach (var addOn in sub3.AddOns)
                {
                    addOn.UnitAmountInCents.Should().Equals(plan2.UnitAmountInCents["USD"]);
                }

            } finally {
                if (sub != null) sub.Cancel();
                if (plan2 != null) plan2.Deactivate();
                if (plan != null) plan.Deactivate();
                if (account != null) account.Close();
            }
        }
    }
}
