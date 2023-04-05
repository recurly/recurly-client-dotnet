using System;
using System.Xml;

namespace Recurly
{
    /// <summary>
    /// An invoice from an external resource that is not managed by the Recurly platform and instead is managed by third-party platforms like Apple Store and Google Play.
    /// </summary>
    public class ExternalCharge : RecurlyEntity
    {
        private string _accountCode;
        public string AccountCode => _accountCode;

        private Account _account;
        public Account Account
        {
            get { return _account ?? (_account = Accounts.Get(_accountCode)); }
            internal set { _account = value; }
        }
        private string _externalInvoiceUuid;
        public string ExternalInvoiceUuid => _externalInvoiceUuid;

        private ExternalInvoice _externalInvoice;
        public ExternalInvoice ExternalInvoice
        {
            get { return _externalInvoice ?? (_externalInvoice = ExternalInvoices.Get(_externalInvoiceUuid)); }
            internal set { _externalInvoice = value; }
        }
        public string Description { get; private set; }
        public decimal UnitAmount { get; private set; }
        public string Currency { get; private set; }
        public int Quantity { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }
        internal ExternalCharge()
        {
        }
        internal ExternalCharge(XmlTextReader reader)
        {
            ReadXml(reader);
        }
        #region Read XML documents

        internal override void ReadXml(XmlTextReader reader)
        {
            while (reader.Read())
            {
                string href;
                DateTime dateVal;

                if (reader.Name == "external_charge" && reader.NodeType == XmlNodeType.EndElement)
                    break;

                if (reader.NodeType != XmlNodeType.Element) continue;

                switch (reader.Name)
                {
                    case "account":
                        href = reader.GetAttribute("href");
                        if (null != href)
                            _accountCode = Uri.UnescapeDataString(href.Substring(href.LastIndexOf("/") + 1));
                        break;

                    case "external_invoice":
                        href = reader.GetAttribute("href");
                        if (null != href)
                            _externalInvoiceUuid = Uri.UnescapeDataString(href.Substring(href.LastIndexOf("/") + 1));
                        break;

                    case "description":
                        Description = reader.ReadElementContentAsString();
                        break;

                    case "unit_amount":
                        UnitAmount = reader.ReadElementContentAsDecimal();
                        break;

                    case "quantity":
                        Quantity = reader.ReadElementContentAsInt();
                        break;

                    case "currency":
                        Currency = reader.ReadElementContentAsString();
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

        internal override void WriteXml(XmlTextWriter writer)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}