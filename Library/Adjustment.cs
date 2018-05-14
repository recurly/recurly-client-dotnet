using System;
using System.Xml;

namespace Recurly
{
    /// <summary>
    /// Represents adjustments - credits and charges - on accounts.
    /// </summary>
    public class Adjustment : RecurlyEntity
    {
        // The currently valid adjustment types
        public enum AdjustmentType : short
        {
            All = 0,
            Charge,
            Credit
        }

        public enum AdjustmentState : short
        {
            Any = 0,
            Pending,
            Invoiced
        }

        public enum RevenueSchedule : short
        {
            Evenly = 0,
            Never,
            AtRangeStart,
            AtRangeEnd,
            AtInvoice,
            EndDate
        }

        public string AccountCode { get; private set; }
        public string Uuid { get; protected set; }
        public string Description { get; set; }
        public string AccountingCode { get; set; }
        public string ProductCode { get; set; }
        public string Origin { get; protected set; }
        public int UnitAmountInCents { get; set; }
        public int Quantity { get; set; }
        public int DiscountInCents { get; protected set; }
        public int TaxInCents { get; protected set; }
        public int TotalInCents { get; protected set; }
        public string Currency { get; set; }
        public bool TaxExempt { get; set; }
        public string TaxCode { get; set; }
        public RevenueSchedule? RevenueScheduleType { get; set; }

        public string TaxType { get; private set; }
        public decimal? TaxRate { get; private set; }
        public string TaxRegion { get; private set; }

        public AdjustmentState State { get; protected set; }

        public string CreditReasonCode { get; set; }
        public string OriginalAjustmentUuid { get; set; }

        public ShippingAddress ShippingAddress { get; private set; }

        public DateTime StartDate { get; protected set; }
        public DateTime? EndDate { get; protected set; }

        public DateTime? CreatedAt { get ; protected set; }
        public DateTime UpdatedAt { get; private set; }

        private const string UrlPrefix = "/accounts/";
        private const string UrlPostfix = "/adjustments/";

        private const int AccountingCodeMaxLength = 20;
        private const int UnitAmountMax = 10000000;

        #region Constructors


        public Adjustment(int unitAmountInCents, string description, int quantity = 1)
        {
            UnitAmountInCents = unitAmountInCents;
            Description = description;
            Quantity = quantity;
        }

        internal Adjustment()
        {
            
        }

        internal Adjustment(string accountCode, string description, string currency, int unitAmountInCents, int quantity, string accountingCode = "", bool taxExempt = false)
        {
            AccountCode = accountCode;
            Description = description;
            Currency = currency;
            UnitAmountInCents = unitAmountInCents;
            Quantity = quantity;
            AccountingCode = accountingCode;
            TaxExempt = taxExempt;
            State = AdjustmentState.Pending;

            if (!AccountingCode.IsNullOrEmpty() && AccountingCode.Length > AccountingCodeMaxLength)
                throw new PropertyOutOfRangeException("AccountingCode",
                    string.Format("Adjustment's AccountingCode can be at most {0} characters in length.", AccountingCodeMaxLength));

            if(UnitAmountInCents > UnitAmountMax)
                throw new PropertyOutOfRangeException("UnitAmountInCents",
                    string.Format("Adjustment's UnitAmountInCents may be at most {0}.", UnitAmountMax));
        }

        internal Adjustment(XmlTextReader xmlReader)
        {
            ReadXml(xmlReader);
        }

        #endregion


        /// <summary>
        /// Create a new adjustment in Recurly
        /// </summary>
        public void Create()
        {
            // POST /accounts/<account code>/adjustments
            Client.Instance.PerformRequest(Client.HttpRequestMethod.Post,
                UrlPrefix + Uri.EscapeDataString(AccountCode) + UrlPostfix,
                WriteXml,
                ReadXml);
        }

        /// <summary>
        /// Deletes an adjustment from an account.
        /// 
        /// Adjustments can only be deleted when not invoiced
        /// </summary>
        public void Delete()
        {
            // DELETE /adjustments/<uuid>
            Client.Instance.PerformRequest(Client.HttpRequestMethod.Delete,
                UrlPostfix + Uri.EscapeDataString(Uuid));
        }


        #region Read and Write XML documents

