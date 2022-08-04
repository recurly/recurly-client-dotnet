using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;
using System.Linq;

namespace Recurly.Test
{
    public class PlanTest : BaseTest
    {
        [RecurlyFact(TestEnvironment.Type.Integration)]
        public void LookupPlan()
        {
            var plan = new Plan(GetMockPlanCode(), GetMockPlanName()) {Description = "Test Lookup"};
            plan.UnitAmountInCents.Add("USD", 100);
            plan.TaxExempt = true;
            plan.TotalBillingCycles = 6;

            plan.Create();
            PlansToDeactivateOnDispose.Add(plan);

            plan.CreatedAt.Should().NotBe(default(DateTime));
            plan.TotalBillingCycles.Value.Should().Be(6);

            var fromService = Plans.Get(plan.PlanCode);
            fromService.PlanCode.Should().Be(plan.PlanCode);
            fromService.UnitAmountInCents.Should().Contain("USD", 100);
            fromService.Description.Should().Be("Test Lookup");
            Assert.True(plan.TaxExempt.Value);
        }

        [RecurlyFact(TestEnvironment.Type.Integration)]
        public void LookupPlanWithRamps()
        {
            var plan = new Plan(GetMockPlanCode(), GetMockPlanName()) { Description = "Test Ramp Lookup" };
            plan.SetupFeeInCents.Add("USD", 0);
            plan.PricingModel = PricingModelType.Ramp;
            plan.RampIntervals = GetMockRampIntervals(3);

            plan.Create();
            PlansToDeactivateOnDispose.Add(plan);

            var fromService = Plans.Get(plan.PlanCode);
            fromService.PricingModel.Should().Be(PricingModelType.Ramp);
            fromService.RampIntervals.Count.Should().Be(3);
        }

        [RecurlyFact(TestEnvironment.Type.Integration)]
        public void LookupPlanWithRampsMultiCurrency()
        {
            var plan = new Plan(GetMockPlanCode(), GetMockPlanName()) { Description = "Test Create Multicurrency Plan with Ramps" };
            plan.SetupFeeInCents.Add("USD", 0);

            plan.PricingModel = PricingModelType.Ramp;
            plan.RampIntervals = GetMockRampIntervalsMultiCurrency(3);

            plan.Create();
            PlansToDeactivateOnDispose.Add(plan);

            var fromService = Plans.Get(plan.PlanCode);
            fromService.PricingModel.Should().Be(PricingModelType.Ramp);
            fromService.RampIntervals[0].Currencies.Count.Should().Be(2);
            fromService.RampIntervals[1].Currencies.Count.Should().Be(2);
        }

        [RecurlyFact(TestEnvironment.Type.Integration)]
        public void CreatePlanWithRamps()
        {
            var plan = new Plan(GetMockPlanCode(), GetMockPlanName()) { Description = "Test Create Plan with Ramps" };
            plan.TaxExempt = true;
            plan.PlanIntervalLength = 12;
            plan.PlanIntervalUnit = Plan.IntervalUnit.Months;
            plan.SetupFeeInCents.Add("USD", 0);
            plan.PricingModel = PricingModelType.Ramp;
            plan.RampIntervals = GetMockRampIntervals(2);

            plan.Create();
            PlansToDeactivateOnDispose.Add(plan);

            var fromService = Plans.Get(plan.PlanCode);
            fromService.PricingModel.Should().Be(PricingModelType.Ramp);
            var firstRamp = fromService.RampIntervals[0];
            var secondRamp = fromService.RampIntervals[1];

            firstRamp.StartingBillingCycle.Should().Be(1);
            firstRamp.Currencies.First().Currency.Should().Be("USD");
            firstRamp.Currencies.First().UnitAmountInCents.Should().Be(200);
            secondRamp.StartingBillingCycle.Should().Be(3);
            secondRamp.Currencies.First().Currency.Should().Be("USD");
            secondRamp.Currencies.First().UnitAmountInCents.Should().Be(400);
        }

        [RecurlyFact(TestEnvironment.Type.Integration)]
        public void UpdatePlanWithRamps()
        {
            var plan = new Plan(GetMockPlanCode(), GetMockPlanName()) { Description = "Test Update Plan with Ramps" };
            plan.SetupFeeInCents.Add("USD", 0);
            plan.PricingModel = PricingModelType.Ramp;
            plan.RampIntervals = GetMockRampIntervals(2);
            plan.Create();
            PlansToDeactivateOnDispose.Add(plan);

            plan.RampIntervals = GetMockRampIntervalsMultiCurrency(4);
            plan.Update();

            var updatedPlan = Plans.Get(plan.PlanCode);
            updatedPlan.PricingModel.Should().Be(PricingModelType.Ramp);
            updatedPlan.RampIntervals.Count.Should().Be(4);

            updatedPlan.RampIntervals.ForEach(
                ramp => ramp.Currencies.Count.Should().Be(2)
            );
        }

        [RecurlyFact(TestEnvironment.Type.Integration)]
        public void FixedPricingModelPlan()
        {
            var plan = new Plan(GetMockPlanCode(), GetMockPlanName()) { Description = "Test Fixed Plan Lookup" };
            plan.SetupFeeInCents.Add("USD", 0);
            plan.UnitAmountInCents.Add("USD", 500);
            plan.TaxExempt = false;
            plan.PlanIntervalLength = 12;
            plan.PlanIntervalUnit = Plan.IntervalUnit.Months;

            plan.Create();
            PlansToDeactivateOnDispose.Add(plan);

            var fromService = Plans.Get(plan.PlanCode);
            fromService.PricingModel.Should().Be(PricingModelType.Fixed);
        }

