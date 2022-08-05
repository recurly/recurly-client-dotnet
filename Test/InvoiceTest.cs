﻿using System;
using FluentAssertions;
using Xunit;

namespace Recurly.Test
{
    public class InvoiceTest : BaseTest
    {
        [RecurlyFact(TestEnvironment.Type.Integration)]
        public void GetInvoice()
        {
            var account = CreateNewAccountWithBillingInfo();

            var adjustment = account.NewAdjustment("USD", 5000, "Test Charge");
            adjustment.Create();

            var invoice = account.InvoicePendingCharges().ChargeInvoice;
            Assert.Equal("usst", invoice.TaxType);
            Assert.Equal(0.08625M, invoice.TaxRate.Value);

            var fromService = Invoices.Get(invoice.InvoiceNumber);

            invoice.Should().Be(fromService);
        }

        [RecurlyFact(TestEnvironment.Type.Integration)]
        public void GetInvoicePdf()
        {
            var account = CreateNewAccount();

            var adjustment = account.NewAdjustment("USD", 5000, "Test Charge");
            adjustment.Create();

            var collection = account.InvoicePendingCharges();
            var invoice = collection.ChargeInvoice;

            var pdf = invoice.GetPdf();

            pdf.Should().NotBeEmpty();
        }

        [RecurlyFact(TestEnvironment.Type.Integration)]
        public void AdjustmentAggregationInAnInvoice()
        {
            var account = CreateNewAccount();

            var adjustment = account.NewAdjustment("USD", 5000, "Test Charge");
            adjustment.Create();

            adjustment = account.NewAdjustment("USD", 5000, "Test Charge 2");
            adjustment.Create();

            adjustment = account.NewAdjustment("USD", -2500, "Test Credit");
            adjustment.Create();

            var invoice = account.InvoicePendingCharges().ChargeInvoice;

            invoice.State.Should().Be(Invoice.InvoiceState.Pending);
            invoice.TotalInCents.Should().Be(10000);
        }

        [RecurlyFact(TestEnvironment.Type.Integration)]
        public void InvoicePendingChargesWithNotes()
        {
            var account = CreateNewAccount();

            var adjustment = account.NewAdjustment("USD", 5000, "Test Charge");
            adjustment.Create();

            adjustment = account.NewAdjustment("USD", 5000, "Test Charge 2");
            adjustment.Create();

            adjustment = account.NewAdjustment("USD", -2500, "Test Credit");
            adjustment.Create();

            var collection = account.InvoicePendingCharges(new Invoice
            {
                CustomerNotes = "Some customer notes",
                TermsAndConditions = "Some terms and conditions",
                VatReverseChargeNotes = "Some vat reverse charge notes",
                CollectionMethod = Invoice.Collection.Manual,
                NetTerms = 5,
                PoNumber = "Some po number"
            });

            var invoice = collection.ChargeInvoice;

            Assert.NotNull(invoice);
            Assert.Equal(invoice.CustomerNotes, "Some customer notes");
            Assert.Equal(invoice.TermsAndConditions, "Some terms and conditions");
            Assert.Equal(invoice.CollectionMethod, Invoice.Collection.Manual);
            Assert.Equal(invoice.NetTerms, 5);
            Assert.Equal(invoice.PoNumber, "Some po number");
        }

        [RecurlyFact(TestEnvironment.Type.Integration)]
        public void InvoicePendingCharges()
        {
            var account = CreateNewAccount();

            var adjustment = account.NewAdjustment("USD", 5000, "Test Charge");
            adjustment.Create();

            adjustment = account.NewAdjustment("USD", 5000, "Test Charge 2");
            adjustment.Create();

            adjustment = account.NewAdjustment("USD", -2500, "Test Credit");
            adjustment.Create();

            var invoice = account.InvoicePendingCharges();

            Assert.NotNull(invoice);
        }

        [RecurlyFact(TestEnvironment.Type.Integration)]
        public void PreviewInvoicePendingChargesWithNotes()
        {
            var account = CreateNewAccount();

            var adjustment = account.NewAdjustment("USD", 5000, "Test Charge");
            adjustment.Create();

            adjustment = account.NewAdjustment("USD", 5000, "Test Charge 2");
            adjustment.Create();

            adjustment = account.NewAdjustment("USD", -2500, "Test Credit");
            adjustment.Create();

            var collection = account.PreviewInvoicePendingCharges(new Invoice
            {
                CustomerNotes = "Some customer notes",
                TermsAndConditions = "Some terms and conditions",
                VatReverseChargeNotes = "Some vat reverse charge notes",
                CollectionMethod = Invoice.Collection.Manual,
                NetTerms = 5,
                PoNumber = "Some po number"
            });

            var invoice = collection.ChargeInvoice;

            Assert.NotNull(invoice);
            Assert.Equal(invoice.CustomerNotes, "Some customer notes");
            Assert.Equal(invoice.TermsAndConditions, "Some terms and conditions");
            Assert.Equal(invoice.CollectionMethod, Invoice.Collection.Manual);
            Assert.Equal(invoice.NetTerms, 5);
            Assert.Equal(invoice.PoNumber, "Some po number");
        }

