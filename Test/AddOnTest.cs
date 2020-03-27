using System;
using FluentAssertions;
using Xunit;

namespace Recurly.Test
{
  public class AddOnTest : BaseTest
  {
    [RecurlyFact(TestEnvironment.Type.Integration)]
    public void CreateAddOn()
    {
      var plan = new Plan(GetMockPlanCode(), GetMockPlanName()) {Description = "Test Lookup"};
      plan.UnitAmountInCents.Add("USD", 100);
      plan.Create();
      PlansToDeactivateOnDispose.Add(plan);

      var addon = plan.NewAddOn("extra-padding", "Extra Padding");
      addon.UnitAmountInCents.Add("USD", 200);
      addon.DefaultQuantity = 1;
      addon.DisplayQuantityOnHostedPage = true;
      addon.Create();

      addon.DefaultQuantity.Value.Should().Be(1);
    }

        [RecurlyFact(TestEnvironment.Type.Integration)]
    public void CreateAddOnWithTiers()
    {
      var plan = new Plan(GetMockPlanCode(), GetMockPlanName()) {Description = "Test Lookup"};
      plan.UnitAmountInCents.Add("USD", 100);
      plan.Create();
      PlansToDeactivateOnDispose.Add(plan);

      var addon = plan.NewAddOn("extra-padding", "Extra Padding");
      addon.TierType = "tiered";
      var tier = new Tier();
      tier.UnitAmountInCents.Add("USD", 100);
      tier.EndingQuantity = 60;
      addon.Tiers.Add(tier);
      var anotherTier = new Tier();
      anotherTier.UnitAmountInCents.Add("USD", 50);
      addon.Tiers.Add(anotherTier);
      addon.Create();

      addon.Tiers.Count.Should().Be(2);
    }

  }
}
