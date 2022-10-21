using System;
using System.Collections.Generic;
using System.Globalization;
using System.Xml;

namespace Recurly
{
    public class SubscriptionAddOn : RecurlyEntity
    {
        public string AddOnCode { get; set; }
        public AddOn.Type? AddOnType { get; set; }
        public int? UnitAmountInCents { get; set; }
        public int Quantity { get; set; }
        public Adjustment.RevenueSchedule? RevenueScheduleType { get; set; }
        public float? UsagePercentage { get; set; }
        public Usage.CalculationType? UsageCalculationType { get; set; }
        public string TierType { get; set; }
        public string UsageTimeframe { get; set; }

        private List<SubscriptionAddOnTier> _tiers;

        private List<SubscriptionAddOnPercentageTier> _percentageTiers;

        /// <summary>
        /// List of tiers for this add-on
        /// </summary>
        public List<SubscriptionAddOnTier> Tiers
        {
            get { return _tiers ?? (_tiers = new List<SubscriptionAddOnTier>()); }
            set { _tiers = value; }
        }

        /// <summary>
        /// List of percentage tiers for this add-on
        /// </summary>
        public List<SubscriptionAddOnPercentageTier> PercentageTiers
        {
            get { return _percentageTiers ?? (_percentageTiers = new List<SubscriptionAddOnPercentageTier>()); }
            set { _percentageTiers = value; }
        }

        public string AddOnSource { get; set; }

        #region Constructors

        public SubscriptionAddOn(XmlTextReader reader)
        {
            ReadXml(reader);
        }

        // keep old constructor
        public SubscriptionAddOn(string addOnCode, int? unitAmountInCents, int quantity = 1)
        {
            AddOnCode = addOnCode;
            UnitAmountInCents = unitAmountInCents;
            Quantity = quantity;
        }

        // new constructor including addOnType (recommended)
        public SubscriptionAddOn(string addOnCode, AddOn.Type? addOnType, int? unitAmountInCents, int quantity = 1)
        {
            AddOnCode = addOnCode;
            AddOnType = addOnType;
            UnitAmountInCents = unitAmountInCents;
            Quantity = quantity;
        }

        // new constructor for tiered-pricing
        public SubscriptionAddOn(string addOnCode, string tierType, int quantity = 1)
        {
            AddOnCode = addOnCode;
            TierType = tierType;
            Quantity = quantity;
        }

        // new constructor including add-on source
        public SubscriptionAddOn(string addOnCode, string addOnSource, int unitAmountInCents, int quantity = 1)
        {
            AddOnCode = addOnCode;
            AddOnSource = addOnSource;
            UnitAmountInCents = unitAmountInCents;
            Quantity = quantity;
        }

        #endregion

        #region Read and Write XML documents

        internal override void ReadXml(XmlTextReader reader)
        {
            while (reader.Read())
            {
                if (reader.Name == "subscription_add_on" && reader.NodeType == XmlNodeType.EndElement)
                    break;

                if (reader.NodeType != XmlNodeType.Element) continue;

                switch (reader.Name)
                {
                    case "add_on_code":
                        AddOnCode = reader.ReadElementContentAsString();
                        break;

                    case "add_on_type":
                        AddOnType = reader.ReadElementContentAsString().ParseAsEnum<AddOn.Type>();
                        break;

                    case "quantity":
                        Quantity = reader.ReadElementContentAsInt();
                        break;

                    case "unit_amount_in_cents":
                        int unitAmountInCents;
                        if (Int32.TryParse(reader.ReadElementContentAsString(), out unitAmountInCents))
                            UnitAmountInCents = unitAmountInCents;
                        break;

                    case "revenue_schedule_type":
                        var revenueScheduleType = reader.ReadElementContentAsString();
                        if (!revenueScheduleType.IsNullOrEmpty())
                            RevenueScheduleType = revenueScheduleType.ParseAsEnum<Adjustment.RevenueSchedule>();
                        break;

                    case "usage_percentage":
                        var usagePercentage = reader.ReadElementContentAsString();
                        if (Single.TryParse(usagePercentage, NumberStyles.Number,
                                CultureInfo.InvariantCulture.NumberFormat, out float percentage))
                            UsagePercentage = percentage;
                        break;

                    case "usage_calculation_type":
                        if (!reader.ReadElementContentAsString().IsNullOrEmpty())
                            UsageCalculationType = reader.ReadElementContentAsString().ParseAsEnum<Usage.CalculationType>();
                        break;

                    case "tier_type":
                        TierType = reader.ReadElementContentAsString();
                        break;

                    case "usage_timeframe":
                        UsageTimeframe = reader.ReadElementContentAsString();
                        break;

                    case "tiers":
                        Tiers = new List<SubscriptionAddOnTier>();
                        while (reader.Read())
                        {
                            if (reader.Name == "tiers" && reader.NodeType == XmlNodeType.EndElement)
                                break;
                            else if (reader.NodeType == XmlNodeType.Element && reader.Name == "tier")
                            {
                                Tiers.Add(new SubscriptionAddOnTier(reader));
                            }
                        }
                        break;

                    case "percentage_tiers":
                        PercentageTiers = new List<SubscriptionAddOnPercentageTier>();
                        while (reader.Read())
                        {
                            if (reader.Name == "percentage_tiers" && reader.NodeType == XmlNodeType.EndElement)
                                break;
                            else if (reader.NodeType == XmlNodeType.Element && reader.Name == "percentage_tier")
                            {
                                PercentageTiers.Add(new SubscriptionAddOnPercentageTier(reader));
                            }
                        }
                        break;

                    case "add_on_source":
                        AddOnSource = reader.ReadElementContentAsString();
                        break;

                }
            }
        }

        internal override void WriteXml(XmlTextWriter writer)
        {
            writer.WriteStartElement("subscription_add_on");

            writer.WriteElementString("add_on_code", AddOnCode);
            writer.WriteElementString("quantity", Quantity.AsString());

            if (UnitAmountInCents.HasValue)
                writer.WriteElementString("unit_amount_in_cents", UnitAmountInCents.Value.AsString());

            if (RevenueScheduleType.HasValue)
                writer.WriteElementString("revenue_schedule_type", RevenueScheduleType.Value.ToString().EnumNameToTransportCase());

            if (UsagePercentage.HasValue)
                writer.WriteElementString("usage_percentage", UsagePercentage.ToString());

            if (TierType != null)
                writer.WriteElementString("tier_type", TierType);

            if (UsageTimeframe != null)
                writer.WriteElementString("usage_timeframe", UsageTimeframe);

            writer.WriteIfCollectionHasAny("tiers", Tiers);

            writer.WriteIfCollectionHasAny("percentage_tiers", PercentageTiers);

            if (AddOnSource != null)
                writer.WriteElementString("add_on_source", AddOnSource);

            writer.WriteEndElement();
        }

        #endregion
    }
}
