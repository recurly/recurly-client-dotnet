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
