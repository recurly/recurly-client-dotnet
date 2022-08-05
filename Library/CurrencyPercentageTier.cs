using System;
using System.Collections.Generic;
using System.Xml;

namespace Recurly
{
    /// <summary>
    /// Represents add-on tiers
    /// </summary>
    public class CurrencyPercentageTier : RecurlyEntity
    {
        public string Currency { get; set; }

        private List<PercentageTier> _percentageTiers;

        public List<PercentageTier> PercentageTiers
        {
            get { return _percentageTiers ?? (_percentageTiers = new List<PercentageTier>()); }
            set { _percentageTiers = value; }
        }

        #region Constructors

        public CurrencyPercentageTier() { }

        internal CurrencyPercentageTier(XmlTextReader xmlReader)
        {
            ReadXml(xmlReader);
        }

        #endregion

        #region Read and Write XML documents

        internal override void ReadXml(XmlTextReader reader)
        {
            while (reader.Read())
            {
                if (reader.Name == "percentage_tier" && reader.NodeType == XmlNodeType.EndElement)
                    break;

                if (reader.NodeType != XmlNodeType.Element) continue;
                switch (reader.Name)
                {
                    case "currency":
                        Currency = reader.ReadElementContentAsString();
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
            xmlWriter.WriteStartElement("percentage_tier");

            xmlWriter.WriteStringIfValid("currency", Currency);

            xmlWriter.WriteIfCollectionHasAny("tiers", PercentageTiers);

            xmlWriter.WriteEndElement();
        }

        #endregion
    }
}
