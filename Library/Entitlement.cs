using System;
using System.Collections.Generic;
using System.Net;
using System.Xml;

namespace Recurly
{

    public class Entitlement : RecurlyEntity
    {
        public string AccountCode { get; private set; }

        public CustomerPermission CustomerPermission { get; private set; }

        private List<string> _grantedBy;

        public List<string> GrantedBy
        {
            get { return _grantedBy ?? (_grantedBy = new List<string>()); }
        }

        public DateTime? CreatedAt { get; private set; }

        public DateTime? UpdatedAt { get; private set; }

        internal Entitlement(string accountCode) : this()
        {
            AccountCode = accountCode;
        }

        public Entitlement(Account account) : this()
        {
            AccountCode = account.AccountCode;
        }

        internal Entitlement(XmlTextReader xmlReader)
        {
            ReadXml(xmlReader);
        }

        public Entitlement() { }

        internal override void ReadXml(XmlTextReader reader)
        {
            while (reader.Read())
            {
                if (reader.Name == "entitlement" && reader.NodeType == XmlNodeType.EndElement)
                    break;

                if (reader.NodeType != XmlNodeType.Element) continue;

                switch (reader.Name)
                {
                    case "entitlement":
                        break;

                    case "account":
                        var href = reader.GetAttribute("href");
                        AccountCode = Uri.UnescapeDataString(href.Substring(href.LastIndexOf("/") + 1));
                        break;

                    case "customer_permission":
                        CustomerPermission = new CustomerPermission(reader);
                        break;

                    case "granted_by":
                        ReadXMLGrantedBys(reader);
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

        internal void ReadXMLGrantedBys(XmlTextReader reader)
        {
            GrantedBy.Clear();

            while (reader.Read())
            {
                if (reader.Name == "granted_by" && reader.NodeType == XmlNodeType.EndElement)
                    break;

                if (reader.NodeType == XmlNodeType.Element)
                {
                    var href = reader.GetAttribute("href");
                    GrantedBy.Add(href);
                }
            }
        }

        internal override void WriteXml(XmlTextWriter writer)
        {
            throw new NotImplementedException();
        }
    }
}
