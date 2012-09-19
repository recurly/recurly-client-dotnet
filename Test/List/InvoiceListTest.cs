using System;
using System.Collections.Generic;
using System.Text;
using Recurly;
using NUnit.Framework;
using System.Threading;


namespace Recurly.Test
{
    [TestFixture]
    class InvoiceListTest
    {

        [Test]
        public void GetInvoices()
        {

            for (int x = 0; x < 6; x++)
            {
                Account acct = new Account(Factories.GetMockAccountName());
                acct.Create();

                Adjustment a = acct.CreateAdjustment("Test Charge", 500 + x, "USD");
                a.Create();

                Invoice i = acct.InvoicePendingCharges();

                if (x < 2)
                {
                    // leave open
                }
                else if (x == 3 || x == 4)
                {
                    i.MarkFailed();
                }
                else
                {
                    i.MarkSuccessful();
                }
                Thread.Sleep(1);
            } 
            
            InvoiceList list = InvoiceList.GetInvoices();

            Assert.IsTrue(list.Count > 0);

        }

        [Test]
        public void GetOpenInvoices()
        {
            for (int x = 0; x < 2; x++)
            {
                Account acct = new Account(Factories.GetMockAccountName());
                acct.Create();

                Adjustment a = acct.CreateAdjustment("Test Charge", 500 + x, "USD");
                a.Create();

                Invoice i = acct.InvoicePendingCharges();

                Thread.Sleep(1);
            }
            InvoiceList list = InvoiceList.GetInvoices(Invoice.InvoiceState.open);

            Assert.IsTrue(list.Count > 0);
        }

        [Test]
        public void GetCollectedInvoices()
        {
            for (int x = 0; x < 2; x++)
            {
                Account acct = new Account(Factories.GetMockAccountName());
                acct.Create();

                Adjustment a = acct.CreateAdjustment("Test Charge", 500 + x, "USD");
                a.Create();

                Invoice i = acct.InvoicePendingCharges();


                i.MarkSuccessful();
                Thread.Sleep(1);
            }
            InvoiceList list = InvoiceList.GetInvoices(Invoice.InvoiceState.collected);

            Assert.IsTrue(list.Count > 0);
        }

        [Test]
        public void GetFailedInvoices()
        {
            for (int x = 0; x < 2; x++)
            {
                Account acct = new Account(Factories.GetMockAccountName());
                acct.Create();

                Adjustment a = acct.CreateAdjustment("Test Charge", 500 + x, "USD");
                a.Create();

                Invoice i = acct.InvoicePendingCharges();

                i.MarkFailed();
                Thread.Sleep(1);
            }
            InvoiceList list = InvoiceList.GetInvoices(Invoice.InvoiceState.failed);

            Assert.IsTrue(list.Count > 0);
        }

        [Test]
        public void GetPastDueInvoices()
        {
            for (int x = 0; x < 2; x++)
            {
                Account acct = new Account(Factories.GetMockAccountName());
                acct.Create();

                Adjustment a = acct.CreateAdjustment("Test Charge", 500 + x, "USD");
                a.Create();

                Invoice i = acct.InvoicePendingCharges();

                Thread.Sleep(1);
            }
            InvoiceList list = InvoiceList.GetInvoices(Invoice.InvoiceState.past_due);

            Assert.IsTrue(list.Count > 0);
        }

        [Test]
        public void GetInvoicesForAccount()
        {
            string accountCode = Factories.GetMockAccountName();
            Account acct = new Account(accountCode);
            acct.Create();

            Adjustment a = acct.CreateAdjustment("Test Charge #1", 450, "USD");
            a.Create();

            Invoice i = acct.InvoicePendingCharges();
            i.MarkSuccessful();

            a = acct.CreateAdjustment("Test Charge #2", 350, "USD");
            a.Create();

            InvoiceList list = InvoiceList.GetInvoices(accountCode);

            Assert.IsTrue(list.Count > 0);

        }


    }
}
