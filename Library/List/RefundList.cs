using System.Xml;
using System.Collections;
using System.Collections.Generic;

namespace Recurly
{
    internal class RefundList : IEnumerable<Refund>
    {
        private List<Refund> Refunds = new List<Refund>();
        private Invoice.RefundOrderPriority RefundPriority;

        internal RefundList(IEnumerable<Adjustment> adjustments, bool prorate, int quantity = 0, Invoice.RefundOrderPriority refundPriority = Invoice.RefundOrderPriority.Credit)
        {
            foreach (var adjustment in adjustments)
            {
                var count = quantity == 0
                    ? adjustment.Quantity
                    : quantity;

                var refund = new Refund(adjustment, prorate, count);
                Refunds.Add(refund);
            }

            RefundPriority = refundPriority;
        }

        internal void WriteXml(XmlTextWriter writer) 
        {
            writer.WriteStartElement("invoice");
            writer.WriteElementString("refund_apply_order", RefundPriority.ToString().ToLower());
            writer.WriteStartElement("line_items");

            foreach (var refund in Refunds)
            {
                refund.WriteXml(writer);
            }

            writer.WriteEndElement(); // line_items
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