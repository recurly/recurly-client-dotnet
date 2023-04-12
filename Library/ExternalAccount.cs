using System;
using System.Collections.Generic;
using System.Net;
using System.Xml;

namespace Recurly
{
    /// <summary>
    /// Represents external_accounts associated with Recurly accounts
    /// </summary>
    public class ExternalAccount : RecurlyEntity
    {
        public string Id { get; set; }
        public string ExternalAccountCode { get; set; }
        public string ExternalConnectionType { get; set; }
        public DateTime? CreatedAt { get; private set; }
        public DateTime? UpdatedAt { get; private set; }

        public List<ExternalAccount> ExternalAccounts
        {
            get { return _externalAccounts ?? (_externalAccounts = new List<ExternalAccount>()); }
            set { _externalAccounts = value; }
        }

        private List<ExternalAccount> _externalAccounts;

        public ExternalAccount() { }

        internal ExternalAccount(XmlTextReader reader)
        {
            ReadXml(reader);
        }

        internal override void ReadXml(XmlTextReader reader)
        {
            while (reader.Read())
            {
                if (reader.Name == "external_account" && reader.NodeType == XmlNodeType.EndElement)
                    break;

                if (reader.NodeType != XmlNodeType.Element)
                    continue;

                switch (reader.Name)
                {
                    case "id":
                        Id = reader.ReadElementContentAsString();
                        break;
                    case "external_account_code":
                        ExternalAccountCode = reader.ReadElementContentAsString();
                        break;
                    case "external_connection_type":
                        ExternalConnectionType = reader.ReadElementContentAsString();
                        break;
                    case "created_at":
                        CreatedAt = reader.ReadElementContentAsDateTime();
                        break;
                    case "updated_at":
                        UpdatedAt = reader.ReadElementContentAsDateTime();
                        break;
                }
            }
        }

        internal override void WriteXml(XmlTextWriter writer)
        {
            writer.WriteStartElement("external_account");
            writer.WriteElementString("external_account_code", ExternalAccountCode);
            writer.WriteElementString("external_connection_type", ExternalConnectionType);
            writer.WriteEndElement();
        }
    }
}
