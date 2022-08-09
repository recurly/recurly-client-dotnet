using System;
using System.Collections.Generic;
using System.Xml;

namespace Recurly
{
    /// <summary>
    /// Represents add-on tiers
    /// </summary>
    public class PercentageTier : RecurlyEntity
    {
        public string UsagePercentage { get; set; }

        public long? EndingAmountInCents { get; set; }

        #region Constructors

        public PercentageTier() { }

        internal PercentageTier(XmlTextReader xmlReader)
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
                    case "usage_percentage":
                        UsagePercentage = reader.ReadElementContentAsString();
                        break;

                    case "ending_amount_in_cents":
                        long endingAmountInCents;
                        if (Int64.TryParse(reader.ReadElementContentAsString(), out endingAmountInCents))
                            EndingAmountInCents = endingAmountInCents;
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

            xmlWriter.WriteStringIfValid("usage_percentage", UsagePercentage);

            if (EndingAmountInCents.HasValue)
                xmlWriter.WriteElementString("ending_amount_in_cents", EndingAmountInCents.ToString());

            xmlWriter.WriteEndElement();
        }

        #endregion
    }
}