        [RecurlyFact(TestEnvironment.Type.Integration)]
        public void PreviewInvoicePendingCharges()
        {
            var account = CreateNewAccount();

            var adjustment = account.NewAdjustment("USD", 5000, "Test Charge");
            adjustment.Create();

            adjustment = account.NewAdjustment("USD", 5000, "Test Charge 2");
            adjustment.Create();

            adjustment = account.NewAdjustment("USD", -2500, "Test Credit");
            adjustment.Create();

            var invoice = account.PreviewInvoicePendingCharges();

            Assert.NotNull(invoice);
        }

        [RecurlyFact(TestEnvironment.Type.Integration)]
        public void MarkSuccessful()
        {
            var account = CreateNewAccount();

            var adjustment = account.NewAdjustment("USD", 3999, "Test Charge");
            adjustment.Create();

            var collection = account.InvoicePendingCharges();
            var invoice = collection.ChargeInvoice;

            invoice.MarkSuccessful();

            Assert.Equal(1, invoice.Adjustments.Count);

            invoice.State.Should().Be(Invoice.InvoiceState.Paid);
        }

        [RecurlyFact(TestEnvironment.Type.Integration)]
        public void FailedCollection()
        {
            var account = CreateNewAccountWithBillingInfo();

            var adjustment = account.NewAdjustment("USD", 3999, "Test Charge");
            adjustment.Create();

            var invoiceData = new Invoice()
            {
                CollectionMethod = Invoice.Collection.Manual
            };

            var collection = account.InvoicePendingCharges(invoiceData);
            var invoice = collection.ChargeInvoice;

            invoice = invoice.MarkFailed().ChargeInvoice;
            invoice.State.Should().Be(Invoice.InvoiceState.Failed);
            Assert.NotNull(invoice.ClosedAt);
        }

        [RecurlyFact(TestEnvironment.Type.Integration)]
        public void RefundSingle()
        {
            var account = CreateNewAccountWithBillingInfo();

            var adjustment = account.NewAdjustment("USD", 3999, "Test Charge");
            adjustment.Create();

            var collection = account.InvoicePendingCharges();
            var invoice = collection.ChargeInvoice;

            invoice.MarkSuccessful();

            invoice.State.Should().Be(Invoice.InvoiceState.Paid);

            Assert.Equal(1, invoice.Adjustments.Count);

            // refund
            var refundInvoice = invoice.Refund(adjustment, false);
            Assert.NotEqual(invoice.Uuid, refundInvoice.Uuid);
            Assert.Equal(-3999, refundInvoice.SubtotalInCents);
            Assert.Equal(1, refundInvoice.Adjustments.Count);
            Assert.Equal(0, refundInvoice.Transactions.Count);

            account.Close();
        }

        [RecurlyFact(TestEnvironment.Type.Integration)]
        public void UpdateInvoice()
        {
            var account = CreateNewAccount();

            var adjustment = account.NewAdjustment("USD", 5000, "Test Charge");
            adjustment.Create();

            var invoice = account.InvoicePendingCharges().ChargeInvoice;

            var address = new Address();
            address.FirstName = "Doc";
            address.LastName = "Brown";
            address.NameOnAccount = "Doc Brown";
            address.Company = "Flux Capacitors, LLC.";
            address.Phone = "916-555-4385";
            invoice.Address = address;

            invoice.PoNumber = "1234";
            invoice.CustomerNotes = "Some Customer Notes";
            invoice.TermsAndConditions = "Some Terms and Conditions";
            invoice.GatewayCode = "jhq4mlfe7wtw";
            invoice.Update();

            Assert.Equal(invoice.PoNumber, "1234");
            Assert.Equal(invoice.CustomerNotes, "Some Customer Notes");
            Assert.Equal(invoice.TermsAndConditions, "Some Terms and Conditions");
            Assert.Equal(invoice.GatewayCode, "jhq4mlfe7wtw");
        }

