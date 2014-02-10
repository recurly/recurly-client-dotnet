using FluentAssertions;
using Xunit;

namespace Recurly.Test
{
    public class InvoiceTest : BaseTest
    {
        [Fact]
        public void GetInvoice()
        {
            var account = CreateNewAccount();

            var adjustment = account.CreateAdjustment("Test Charge", 5000, "USD");
            adjustment.Create();

            var invoice = account.InvoicePendingCharges();

            var fromService = Invoices.Get(invoice.InvoiceNumber);

            invoice.Should().Be(fromService);
        }

        [Fact]
        public void GetInvoicePdf()
        {
            var account = CreateNewAccount();

            var adjustment = account.CreateAdjustment("Test Charge", 5000, "USD");
            adjustment.Create();

            var invoice = account.InvoicePendingCharges();

            var pdf = invoice.GetPdf();

            pdf.Should().NotBeEmpty();
        }

        [Fact]
        public void AdjustmentAggregationInAnInvoice()
        {
            var account = CreateNewAccount();

            var adjustment = account.CreateAdjustment("Test Charge", 5000, "USD");
            adjustment.Create();

            adjustment = account.CreateAdjustment("Test Charge 2", 5000, "USD");
            adjustment.Create();

            adjustment = account.CreateAdjustment("Test Credit", -2500, "USD");
            adjustment.Create();

            var invoice = account.InvoicePendingCharges();

            invoice.State.Should().Be(Invoice.InvoiceState.Open);
            invoice.TotalInCents.Should().Be(7500);
        }

        [Fact]
        public void MarkSuccessful()
        {
            var account = CreateNewAccount();

            var adjustment = account.CreateAdjustment("Test Charge", 3999, "USD");
            adjustment.Create();

            var invoice = account.InvoicePendingCharges();

            invoice.MarkSuccessful();

            invoice.State.Should().Be(Invoice.InvoiceState.Collected);
        }

        [Fact]
        public void FailedCollection()
        {
            var account = CreateNewAccount();

            var adjustment = account.CreateAdjustment("Test Charge", 3999, "USD");
            adjustment.Create();

            var invoice = account.InvoicePendingCharges();

            invoice.MarkFailed();

            invoice.State.Should().Be(Invoice.InvoiceState.Failed);
        }
    }
}
