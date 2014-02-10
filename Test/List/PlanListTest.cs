using FluentAssertions;
using Xunit;

namespace Recurly.Test
{
    public class PlanListTest : BaseTest
    {
        [Fact]
        public void ListPlans()
        {
            var plan = new Plan(GetMockPlanCode(), GetMockPlanName());
            plan.SetupFeeInCents.Add("USD", 100);
            plan.Create();

            var plans = Plans.List();
            plans.Should().NotBeEmpty();

            plan.Deactivate();
        }

        [Fact]
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
