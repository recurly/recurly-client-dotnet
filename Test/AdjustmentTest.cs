using NUnit.Framework;

namespace Recurly.Test
{
    [TestFixture]
    public class AdjustmentTest
    {

        [Test]
        public void CreateAdjustment()
        {
            Account acct = new Account(Factories.GetMockAccountName());
            acct.Create();

            Adjustment a = acct.CreateAdjustment("Charge", 5000, "USD", 1);
            a.Create();

            Assert.IsNotNull(a);
        }

        [Test]
        public void ListAdjustments()
        {
            Account acct = new Account(Factories.GetMockAccountName());
            acct.Create();

            Adjustment a = acct.CreateAdjustment("Charge", 5000, "USD", 1);
            a.Create();

            a = acct.CreateAdjustment("Credit", -1492, "USD", 1);
            a.Create();

            acct.InvoicePendingCharges();

            AdjustmentList adjustments = acct.GetAdjustments();
            Assert.IsTrue(adjustments.Count == 2);
        }

        /// <summary>
        /// This test will return two adjustments: one to negate the charge, the 
        /// other for the balance
        /// </summary>
        [Test]
        public void ListAdjustmentsOverCredit()
        {
            Account acct = new Account(Factories.GetMockAccountName());
            acct.Create();

            Adjustment a = acct.CreateAdjustment("Charge", 1234, "USD", 1);
            a.Create();

            a = acct.CreateAdjustment("Credit", -5678, "USD", 1);
            a.Create();

            acct.InvoicePendingCharges();

            AdjustmentList adjustments = acct.GetAdjustments(Adjustment.AdjustmentType.Credit);
            Assert.IsTrue(adjustments.Count == 2);
            int sum = adjustments[0].UnitAmountInCents + adjustments[1].UnitAmountInCents;
            Assert.AreEqual(sum , -5678);
        }


        [Test]
        public void ListAdjustmentsCredits()
        {
            Account acct = new Account(Factories.GetMockAccountName());
            acct.Create();

            Adjustment a = acct.CreateAdjustment("Charge", 3456, "USD", 1);
            a.Create();

            a = acct.CreateAdjustment("Credit", -3456, "USD", 1);
            a.Create();

            AdjustmentList adjustments = acct.GetAdjustments(Adjustment.AdjustmentType.Credit);
            Assert.IsTrue(adjustments.Count == 1);
            Assert.AreEqual(adjustments[0].UnitAmountInCents, -3456);
        }

        [Test]
        public void ListAdjustmentsCharges()
        {
            Account acct = new Account(Factories.GetMockAccountName());
            acct.Create();

            Adjustment a = acct.CreateAdjustment("Charge", 1234, "USD", 1);
            a.Create();

            a = acct.CreateAdjustment("Credit", -5678, "USD", 1);
            a.Create();

            acct.InvoicePendingCharges();

            AdjustmentList adjustments = acct.GetAdjustments(Adjustment.AdjustmentType.Charge);
            Assert.IsTrue(adjustments.Count == 1);
            Assert.AreEqual(adjustments[0].UnitAmountInCents, 1234);
        }

        [Test]
        public void ListAdjustmentsPendingToInvoiced()
        {
            Account acct = new Account(Factories.GetMockAccountName());
            acct.Create();

            Adjustment a = acct.CreateAdjustment("Charge", 1234, "USD", 1);
            a.Create();

            a = acct.CreateAdjustment("Credit", -5678, "USD", 1);
            a.Create();


            AdjustmentList adjustments = acct.GetAdjustments(state: Adjustment.AdjustmentState.Pending);
            Assert.IsTrue(adjustments.Count == 2);

            acct.InvoicePendingCharges();

            adjustments = acct.GetAdjustments(state: Adjustment.AdjustmentState.Invoiced);
            Assert.IsTrue(adjustments.Count == 2);

        }


    }
}