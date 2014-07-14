﻿using System;
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

        public string AccountCode { get; private set; }
        public string Uuid { get; protected set; }
        public string Description { get; set; }
        public string AccountingCode { get; set; }
        public string Origin { get; protected set; }
        public int UnitAmountInCents { get; set; }
        public int Quantity { get; set; }
        public int DiscountInCents { get; protected set; }
        public int TaxInCents { get; protected set; }
        public int TotalInCents { get; protected set; }
        public string Currency { get; set; }
        public bool TaxExempt { get; set; }

        public AdjustmentState State { get; protected set; }

        public DateTime StartDate { get; protected set; }
        public DateTime? EndDate { get; protected set; }

        public DateTime CreatedAt { get ; protected set; }

        private const string UrlPrefix = "/accounts/";
        private const string UrlPostfix = "/adjustments/";

        private const int AccountingCodeMaxLength = 20;
        private const int UnitAmountMax = 10000000;

        #region Constructors

        internal Adjustment(string uuid)
        {
            this.Uuid = uuid;
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
                UrlPrefix + Uri.EscapeUriString(AccountCode) + UrlPostfix,
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
                UrlPostfix + Uri.EscapeUriString(Uuid));
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

                    case "start_date":
                        StartDate = reader.ReadElementContentAsDateTime();
                        break;

                    case "end_date":
                        DateTime endDate;
                        if (DateTime.TryParse(reader.ReadElementContentAsString(), out endDate))
                            EndDate = endDate;
                        break;

                    case "created_at":
                        CreatedAt = reader.ReadElementContentAsDateTime();
                        break;

                    case "state":
                        State = reader.ReadElementContentAsString().ParseAsEnum<AdjustmentState>();
                        break;

                }
            }
        }

        
        internal override void WriteXml(XmlTextWriter xmlWriter)
        {
            xmlWriter.WriteStartElement("adjustment"); 
            xmlWriter.WriteElementString("description", Description);
            xmlWriter.WriteElementString("unit_amount_in_cents", UnitAmountInCents.AsString());
            xmlWriter.WriteElementString("currency", Currency);
            xmlWriter.WriteElementString("quantity", Quantity.AsString());
            xmlWriter.WriteElementString("accounting_code", AccountingCode);
            xmlWriter.WriteElementString("tax_exempt", TaxExempt.AsString());
            xmlWriter.WriteEndElement(); 
        }

        #endregion
    }

    public class Adjustments
    {
        public static Adjustment Get(string uuid)
        {
            var adjustment = new Adjustment(uuid);
            Client.Instance.PerformRequest(Client.HttpRequestMethod.Get,
                "/adjustments/" + Uri.EscapeUriString(uuid),
                adjustment.WriteXml);
            return adjustment;
        }
    }
}
