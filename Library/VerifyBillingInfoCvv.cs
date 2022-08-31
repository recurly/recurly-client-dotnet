using System;
using System.Xml;

namespace Recurly
{
    class VerifyBillingInfoCvv : RecurlyEntity
    {
        public string VerificationValue { get; set; }

        internal VerifyBillingInfoCvv(string verification_value)
        {
            VerificationValue = verification_value;
        }

        internal override void ReadXml(XmlTextReader reader)
        {
            while (reader.Read())
            {
                if (reader.Name == "verify_cvv" && reader.NodeType == XmlNodeType.EndElement)
                    break;

                if (reader.NodeType != XmlNodeType.Element) continue;

                if (reader.Name == "verification_value")
                    VerificationValue = reader.ReadElementContentAsString();
            }
        }

        internal override void WriteXml(XmlTextWriter writer)
        {
            writer.WriteStartElement("billing_info");
            if (!VerificationValue.IsNullOrEmpty())
            {
                writer.WriteElementString("verification_value", VerificationValue);
            };
            writer.WriteEndElement();
        }
    }
}
