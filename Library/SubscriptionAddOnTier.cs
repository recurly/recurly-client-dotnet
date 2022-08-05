using System;
using System.Collections.Generic;
using System.Xml;

namespace Recurly
{
    /// <summary>
    /// Represents subscription add-on tiers
    /// </summary>
    public class SubscriptionAddOnTier : RecurlyEntity
    {
        public int? EndingQuantity { get; set; }

        public int? UnitAmountInCents { get; set; }

        #region Constructors

        public SubscriptionAddOnTier()
        {
        }

        internal SubscriptionAddOnTier(XmlTextReader xmlReader)
        {
            ReadXml(xmlReader);
        }

        #endregion

        #region Read and Write XML documents

        internal override void ReadXml(XmlTextReader reader)
        {

            while (reader.Read())
            {
                if (reader.Name == "tier" && reader.NodeType == XmlNodeType.EndElement)
                    break;

                if (reader.NodeType != XmlNodeType.Element) continue;
                switch (reader.Name)
                {
                    case "unit_amount_in_cents":
                        UnitAmountInCents = reader.ReadElementContentAsInt();
                        break;

                    case "ending_quantity":
                        EndingQuantity = reader.ReadElementContentAsInt();
                        break;
                }
            }
        }

        internal override void WriteXml(XmlTextWriter xmlWriter)
        {
            WriteXml(xmlWriter, false);
        }

        internal void WriteEmbeddedXml(XmlTextWriter xmlWriter)
        {
            WriteXml(xmlWriter, true);
        }

        internal void WriteXml(XmlTextWriter xmlWriter, bool embedded = false)
        {
            xmlWriter.WriteStartElement("tier");

            if (UnitAmountInCents.HasValue)
                xmlWriter.WriteElementString("unit_amount_in_cents", UnitAmountInCents.Value.AsString());

            if (EndingQuantity.HasValue)
                xmlWriter.WriteElementString("ending_quantity", EndingQuantity.Value.AsString());

            xmlWriter.WriteEndElement();
        }

        #endregion
    }
}
