using System;
using FluentAssertions;
using Xunit;

namespace Recurly.Test
{
    public class AdjustmentTest : BaseTest
    {

        [RecurlyFact(TestEnvironment.Type.Integration)]
        public void CreateAdjustmentWithItemCode()
        {
            var account = CreateNewAccount();
            var item = new Item(GetMockItemCode(), GetMockItemName()) {Description = "Test Lookup"};
            item.Description = "A test description";
            item.ExternalSku = "tester-sku";
            item.Create();

            var adjustment = account.NewAdjustment("USD", 5000);
            adjustment.ItemCode = item.ItemCode;
            adjustment.StartDate = new DateTime(2019, 6, 11);
            adjustment.EndDate = new DateTime(2045, 7, 11);
            adjustment.Create();

            adjustment.CreatedAt.Should().NotBe(default(DateTime));
            Assert.False(adjustment.TaxExempt);
            Assert.Equal(item.ItemCode, adjustment.ItemCode);
            Assert.Equal(item.ExternalSku, adjustment.ExternalSku);
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
            adjustments.Should().HaveCount(1);
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

            adjustment = account.NewAdjustment("USD", 5678, "list adjustments", 1);
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

            fromService.Uuid.Should().NotBeNull();
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

        [RecurlyFact(TestEnvironment.Type.Integration)]
        public void AdjustmentBillForAccount()
        {


//            var adjustment2 = account.GetAdjustments.get("abcdef1234567890");

//            Assert.Equal('dsd', adjustment.BillForAccount);
//            var account = CreateNewAccount();

//            var adjustments = account.GetAdjustments();


//            var adjustment = Adjustments.Get("abcdef1234567890");
//            Console.WriteLine(adjustment2.uuid);
//            Assert.Equal("fsdfdsfdf", adjustment.BillForAccount);
//            string test = "asdasd";
//            Assert.Equal(test, adjustment.BillForAccount);
//            Assert.Equal(account.AccountCode, adjustment2.BillForAccount);
              var account = CreateNewAccount();

             var adjustment = account.NewAdjustment("USD", 1234);
             adjustment.Create();

            var adj =  Adjustments.Get(adjustment.Uuid);



            Assert.Equal(account.AccountCode, adj.BillForAccount);

        }
    }
}
