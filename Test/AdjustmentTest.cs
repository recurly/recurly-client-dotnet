using System;
using FluentAssertions;
using Xunit;

namespace Recurly.Test
{
    public class AdjustmentTest : BaseTest
    {

        [Fact]
        public void CreateAdjustment()
        {
            var account = CreateNewAccount();

            var adjustment = account.CreateAdjustment("Charge", 5000, "USD", 1);
            adjustment.Create();

            adjustment.CreatedAt.Should().NotBe(default(DateTime));
        }

        [Fact]
        public void ListAdjustments()
        {
            var account = CreateNewAccount();

            var adjustment = account.CreateAdjustment("Charge", 5000, "USD", 1);
            adjustment.Create();

            adjustment = account.CreateAdjustment("Credit", -1492, "USD", 1);
            adjustment.Create();

            account.InvoicePendingCharges();

            var adjustments = account.GetAdjustments();
            adjustments.Should().HaveCount(2);
        }

        /// <summary>
        /// This test will return two adjustments: one to negate the charge, the 
        /// other for the balance
        /// </summary>
        [Fact]
        public void ListAdjustmentsOverCredit()
        {
            var account = CreateNewAccount();

            var adjustment = account.CreateAdjustment("Charge", 1234, "USD", 1);
            adjustment.Create();

            adjustment = account.CreateAdjustment("Credit", -5678, "USD", 1);
            adjustment.Create();

            account.InvoicePendingCharges();

            var adjustments = account.GetAdjustments(Adjustment.AdjustmentType.Credit);
            adjustments.Should().HaveCount(2);

            var sum = adjustments[0].UnitAmountInCents + adjustments[1].UnitAmountInCents;
            sum.Should().Be(-10122);
        }


        [Fact]
        public void ListAdjustmentsCredits()
        {
            var account = CreateNewAccount();

            var adjustment = account.CreateAdjustment("Charge", 3456, "USD", 1);
            adjustment.Create();

            adjustment = account.CreateAdjustment("Credit", -3456, "USD", 1);
            adjustment.Create();

            var adjustments = account.GetAdjustments(Adjustment.AdjustmentType.Credit);
            adjustments.Should().HaveCount(1);
            adjustments.Should().Contain(x => x.UnitAmountInCents == -3456);
        }

        [Fact]
        public void ListAdjustmentsCharges()
        {
            var account = CreateNewAccount();

            var adjustment = account.CreateAdjustment("Charge", 1234, "USD", 1);
            adjustment.Create();

            adjustment = account.CreateAdjustment("Credit", -5678, "USD", 1);
            adjustment.Create();

            account.InvoicePendingCharges();

            var adjustments = account.GetAdjustments(Adjustment.AdjustmentType.Charge);
            adjustments.Should().HaveCount(1);
            adjustments.Should().Contain(x => x.UnitAmountInCents == 1234);
        }

        [Fact]
        public void ListAdjustmentsPendingToInvoiced()
        {
            var account = CreateNewAccount();

            var adjustment = account.CreateAdjustment("Charge", 1234, "USD", 1);
            adjustment.Create();

            adjustment = account.CreateAdjustment("Credit", -5678, "USD", 1);
            adjustment.Create();


            var adjustments = account.GetAdjustments(state: Adjustment.AdjustmentState.Pending);
            adjustments.Should().HaveCount(2);

            account.InvoicePendingCharges();

            adjustments = account.GetAdjustments(state: Adjustment.AdjustmentState.Invoiced);
            adjustments.Should().HaveCount(3);
            adjustments.Should().OnlyContain(x => x.State == Adjustment.AdjustmentState.Invoiced);
        }
    }
}