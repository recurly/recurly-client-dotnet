using System;
using FluentAssertions;
using Xunit;

namespace Recurly.Test
{
    public class AdjustmentTest : BaseTest
    {

        [RecurlyFact(TestEnvironment.Type.Integration)]
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

        [RecurlyFact(TestEnvironment.Type.Integration)]
        public void CreateAdjustmentWithProperties()
        {
            var account = CreateNewAccount();
            string desc = "my description";
            string accountingCode = "accountng code";
            string currency = "USD";
            int unitAmountInCents = 5000;
            int quantity = 2;

            var adjustment = account.NewAdjustment("ABC", 1000);
            adjustment.TaxExempt = true;
            adjustment.Description = desc;
            adjustment.Currency = currency;
            adjustment.Quantity = quantity;
            adjustment.AccountingCode = accountingCode;
            adjustment.UnitAmountInCents = unitAmountInCents;

            adjustment.Create();

            adjustment.CreatedAt.Should().NotBe(default(DateTime));
            Assert.True(adjustment.TaxExempt);
            Assert.Equal(desc, adjustment.Description);
            Assert.Equal(currency, adjustment.Currency);
            Assert.Equal(quantity, adjustment.Quantity);
            Assert.Equal(accountingCode, adjustment.AccountingCode);
            Assert.Equal(unitAmountInCents, adjustment.UnitAmountInCents);
        }

        [RecurlyFact(TestEnvironment.Type.Integration)]
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
        [RecurlyFact(TestEnvironment.Type.Integration)]
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


        [RecurlyFact(TestEnvironment.Type.Integration)]
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

        [RecurlyFact(TestEnvironment.Type.Integration)]
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

        [RecurlyFact(TestEnvironment.Type.Integration)]
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

        [RecurlyFact(TestEnvironment.Type.Integration)]
        public void AdjustmentGet()
        {
            var account = CreateNewAccountWithBillingInfo();

            var adjustment = account.NewAdjustment("USD", 1234);
            adjustment.Create();

            adjustment.Uuid.Should().NotBeNullOrEmpty();

            var fromService = Adjustments.Get(adjustment.Uuid);

            fromService.Should().NotBeNull();
        }

        [RecurlyFact(TestEnvironment.Type.Integration)]
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