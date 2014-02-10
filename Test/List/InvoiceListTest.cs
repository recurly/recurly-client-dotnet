﻿using NUnit.Framework;
using System.Threading;


namespace Recurly.Test
{
    [TestFixture]
    class InvoiceListTest : BaseTest
    {

        [Test]
        public void GetInvoices()
        {

            for (int x = 0; x < 6; x++)
            {
                Account acct = new Account(GetMockAccountName());
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
                Thread.Sleep(1000);
            } 
            
            InvoiceList list = Invoices.List();

            Assert.IsTrue(list.Count > 0);

        }

        [Test]
        public void GetOpenInvoices()
        {
            for (int x = 0; x < 2; x++)
            {
                Account acct = new Account(GetMockAccountName());
                acct.Create();

                Adjustment a = acct.CreateAdjustment("Test Charge", 500 + x, "USD");
                a.Create();

                Invoice i = acct.InvoicePendingCharges();

                Thread.Sleep(1000);
            }
            InvoiceList list = Invoices.List(Invoice.InvoiceState.Open);

            Assert.IsTrue(list.Count > 0);
        }

        [Test]
        public void GetCollectedInvoices()
        {
            for (int x = 0; x < 2; x++)
            {
                Account acct = new Account(GetMockAccountName());
                acct.Create();

                Adjustment a = acct.CreateAdjustment("Test Charge", 500 + x, "USD");
                a.Create();

                Invoice i = acct.InvoicePendingCharges();


                i.MarkSuccessful();
                Thread.Sleep(1000);
            }
            InvoiceList list = Invoices.List(Invoice.InvoiceState.Collected);

            Assert.IsTrue(list.Count > 0);
        }

        [Test]
        public void GetFailedInvoices()
        {
            for (int x = 0; x < 2; x++)
            {
                Account acct = new Account(GetMockAccountName());
                acct.Create();

                Adjustment a = acct.CreateAdjustment("Test Charge", 500 + x, "USD");
                a.Create();

                Invoice i = acct.InvoicePendingCharges();

                i.MarkFailed();
                Thread.Sleep(1000);
            }
            InvoiceList list = Invoices.List(Invoice.InvoiceState.Failed);

            Assert.IsTrue(list.Count > 0);
        }

        [Test]
        public void GetPastDueInvoices()
        {
            for (int x = 0; x < 2; x++)
            {
                Account acct = new Account(GetMockAccountName());
                acct.Create();

                Adjustment a = acct.CreateAdjustment("Test Charge", 500 + x, "USD");
                a.Create();

                Invoice i = acct.InvoicePendingCharges();

                Thread.Sleep(1000);
            }
            InvoiceList list = Invoices.List(Invoice.InvoiceState.PastDue);

            Assert.IsTrue(list.Count > 0);
        }

        [Test]
        public void GetInvoicesForAccount()
        {
            string accountCode = GetMockAccountName();
            Account acct = new Account(accountCode);
            acct.Create();

            Adjustment a = acct.CreateAdjustment("Test Charge #1", 450, "USD");
            a.Create();

            Invoice i = acct.InvoicePendingCharges();
            i.MarkSuccessful();

            a = acct.CreateAdjustment("Test Charge #2", 350, "USD");
            a.Create();

            InvoiceList list = Invoices.List(accountCode);

            Assert.IsTrue(list.Count > 0);

        }


    }
}