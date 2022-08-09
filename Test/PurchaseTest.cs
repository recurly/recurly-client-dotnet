using System;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace Recurly.Test
{
    public class PurchaseTest : BaseTest
    {
        [RecurlyFact(TestEnvironment.Type.Integration)]
        public void InvoicePurchase()
        {
            var account = CreateNewAccountWithBillingInfo();
            var currency = "USD";
            var plan = new Plan(GetMockPlanCode(), GetMockPlanName()) { Description = "Plan for Purchase Test" };
            plan.UnitAmountInCents.Add("USD", 580);
            plan.Create();

            var purchase = new Purchase(account.AccountCode, currency);

            purchase.Account.BillingInfo = account.BillingInfo;

            var sub = new Subscription(plan.PlanCode);
            purchase.Subscriptions.Add(sub);

            var collection = Purchase.Invoice(purchase);
            Assert.NotNull(collection.ChargeInvoice);
            Assert.Equal(collection.ChargeInvoice.Transactions[0].Account.AccountCode, account.AccountCode);
            Assert.Equal(collection.ChargeInvoice.Address.Company, "Acme Software");
        }

        [RecurlyFact(TestEnvironment.Type.Integration)]
        public void CancelPurchase()
        {
            var collection = CreateNewCollection();

            var transactionUuid = collection.ChargeInvoice.Transactions[0].Uuid;
            var cancelledCollection = Purchase.Cancel(transactionUuid);
            cancelledCollection.ChargeInvoice.State.Should().Be(Invoice.InvoiceState.Failed);
        }

        [RecurlyFact(TestEnvironment.Type.Integration)]
        public void CapturePurchase()
        {
            var collection = CreateNewCollection();

            var transactionUuid = collection.ChargeInvoice.Transactions[0].Uuid;
            var capturedCollection = Purchase.Capture(transactionUuid);
            capturedCollection.ChargeInvoice.State.Should().Be(Invoice.InvoiceState.Paid);
        }
    }
}
