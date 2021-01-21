using System;
using FluentAssertions;
using Xunit;

namespace Recurly.Test
{
  public class SubscriptionAddOnTest : BaseTest
  {
    [RecurlyFact(TestEnvironment.Type.Integration)]
    public void CreateSubscriptionAddOn()
    {
      var account = CreateNewAccountWithBillingInfo();   
      var plan = new Plan(GetMockPlanCode(), GetMockPlanName()) {Description = "Test Lookup"};
      plan.UnitAmountInCents.Add("USD", 100);
      plan.Create();
      PlansToDeactivateOnDispose.Add(plan);

      var addon = plan.NewAddOn("extra-padding", "Extra Padding");
      addon.UnitAmountInCents.Add("USD", 200);
      addon.DefaultQuantity = 1;
      addon.DisplayQuantityOnHostedPage = true;
      addon.Create();

      var subscription = new Subscription(account, plan, "USD");
      subscription.AddOns.Add(addon.AddOnCode, 3);
      subscription.Create();

      subscription.AddOns[0].Quantity.Should().Be(3);
      subscription.AddOns[0].AddOnCode.Should().Be("extra-padding");
    }

    [RecurlyFact(TestEnvironment.Type.Integration)]
    public void CreateSubscriptionAddOnWithTiers()
    {
      var account = CreateNewAccountWithBillingInfo();   
      var plan = new Plan(GetMockPlanCode(), GetMockPlanName()) {Description = "Test Lookup"};
      plan.UnitAmountInCents.Add("USD", 100);
      plan.Create();
      PlansToDeactivateOnDispose.Add(plan);

      var addon = plan.NewAddOn("tiered-add-on", "Tiered Add-On");
      addon.TierType = "tiered";
      addon.DisplayQuantityOnHostedPage = true;

      var tier1 = new Tier();
      tier1.UnitAmountInCents.Add("USD", 123);
      tier1.EndingQuantity = 50;
      addon.Tiers.Add(tier1);

      var tier2 = new Tier();
      tier2.UnitAmountInCents.Add("USD", 99);
      addon.Tiers.Add(tier2);

      addon.Create();

      var subscription = new Subscription(account, plan, "USD");
      subscription.AddOns.Add(plan.GetAddOn(addon.AddOnCode), addon.TierType, 2);
      subscription.Create();

      subscription.AddOns[0].Tiers[0].UnitAmountInCents.Should().Be(123);
      subscription.AddOns[0].Tiers[1].EndingQuantity.Should().Be(999999999);
    }

    [RecurlyFact(TestEnvironment.Type.Integration)]
    public void UpdateSubscriptionAddOn()
    {
      var account = CreateNewAccountWithBillingInfo();   
      var plan = new Plan(GetMockPlanCode(), GetMockPlanName()) {Description = "Test Lookup"};
      plan.UnitAmountInCents.Add("USD", 100);
      plan.Create();
      PlansToDeactivateOnDispose.Add(plan);

      var addon = plan.NewAddOn("extra-padding", "Extra Padding");
      addon.UnitAmountInCents.Add("USD", 200);
      addon.DefaultQuantity = 1;
      addon.DisplayQuantityOnHostedPage = true;
      addon.Create();

      var subscription = new Subscription(account, plan, "USD");
      subscription.AddOns.Add(addon.AddOnCode, 3);
      subscription.Create();

      subscription.Quantity.Should().Be(1);
      subscription.AddOns[0].Quantity.Should().Be(3);

      var change = new SubscriptionChange {
        TimeFrame = SubscriptionChange.ChangeTimeframe.Now,
        Quantity = 2,
        AddOns = new SubscriptionAddOnList()
      };

      var quantity = 3;
      var amountInCents = 199;
      change.AddOns.Add(addon.AddOnCode, quantity, amountInCents);

      subscription = Subscription.ChangeSubscription(subscription.Uuid, change);

      subscription.Quantity.Should().Be(2);
      subscription.AddOns[0].Quantity.Should().Be(3);
    }

    [RecurlyFact(TestEnvironment.Type.Integration)]
    public void UpdateSubscriptionAddOnWithTiers()
    {
      var account = CreateNewAccountWithBillingInfo();   
      var plan = new Plan(GetMockPlanCode(), GetMockPlanName()) {Description = "Test Lookup"};
      plan.UnitAmountInCents.Add("USD", 100);
      plan.Create();
      PlansToDeactivateOnDispose.Add(plan);

      var addon = plan.NewAddOn("tiered-add-on", "Tiered Add-On");
      addon.TierType = "tiered";
      addon.DisplayQuantityOnHostedPage = true;

      var tier1 = new Tier();
      tier1.UnitAmountInCents.Add("USD", 100);
      tier1.EndingQuantity = 50;
      addon.Tiers.Add(tier1);

      var tier2 = new Tier();
      tier2.UnitAmountInCents.Add("USD", 89);
      addon.Tiers.Add(tier2);

      addon.Create();

      var subscription = new Subscription(account, plan, "USD");
      subscription.AddOns.Add(plan.GetAddOn(addon.AddOnCode), addon.TierType, 2);
      subscription.Create();

      var change = new SubscriptionChange {
        TimeFrame = SubscriptionChange.ChangeTimeframe.Now,
        AddOns = new SubscriptionAddOnList()
      };
      SubscriptionAddOn subaddon = subscription.AddOns[0];
      var subTier1 = subaddon.Tiers[0];
      subTier1.UnitAmountInCents = 99;
      var subTier2 = subaddon.Tiers[1];
      subTier2.UnitAmountInCents = 79;
      change.AddOns.Add(subaddon);

      Subscription.ChangeSubscription(subscription.Uuid, change);

      subscription.AddOns[0].Tiers[0].UnitAmountInCents.Should().Be(99);
      subscription.AddOns[0].Tiers[1].UnitAmountInCents.Should().Be(79);
    }
  }
}
