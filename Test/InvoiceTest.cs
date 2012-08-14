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
            // Account a = Account.Get("josh1");

            Invoice i = Invoice.Get("1008");
            foreach (Transaction t in i.Transactions)
            {
                System.Diagnostics.Debug.WriteLine("Found transaction: ");
                System.Diagnostics.Debug.WriteLine(t.AmountInCents);
                System.Diagnostics.Debug.WriteLine(t.ToString());

            }
        }
    }
}
