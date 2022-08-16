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
        public void InvoicePurchaseWithRampPlan()
        {
            var account = CreateNewAccountWithBillingInfo();
            var plan = CreateNewRampPlan(3);
            PlansToDeactivateOnDispose.Add(plan);

            var purchase = new Purchase(account.AccountCode, "USD");
            purchase.Account.BillingInfo = account.BillingInfo;

            var sub = new Subscription(plan.PlanCode);
            purchase.Subscriptions.Add(sub);

            var collection = Purchase.Invoice(purchase);
            int firstRampUnitAmount = plan.RampIntervals[0].Currencies[0].UnitAmountInCents;

            Assert.NotNull(collection.ChargeInvoice);
            Assert.Equal(collection.ChargeInvoice.SubtotalInCents, firstRampUnitAmount);
            Assert.Equal(collection.ChargeInvoice.TotalInCents, firstRampUnitAmount);
            Assert.Equal(collection.ChargeInvoice.SubtotalBeforeDiscountInCents, firstRampUnitAmount);
            Assert.Equal(collection.ChargeInvoice.Adjustments[0].UnitAmountInCents, firstRampUnitAmount);
            Assert.Equal(collection.ChargeInvoice.Adjustments[0].TotalInCents, firstRampUnitAmount);
            Assert.Equal(collection.ChargeInvoice.Transactions[0].AmountInCents, firstRampUnitAmount);
            account.Close();
        }

        [RecurlyFact(TestEnvironment.Type.Integration)]
        public void InvoicePurchaseWithCustomRamps()
        {
            var plan = CreateNewRampPlan(3);
            PlansToDeactivateOnDispose.Add(plan);
            var account = CreateNewAccountWithBillingInfo();

            var sub = new Subscription(account, plan, "USD");
            sub.RampIntervals = GetMockSubscriptionRampIntervals(2);

            var purchase = new Purchase(sub.AccountCode, "USD");
            purchase.Account.BillingInfo = sub.Account.BillingInfo;
            purchase.Subscriptions.Add(sub);

            var collection = Purchase.Invoice(purchase);
            int firstRampUnitAmount = sub.RampIntervals[0].UnitAmountInCents;

            Assert.NotNull(collection.ChargeInvoice);
            Assert.Equal(collection.ChargeInvoice.SubtotalInCents, firstRampUnitAmount);
            Assert.Equal(collection.ChargeInvoice.TotalInCents, firstRampUnitAmount);
            Assert.Equal(collection.ChargeInvoice.SubtotalBeforeDiscountInCents, firstRampUnitAmount);
            Assert.Equal(collection.ChargeInvoice.Adjustments[0].UnitAmountInCents, firstRampUnitAmount);
            Assert.Equal(collection.ChargeInvoice.Adjustments[0].TotalInCents, firstRampUnitAmount);
            Assert.Equal(collection.ChargeInvoice.Transactions[0].AmountInCents, firstRampUnitAmount);
            account.Close();
        }

        [RecurlyFact(TestEnvironment.Type.Integration)]
        public void PreviewPurchaseWithRamps()
        {
            var account = CreateNewAccountWithBillingInfo();
            var plan = CreateNewRampPlan(3);
            PlansToDeactivateOnDispose.Add(plan);

            var purchase = new Purchase(account.AccountCode, "USD");
            purchase.Account.BillingInfo = account.BillingInfo;

            var sub = new Subscription(plan.PlanCode);
            purchase.Subscriptions.Add(sub);

            var collection = Purchase.Preview(purchase);
            int firstRampUnitAmount = plan.RampIntervals[0].Currencies[0].UnitAmountInCents;

            Assert.NotNull(collection.ChargeInvoice);
            Assert.Equal(collection.ChargeInvoice.SubtotalInCents, firstRampUnitAmount);
            Assert.Equal(collection.ChargeInvoice.TotalInCents, firstRampUnitAmount);
            Assert.Equal(collection.ChargeInvoice.SubtotalBeforeDiscountInCents, firstRampUnitAmount);
            Assert.Equal(collection.ChargeInvoice.Adjustments[0].UnitAmountInCents, firstRampUnitAmount);
            Assert.Equal(collection.ChargeInvoice.Adjustments[0].TotalInCents, firstRampUnitAmount);
            account.Close();
        }

        [RecurlyFact(TestEnvironment.Type.Integration)]
        public void PendingPurchaseWithRamps()
        {
            var plan = CreateNewRampPlan(3);
            PlansToDeactivateOnDispose.Add(plan);
            var account = CreateNewAccountWithBillingInfo();

            var sub = new Subscription(account, plan, "USD");
            sub.RampIntervals = GetMockSubscriptionRampIntervals(2);

            var purchase = new Purchase(sub.AccountCode, "USD");
            purchase.Account.BillingInfo = sub.Account.BillingInfo;
            // Randomly generate an email address
            purchase.Account.Email = Guid.NewGuid().ToString().Substring(0, 8) + "@test.com";
            purchase.Subscriptions.Add(sub);

            var collection = Purchase.Pending(purchase);
            int firstRampUnitAmount = sub.RampIntervals[0].UnitAmountInCents;

            Assert.NotNull(collection.ChargeInvoice);
            Assert.Equal(collection.ChargeInvoice.SubtotalInCents, firstRampUnitAmount);
            Assert.Equal(collection.ChargeInvoice.TotalInCents, firstRampUnitAmount);
            Assert.Equal(collection.ChargeInvoice.SubtotalBeforeDiscountInCents, firstRampUnitAmount);
            Assert.Equal(collection.ChargeInvoice.Adjustments[0].UnitAmountInCents, firstRampUnitAmount);
            Assert.Equal(collection.ChargeInvoice.Adjustments[0].TotalInCents, firstRampUnitAmount);
            account.Close();
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

        [RecurlyFact(TestEnvironment.Type.Integration)]
        public void AuthAndCapturePurchaseWithRamps()
        {
            var account = CreateNewAccountWithBillingInfo();
            var plan = CreateNewRampPlan(3);
            PlansToDeactivateOnDispose.Add(plan);

            var purchase = new Purchase(account.AccountCode, "USD");
            purchase.Account.BillingInfo = account.BillingInfo;

            var sub = new Subscription(plan.PlanCode);
            sub.RampIntervals = GetMockSubscriptionRampIntervals(2);
            purchase.Subscriptions.Add(sub);

            var collection = Purchase.Authorize(purchase);
            int firstRampUnitAmount = sub.RampIntervals[0].UnitAmountInCents;

            Assert.Equal(collection.ChargeInvoice.SubtotalInCents, firstRampUnitAmount);
            var transactionUuid = collection.ChargeInvoice.Transactions[0].Uuid;
            var capturedCollection = Purchase.Capture(transactionUuid);
            capturedCollection.ChargeInvoice.State.Should().Be(Invoice.InvoiceState.Paid);
            Assert.Equal(capturedCollection.ChargeInvoice.SubtotalInCents, firstRampUnitAmount);
            account.Close();
        }
    }
}
