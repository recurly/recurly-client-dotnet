using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using FluentAssertions;
using Recurly.Test.Fixtures;
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

        [RecurlyFact(TestEnvironment.Type.Integration)]
        public void CreatePurchaseWithCustomFields()
        {
            var account = CreateNewAccountWithBillingInfo();
            string currency = "USD";

            var adjustment = account.NewAdjustment("ABC", 1000);
            adjustment.TaxExempt = true;
            adjustment.Description = "my description";
            adjustment.Currency = currency;
            adjustment.Quantity = 1;
            adjustment.AccountingCode = "accounting code";
            adjustment.UnitAmountInCents = 5000;

            var customField = new CustomField()
            {
                Name = "color",
                Value = "purple"
            };

            adjustment.CustomFields.Add(customField);

            var purchase = new Purchase(account.AccountCode, currency);
            purchase.Account.BillingInfo = account.BillingInfo;

            purchase.Adjustments.Add(adjustment);

            var response = Purchase.Invoice(purchase);

            Assert.NotNull(response.ChargeInvoice);
            Assert.Equal(response.ChargeInvoice.Adjustments[0].CustomFields[0].Name, "color");
            Assert.Equal(response.ChargeInvoice.Adjustments[0].CustomFields[0].Value, "purple");
            account.Close();
        }

        [RecurlyFact(TestEnvironment.Type.Integration)]
        public void AuthAndCapturePurchaseWithCustomFields()
        {
            var account = CreateNewAccountWithBillingInfo();

            string currency = "USD";

            var adjustment = account.NewAdjustment("ABC", 1000);
            adjustment.TaxExempt = true;
            adjustment.Description = "my description";
            adjustment.Currency = currency;
            adjustment.Quantity = 1;
            adjustment.AccountingCode = "accounting code";
            adjustment.UnitAmountInCents = 5000;

            var customField = new CustomField()
            {
                Name = "color",
                Value = "purple"
            };

            adjustment.CustomFields.Add(customField);
            var purchase = new Purchase(account.AccountCode, currency);
            purchase.Account.BillingInfo = account.BillingInfo;
            purchase.Adjustments.Add(adjustment);

            var authResponse = Purchase.Authorize(purchase);
            Assert.Equal(authResponse.ChargeInvoice.Adjustments[0].CustomFields[0].Name, "color");
            Assert.Equal(authResponse.ChargeInvoice.Adjustments[0].CustomFields[0].Value, "purple");


            var transactionUuid = authResponse.ChargeInvoice.Transactions[0].Uuid;
            var capturedResponse = Purchase.Capture(transactionUuid);
            capturedResponse.ChargeInvoice.State.Should().Be(Invoice.InvoiceState.Paid);
            Assert.Equal(capturedResponse.ChargeInvoice.Adjustments[0].CustomFields[0].Name, "color");
            Assert.Equal(capturedResponse.ChargeInvoice.Adjustments[0].CustomFields[0].Value, "purple");
            account.Close();
        }

        [RecurlyFact(TestEnvironment.Type.Integration)]
        public void PurchaseWithEOMNetTerms()
        {
            var account = CreateNewAccountWithBillingInfo();
            var currency = "USD";
            var plan = new Plan(GetMockPlanCode(), GetMockPlanName()) { Description = "Plan for Purchase Test" };
            plan.UnitAmountInCents.Add("USD", 580);
            plan.Create();

            var purchase = new Purchase(account.AccountCode, currency);

            purchase.Account.BillingInfo = account.BillingInfo;
            purchase.NetTerms = 45;
            purchase.NetTermsType = NetTermsType.EOM;

            var sub = new Subscription(plan.PlanCode);
            purchase.Subscriptions.Add(sub);

            var response = Purchase.Invoice(purchase);
            Assert.NotNull(response.ChargeInvoice);
            Assert.Equal(response.ChargeInvoice.NetTerms, 45);
            response.ChargeInvoice.NetTermsType.Should().Be(NetTermsType.EOM);
        }

        [RecurlyFact(TestEnvironment.Type.Unit)]
        public void PurchaseWithVertexTransactionType()
        {
            // Create an actual purchase with vertex_transaction_type
            var account = NewAccountWithBillingInfo();

            var adjustment = account.NewAdjustment("Test Adjustment", 580);
            adjustment.Currency = "USD";
            adjustment.Quantity = 1;
            adjustment.UnitAmountInCents = 580;

            var purchase = new Purchase(account.AccountCode, "USD");
            purchase.Account = account;
            purchase.VertexTransactionType = "lease";
            purchase.Adjustments.Add(adjustment);

            // Verify the request serializes vertex_transaction_type correctly
            var xmlOutput = new System.Text.StringBuilder();
            using (var xmlWriter = new XmlTextWriter(new System.IO.StringWriter(xmlOutput)))
            {
                purchase.WriteXml(xmlWriter);
            }
            var xml = xmlOutput.ToString();
            Assert.Contains("<vertex_transaction_type>lease</vertex_transaction_type>", xml);

            // Verify that a valid InvoiceCollection can be deserialized
            // (vertex_transaction_type is only sent in requests, not returned in responses)
            var mockResponse = GetMockInvoiceCollectionResponse();
            Assert.NotNull(mockResponse.ChargeInvoice);
            Assert.Equal(mockResponse.ChargeInvoice.State, Invoice.InvoiceState.Paid);
        }

        [RecurlyFact(TestEnvironment.Type.Unit)]
        public void PurchaseWithAdjustmentsContainingVertexTransactionType()
        {
            // Create a purchase with adjustments that have vertex_transaction_type
            var account = NewAccountWithBillingInfo();

            var adjustment1 = account.NewAdjustment("Adjustment with lease type", 580);
            adjustment1.Currency = "USD";
            adjustment1.Quantity = 1;
            adjustment1.VertexTransactionType = "lease";

            var adjustment2 = account.NewAdjustment("Adjustment with rental type", 1200);
            adjustment2.Currency = "USD";
            adjustment2.Quantity = 2;
            adjustment2.UnitAmountInCents = 600;
            adjustment2.VertexTransactionType = "rental";

            var purchase = new Purchase(account.AccountCode, "USD");
            purchase.Account = account;
            purchase.Adjustments.Add(adjustment1);
            purchase.Adjustments.Add(adjustment2);

            // Verify the request serializes vertex_transaction_type correctly for each adjustment
            var xmlOutput = new System.Text.StringBuilder();
            using (var xmlWriter = new XmlTextWriter(new System.IO.StringWriter(xmlOutput)))
            {
                purchase.WriteXml(xmlWriter);
            }
            var xml = xmlOutput.ToString();

            // Should contain vertex_transaction_type for both adjustments
            Assert.Contains("<vertex_transaction_type>lease</vertex_transaction_type>", xml);
            Assert.Contains("<vertex_transaction_type>rental</vertex_transaction_type>", xml);

            // Verify both adjustments are in the XML with their properties
            Assert.Contains("<unit_amount_in_cents>580</unit_amount_in_cents>", xml);
            Assert.Contains("<unit_amount_in_cents>600</unit_amount_in_cents>", xml);
        }

        private InvoiceCollection GetMockInvoiceCollectionResponse()
        {
            // Mock the Purchase.Invoice response using a fixture
            var collection = new InvoiceCollection();
            var xmlFixture = FixtureImporter.Get(FixtureType.Purchases, "invoice-with-vertex-201").Xml;
            using (var reader = new XmlTextReader(new System.IO.StringReader(xmlFixture)))
            {
                collection.ReadXml(reader);
            }
            return collection;
        }
    }
}
