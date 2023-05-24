using System;
using System.Collections.Generic;
using System.Xml;

namespace Recurly
{
    /// <summary>
    /// Additional attributes to send to the gateway.
    /// </summary>
    public class GatewayAttributes : RecurlyEntity
    {

        /// <summary>Used by Adyen gateways. The Shopper Reference value used when the external token was created. Must be used in conjunction with gateway_token and gateway_code.
        /// </summary>
        public string AccountReference { get; set; }

        public GatewayAttributes()
        { }

        internal GatewayAttributes(XmlTextReader xmlReader)
        {
            ReadXml(xmlReader);
        }

        internal override void WriteXml(XmlTextWriter xmlWriter)
        {
            xmlWriter.WriteStartElement("gateway_attributes");
            xmlWriter.WriteElementString("account_reference", AccountReference);
            xmlWriter.WriteEndElement();
        }

        internal override void ReadXml(XmlTextReader reader)
        {
            while (reader.Read())
            {
                if (reader.Name == "gateway_attributes" && reader.NodeType == XmlNodeType.EndElement)
                    break;

                if (reader.NodeType != XmlNodeType.Element) continue;

                switch (reader.Name)
                {
                    case "account_reference":
                        AccountReference = reader.ReadElementContentAsString();
                        break;
                }
            }
        }

    }
}