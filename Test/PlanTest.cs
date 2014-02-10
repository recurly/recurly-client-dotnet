using System;
using NUnit.Framework;

namespace Recurly.Test
{
    [TestFixture]
    class  PlanTest : BaseTest
    {

        [Test]
        public void LookupPlan()
        {
            String s = GetMockPlanCode();
            Plan p = new Plan(s, GetMockPlanName());
            p.Description = "Test Lookup";
            p.UnitAmountInCents.Add("USD", 100);
            p.Create();

            Plan l = Plan.Get(s);
            Assert.IsNotNull(l.CreatedAt);
            Assert.AreEqual(l.UnitAmountInCents["USD"], 100);
            Assert.AreEqual(l.PlanCode, s);
            Assert.AreEqual(l.Description, "Test Lookup");
            p.Deactivate();

        }

        [Test]
        public void CreatePlanSmall()
        {
            Plan p = new Plan(GetMockPlanCode(), GetMockPlanName());
            p.SetupFeeInCents.Add("USD",100);
            p.Create();

            Assert.IsNotNull(p.CreatedAt);
            Assert.AreEqual(p.SetupFeeInCents["USD"], 100);
            p.Deactivate();

        }

        [Test]
        public void CreatePlan()
        {
            Plan p = new Plan(GetMockPlanCode(), GetMockPlanName());
            p.SetupFeeInCents.Add("USD",500);
            p.AccountingCode = "accountingcode123";
            p.Description = "a test plan";
            p.DisplayDonationAmounts = true;
            p.DisplayPhoneNumber = false;
            p.DisplayQuantity = true;
            p.TotalBillingCycles = 5;
            p.TrialIntervalUnit = Plan.IntervalUnit.Months;
            p.TrialIntervalLength = 1;
            p.PlanIntervalUnit = Plan.IntervalUnit.Days;
            p.PlanIntervalLength = 180;
            p.Create();

            Assert.IsNotNull(p.CreatedAt);
            Assert.AreEqual(p.AccountingCode, "accountingcode123");
            Assert.AreEqual(p.Description, "a test plan");
            Assert.IsTrue(p.DisplayDonationAmounts.Value);
            Assert.IsFalse(p.DisplayPhoneNumber.Value);
            Assert.IsTrue(p.DisplayQuantity.Value);
            Assert.AreEqual(p.TotalBillingCycles, 5);
            Assert.AreEqual(p.TrialIntervalUnit, Plan.IntervalUnit.Months);
            Assert.AreEqual(p.TrialIntervalLength, 1);
            Assert.AreEqual(p.PlanIntervalUnit, Plan.IntervalUnit.Days);
            Assert.AreEqual(p.PlanIntervalLength, 180);
            p.Deactivate();


        }

        [Test]
        public void UpdatePlan()
        {
            String s = GetMockPlanCode();
            Plan p = new Plan(s, GetMockPlanName());
            p.Description = "Test Update";
            p.UnitAmountInCents.Add("USD", 100);
            p.Create();


            p.UnitAmountInCents["USD"] = 5000;
            p.SetupFeeInCents.Add("USD", 100);

            p.Update();

            p = Plan.Get(s);
            Assert.AreEqual(p.UnitAmountInCents["USD"], 5000);
            Assert.AreEqual(p.SetupFeeInCents["USD"], 100);
            p.Deactivate();


        }


        [Test]
        public void DeactivatePlan()
        {
            String s = GetMockPlanCode();
            Plan p = new Plan(s, GetMockPlanName());
            p.Description = "Test Delete";
            p.UnitAmountInCents.Add("USD", 100);
            p.Create();
            
            p = Plan.Get(s);
            Assert.IsNotNull(p.CreatedAt);
            Assert.AreEqual(p.UnitAmountInCents["USD"], 100);

            p.Deactivate();

            try
            {
                Plan p2 = Plan.Get(s);
                Assert.Fail("Plan has not been deactivated.");
            }
            catch (Exception)
            {
                // Expected
            }
        }

    }
}
