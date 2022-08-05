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
            var plan = new Plan(GetMockPlanCode(), GetMockPlanName()) { Description = "Test Lookup" };
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
            var plan = new Plan(GetMockPlanCode(), GetMockPlanName()) { Description = "Test Lookup" };
            plan.UnitAmountInCents.Add("USD", 100);
            plan.Create();
            PlansToDeactivateOnDispose.Add(plan);

            var addon = plan.NewAddOn("extra-padding", "Extra Padding");
            addon.TierType = "tiered";
            addon.DisplayQuantityOnHostedPage = true;
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

        [RecurlyFact(TestEnvironment.Type.Integration)]
        public void CreateAddOnWithPercentageTiers()
        {
            var plan = new Plan(GetMockPlanCode(), GetMockPlanName()) { Description = "Test Lookup" };
            plan.UnitAmountInCents.Add("USD", 100);
            plan.Create();
            PlansToDeactivateOnDispose.Add(plan);
            var measuredUnit = new MeasuredUnit(
              GetMockMeasuredUnitName(),
              "GB",
              "Video steaming bandwidth measured in gigabytes");
            measuredUnit.Create();

            var addon = plan.NewAddOn("extra-padding", "Extra Padding");
            addon.TierType = "tiered";
            addon.AddOnType = AddOn.Type.Usage;
            addon.UsageType = Usage.Type.Percentage;
            addon.DisplayQuantityOnHostedPage = true;
            addon.MeasuredUnitId = measuredUnit.Id;

            var currencyPercentageTier = new CurrencyPercentageTier();
            currencyPercentageTier.Currency = "USD";

            var percentageTier = new PercentageTier();
            percentageTier.EndingAmountInCents = 1000;
            percentageTier.UsagePercentage = "30";
            currencyPercentageTier.PercentageTiers.Add(percentageTier);

            var otherPercentageTier = new PercentageTier();
            otherPercentageTier.UsagePercentage = "40";
            currencyPercentageTier.PercentageTiers.Add(otherPercentageTier);

            addon.CurrencyPercentageTiers.Add(currencyPercentageTier);
            addon.Create();

            addon.CurrencyPercentageTiers.Count.Should().Be(1);
            addon.CurrencyPercentageTiers[0].PercentageTiers.Count.Should().Be(2);
            addon.UsageTimeframe.Should().Be("billing_period");
        }

        [RecurlyFact(TestEnvironment.Type.Integration)]
        public void UpdateAddOn()
        {
            var plan = new Plan(GetMockPlanCode(), GetMockPlanName()) { Description = "Test Lookup" };
            plan.UnitAmountInCents.Add("USD", 100);
            plan.Create();
            PlansToDeactivateOnDispose.Add(plan);

            var addon = plan.NewAddOn("extra-padding", "Extra Padding");
            addon.TierType = "tiered";
            addon.DisplayQuantityOnHostedPage = true;
            var tier = new Tier();
            tier.UnitAmountInCents.Add("USD", 100);
            tier.EndingQuantity = 60;
            addon.Tiers.Add(tier);
            var anotherTier = new Tier();
            anotherTier.UnitAmountInCents.Add("USD", 50);
            addon.Tiers.Add(anotherTier);
            addon.Create();

            addon.Name = "Deluxe Padding";
            addon.Tiers[0].UnitAmountInCents["USD"] = 75;
            addon.Update();

            addon.Name.Should().Be("Deluxe Padding");
            addon.Tiers[0].UnitAmountInCents.Should().Contain("USD", 75);
        }

        [RecurlyFact(TestEnvironment.Type.Integration)]
        public void UpdateAddOnWithPercentageTiers()
        {
            var plan = new Plan(GetMockPlanCode(), GetMockPlanName()) { Description = "Test Lookup" };
            plan.UnitAmountInCents.Add("USD", 100);
            plan.Create();
            PlansToDeactivateOnDispose.Add(plan);
            var measuredUnit = new MeasuredUnit(
              GetMockMeasuredUnitName(),
              "GB",
              "Video steaming bandwidth measured in gigabytes");
            measuredUnit.Create();

            var addon = plan.NewAddOn("extra-padding", "Extra Padding");
            addon.TierType = "tiered";
            addon.AddOnType = AddOn.Type.Usage;
            addon.UsageType = Usage.Type.Percentage;
            addon.DisplayQuantityOnHostedPage = true;
            addon.MeasuredUnitId = measuredUnit.Id;

            var currencyPercentageTier = new CurrencyPercentageTier();
            currencyPercentageTier.Currency = "USD";

            var percentageTier = new PercentageTier();
            percentageTier.EndingAmountInCents = 1000;
            percentageTier.UsagePercentage = "30";
            currencyPercentageTier.PercentageTiers.Add(percentageTier);

            var otherPercentageTier = new PercentageTier();
            otherPercentageTier.UsagePercentage = "40";
            currencyPercentageTier.PercentageTiers.Add(otherPercentageTier);

            addon.CurrencyPercentageTiers.Add(currencyPercentageTier);
            addon.Create();

            addon.CurrencyPercentageTiers[0].PercentageTiers[0].EndingAmountInCents = 2000;
            addon.CurrencyPercentageTiers[0].PercentageTiers[0].UsagePercentage = "25";

            addon.Update();

            addon.CurrencyPercentageTiers[0].PercentageTiers[0].EndingAmountInCents.Should().Be(2000);
            addon.CurrencyPercentageTiers[0].PercentageTiers[0].UsagePercentage.Should().Be("25");
        }
    }
}
