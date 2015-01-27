using System.Xml;

namespace Recurly
{
    class OpenAmountRefund : RecurlyEntity
    {
        public int AmountInCents { get; protected set; }

        internal OpenAmountRefund(int amountInCents)
        {
            AmountInCents = amountInCents;
        }

        internal override void ReadXml(XmlTextReader reader)
        {
            throw new System.NotImplementedException();
        }

        internal override void WriteXml(XmlTextWriter writer)
        {
            writer.WriteStartElement("invoice");
            writer.WriteElementString("amount_in_cents", AmountInCents.AsString());
            writer.WriteEndElement();
        }
    }
}
