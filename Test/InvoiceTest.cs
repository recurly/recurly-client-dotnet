using System;
using System.Collections.Generic;
using System.Text;
using Recurly;
using NUnit.Framework;

namespace Recurly.Test
{
    [TestFixture]
    class InvoiceTest
    {
  
        [Test]
        public void GetInvoice()
        {
            Account acct = new Account(Factories.GetMockAccountName());
            acct.Create();

            Adjustment a = acct.CreateAdjustment("Test Charge", 5000, "USD");
            a.Create();

            Invoice i = acct.InvoicePendingCharges();

            Invoice i2 = Invoice.Get(i.InvoiceNumber);

            Assert.AreEqual(i, i2);
        }

        [Test]
        public void GetInvoicePDF()
        {
            Account acct = new Account(Factories.GetMockAccountName());
            acct.Create();

            Adjustment a = acct.CreateAdjustment("Test Charge", 5000, "USD");
            a.Create();

            Invoice i = acct.InvoicePendingCharges();

            byte[] pdf = i.GetPdf();
            // Not sure what the PDF size will be, so guessing the results are correct if length is greater than 25000 bytes.
            Assert.IsTrue(pdf.Length > 25000);

        }

        [Test]
        public void Post()
        {
            Account acct = new Account(Factories.GetMockAccountName());
            acct.Create();

            Adjustment a = acct.CreateAdjustment("Test Charge", 5000, "USD");
            a.Create();

            a = acct.CreateAdjustment("Test Charge 2", 5000, "USD");
            a.Create();

            a = acct.CreateAdjustment("Test Credit", -2500, "USD");
            a.Create();


            Invoice i = acct.InvoicePendingCharges();

            Assert.AreEqual(i.State, Invoice.InvoiceState.open);
            Assert.AreEqual(i.TotalInCents, 7500);
        }

       

        [Test]
        public void MarkSuccessful()
        {
            Account acct = new Account(Factories.GetMockAccountName());
            acct.Create();

            Adjustment a = acct.CreateAdjustment("Test Charge", 3999, "USD");
            a.Create();

            Invoice i = acct.InvoicePendingCharges();

            i.MarkSuccessful();

            Assert.AreEqual(i.State, Invoice.InvoiceState.collected);

        }

        [Test]
        public void FailedCollection()
        {
            Account acct = new Account(Factories.GetMockAccountName());
            acct.Create();

            Adjustment a = acct.CreateAdjustment("Test Charge", 3999, "USD");
            a.Create();

            Invoice i = acct.InvoicePendingCharges();

            i.MarkFailed();

            Assert.AreEqual(i.State, Invoice.InvoiceState.failed);
        }


    }
}
