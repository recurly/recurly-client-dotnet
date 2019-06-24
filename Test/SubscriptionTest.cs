﻿using System;
using FluentAssertions;
using System.Collections.Generic;
using Xunit;
using System.Linq;

namespace Recurly.Test
{
    public class SubscriptionTest : BaseTest
    {
        [RecurlyFact(TestEnvironment.Type.Integration)]
        public Subscription LookupSubscription()
        {
            var plan = new Plan(GetMockPlanCode(), GetMockPlanName()) { Description = "Lookup Subscription Test" };
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
            return sub;
        }

        [RecurlyFact(TestEnvironment.Type.Integration)]
        public void LookupSubscriptionWithNullCouponCode()
        {
            var sub = LookupSubscription();
            Assert.Equal(null, sub.Coupon);
        }

        [RecurlyFact(TestEnvironment.Type.Integration)]
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

            var subChange = new SubscriptionChange()
            {
                UnitAmountInCents = 3000,
                TimeFrame = SubscriptionChange.ChangeTimeframe.Renewal
            };

            Subscription.ChangeSubscription(sub.Uuid, subChange);

            var newSubscription = Subscriptions.Get(sub.Uuid);
            newSubscription.PendingSubscription.Should().NotBeNull();
            newSubscription.PendingSubscription.UnitAmountInCents.Should().Be(3000);
        }

        [RecurlyFact(TestEnvironment.Type.Integration)]
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
            sub.CustomFields.Add(new CustomField("food", "taco"));
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
            Assert.Equal(0.085M, sub.TaxRate.Value);

