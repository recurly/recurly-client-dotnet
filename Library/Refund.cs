using System;
using System.Xml;

namespace Recurly
{
    public class Refund : RecurlyEntity
    {
        public bool Prorate { get; protected set; }
        public int Quantity { get; protected set; }
        public decimal? QuantityDecimal { get; protected set; }
        public string Uuid { get; protected set; }

        [Obsolete("This constructor is deprecated, please use Refund(Adjustment).")]
        internal Refund(Adjustment adjustment, bool prorate, int quantity)
        {
            Prorate = prorate;
            Quantity = quantity;
            Uuid = adjustment.Uuid;
        }

        internal Refund(Adjustment adjustment)
        {
            Prorate = adjustment.Prorate.HasValue ? adjustment.Prorate.Value : false;
            Quantity = adjustment.Quantity;
            QuantityDecimal = adjustment.QuantityDecimal;
            Uuid = adjustment.Uuid;
        }

        internal override void ReadXml(XmlTextReader reader)
        {
            throw new System.NotImplementedException();
        }

        internal override void WriteXml(XmlTextWriter writer)
        {
            writer.WriteStartElement("adjustment");

            writer.WriteElementString("uuid", Uuid);
            writer.WriteElementString("quantity", Quantity.AsString());

            if (QuantityDecimal.HasValue)
                writer.WriteElementString("quantity_decimal", QuantityDecimal.Value.ToString());

            writer.WriteElementString("prorate", Prorate.AsString());

            writer.WriteEndElement(); // adjustment
        }
    }
}
