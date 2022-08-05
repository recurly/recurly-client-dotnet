using System.Linq;
using FluentAssertions;
using Xunit;

namespace Recurly.Test
{
    public class PlanListTest : BaseTest
    {
        [RecurlyFact(TestEnvironment.Type.Integration)]
        public void ListPlans()
        {
            var plan = new Plan(GetMockPlanCode(), GetMockPlanName());
            plan.SetupFeeInCents.Add("USD", 100);
            plan.Create();
            PlansToDeactivateOnDispose.Add(plan);

            var plans = Plans.List();
            plans.Should().NotBeEmpty();
        }

        [RecurlyFact(TestEnvironment.Type.Integration)]
        public void ListPlansWithRampIntervals()
        {
            var plan = new Plan(GetMockPlanCode(), GetMockPlanName()) { Description = "Test Plan List with Ramps" };
            plan.SetupFeeInCents.Add("USD", 0);
            plan.PricingModel = PricingModelType.Ramp;
            plan.RampIntervals = GetMockRampIntervals(3);
            plan.Create();
            PlansToDeactivateOnDispose.Add(plan);

            var plans = Plans.List();
            var rampPlan = plans.FirstOrDefault(p => p.PricingModel == PricingModelType.Ramp);
            rampPlan.Should().NotBeNull();
            rampPlan.RampIntervals.Count.Should().Be(3);
        }

        [Fact(Skip = "utility, for cleaning up test data; may no longer be necessary")]
        public void DeactivateAllPlans()
        {
            var plans = Plans.List();
            foreach (var plan in plans)
            {
                plan.Deactivate();
            }
        }
    }
}
