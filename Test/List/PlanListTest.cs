using System;
using System.Collections.Generic;
using System.Text;
using Recurly;
using NUnit.Framework;

namespace Recurly.Test
{
    [TestFixture]
    class PlanListTest
    {

        [Test]
        public void ListPlans()
        {
            Plan p = new Plan(Factories.GetMockPlanCode(), Factories.GetMockPlanName());
            p.SetupFeeInCents.Add("USD", 100);
            p.Create();

            p = new Plan(Factories.GetMockPlanCode(), Factories.GetMockPlanName());
            p.SetupFeeInCents.Add("USD", 200);
            p.Create();

            PlanList l = PlanList.GetPlans();
            Assert.IsTrue(l.Count > 1);


        }

    }
}
