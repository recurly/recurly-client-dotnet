using System;
using System.Xml;

namespace Recurly
{
    class VerifyGateway : RecurlyEntity
    {
        public string GatewayCode { get; set; }

        internal VerifyGateway(string gateway_code)
        {
            GatewayCode = gateway_code;
        }

        internal override void ReadXml(XmlTextReader reader)
            {
            while (reader.Read())
            {
              if (reader.Name == "verify" && reader.NodeType == XmlNodeType.EndElement)
                  break;

              if (reader.NodeType != XmlNodeType.Element) continue;

              if (reader.Name == "gateway_code")
                    GatewayCode = reader.ReadElementContentAsString();
            }
        }

        internal override void WriteXml(XmlTextWriter writer)
        {
            writer.WriteStartElement("verify");

            writer.WriteElementString("gateway_code", GatewayCode);

            writer.WriteEndElement(); 
        }
    }
}