            var sub1 = Subscriptions.Get(sub.Uuid);
            Assert.Equal(5, sub1.TotalBillingCycles);
            Assert.Equal(sub1.CustomFields.First().Name, "food");
            Assert.Equal(sub1.CustomFields.First().Value, "taco");
        }

        [RecurlyFact(TestEnvironment.Type.Integration)]
        public void CreateSubscription_TrialRequiresBillingInfo()
        {
            var plan = new Plan(GetMockPlanCode(), GetMockPlanName())
            {
                Description = "Create Subscription Test"
            };
            plan.UnitAmountInCents.Add("USD", 100);
            plan.TrialRequiresBillingInfo = true;
            plan.TrialIntervalLength = 10;
            plan.TrialIntervalUnit = Plan.IntervalUnit.Days;
            plan.Create();
            PlansToDeactivateOnDispose.Add(plan);

            var account = CreateNewAccount();

            var coup = CreateNewCoupon(3);
            var sub = new Subscription(account, plan, "USD");
            sub.TotalBillingCycles = 5;
            sub.Coupon = coup;
            sub.TrialPeriodEndsAt = DateTime.UtcNow.AddDays(2);

            Assert.Null(sub.TaxInCents);
            Assert.Null(sub.TaxType);
            Assert.Null(sub.TaxRate);

            try
            {
                sub.Create();
            }
            catch (RecurlyException e)
            {
                Assert.True(e.Errors.Any());
                Assert.True(e.Errors[0].Symbol == "billing_info_required");
                return;
            }

            throw new Exception("test failed");
        }

        [RecurlyFact(TestEnvironment.Type.Integration)]
        public void CreateSubscription_BillingInfoHasReason()
        {
            var plan = new Plan(GetMockPlanCode(), GetMockPlanName())
            {
                Description = "Create Subscription Test"
            };
            plan.UnitAmountInCents.Add("USD", 100);
            plan.TrialRequiresBillingInfo = false;
            plan.TrialIntervalLength = 10;
            plan.TrialIntervalUnit = Plan.IntervalUnit.Days;
            plan.Create();
            PlansToDeactivateOnDispose.Add(plan);

            var account = CreateNewAccount();

            var coup = CreateNewCoupon(3);
            var sub = new Subscription(account, plan, "USD");
            sub.TotalBillingCycles = 5;
            sub.Coupon = coup;
            sub.TrialPeriodEndsAt = DateTime.UtcNow.AddDays(2);

            Assert.Null(sub.TaxInCents);
            Assert.Null(sub.TaxType);
            Assert.Null(sub.TaxRate);

            sub.Create();
            Assert.True(sub.NoBillingInfoReason != null);
        }

        [RecurlyFact(TestEnvironment.Type.Integration)]
        public void CreateBulkSubscriptions()
        {
            var plan = new Plan(GetMockPlanCode(), GetMockPlanName())
            {
                Description = "Create Bulk Subscription Test"
            };
            plan.UnitAmountInCents.Add("USD", 100);
            plan.Create();
            PlansToDeactivateOnDispose.Add(plan);

            var account = CreateNewAccountWithBillingInfo();

            for (int i = 1; i < 4; i++)
            {
                var sub = new Subscription(account, plan, "USD");
                sub.Bulk = true;
                sub.Create();

                sub.ActivatedAt.Should().HaveValue().And.NotBe(default(DateTime));
                sub.State.Should().Be(Subscription.SubscriptionState.Active);

            }

        }

        [RecurlyFact(TestEnvironment.Type.Integration)]
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

        [RecurlyFact(TestEnvironment.Type.Integration)]
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

            var subChange = new SubscriptionChange()
            {
                PlanCode = plan2.PlanCode
            };

            Subscription.ChangeSubscription(sub.Uuid, subChange);

            var newSubscription = Subscriptions.Get(sub.Uuid);

            newSubscription.PendingSubscription.Should().BeNull();
            newSubscription.Plan.Should().Be(plan2);
        }

        [RecurlyFact(TestEnvironment.Type.Integration)]
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

        [RecurlyFact(TestEnvironment.Type.Integration)]
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

        [RecurlyFact(TestEnvironment.Type.Integration)]
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

        [RecurlyFact(TestEnvironment.Type.Integration)]
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

        [RecurlyFact(TestEnvironment.Type.Integration)]
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

        [RecurlyFact(TestEnvironment.Type.Integration)]
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
            diff.Should().Be(0);
        }

        [RecurlyFact(TestEnvironment.Type.Integration)]
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

            Dictionary<string, string> notes = new Dictionary<string, string>();

            notes.Add("CustomerNotes", "New Customer Notes");
            notes.Add("TermsAndConditions", "New T and C");
            notes.Add("VatReverseChargeNotes", "New VAT Notes");
            notes.Add("GatewayCode", "jhq4mlfe7wtw");
            sub.CustomFields.Add(new CustomField("food", "taco"));

            sub.UpdateNotes(notes);

            sub.CustomerNotes.Should().Be(notes["CustomerNotes"]);
            sub.TermsAndConditions.Should().Be(notes["TermsAndConditions"]);
            sub.VatReverseChargeNotes.Should().Be(notes["VatReverseChargeNotes"]);
            sub.GatewayCode.Should().Be(notes["GatewayCode"]);
            sub.CustomFields.Should().Contain(cf => cf.Name == "food");
            sub.CustomFields.Should().Contain(cf => cf.Value == "taco");

        }

        [RecurlyFact(TestEnvironment.Type.Integration)]
        public void CreateSubscriptionPlanWithAddons()
        {
            Plan plan = null;
            Plan plan2 = null;
            IAddOn addon1 = null;
            IAddOn addon2 = null;
            IAccount account = null;
            Subscription sub = null;
            Subscription sub2 = null;
            SubscriptionChange subChange = null;

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
                addon1.AddOnType = AddOn.Type.Fixed;
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
                addon2.AddOnType = AddOn.Type.Fixed;
                addon2.DefaultQuantity = 1;
                addon2.Create();

                var addon_test_2 = plan2.GetAddOn("addon1");
                Assert.Equal(addon2.UnitAmountInCents["USD"], addon_test_2.UnitAmountInCents["USD"]);

                account = CreateNewAccountWithBillingInfo();

                sub = new Subscription(account, plan, "USD");
                sub.AddOns.Add(new SubscriptionAddOn("addon1", AddOn.Type.Fixed, 100, 1)); // TODO allow passing just the addon code
                sub.Create();

                // confirm that Create() doesn't duplicate the AddOns
                Assert.Equal(1, sub.AddOns.Count);

                sub.ActivatedAt.Should().HaveValue().And.NotBe(default(DateTime));
                sub.State.Should().Be(Subscription.SubscriptionState.Active);

                // test changing the plan of a subscription

                subChange = new SubscriptionChange()
                {
                    UnitAmountInCents = plan2.UnitAmountInCents["USD"],
                    PlanCode = plan2.PlanCode,
                    AddOns = sub.AddOns
                };

                foreach (var addOn in subChange.AddOns)
                {
                    addOn.UnitAmountInCents = plan2.UnitAmountInCents["USD"];
                }

                Subscription.ChangeSubscription(sub.Uuid, subChange);

                // check if the changes were saved
                sub2 = Subscriptions.Get(sub.Uuid);
                sub2.UnitAmountInCents.Should().Equals(plan2.UnitAmountInCents["USD"]);
                Assert.Equal(1, sub2.AddOns.Count);
                foreach (var addOn in sub2.AddOns)
                {
                    addOn.UnitAmountInCents.Should().Equals(plan2.UnitAmountInCents["USD"]);
                }

            }
            finally
            {
                if (sub != null) sub.Cancel();
                if (plan2 != null) plan2.Deactivate();
                if (plan != null) plan.Deactivate();
                if (account != null) account.Close();
            }
        }

        [RecurlyFact(TestEnvironment.Type.Integration)]
        [Trait("include", "y")]
        public void SubscriptionAddOverloads()
        {
            Plan plan = null;
            Account account = null;
            Subscription sub = null;
            System.Collections.Generic.List<IAddOn> addons = new System.Collections.Generic.List<IAddOn>();

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
                    addon.AddOnType = AddOn.Type.Fixed;
                    addon.UnitAmountInCents.Add("USD", 1000 + i);
                    addon.DefaultQuantity = i + 1;
                    addon.Create();
                    addons.Add(addon);
                }

                account = CreateNewAccountWithBillingInfo();

                sub = new Subscription(account, plan, "USD");
                Assert.NotNull(sub.AddOns);

                sub.AddOns.Add(new SubscriptionAddOn("Addon0", AddOn.Type.Fixed, 100, 1));
                sub.AddOns.Add(addons[1]);
                sub.AddOns.Add(addons[2], 2);
                sub.AddOns.Add(addons[3], 3, 100);
                sub.AddOns.Add(addons[4].AddOnCode, addons[4].AddOnType.Value);
                sub.AddOns.Add(addons[5].AddOnCode, addons[5].AddOnType.Value, 4);
                sub.AddOns.Add(addons[6].AddOnCode, addons[6].AddOnType.Value, 5, 100);

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

                var subaddon = new SubscriptionAddOn("a", AddOn.Type.Fixed, 1);
                var list = new System.Collections.Generic.List<SubscriptionAddOn>();
                list.Add(subaddon);
                sub.AddOns.AddRange(list);
                Assert.Equal(1, sub.AddOns.Count);


                sub.AddOns.AsReadOnly();

                Assert.True(sub.AddOns.Contains(subaddon));

                Predicate<SubscriptionAddOn> p = x => x.AddOnCode == "a";
                Assert.True(sub.AddOns.Exists(p));
                Assert.NotNull(sub.AddOns.Find(p));
                Assert.Equal(1, sub.AddOns.FindAll(p).Count());
                Assert.NotNull(sub.AddOns.FindLast(p));

                int count = 0;
                sub.AddOns.ForEach(delegate (SubscriptionAddOn s)
                {
                    count++;
                });
                Assert.Equal(1, count);

                Assert.Equal(0, sub.AddOns.IndexOf(subaddon));

                sub.AddOns.Reverse();
                sub.AddOns.Sort();
            }
            finally
            {
                try
                {
                    if (sub != null && sub.Uuid != null) sub.Cancel();
                    if (plan != null) plan.Deactivate();
                    if (account != null) account.Close();
                }
                catch (RecurlyException) { }
            }
        }

        [RecurlyFact(TestEnvironment.Type.Integration)]
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
            sub.Preview();
            Assert.Equal("usst", sub.TaxType);
            Assert.Equal(Subscription.SubscriptionState.Active, sub.State);

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
