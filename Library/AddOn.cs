using System;
using System.Collections.Generic;
using System.Xml;

namespace Recurly
{
    public class AddOn : RecurlyEntity
    {
        public enum Type
        {
            Fixed,
            Usage
        }

        public string PlanCode { get; set; }
        public string AddOnCode { get; set; }
        public string Name { get; set; }
        public int? DefaultQuantity { get; set; }
        public bool? DisplayQuantityOnHostedPage { get; set; }
        public string TaxCode { get; set; }
        public bool? Optional { get; set; }
        public string AccountingCode { get; set; }
        public long? MeasuredUnitId { get; set; }
        public Type? AddOnType { get; set; }
        public Usage.Type? UsageType { get; set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }
        public Adjustment.RevenueSchedule? RevenueScheduleType { get; set; }
        public string TierType { get; set; }

        private List<Tier> _tiers; 

        /// <summary>
        /// List of tiers for this add-on
        /// </summary>
        public List<Tier> Tiers
        {
            get {return _tiers ?? (_tiers = new List<Tier>()); }
            set { _tiers = value; }
        }

        private Dictionary<string, int> _unitAmountInCents;
        /// <summary>
        /// A dictionary of currencies and values for the add-on amount
        /// </summary>
        public Dictionary<string, int> UnitAmountInCents
        {
            get { return _unitAmountInCents ?? (_unitAmountInCents = new Dictionary<string, int>()); }
        }

        private const string UrlPrefix = "/plans/";
        private const string UrlPostfix = "/add_ons/";

        #region Constructors
        internal AddOn()
        {
        }

        internal AddOn(XmlTextReader xmlReader)
        {
            ReadXml(xmlReader);
        }

        internal AddOn(string planCode, string addOnCode, string name)
        {
            PlanCode = planCode;
            AddOnCode = addOnCode;
            Name = name;
        }

        #endregion

        /// <summary>
        /// Creates an addon
        /// </summary>
        public void Create()
        {
            Client.Instance.PerformRequest(Client.HttpRequestMethod.Post,
                UrlPrefix + Uri.EscapeDataString(PlanCode) + UrlPostfix,
                WriteXml,
                ReadXml);
        }

        /// <summary>
        /// Update an existing add on in Recurly
        /// </summary>
        public void Update()
        {
            Client.Instance.PerformRequest(Client.HttpRequestMethod.Put,
                UrlPrefix + Uri.EscapeDataString(PlanCode) + UrlPostfix + Uri.EscapeDataString(AddOnCode),
                WriteXml,
                ReadXml);
        }

        /// <summary>
        /// Deletes this add on, making it inactive
        /// </summary>
        public void Delete()
        {
            Client.Instance.PerformRequest(Client.HttpRequestMethod.Delete,
                UrlPrefix + Uri.EscapeDataString(PlanCode) + UrlPostfix + Uri.EscapeDataString(AddOnCode));
        }

        #region Read and Write XML documents

        internal void ReadXmlUnitAmount(XmlTextReader reader)
        {
            while (reader.Read())
            {
                if (reader.Name == "unit_amount_in_cents" && reader.NodeType == XmlNodeType.EndElement)
                    break;

                if (reader.NodeType == XmlNodeType.Element)
                {
                    UnitAmountInCents.Remove(reader.Name);
                    UnitAmountInCents.Add(reader.Name, reader.ReadElementContentAsInt());
                }
            }
        }

