using System;
using FluentAssertions;
using Xunit;

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
            plan.Create();
            PlansToDeactivateOnDispose.Add(plan);

            plan.CreatedAt.Should().NotBe(default(DateTime));

            var fromService = Plans.Get(plan.PlanCode);
            fromService.PlanCode.Should().Be(plan.PlanCode);
            fromService.UnitAmountInCents.Should().Contain("USD", 100);
            fromService.Description.Should().Be("Test Lookup");
            Assert.True(plan.TaxExempt.Value);
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
                PlanIntervalLength = 180
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
