using System;
using FluentAssertions;
using Xunit;
using System.Linq;

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

            var coup = CreateNewCoupon(3);
            var sub = new Subscription(account, plan, "USD");
            sub.TotalBillingCycles = 5;
            sub.Coupon = coup;
            Assert.Null(sub.TaxInCents);
            Assert.Null(sub.TaxType);
            Assert.Null(sub.TaxRate);
            sub.Create();

            sub.ActivatedAt.Should().HaveValue().And.NotBe(default(DateTime));
            sub.State.Should().Be(Subscription.SubscriptionState.Active);
            Assert.Equal(5, sub.TotalBillingCycles);
            Assert.Equal(coup.CouponCode, sub.Coupon.CouponCode);
            Assert.Equal(9, sub.TaxInCents.Value);
            Assert.Equal("usst", sub.TaxType);
            Assert.Equal(0.0875M, sub.TaxRate.Value);

            var sub1 = Subscriptions.Get(sub.Uuid);
            Assert.Equal(5, sub1.TotalBillingCycles);

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

            sub.ChangeSubscription(); // change "Now" is default

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
        public void UpdateNotesSubscription()
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

            sub.UpdateNotes("New Customer Notes", "New T and C", "New VAT Notes");

            sub.CustomerNotes.Should().Be("New Customer Notes");
            sub.TermsAndConditions.Should().Be("New T and C");
            sub.VatReverseChargeNotes.Should().Be("New VAT Notes");

        }

        [Fact]
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

                addon1 = plan.NewAddOn("addon1", "addon1");
                addon1.DisplayQuantityOnHostedPage = true;
                addon1.UnitAmountInCents.Add("USD", 100);
                addon1.DefaultQuantity = 1;
                addon1.Create();

                plan = Plans.Get(plan.PlanCode);

                var addon_test_1 = plan.GetAddOn("addon1");
                Assert.Equal(addon1.UnitAmountInCents["USD"], addon_test_1.UnitAmountInCents["USD"]);

                plan2 = new Plan(GetMockPlanCode(), "aarons test plan 2")
                {
                    Description = "Create Subscription Plan With Addons Test 2"
                };
                plan2.UnitAmountInCents.Add("USD", 1900);
                plan2.Create();

                addon2 = plan2.NewAddOn("addon1", "addon2");
                addon2.DisplayQuantityOnHostedPage = true;
                addon2.UnitAmountInCents.Add("USD", 200);
                addon2.DefaultQuantity = 1;
                addon2.Create();

                var addon_test_2 = plan2.GetAddOn("addon1");
                Assert.Equal(addon2.UnitAmountInCents["USD"], addon_test_2.UnitAmountInCents["USD"]);

                account = CreateNewAccountWithBillingInfo();

                sub = new Subscription(account, plan, "USD");
                sub.AddOns.Add(new SubscriptionAddOn("addon1", 100, 1)); // TODO allow passing just the addon code
                sub.Create();

                // confirm that Create() doesn't duplicate the AddOns
                Assert.Equal(1, sub.AddOns.Count);

                sub.ActivatedAt.Should().HaveValue().And.NotBe(default(DateTime));
                sub.State.Should().Be(Subscription.SubscriptionState.Active);

                // test changing the plan of a subscription

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
                Assert.Equal(1, sub3.AddOns.Count);
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

        [Fact]
        [Trait("include", "y")]
        public void SubscriptionAddOverloads()
        {
            Plan plan = null;
            Account account = null;
            Subscription sub = null;
            System.Collections.Generic.List<AddOn> addons = new System.Collections.Generic.List<AddOn>();

            try
            {
                plan = new Plan(GetMockPlanCode(), "subscription addon overload plan")
                {
                    Description = "Create Subscription Plan With Addons Test"
                };
                plan.UnitAmountInCents.Add("USD", 100);
                plan.Create();

                int numberOfAddons = 7;

                for (int i = 0; i < numberOfAddons; ++i)
                {
                    var name = "Addon" + i.AsString();
                    var addon = plan.NewAddOn(name, name);
                    addon.DisplayQuantityOnHostedPage = true;
                    addon.UnitAmountInCents.Add("USD", 1000 + i);
                    addon.DefaultQuantity = i;
                    addon.Create();
                    addons.Add(addon);
                }

                account = CreateNewAccountWithBillingInfo();

                sub = new Subscription(account, plan, "USD");
                Assert.NotNull(sub.AddOns);

                sub.AddOns.Add(new SubscriptionAddOn("Addon0", 100, 1));
                sub.AddOns.Add(addons[1]);
                sub.AddOns.Add(addons[2], 2);
                sub.AddOns.Add(addons[3], 3, 100);
                sub.AddOns.Add(addons[4].AddOnCode);
                sub.AddOns.Add(addons[5].AddOnCode, 4);
                sub.AddOns.Add(addons[6].AddOnCode, 5, 100);

                sub.Create();
                sub.State.Should().Be(Subscription.SubscriptionState.Active);

                for (int i = 0; i < numberOfAddons; ++i)
                {
                    var code = "Addon" + i.AsString();
                    var addon = sub.AddOns.AsQueryable().First(x => x.AddOnCode == code);
                    Assert.NotNull(addon);
                }

                sub.AddOns.RemoveAt(0);
                Assert.Equal(6, sub.AddOns.Count);

                sub.AddOns.Clear();
                Assert.Equal(0, sub.AddOns.Count);

                var subaddon = new SubscriptionAddOn("a",1);
                var list = new System.Collections.Generic.List<SubscriptionAddOn>();
                list.Add(subaddon);
                sub.AddOns.AddRange(list);
                Assert.Equal(1, sub.AddOns.Capacity);

                Assert.DoesNotThrow(delegate {
                    sub.AddOns.AsReadOnly();
                });

                Assert.True(sub.AddOns.Contains(subaddon));

                Predicate<SubscriptionAddOn> p = x => x.AddOnCode == "a";
                Assert.True(sub.AddOns.Exists(p));
                Assert.NotNull(sub.AddOns.Find(p));
                Assert.Equal(1, sub.AddOns.FindAll(p).Count);
                Assert.NotNull(sub.AddOns.FindLast(p));

                int count = 0;
                sub.AddOns.ForEach(delegate(SubscriptionAddOn s)
                {
                    count++;
                });
                Assert.Equal(1, count);

                Assert.Equal(0, sub.AddOns.IndexOf(subaddon));

                Assert.DoesNotThrow(delegate {
                    sub.AddOns.Reverse();
                    sub.AddOns.Sort();
                });
            }
            finally
            {
                try
                {
                    if (sub != null && sub.Uuid != null) sub.Cancel();
                    if (plan != null) plan.Deactivate();
                    if (account != null) account.Close();
                }
                catch (RecurlyException e) { }
            }
        }

        [Fact]
        public void PreviewSubscription()
        {
            var plan = new Plan(GetMockPlanCode(), GetMockPlanName())
            {
                Description = "Preview Subscription Test"
            };
            plan.UnitAmountInCents.Add("USD", 1500);
            plan.Create();
            PlansToDeactivateOnDispose.Add(plan);

            var account = CreateNewAccountWithBillingInfo();

            var sub = new Subscription(account, plan, "USD");
            sub.UnitAmountInCents = 100;
            Assert.Null(sub.TaxType);
            Assert.DoesNotThrow(delegate { sub.Preview(); });
            Assert.Equal("usst", sub.TaxType);
            Assert.Equal(Subscription.SubscriptionState.Pending, sub.State);

            sub.Create();
            Assert.Throws<Recurly.RecurlyException>(
                delegate
                {
                    sub.Preview();
                }
            );

            sub.Terminate(Subscription.RefundType.None);
            account.Close();
        }
    }
}