        internal override void ReadXml(XmlTextReader reader)
        {
            while (reader.Read())
            {
                // End of account element, get out of here
                if (reader.Name == "add_on" && reader.NodeType == XmlNodeType.EndElement)
                    break;

                if (reader.NodeType != XmlNodeType.Element) continue;

                switch (reader.Name)
                {
                    case "add_on_code":
                        AddOnCode = reader.ReadElementContentAsString();
                        break;

                    case "accounting_code":
                        AccountingCode = reader.ReadElementContentAsString();
                        break;

                    case "name":
                        Name = reader.ReadElementContentAsString();
                        break;

                    case "display_quantity_on_hosted_page":
                        DisplayQuantityOnHostedPage = reader.ReadElementContentAsBoolean();
                        break;

                    case "default_quantity":
                        DefaultQuantity = reader.ReadElementContentAsInt();
                        break;

                    case "optional":
                        Optional = reader.ReadElementContentAsBoolean();
                        break;

                    case "created_at":
                        CreatedAt = reader.ReadElementContentAsDateTime();
                        break;

                    case "updated_at":
                        UpdatedAt = reader.ReadElementContentAsDateTime();
                        break;

                    case "unit_amount_in_cents":
                        ReadXmlUnitAmount(reader);
                        break;

                    case "tax_code":
                        TaxCode = reader.ReadElementContentAsString();
                        break;

                    case "add_on_type":
                        AddOnType = reader.ReadElementContentAsString().ParseAsEnum<Type>();
                        break;

                    case "usage_type":
                        UsageType = reader.ReadElementContentAsString().ParseAsEnum<Usage.Type>();
                        break;

                    case "revenue_schedule_type":
                        var revenueScheduleType = reader.ReadElementContentAsString();
                        if (!revenueScheduleType.IsNullOrEmpty())
                            RevenueScheduleType = revenueScheduleType.ParseAsEnum<Adjustment.RevenueSchedule>();
                        break;

                    case "tier_type":
                        TierType = reader.ReadElementContentAsString();
                        break;
                }
            }
        }

        internal override void WriteXml(XmlTextWriter xmlWriter)
        {
            xmlWriter.WriteStartElement("add_on");

            xmlWriter.WriteElementString("add_on_code", AddOnCode);
            xmlWriter.WriteElementString("name", Name);
            xmlWriter.WriteElementString("accounting_code", AccountingCode);

            if (DefaultQuantity.HasValue)
                xmlWriter.WriteElementString("default_quantity", DefaultQuantity.Value.AsString());

            if (AddOnType.HasValue)
                xmlWriter.WriteElementString("add_on_type", AddOnType.Value.ToString().EnumNameToTransportCase());

            if (UsageType.HasValue)
                xmlWriter.WriteElementString("usage_type", UsageType.Value.ToString().EnumNameToTransportCase());

            if (MeasuredUnitId.HasValue)
                xmlWriter.WriteElementString("measured_unit_id", MeasuredUnitId.ToString());

            if (DisplayQuantityOnHostedPage.HasValue)
                xmlWriter.WriteElementString("display_quantity_on_hosted_page", DisplayQuantityOnHostedPage.Value.AsString());

            if (Optional.HasValue)
                xmlWriter.WriteElementString("optional", Optional.Value.AsString());

            xmlWriter.WriteIfCollectionHasAny("unit_amount_in_cents", UnitAmountInCents, pair => pair.Key,
                pair => pair.Value.AsString());

            if (RevenueScheduleType.HasValue)
                xmlWriter.WriteElementString("revenue_schedule_type", RevenueScheduleType.Value.ToString().EnumNameToTransportCase());

            if (TierType != null)
                xmlWriter.WriteElementString("tier_type", TierType);

            xmlWriter.WriteIfCollectionHasAny("tiers", Tiers);

            xmlWriter.WriteEndElement();
        }

        #endregion

        #region Object Overrides

        public override string ToString()
        {
            return "Recurly Plan AddOn: " + AddOnCode;
        }

        public override bool Equals(object obj)
        {
            var addon = obj as AddOn;
            return addon != null && Equals(addon);
        }

        public bool Equals(AddOn addon)
        {
            return PlanCode == addon.PlanCode && AddOnCode == addon.AddOnCode;
        }

        public override int GetHashCode()
        {
            var planCodeHash = PlanCode?.GetHashCode() ?? 0;
            var addOnCodeHash = AddOnCode?.GetHashCode() ?? 0;
            return planCodeHash + addOnCodeHash;
        }

        #endregion
    }
}
