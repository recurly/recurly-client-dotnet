using NUnit.Framework;

namespace Recurly.Test
{
    [TestFixture]
    class PlanListTest : BaseTest
    {

        [Test]
        public void ListPlans()
        {
            Plan p = new Plan(GetMockPlanCode(), GetMockPlanName());
            p.SetupFeeInCents.Add("USD", 100);
            p.Create();

            p = new Plan(GetMockPlanCode(), GetMockPlanName());
            p.SetupFeeInCents.Add("USD", 200);
            p.Create();

            PlanList l = PlanList.GetPlans();
            Assert.IsTrue(l.Count > 1);


        }

    }
}
