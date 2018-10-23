using System;
using System.Xml;
using System.Collections;
using System.Collections.Generic;

namespace Recurly
{
    internal class RefundList : IEnumerable<Refund>
    {
        private List<Refund> Refunds = new List<Refund>();
        private Invoice.RefundOptions RefundOptions;

        [Obsolete("This constructor is deprecated, please use RefundList(IEnumerable<Adjustment>, Invoice.RefundOptions).")]
        internal RefundList(IEnumerable<Adjustment> adjustments, bool prorate, int quantity = 0, Invoice.RefundMethod method = Invoice.RefundMethod.CreditFirst)
        {
            foreach (var adjustment in adjustments)
            {
                var count = quantity == 0
                    ? adjustment.Quantity
                    : quantity;

                var refund = new Refund(adjustment, prorate, count);
                Refunds.Add(refund);
            }

            RefundOptions = new Invoice.RefundOptions() {
              Method = method
            };
        }

        internal RefundList(IEnumerable<Adjustment> adjustments, Invoice.RefundOptions options)
        {
            foreach (var adjustment in adjustments)
            {
                var refund = new Refund(adjustment);
                Refunds.Add(refund);
            }

            RefundOptions = options;
        }


        internal void WriteXml(XmlTextWriter writer) 
        {
            writer.WriteStartElement("invoice");
            writer.WriteElementString("refund_method", RefundOptions.Method.ToString().EnumNameToTransportCase());
            writer.WriteStartElement("line_items");

            foreach (var refund in Refunds)
            {
                refund.WriteXml(writer);
            }

            writer.WriteEndElement(); // line_items

            if (RefundOptions.ExternalRefund.HasValue)
              writer.WriteElementString("external_refund", RefundOptions.ExternalRefund.Value.AsString());
            if (RefundOptions.RefundedAt.HasValue)
              writer.WriteElementString("refunded_at", RefundOptions.RefundedAt.Value.ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ssZ"));

            if (!RefundOptions.Description.IsNullOrEmpty())
              writer.WriteElementString("description", RefundOptions.Description);
            if (!RefundOptions.PaymentMethod.IsNullOrEmpty())
              writer.WriteElementString("payment_method", RefundOptions.PaymentMethod);
            if (!RefundOptions.CreditCustomerNotes.IsNullOrEmpty())
              writer.WriteElementString("credit_customer_notes", RefundOptions.CreditCustomerNotes);

            writer.WriteEndElement(); // invoice
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return Refunds.GetEnumerator();
        }

        public IEnumerator<Refund> GetEnumerator()
        {
            return Refunds.GetEnumerator();
        }
    }
}
