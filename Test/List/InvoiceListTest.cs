using FluentAssertions;
using Xunit;

namespace Recurly.Test
{
    public class InvoiceListTest : BaseTest
    {
        [RecurlyFact(TestEnvironment.Type.Integration)]
        public void GetInvoices()
        {
            for (var x = 0; x < 6; x++)
            {
                var acct = CreateNewAccount();

                var adjustment = acct.NewAdjustment("USD", 500 + x, "Test Charge");
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

        [RecurlyFact(TestEnvironment.Type.Integration)]
        public void GetOpenInvoices()
        {
            for (var x = 0; x < 2; x++)
            {
                var account = CreateNewAccount();
                var adjustment = account.NewAdjustment("USD", 500 + x, "Test Charge");
                adjustment.Create();
                account.InvoicePendingCharges();
            }

            var list = Invoices.List(Invoice.InvoiceState.Open);
            list.Should().NotBeEmpty();
        }

        [RecurlyFact(TestEnvironment.Type.Integration)]
        public void GetCollectedInvoices()
        {
            for (var x = 0; x < 2; x++)
            {
                var acct = CreateNewAccount();
                var adjustment = acct.NewAdjustment("USD", 500 + x, "Test Charge");
                adjustment.Create();
                var invoice = acct.InvoicePendingCharges();
                invoice.MarkSuccessful();
            }

            var list = Invoices.List(Invoice.InvoiceState.Collected);
            list.Should().NotBeEmpty();
        }

        [RecurlyFact(TestEnvironment.Type.Integration)]
        public void GetFailedInvoices()
        {
            for (var x = 0; x < 2; x++)
            {
                var acct = CreateNewAccount();
                var adjustment = acct.NewAdjustment("USD", 500 + x, "Test Charge");
                adjustment.Create();
                var invoice = acct.InvoicePendingCharges();
                invoice.MarkFailed();
            }

            var list = Invoices.List(Invoice.InvoiceState.Failed);
            list.Should().NotBeEmpty();
        }

        [RecurlyFact(TestEnvironment.Type.Integration)]
        public void GetPastDueInvoices()
        {
            for (var x = 0; x < 2; x++)
            {
                var acct = CreateNewAccount();
                var adjustment = acct.NewAdjustment("USD", 500 + x, "Test charge");
                adjustment.Create();
                acct.InvoicePendingCharges();
            }

            var list = Invoices.List(Invoice.InvoiceState.PastDue);
            list.Should().NotBeEmpty();
        }

        [RecurlyFact(TestEnvironment.Type.Integration)]
        public void GetInvoicesForAccount()
        {
            var account = CreateNewAccountWithBillingInfo();

            var adjustment = account.NewAdjustment("USD", 450, "Test Charge #1");
            adjustment.Create();

            var invoice = account.InvoicePendingCharges();
            invoice.MarkSuccessful();

            adjustment = account.NewAdjustment("USD", 350, "Test Charge #2");
            adjustment.Create();

            invoice = account.InvoicePendingCharges();
            invoice.MarkFailed();

            var list = Invoices.List(account.AccountCode);
            Assert.Equal(2, list.Count);
        }
    }
}
