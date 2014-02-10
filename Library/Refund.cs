using System.Xml;

namespace Recurly
{
    public class Refund
    {
        public bool Prorate { get; protected set; }
        public int Quantity { get; protected set; }
        public string Uuid { get; protected set; }

        internal Refund(Adjustment adjustment, bool prorate, int quantity)
        {
            Prorate = prorate;
            Quantity = quantity;
            Uuid = adjustment.Uuid;
        }

        internal void WriteXml(XmlTextWriter writer)
        {
            writer.WriteStartElement("invoice");
            writer.WriteStartElement("line_items");
            writer.WriteStartElement("adjustment");

            writer.WriteElementString("uuid", Uuid);
            writer.WriteElementString("quantity", Quantity.AsString());
            writer.WriteElementString("prorate", Prorate.ToString());

            writer.WriteEndElement(); // adjustment
            writer.WriteEndElement(); // line_items
            writer.WriteEndElement(); // invoice
        }
    }
}