        [Fact(Skip = "This feature is deprecated and no longer supported for accounts where line item refunds are turned on.")]
        public void RefundMultiple()
        {
            var account = CreateNewAccountWithBillingInfo();

            var adjustment1 = account.NewAdjustment("USD", 1, "Test Charge 1");
            adjustment1.Create();

            var adjustment2 = account.NewAdjustment("USD", 2, "Test Charge 2", 2);
            adjustment2.Create();

            var collection = account.InvoicePendingCharges();
            var invoice = collection.ChargeInvoice;
            invoice.MarkSuccessful();

            System.Threading.Thread.Sleep(2000); // hack

            Assert.Equal(2, invoice.Adjustments.Count);
            Assert.Equal(1, invoice.Transactions.Count);
            Assert.Equal(7, invoice.Transactions[0].AmountInCents);

            // refund
            var refundInvoice = invoice.Refund(invoice.Adjustments);
            Assert.NotEqual(invoice.Uuid, refundInvoice.Uuid);
            Assert.Equal(-5, refundInvoice.SubtotalInCents);
            Assert.Equal(2, refundInvoice.Adjustments.Count);
            Assert.Equal(-1, refundInvoice.Adjustments[0].Quantity);
            Assert.Equal(-2, refundInvoice.Adjustments[1].Quantity);
            Assert.Equal(1, refundInvoice.Transactions.Count);
            Assert.Equal(5, refundInvoice.Transactions[0].AmountInCents);

            account.Close();
        }

        [RecurlyFact(TestEnvironment.Type.Integration)]
        public void RefundOpenAmount()
        {
            var account = CreateNewAccountWithBillingInfo();
            var adjustment = account.NewAdjustment("USD", 3999, "Test Charge");
            adjustment.Create();
            var collection = account.InvoicePendingCharges();
            var invoice = collection.ChargeInvoice;
            invoice.MarkSuccessful();
            invoice.State.Should().Be(Invoice.InvoiceState.Paid);
            Assert.Equal(1, invoice.Adjustments.Count);

            var refundOptions = new Invoice.RefundOptions() {
              ExternalRefund = true,
              Description = "External Refund Description",
              CreditCustomerNotes = "Credit Customer Notes",
              PaymentMethod = "credit_card",
              Method = Invoice.RefundMethod.AllTransaction
            };

            var refundInvoice = invoice.RefundAmount(100, refundOptions); // 1 dollar
            Assert.NotEqual(invoice.Uuid, refundInvoice.Uuid);

            account.Close();
        }

        [RecurlyFact(TestEnvironment.Type.Integration)]
        public void RefundLineItems()
        {
            var account = CreateNewAccountWithBillingInfo();
            var adjustment = account.NewAdjustment("USD", 3999, "Test Charge 1");
            adjustment.Create();
            adjustment = account.NewAdjustment("USD", 4999, "Test Charge 2");
            adjustment.Create();
            var collection = account.InvoicePendingCharges();
            var invoice = collection.ChargeInvoice;
            invoice.MarkSuccessful();
            invoice.State.Should().Be(Invoice.InvoiceState.Paid);
            Assert.Equal(2, invoice.Adjustments.Count);

            var refundOptions = new Invoice.RefundOptions() {
              ExternalRefund = true,
              Description = "External Refund Description",
              CreditCustomerNotes = "Credit Customer Notes",
              PaymentMethod = "credit_card",
              Method = Invoice.RefundMethod.AllTransaction
            };

            adjustment = invoice.Adjustments[0];
            var refundInvoice = invoice.Refund(adjustment, refundOptions);
            Assert.NotEqual(invoice.Uuid, refundInvoice.Uuid);
            Assert.Equal(1, refundInvoice.Adjustments.Count);

            account.Close();
        }

        [RecurlyFact(TestEnvironment.Type.Integration)]
        public void EnterOfflinePayment()
        {
            var account = CreateNewAccountWithBillingInfo();
            var adjustment = account.NewAdjustment("USD", 5000, "Test Charge");
            adjustment.Create();

            // Can only record offline transactions on manual invoices
            var newInvoice = new Invoice();
            newInvoice.CollectionMethod = Invoice.Collection.Manual;

            var invoice = account.InvoicePendingCharges(newInvoice).ChargeInvoice;

            var offlineTransaction = new Transaction(account, 5000, "");
            offlineTransaction.PaymentMethod = "credit_card";
            offlineTransaction.CollectedAt = DateTime.Now;
            offlineTransaction.Description = "Paid the test charge. Gooood customer *pats customer head*";

            var recordedTransaction = invoice.EnterOfflinePayment(offlineTransaction);
            Assert.Equal(recordedTransaction.Status, Recurly.Transaction.TransactionState.Success);
        }
    }
}
