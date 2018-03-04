using System;
using System.Net;
using System.Xml;

namespace Recurly
{
    public class AccountAcquisition : RecurlyEntity
    {
        public enum AccountAcquisitionChannel : short
        {
            Referral,
            SocialMedia,
            Email,
            PaidSearch,
            OrganicSearch,
            DirectTraffic,
            MarketingContent,
            Blog,
            Events,
            OutboundSales,
            Advertising,
            PublicRelations,
            Other
        }

        public string AccountCode { get; private set; }
        public int CostInCents { get; set; }
        public string Currency { get; set; }
        public AccountAcquisitionChannel Channel { get; set; }
        public string SubChannel { get; set; }
        public string Campaign { get; set; }

        private const string UrlPrefix = "/accounts/";
        private const string UrlPostfix = "/acquisition";

        public AccountAcquisition(string accountCode) : this()
        {
            AccountCode = accountCode;
        }

        public AccountAcquisition(Account account) : this()
        {
            AccountCode = account.AccountCode;
        }

        private AccountAcquisition()
        {
        }

        public static AccountAcquisition Get(string accountCode)
        {
            var accountAcquisition = new AccountAcquisition();

            var statusCode = Client.Instance.PerformRequest(Client.HttpRequestMethod.Get,
                AccountAcquisitionUrl(accountCode),
                accountAcquisition.ReadXml);

            return statusCode == HttpStatusCode.NotFound ? null : accountAcquisition;
        }

        public void Create()
        {
            Client.Instance.PerformRequest(Client.HttpRequestMethod.Post,
                AccountAcquisitionUrl(AccountCode),
                WriteXml,
                ReadXml);
        }

        public void Update()
        {
            Client.Instance.PerformRequest(Client.HttpRequestMethod.Put,
                AccountAcquisitionUrl(AccountCode),
                WriteXml);
        }

        private static string AccountAcquisitionUrl(string accountCode)
        {
            return UrlPrefix + Uri.EscapeDataString(accountCode) + UrlPostfix;
        }

        internal override void ReadXml(XmlTextReader reader)
        {
            while (reader.Read())
            {
                if (reader.Name == "account_acquisition" && reader.NodeType == XmlNodeType.EndElement)
                    break;

                if (reader.NodeType != XmlNodeType.Element)
                    continue;

                switch (reader.Name)
                {
                    case "account":
                        var href = reader.GetAttribute("href");
                        AccountCode = Uri.UnescapeDataString(href.Substring(href.LastIndexOf("/") + 1));
                        break;

                    case "cost_in_cents":
                        CostInCents = reader.ReadElementContentAsInt();
                        break;

                    case "currency":
                        Currency = reader.ReadElementContentAsString();
                        break;

                    case "channel":
                        Channel = reader.ReadElementContentAsString().ParseAsEnum<AccountAcquisitionChannel>();
                        break;

                    case "subchannel":
                        SubChannel = reader.ReadElementContentAsString();
                        break;

                    case "campaign":
                        Campaign = reader.ReadElementContentAsString();
                        break;
                }
            }
        }

        internal override void WriteXml(XmlTextWriter xmlWriter)
        {
            xmlWriter.WriteStartElement("account_acquisition"); // Start: Account Acquisition
            xmlWriter.WriteElementString("cost_in_cents", CostInCents.AsString());
            xmlWriter.WriteElementString("currency", Currency);
            xmlWriter.WriteElementString("channel", Channel.ToString().EnumNameToTransportCase());
            xmlWriter.WriteElementString("subchannel", SubChannel);
            xmlWriter.WriteElementString("campaign", Campaign);
            xmlWriter.WriteEndElement(); // End: Account Acquisition
        }

        #region Object Overrides

        public override string ToString()
        {
            return "Recurly Account Acquisition : " + AccountCode;
        }

        public override bool Equals(object obj)
        {
            var a = obj as AccountAcquisition;
            return a != null && Equals(a);
        }

        public bool Equals(AccountAcquisition accountAcquisition)
        {
            return AccountCode == accountAcquisition.AccountCode;
        }

        public override int GetHashCode()
        {
            return AccountCode?.GetHashCode() ?? 0;
        }

        #endregion
    }
}
