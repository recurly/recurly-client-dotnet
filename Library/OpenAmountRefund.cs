using System.Xml;

namespace Recurly
{
    class OpenAmountRefund : RecurlyEntity
    {
        public int AmountInCents { get; protected set; }
        private Invoice.RefundMethod RefundMethod;

        internal OpenAmountRefund(int amountInCents, Invoice.RefundMethod method = Invoice.RefundMethod.CreditFirst)
        {
            AmountInCents = amountInCents;
            RefundMethod = method;
        }

        internal override void ReadXml(XmlTextReader reader)
        {
            throw new System.NotImplementedException();
        }

        internal override void WriteXml(XmlTextWriter writer)
        {
            writer.WriteStartElement("invoice");
            writer.WriteElementString("refund_method", RefundMethod.ToString().ToLower());
            writer.WriteElementString("amount_in_cents", AmountInCents.AsString());
            writer.WriteEndElement();
        }
    }
}
