using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Recurly
{
    public class Usage : RecurlyEntity {

        public enum Type
        {
            Price,
            Percentage
        }

        public long? Id { get; private set; }
        public int? UnitAmountInCents { get; set; }
        public float? UsagePercentage { get; set; }
        public int Amount{ get; set; }
        public String MerchantTag { get; set; }
        public Type UsageType { get; set; }
        public DateTime UsageTimestamp { get; set; }
        public DateTime? RecordingTimestamp { get; set; }
        public DateTime? BilledAt { get; set; }
        public DateTime? CreatedAt { get; private set; }
        public DateTime? UpdatedAt { get; private set; }

        // needed for GET parameters
        public String SubscriptionUuid { get; private set; }
        public String SubscriptionAddOnCode { get; private set; }

        internal Usage()
        {
        }

        internal Usage(XmlTextReader reader)
            : this()
        {
            ReadXml(reader);
        }

        public Usage(String subscriptionUuid, String subscriptionAddOnCode)
        {
            SubscriptionUuid = subscriptionUuid;
            SubscriptionAddOnCode = subscriptionAddOnCode;
        }

        /// <summary>
        /// Log a usage record in Recurly
        /// </summary>
        public void Create()
        {
            Client.Instance.PerformRequest(Client.HttpRequestMethod.Post,
                UrlPrefix(),
                WriteXml,
                ReadXml);
        }

        /// <summary>
        /// Update a usage record in Recurly
        /// </summary>
        public void Update()
        {
            Client.Instance.PerformRequest(Client.HttpRequestMethod.Put,
                UrlPrefix() + "/" + Id.ToString(),
                WriteXml);
        }

        /// <summary>
        /// Deletes this usage record
        /// </summary>
        public void Delete()
        {
            Client.Instance.PerformRequest(Client.HttpRequestMethod.Delete, UrlPrefix() + "/" + Id.ToString());
        }

        private String UrlPrefix()
        {
            return "/subscriptions/" + SubscriptionUuid + "/add_ons/" + SubscriptionAddOnCode + "/usage";
        }

        #region Read and Write XML documents

        internal override void ReadXml(XmlTextReader reader)
        {
            while (reader.Read())
            {
                // End of invoice element, get out of here
                if (reader.Name == "usage" && reader.NodeType == XmlNodeType.EndElement)
                    break;

                if (reader.NodeType != XmlNodeType.Element) continue;

                int unitAmountInCents;
                DateTime dateVal;

                switch (reader.Name)
                {
                    case "amount":
                        Amount = reader.ReadElementContentAsInt();
                        break;

                    case "unit_amount_in_cents":
                        if (Int32.TryParse(reader.ReadElementContentAsString(), out unitAmountInCents))
                            UnitAmountInCents = unitAmountInCents;
                        break;

                    case "merchant_tag":
                        MerchantTag = reader.ReadElementContentAsString();
                        break;

                    case "usage_percentage":
                        UsagePercentage = reader.ReadElementContentAsFloat();
                        break;

                    case "recording_timestamp":
                        if (DateTime.TryParse(reader.ReadElementContentAsString(), out dateVal))
                            RecordingTimestamp = dateVal;
                        break;

                    case "usage_timestamp":
                        if (DateTime.TryParse(reader.ReadElementContentAsString(), out dateVal))
                            UsageTimestamp = dateVal;
                        break;

                    case "billed_at":
                        if (DateTime.TryParse(reader.ReadElementContentAsString(), out dateVal))
                            BilledAt = dateVal;
                        break;

                    case "created_at":
                        if (DateTime.TryParse(reader.ReadElementContentAsString(), out dateVal))
                            CreatedAt = dateVal;
                        break;

                    case "updated_at":
                        if (DateTime.TryParse(reader.ReadElementContentAsString(), out dateVal))
                            UpdatedAt = dateVal;
                        break;
                }
            }
        }

        internal override void WriteXml(XmlTextWriter xmlWriter)
        {
            xmlWriter.WriteStartElement("usage");

            if (UsagePercentage.HasValue)
                xmlWriter.WriteElementString("usage_percentage", UsagePercentage.Value.ToString());

            if (UnitAmountInCents.HasValue)
                xmlWriter.WriteElementString("unit_amount_in_cents", UnitAmountInCents.Value.AsString());

            xmlWriter.WriteElementString("amount", Amount.AsString());
            xmlWriter.WriteElementString("merchant_tag", MerchantTag);
            
            if (RecordingTimestamp.HasValue)
                xmlWriter.WriteElementString("recording_timestamp", RecordingTimestamp.Value.ToString("s"));

            xmlWriter.WriteElementString("usage_timestamp", UsageTimestamp.ToString("s"));

            if (BilledAt.HasValue)
                xmlWriter.WriteElementString("billed_at", BilledAt.Value.ToString("s"));

            xmlWriter.WriteEndElement();
        }

        #endregion
    }
}
