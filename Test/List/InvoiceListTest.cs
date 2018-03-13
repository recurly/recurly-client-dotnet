using System.Diagnostics;
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

                var collection = acct.InvoicePendingCharges();
                var invoice = collection.ChargeInvoice;

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

            var list = Invoices.List(Invoice.InvoiceState.Pending);
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
                var collection = acct.InvoicePendingCharges();
                var invoice = collection.ChargeInvoice;
                invoice.MarkSuccessful();
            }

            var list = Invoices.List(Invoice.InvoiceState.Paid);
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
                var collection = acct.InvoicePendingCharges();
                var invoice = collection.ChargeInvoice;
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
        public void GetProcessingInvoices()
        {
            var account = CreateNewAccountWithACHBillingInfo();
            var adjustment = account.NewAdjustment("USD", 510, "ACH invoice test");
            adjustment.Create();
            account.InvoicePendingCharges();

            //The invoice starts out as open and then changes to processing 
            //so we need to wait shortly to experience that
            System.Threading.Thread.Sleep(1500);

            var list = Invoices.List(account.AccountCode);
            list.Should().NotBeEmpty();
            Assert.Equal(1, list.Count);
            Assert.True(list[0].State == Invoice.InvoiceState.Processing);
        }

        [RecurlyFact(TestEnvironment.Type.Integration)]
        public void GetInvoicesForAccount()
        {
            var account = CreateNewAccountWithBillingInfo();

            var adjustment = account.NewAdjustment("USD", 450, "Test Charge #1");
            adjustment.Create();

            var collection = account.InvoicePendingCharges();
            var invoice = collection.ChargeInvoice;
            invoice.MarkSuccessful();

            adjustment = account.NewAdjustment("USD", 350, "Test Charge #2");
            adjustment.Create();

            collection = account.InvoicePendingCharges();
            invoice = collection.ChargeInvoice;
            invoice.MarkFailed();

            var list = Invoices.List(account.AccountCode);
            Assert.Equal(2, list.Count);
        }
    }
}
