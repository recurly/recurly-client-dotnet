using System;
using System.Xml;

namespace Recurly
{
    /// <summary>
    /// Represents tax details
    /// </summary>
    public class TaxDetail : RecurlyEntity
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string Level { get; set; }
        public bool? Billable { get; set; }
        public decimal? TaxRate { get; set; }
        public int? TaxInCents { get; set; }
        public string TaxType { get; set; }
        public string TaxRegion { get; set; }

        #region Constructors

        public TaxDetail()
        {
        }

        internal TaxDetail(XmlTextReader xmlReader)
        {
            ReadXml(xmlReader);
        }

        #endregion

        #region Read and Write XML documents

        internal override void ReadXml(XmlTextReader reader)
        {
            while (reader.Read())
            {
                if (reader.Name == "tax_detail" && reader.NodeType == XmlNodeType.EndElement)
                    break;

                if (reader.NodeType != XmlNodeType.Element) continue;
                switch (reader.Name)
                {
                    case "name":
                        Name = reader.ReadElementContentAsString();
                        break;

                    case "type":
                        Type = reader.ReadElementContentAsString();
                        break;

                    case "level":
                        Level = reader.ReadElementContentAsString();
                        break;

                    case "billable":
                        Billable = reader.ReadElementContentAsBoolean();
                        break;

                    case "tax_rate":
                        TaxRate = reader.ReadElementContentAsDecimal();
                        break;

                    case "tax_in_cents":
                        TaxInCents = reader.ReadElementContentAsInt();
                        break;

                    case "tax_type":
                        TaxType = reader.ReadElementContentAsString();
                        break;

                    case "tax_region":
                        TaxRegion = reader.ReadElementContentAsString();
                        break;
                }
            }
        }

        internal override void WriteXml(XmlTextWriter writer)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
