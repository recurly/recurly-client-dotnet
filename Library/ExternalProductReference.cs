using System;
using System.Collections.Generic;
using System.Net;
using System.Xml;

namespace Recurly
{

    /// <summary>
    /// An item in Recurly.
    ///
    /// </summary>
    public class ExternalProductReference : RecurlyEntity
    {
        public string Id { get; set; }
        public string ReferenceCode { get; set; }
        public string ExternalConnectionType { get; set; }
        public DateTime? CreatedAt { get; private set; }
        public DateTime? UpdatedAt { get; private set; }

        public ExternalProductReference()
        {
        }

        internal ExternalProductReference(XmlTextReader reader)
        {
            ReadXml(reader);
        }

        internal override void ReadXml(XmlTextReader reader)
        {
            DateTime dateVal;

            while (reader.Read())
            {
                if (reader.Name == "external_product_reference" && reader.NodeType == XmlNodeType.EndElement)
                    break;

                if (reader.NodeType != XmlNodeType.Element) continue;

                switch (reader.Name)
                {
                    case "id":
                        Id = reader.ReadElementContentAsString();
                        break;
                    case "reference_code":
                        ReferenceCode = reader.ReadElementContentAsString();
                        break;
                    case "external_connection_type":
                        ExternalConnectionType = reader.ReadElementContentAsString();
                        break;

                    case "updated_at":
                        if (DateTime.TryParse(reader.ReadElementContentAsString(), out dateVal))
                            UpdatedAt = dateVal; ;
                        break;

                    case "created_at":
                        if (DateTime.TryParse(reader.ReadElementContentAsString(), out dateVal))
                            CreatedAt = dateVal; ;
                        break;
                }
            }
        }


        internal override void WriteXml(XmlTextWriter xmlWriter)
        {
            WriteXml(xmlWriter, "external_product_reference");
        }

        internal void WriteXml(XmlTextWriter xmlWriter, string xmlName)
        {
            xmlWriter.WriteStartElement(xmlName); // Start: external_product_reference

            xmlWriter.WriteElementString("reference_code", ReferenceCode);
            xmlWriter.WriteStringIfValid("external_connection_type", ExternalConnectionType);
            xmlWriter.WriteEndElement();
        }
    }
}