        internal override void ReadXml(XmlTextReader reader)
        {
            while (reader.Read())
            {
                // End of account element, get out of here
                if (reader.Name == "adjustment" && reader.NodeType == XmlNodeType.EndElement)
                    break;

                if (reader.NodeType != XmlNodeType.Element) continue;
                switch (reader.Name)
                { 
                    case "account":
                        var href = reader.GetAttribute("href");
                        AccountCode = Uri.UnescapeDataString(href.Substring(href.LastIndexOf("/") + 1));
                        break;

                    case "uuid":
                        Uuid = reader.ReadElementContentAsString();
                        break;

                    case "description":
                        Description = reader.ReadElementContentAsString();
                        break;

                    case "accounting_code":
                        AccountingCode = reader.ReadElementContentAsString();
                        break;

                    case "product_code":
                        ProductCode = reader.ReadElementContentAsString();
                        break;

                    case "origin":
                        Origin = reader.ReadElementContentAsString();
                        break;

                    case "unit_amount_in_cents":
                        UnitAmountInCents = reader.ReadElementContentAsInt();
                        break;

                    case "quantity":
                        Quantity = reader.ReadElementContentAsInt();
                        break;

                    case "discount_in_cents":
                        DiscountInCents = reader.ReadElementContentAsInt();
                        break;

                    case "tax_in_cents":
                        TaxInCents = reader.ReadElementContentAsInt();
                        break;

                    case "total_in_cents":
                        TotalInCents = reader.ReadElementContentAsInt();
                        break;

                    case "currency":
                        Currency = reader.ReadElementContentAsString();
                        break;

                    case "tax_exempt":
                        TaxExempt = reader.ReadElementContentAsBoolean();
                        break;

                    case "tax_code":
                        TaxCode = reader.ReadElementContentAsString();
                        break;

                    case "tax_type":
                        TaxType = reader.ReadElementContentAsString();
                        break;

                    case "tax_rate":
                        TaxRate = reader.ReadElementContentAsDecimal();
                        break;

                    case "tax_region":
                        TaxRegion = reader.ReadElementContentAsString();
                        break;

                    case "credit_reason_code":
                        CreditReasonCode = reader.ReadElementContentAsString();
                        break;

                    case "original_adjustment_uuid":
                        OriginalAjustmentUuid = reader.ReadElementContentAsString();
                        break;

                    case "start_date":
                        DateTime startDate;
                        if (DateTime.TryParse(reader.ReadElementContentAsString(), out startDate))
                            StartDate = startDate;                        
                        break;

                    case "end_date":
                        DateTime endDate;
                        if (DateTime.TryParse(reader.ReadElementContentAsString(), out endDate))
                            EndDate = endDate;
                        break;

                    case "created_at":
                        DateTime createdAt;
                        if (DateTime.TryParse(reader.ReadElementContentAsString(), out createdAt))
                            CreatedAt = createdAt;
                        break;

                    case "updated_at":
                        DateTime updatedAt;
                        if(DateTime.TryParse(reader.ReadElementContentAsString(), out updatedAt))
                            UpdatedAt = updatedAt;
                        break;

                    case "state":
                        State = reader.ReadElementContentAsString().ParseAsEnum<AdjustmentState>();
                        break;

                    case "revenue_schedule_type":
                        var revenueScheduleType = reader.ReadElementContentAsString();
                        if (!revenueScheduleType.IsNullOrEmpty())
                            RevenueScheduleType = revenueScheduleType.ParseAsEnum<Adjustment.RevenueSchedule>();
                        break;

                    case "shipping_address":
                        ShippingAddress = new ShippingAddress();
                        ShippingAddress.ReadXml(reader);
                        break;
                }
            }
        }

        internal override void WriteXml(XmlTextWriter xmlWriter)
        {
            WriteXml(xmlWriter, false);
        }

        internal void WriteEmbeddedXml(XmlTextWriter xmlWriter)
        {
            WriteXml(xmlWriter, true);
        }

        internal void WriteXml(XmlTextWriter xmlWriter, bool embedded = false)
        {
            xmlWriter.WriteStartElement("adjustment"); // Start: adjustment
            xmlWriter.WriteElementString("description", Description);
            xmlWriter.WriteElementString("unit_amount_in_cents", UnitAmountInCents.AsString());
            xmlWriter.WriteElementString("quantity", Quantity.AsString());
            xmlWriter.WriteElementString("accounting_code", AccountingCode);
            xmlWriter.WriteElementString("tax_exempt", TaxExempt.AsString());
            xmlWriter.WriteElementString("product_code", ProductCode);
            if (!embedded)
                xmlWriter.WriteElementString("currency", Currency);
            if (RevenueScheduleType.HasValue)
                xmlWriter.WriteElementString("revenue_schedule_type", RevenueScheduleType.Value.ToString().EnumNameToTransportCase());
            xmlWriter.WriteEndElement(); // End: adjustment
        }

        #endregion
    }

    public class Adjustments
    {
        public static Adjustment Get(string uuid)
        {
            var adjustment = new Adjustment();
            Client.Instance.PerformRequest(Client.HttpRequestMethod.Get,
                "/adjustments/" + Uri.EscapeDataString(uuid),
                adjustment.ReadXml);
            return adjustment;
        }
    }
}
