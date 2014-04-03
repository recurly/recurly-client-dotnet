using System;
using FluentAssertions;
using Xunit;

namespace Recurly.Test
{
    public class AdjustmentTest : BaseTest
    {

        [Fact]
        [Trait("include", "y")]
        public void CreateAdjustment()
        {
            var account = CreateNewAccount();

            string desc = "Charge";
            var adjustment = account.NewAdjustment("USD", 5000, desc);

            adjustment.Create();

            adjustment.CreatedAt.Should().NotBe(default(DateTime));
            Assert.False(adjustment.TaxExempt);
            Assert.Equal(desc, adjustment.Description);
        }

        [Fact]
        [Trait("include", "y")]
        public void CreateTaxExemptAdjustment()
        {
            var account = CreateNewAccount();

            var adjustment = account.NewAdjustment("USD", 5000);
            adjustment.TaxExempt = true;
            adjustment.Create();

            adjustment.CreatedAt.Should().NotBe(default(DateTime));
            Assert.True(adjustment.TaxExempt);
            Assert.Empty(adjustment.Description);
        }

        [Fact]
        public void ListAdjustments()
        {
            var account = CreateNewAccount();

            var adjustment = account.NewAdjustment("USD", 5000, "Charge", 1);
            adjustment.Create();

            adjustment = account.NewAdjustment("USD", -1492, "Credit", 1);
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

            var adjustment = account.NewAdjustment("USD", 1234, "Charge", 1);
            adjustment.Create();

            adjustment = account.NewAdjustment("USD", -5678, "Credit");
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

            var adjustment = account.NewAdjustment("USD", 3456, "Charge", 1);
            adjustment.Create();

            adjustment = account.NewAdjustment("USD", -3456, "Charge", 1);
            adjustment.Create();

            var adjustments = account.GetAdjustments(Adjustment.AdjustmentType.Credit);
            adjustments.Should().HaveCount(1);
            adjustments.Should().Contain(x => x.UnitAmountInCents == -3456);
        }

        [Fact]
        public void ListAdjustmentsCharges()
        {
            var account = CreateNewAccount();

            var adjustment = account.NewAdjustment("USD", 1234);
            adjustment.Create();

            adjustment = account.NewAdjustment("USD", -5678, "list adjustments", 1);
            adjustment.Create();

            account.InvoicePendingCharges();

            var adjustments = account.GetAdjustments(Adjustment.AdjustmentType.Charge);
            adjustments.Should().HaveCount(2);
            adjustments.Should().Contain(x => x.UnitAmountInCents == 1234);
        }

        [Fact]
        public void ListAdjustmentsPendingToInvoiced()
        {
            var account = CreateNewAccount();

            var adjustment = account.NewAdjustment("USD", 1234);
            adjustment.Create();

            adjustment = account.NewAdjustment("USD", -5678, "");
            adjustment.Create();


            var adjustments = account.GetAdjustments(state: Adjustment.AdjustmentState.Pending);
            adjustments.Should().HaveCount(2);

            account.InvoicePendingCharges();

            adjustments = account.GetAdjustments(state: Adjustment.AdjustmentState.Invoiced);
            adjustments.Should().HaveCount(3);
            adjustments.Should().OnlyContain(x => x.State == Adjustment.AdjustmentState.Invoiced);
        }

        [Fact]
        public void AdjustmentGet()
        {
            var account = CreateNewAccountWithBillingInfo();

            var adjustment = account.NewAdjustment("USD", 1234);
            adjustment.Create();

            adjustment.Uuid.Should().NotBeNullOrEmpty();

            var fromService = Adjustments.Get(adjustment.Uuid);

            fromService.Should().NotBeNull();
        }

        [Fact]
        public void AdjustmentDelete()
        {
            var account = CreateNewAccountWithBillingInfo();

            var adjustment = account.NewAdjustment("USD", 1234);
            adjustment.Create();

            adjustment.Uuid.Should().NotBeNullOrEmpty();

            adjustment.Delete();

            Action get = () => Adjustments.Get(adjustment.Uuid);
            get.ShouldThrow<NotFoundException>();
        }
    }
}