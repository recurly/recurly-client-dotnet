using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Recurly
{
    public class UsageRecord : RecurlyEntity
    {
        // The valid Usage Types
        public enum UsageType
        {
            Price,
            Percentage,
        }

        public int Amount { get; set; }
        public string MerchantTag { get; set; }
        public DateTime RecordingTimestamp { get; set; }
        public DateTime UsageTimestamp { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? BilledAt { get; set; }
        public UsageType Type { get; set; }
        public int UnitAmountInCents { get; set; }
        public int? UsagePercentage { get; set; }

        public string SubscriptionUuid { get; set; }
        public string AddOnCode { get; set; }

        internal const string UrlSubscriptionPrefix = "/subscriptions/";
        internal const string UrlAddonPrefix = "/add_ons/";
        internal const string UrlPostfix = "/usage/";

        private string usageUrl()
        {
            return UrlSubscriptionPrefix + Uri.EscapeUriString(SubscriptionUuid) + UrlAddonPrefix + Uri.EscapeUriString(AddOnCode) + UrlPostfix;
        }

        #region API

        public UsageRecord Log()
        {
            var response = Client.Instance.PerformRequest(Client.HttpRequestMethod.Post,
                            usageUrl(),
                            WriteXml,
                            ReadXml);

            if (HttpStatusCode.Created == response || HttpStatusCode.OK == response)
                return this;
            else
                return null;
        }

        #endregion

        #region Read and Write XML documents

        internal override void ReadXml(XmlTextReader reader)
        {
            while (reader.Read())
            {
                // End of account element, get out of here
                if (reader.Name == "usage" && reader.NodeType == XmlNodeType.EndElement)
                    break;

                if (reader.NodeType != XmlNodeType.Element) continue;

                switch (reader.Name)
                {
                    case "amount":
                        Amount = reader.ReadElementContentAsInt();
                        break;

                    case "merchant_tag":
                        MerchantTag = reader.ReadElementContentAsString();
                        break;

                    case "recording_timestamp":
                        RecordingTimestamp = reader.ReadElementContentAsDateTime();
                        break;

                    case "usage_timestamp":
                        UsageTimestamp = reader.ReadElementContentAsDateTime();
                        break;

                    case "created_at":
                        DateTime createdAt;
                        if (DateTime.TryParse(reader.ReadElementContentAsString(), out createdAt))
                            CreatedAt = createdAt;
                        break;

                    case "updated_at":
                        DateTime updatedAt;
                        if (DateTime.TryParse(reader.ReadElementContentAsString(), out updatedAt))
                            UpdatedAt = updatedAt;
                        break;

                    case "billed_at":
                        DateTime billedAt;
                        if (DateTime.TryParse(reader.ReadElementContentAsString(), out billedAt))
                            BilledAt = billedAt;
                        break;

                    case "usage_type":
                        Type = reader.ReadElementContentAsString().ParseAsEnum<UsageType>();
                        break;

                    case "unit_amount_in_cents":
                        UnitAmountInCents = reader.ReadElementContentAsInt();
                        break;

                    case "usage_percentage":
                        UsagePercentage = reader.ReadElementContentAsInt();
                        break;
                }
            }
        }

        internal override void WriteXml(XmlTextWriter xmlWriter)
        {
            xmlWriter.WriteStartElement("usage");

            xmlWriter.WriteElementString("amount", Amount.AsString());
            xmlWriter.WriteElementString("merchant_tag", MerchantTag);
            xmlWriter.WriteElementString("recording_timestamp", RecordingTimestamp.ToString());
            xmlWriter.WriteElementString("usage_timestamp", RecordingTimestamp.ToString()) ;

            xmlWriter.WriteEndElement();
        }

        #endregion
    }

}
