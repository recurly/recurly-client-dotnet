using FluentAssertions;
using Xunit;

namespace Recurly.Test
{
    public class InvoiceListTest : BaseTest
    {
        [Fact]
        public void GetInvoices()
        {
            for (var x = 0; x < 6; x++)
            {
                var acct = CreateNewAccount();

                var adjustment = acct.CreateAdjustment("Test Charge", 500 + x, "USD");
                adjustment.Create();

                var invoice = acct.InvoicePendingCharges();

                if (x < 2)
                {
                    // leave open
                }
                else if (x == 3 || x == 4)
                {
                    invoice.MarkFailed();
                }
                else
                {
                    invoice.MarkSuccessful();
                }
            } 
            
            var list = Invoices.List();
            list.Should().NotBeEmpty();
        }

        [Fact]
        public void GetOpenInvoices()
        {
            for (var x = 0; x < 2; x++)
            {
                var account = CreateNewAccount();
                var adjustment = account.CreateAdjustment("Test Charge", 500 + x, "USD");
                adjustment.Create();
                account.InvoicePendingCharges();
            }

            var list = Invoices.List(Invoice.InvoiceState.Open);
            list.Should().NotBeEmpty();
        }

        [Fact]
        public void GetCollectedInvoices()
        {
            for (var x = 0; x < 2; x++)
            {
                var acct = CreateNewAccount();
                var adjustment = acct.CreateAdjustment("Test Charge", 500 + x, "USD");
                adjustment.Create();
                var invoice = acct.InvoicePendingCharges();
                invoice.MarkSuccessful();
            }

            var list = Invoices.List(Invoice.InvoiceState.Collected);
            list.Should().NotBeEmpty();
        }

        [Fact]
        public void GetFailedInvoices()
        {
            for (var x = 0; x < 2; x++)
            {
                var acct = CreateNewAccount();
                var adjustment = acct.CreateAdjustment("Test Charge", 500 + x, "USD");
                adjustment.Create();
                var invoice = acct.InvoicePendingCharges();
                invoice.MarkFailed();
            }

            var list = Invoices.List(Invoice.InvoiceState.Failed);
            list.Should().NotBeEmpty();
        }

        [Fact]
        public void GetPastDueInvoices()
        {
            for (var x = 0; x < 2; x++)
            {
                var acct = CreateNewAccount();
                var adjustment = acct.CreateAdjustment("Test Charge", 500 + x, "USD");
                adjustment.Create();
                acct.InvoicePendingCharges();
            }

            var list = Invoices.List(Invoice.InvoiceState.PastDue);
            list.Should().NotBeEmpty();
        }

        [Fact]
        public void GetInvoicesForAccount()
        {
            var account = CreateNewAccount();

            var adjustment = account.CreateAdjustment("Test Charge #1", 450, "USD");
            adjustment.Create();

            var invoice = account.InvoicePendingCharges();
            invoice.MarkSuccessful();

            adjustment = account.CreateAdjustment("Test Charge #2", 350, "USD");
            adjustment.Create();

            var list = Invoices.List(account.AccountCode);
            list.Should().NotBeEmpty();
        }
    }
}
