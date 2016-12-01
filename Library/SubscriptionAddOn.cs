using System;
using System.Xml;

namespace Recurly
{
    public class SubscriptionAddOn : RecurlyEntity
    {
        public string AddOnCode { get; set; }
        public AddOn.Type? AddOnType { get; set; }
        public int UnitAmountInCents { get; set; }
        public int Quantity { get; set; }

        public SubscriptionAddOn(XmlTextReader reader)
        {
            ReadXml(reader);
        }

        public SubscriptionAddOn(string addOnCode, AddOn.Type? addOnType, int unitAmountInCents, int quantity = 1)
        {
            AddOnCode = addOnCode;
            AddOnType = addOnType;
            UnitAmountInCents = unitAmountInCents;
            Quantity = quantity;
        }

        internal override void ReadXml(XmlTextReader reader)
        {
            while (reader.Read())
            {
                if (reader.Name == "subscription_add_on" && reader.NodeType == XmlNodeType.EndElement)
                    break;

                if (reader.NodeType != XmlNodeType.Element) continue;

                switch (reader.Name)
                {
                    case "add_on_code":
                        AddOnCode = reader.ReadElementContentAsString();
                        break;

                    case "add_on_type":
                        AddOnType = reader.ReadElementContentAsString().ParseAsEnum<AddOn.Type>();
                        break;

                    case "quantity":
                        Quantity = reader.ReadElementContentAsInt();
                        break;

                    case "unit_amount_in_cents":
                        int unitAmountInCents;
                        if (Int32.TryParse(reader.ReadElementContentAsString(), out unitAmountInCents))
                            UnitAmountInCents = unitAmountInCents;
                        break;
                }
            }
        }

        internal override void WriteXml(XmlTextWriter writer)
        {
            writer.WriteStartElement("subscription_add_on");

            writer.WriteElementString("add_on_code", AddOnCode);
            writer.WriteElementString("quantity", Quantity.AsString());
            if (AddOnType.HasValue && AddOnType == AddOn.Type.Fixed)
                writer.WriteElementString("unit_amount_in_cents", UnitAmountInCents.AsString());

            writer.WriteEndElement();
        }
    }
}
