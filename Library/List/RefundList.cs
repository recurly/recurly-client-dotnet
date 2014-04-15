using System.Xml;
using System.Collections;
using System.Collections.Generic;

namespace Recurly
{
    internal class RefundList : IEnumerable<Refund>
    {
        private List<Refund> Refunds = new List<Refund>();
  
        internal RefundList(IEnumerable<Adjustment> adjustments, bool prorate, int quantity = 0)
        {
            foreach (var adjustment in adjustments)
            {
                var count = quantity == 0
                    ? adjustment.Quantity
                    : quantity;

                var refund = new Refund(adjustment, prorate, count);
                Refunds.Add(refund);
            }
        }

        internal void WriteXml(XmlTextWriter writer) 
        {
            writer.WriteStartElement("invoice");
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