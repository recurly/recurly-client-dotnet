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

            var adjustment = account.NewAdjustment("USD", 5000, "Test Charge");
            adjustment.Create();

            var invoice = account.InvoicePendingCharges();
            Assert.Equal("usst", invoice.TaxType);
            Assert.Equal(0.0875M, invoice.TaxRate.Value);

            var fromService = Invoices.Get(invoice.InvoiceNumber);

            invoice.Should().Be(fromService);
        }

        [Fact]
        public void GetInvoicePdf()
        {
            var account = CreateNewAccount();

            var adjustment = account.NewAdjustment("USD", 5000, "Test Charge");
            adjustment.Create();

            var invoice = account.InvoicePendingCharges();

            var pdf = invoice.GetPdf();

            pdf.Should().NotBeEmpty();
        }

        [Fact]
        public void AdjustmentAggregationInAnInvoice()
        {
            var account = CreateNewAccount();

            var adjustment = account.NewAdjustment("USD", 5000, "Test Charge");
            adjustment.Create();

            adjustment = account.NewAdjustment("USD", 5000, "Test Charge 2");
            adjustment.Create();

            adjustment = account.NewAdjustment("USD", -2500, "Test Credit");
            adjustment.Create();

            var invoice = account.InvoicePendingCharges();

            invoice.State.Should().Be(Invoice.InvoiceState.Open);
            invoice.TotalInCents.Should().Be(7500);
        }

        [Fact]
        public void MarkSuccessful()
        {
            var account = CreateNewAccount();

            var adjustment = account.NewAdjustment("USD", 3999, "Test Charge");
            adjustment.Create();

            var invoice = account.InvoicePendingCharges();

            invoice.MarkSuccessful();

            invoice.State.Should().Be(Invoice.InvoiceState.Collected);
        }

        [Fact]
        public void FailedCollection()
        {
            var account = CreateNewAccount();

            var adjustment = account.NewAdjustment("USD", 3999, "Test Charge");
            adjustment.Create();

            var invoice = account.InvoicePendingCharges();

            invoice.MarkFailed();

            invoice.State.Should().Be(Invoice.InvoiceState.Failed);
        }
    }
}
