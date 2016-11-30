using Recurly.List;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Recurly
{
    public class Usage : RecurlyEntity
    {
        public enum Type
        {
            Price,
            Percentage
        }

        public long? Id { get; private set; }
        public int? UnitAmountInCents { get; set; }
        public float? UsagePercentage { get; set; }
        public int Amount{ get; set; }
        public string MerchantTag { get; set; }
        public Type UsageType { get; set; }
        public DateTime? UsageTimestamp { get; set; }
        public DateTime? RecordingTimestamp { get; set; }
        public DateTime? BilledAt { get; set; }
        public DateTime? CreatedAt { get; private set; }
        public DateTime? UpdatedAt { get; private set; }

        // needed for GET parameters
        public string SubscriptionUuid { get; private set; }
        public string SubscriptionAddOnCode { get; private set; }

        internal Usage()
        {
        }

        internal Usage(XmlTextReader reader)
            : this()
        {
            ReadXml(reader);
        }

        public Usage(string subscriptionUuid, string subscriptionAddOnCode)
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

        private string UrlPrefix()
        {
            return "/subscriptions/" + Uri.EscapeUriString(SubscriptionUuid) + "/add_ons/" + Uri.EscapeUriString(SubscriptionAddOnCode) + "/usage";
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
                long usageId;
                DateTime dateVal;

                switch (reader.Name)
                {
                    case "usage":
                        Uri usageUri = new Uri(reader.GetAttribute("href"));
                        if (Int64.TryParse(usageUri.Segments.Last(), out usageId))
                            Id = usageId;
                        break;

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
                        if (reader.GetAttribute("nil") == null)
                        {
                            UsagePercentage = reader.ReadElementContentAsFloat();
                        }
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

            if (UsageTimestamp.HasValue)
                xmlWriter.WriteElementString("usage_timestamp", UsageTimestamp.Value.ToString("s"));

            if (BilledAt.HasValue)
                xmlWriter.WriteElementString("billed_at", BilledAt.Value.ToString("s"));

            xmlWriter.WriteEndElement();
        }

        #endregion

        #region Object Overrides

        public override string ToString()
        {
            return "Recurly UsageRecord: " + Id;
        }

        public override bool Equals(object obj)
        {
            var usage = obj as Usage;
            return usage != null && Equals(usage);
        }

        public bool Equals(Usage usage)
        {
            return Id == usage.Id;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        #endregion

        public static RecurlyList<Usage> List(String subscriptionUuid, String subscriptionAddOnCode)
        {
            return new UsageList(UrlPrefix(subscriptionUuid, subscriptionAddOnCode));
        }
    }

    public sealed class Usages
    {
        private static readonly QueryStringBuilder Build = new QueryStringBuilder();

        /// <summary>
        /// Lists usages by status and/or time. Defaults to all.
        /// </summary>
        /// <param name="billingState"></param>
        /// <param name="dateTimeType"></param>
        /// <param name="startDateTime"></param>
        /// <param name="endDateTime"></param>
        /// <returns></returns>
        public static RecurlyList<Usage> List(string subscriptionUuid,
            string subscriptionAddOnCode,
            UsageList.UsageBillingState billingState = UsageList.UsageBillingState.All,
            UsageList.UsageDateTimeType dateTimeType = UsageList.UsageDateTimeType.All,
            DateTime? startDateTime = null,
            DateTime? endDateTime = null)
        {
            return new UsageList("/subscriptions/" + Uri.EscapeUriString(subscriptionUuid) +
                "/add_ons/" + Uri.EscapeUriString(subscriptionAddOnCode) + 
                "/usage" +
                Build.QueryStringWith("billing_status=" + billingState.ToString().EnumNameToTransportCase())
                .AndWith(dateTimeType != UsageList.UsageDateTimeType.All ? "datetime_type=" + dateTimeType.ToString().EnumNameToTransportCase() : "")
                .AndWith(startDateTime != null ? "start_datetime=" + Uri.EscapeUriString(startDateTime.Value.ToString("s")) : "")
                .AndWith(endDateTime != null ? "end_datetime=" + Uri.EscapeUriString(endDateTime.Value.ToString("s")) : "")
            );
        }

        public static Usage Get(string subscriptionUuid, string subscriptionAddOnCode, long usageId)
        {
            var usage = new Usage();

            var statusCode = Client.Instance.PerformRequest(Client.HttpRequestMethod.Get,
                "/subscriptions/" + Uri.EscapeUriString(subscriptionUuid) +
                "/add_ons/" + Uri.EscapeUriString(subscriptionAddOnCode) +
                "/usage/" + usageId.ToString(),
                usage.ReadXml);

            return statusCode == HttpStatusCode.NotFound ? null : usage;
        }
    }
}