        [RecurlyFact(TestEnvironment.Type.Integration)]
        public void CreatePlanSmall()
        {
            var plan = new Plan(GetMockPlanCode(), GetMockPlanName());
            plan.SetupFeeInCents.Add("USD", 100);
            plan.Create();
            PlansToDeactivateOnDispose.Add(plan);

            plan.CreatedAt.Should().NotBe(default(DateTime));
            plan.SetupFeeInCents.Should().Contain("USD", 100);
        }

        [RecurlyFact(TestEnvironment.Type.Integration)]
        public void CreatePlan()
        {
            var plan = new Plan(GetMockPlanCode(), GetMockPlanName())
            {
                AccountingCode = "accountingcode123",
                SetupFeeAccountingCode = "setupfeeac",
                Description = "a test plan",
                DisplayDonationAmounts = true,
                DisplayPhoneNumber = false,
                DisplayQuantity = true,
                TotalBillingCycles = 5,
                TrialIntervalUnit = Plan.IntervalUnit.Months,
                TrialIntervalLength = 1,
                PlanIntervalUnit = Plan.IntervalUnit.Days,
                PlanIntervalLength = 180,
                DunningCampaignId = "p050sudtexvv"
            };
            plan.SetupFeeInCents.Add("USD", 500);
            plan.Create();
            PlansToDeactivateOnDispose.Add(plan);

            plan.CreatedAt.Should().NotBe(default(DateTime));
            plan.AccountingCode.Should().Be("accountingcode123");
            plan.SetupFeeAccountingCode.Should().Be("setupfeeac");
            plan.Description.Should().Be("a test plan");
            plan.DisplayDonationAmounts.Should().HaveValue().And.Be(true);
            plan.DisplayPhoneNumber.Should().HaveValue().And.Be(false);
            plan.DisplayQuantity.Should().HaveValue().And.Be(true);
            plan.TotalBillingCycles.Should().Be(5);
            plan.TrialIntervalUnit.Should().Be(Plan.IntervalUnit.Months);
            plan.TrialIntervalLength.Should().Be(1);
            plan.PlanIntervalUnit.Should().Be(Plan.IntervalUnit.Days);
            plan.PlanIntervalLength.Should().Be(180);
            plan.DunningCampaignId.Should().Be("p050sudtexvv");
        }

        [RecurlyFact(TestEnvironment.Type.Integration)]
        public void CreatePlanWithAddOn()
        {
            var plan = new Plan(GetMockPlanCode(), GetMockPlanName());
            plan.SetupFeeInCents.Add("USD", 500);
            plan.Create();
            PlansToDeactivateOnDispose.Add(plan);

            var addon = plan.NewAddOn("add_on", "Add on");
            addon.UnitAmountInCents.Add("USD", 200);
            addon.Create();

            plan.AddOns[0].AddOnCode.Should().Be(addon.AddOnCode);
        }

        [RecurlyFact(TestEnvironment.Type.Integration)]
        public void CreatePlanWithItemBackedAddOn()
        {
            var plan = new Plan(GetMockPlanCode(), GetMockPlanName());
            plan.SetupFeeInCents.Add("USD", 500);
            plan.Create();
            PlansToDeactivateOnDispose.Add(plan);

            var item = new Item(GetMockItemCode(), GetMockItemName());
            item.Create();

            var addon = plan.NewAddOn(item.ItemCode);
            addon.UnitAmountInCents.Add("USD", 200);
            addon.Create();

            addon.ItemCode.Should().Be(item.ItemCode);
        }

        [RecurlyFact(TestEnvironment.Type.Integration)]
        public void UpdatePlan()
        {
            var plan = new Plan(GetMockPlanCode(), GetMockPlanName()) {Description = "Test Update"};
            plan.UnitAmountInCents.Add("USD", 100);
            plan.Create();
            PlansToDeactivateOnDispose.Add(plan);

            plan.UnitAmountInCents["USD"] = 5000;
            plan.SetupFeeInCents["USD"] = 100;
            plan.TaxExempt = false;

            plan.Update();

            plan = Plans.Get(plan.PlanCode);
            plan.UnitAmountInCents.Should().Contain("USD", 5000);
            plan.SetupFeeInCents.Should().Contain("USD", 100);
            Assert.False(plan.TaxExempt.Value);
        }

        [RecurlyFact(TestEnvironment.Type.Integration)]
        public void DeactivatePlan()
        {
            // Arrange
            var plan = new Plan(GetMockPlanCode(), GetMockPlanName()) {Description = "Test Delete"};
            plan.UnitAmountInCents.Add("USD", 100);
            plan.Create();
            PlansToDeactivateOnDispose.Add(plan);

            plan = Plans.Get(plan.PlanCode);
            plan.CreatedAt.Should().NotBe(default(DateTime));
            plan.UnitAmountInCents.Should().Contain("USD", 100);

            //Act
            plan.Deactivate();

            //Assert
            Action get = () => Plans.Get(plan.PlanCode);
            get.ShouldThrow<NotFoundException>();
        }

    }
}
