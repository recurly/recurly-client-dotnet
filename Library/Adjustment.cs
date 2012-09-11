using System;
using System.Collections.Generic;
using System.Net;
using System.Xml;
using System.Text;
using System.ComponentModel;

namespace Recurly
{
    /// <summary>
    /// Represents adjustments - credits and charges - on accounts.
    /// </summary>
    public class Adjustment
    {
        // The currently valid adjustment types
        public enum AdjustmentType : short
        {
            all = 0,
            charge,
            credit
        }

        public enum AdjustmentState : short
        {
            any = 0,
            pending,
            invoiced
        }

        public string AccountCode { get; private set; }
        public string Uuid { get; protected set; }
        public string Description { get; protected set; }
        public string AccountingCode { get; protected set; }
        public string Origin { get; protected set; }
        public int UnitAmountInCents { get; protected set; }
        public int Quantity { get; protected set; }
        public int DiscountInCents { get; protected set; }
        public int TaxInCents {get; protected set; }
        public int TotalInCents { get; protected set; }
        public string Currency { get; protected set; }
        public bool Taxable { get; protected set; }

        public DateTime StartDate { get; protected set; }
        public DateTime? EndDate { get; protected set; }

        public DateTime CreatedAt { get ; protected set; }

        private const string UrlPrefix = "/accounts/";
        private const string UrlPostfix = "/adjustments";


        #region Constructors

        internal Adjustment(string accountCode, string description, string currency, int unitAmountInCents, int quantity)
        {
            this.AccountCode = accountCode;
            this.Description = description;
            this.Currency = currency;
            this.UnitAmountInCents = unitAmountInCents;
            this.Quantity = quantity;
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
            Client.PerformRequest(Client.HttpRequestMethod.Post,
                UrlPrefix + System.Uri.EscapeUriString(AccountCode) + UrlPostfix,
                new Client.WriteXmlDelegate(this.WriteXml),
                new Client.ReadXmlDelegate(this.ReadXml)
                );
        }

        /// <summary>
        /// Deletes an adjustment from an account.
        /// 
        /// Adjustements can only be deleted when not invoiced
        /// </summary>
        public void Delete()
        {
            Client.PerformRequest(Client.HttpRequestMethod.Delete, UrlPostfix + System.Uri.EscapeUriString(AccountCode));
        }


        #region Read and Write XML documents

        internal void ReadXml(XmlTextReader reader)
        {
            while (reader.Read())
            {
                // End of account element, get out of here
                if (reader.Name == "adjustment" && reader.NodeType == XmlNodeType.EndElement)
                    break;

                if (reader.NodeType == XmlNodeType.Element)
                {
                    switch (reader.Name)
                    { 
                        case "account":
                            string href = reader.GetAttribute("href");
                            this.AccountCode = Uri.UnescapeDataString(href.Substring(href.LastIndexOf("/") + 1));
                            break;

                        case "uuid":
                            this.Uuid = reader.ReadElementContentAsString();
                            break;

                        case "description":
                            this.Description = reader.ReadElementContentAsString();
                            break;

                        case "accounting_code":
                            this.AccountingCode = reader.ReadElementContentAsString();
                            break;

                        case "origin":
                            this.Origin = reader.ReadElementContentAsString();
                            break;

                        case "unit_amount_in_cents":
                            this.UnitAmountInCents = reader.ReadElementContentAsInt();
                            break;

                        case "quantity":
                            this.Quantity = reader.ReadElementContentAsInt();
                            break;

                        case "discount_in_cents":
                            this.DiscountInCents = reader.ReadElementContentAsInt();
                            break;

                        case "tax_in_cents":
                            this.TaxInCents = reader.ReadElementContentAsInt();
                            break;

                        case "total_in_cents":
                            this.TotalInCents = reader.ReadElementContentAsInt();
                            break;

                        case "currency":
                            this.Currency = reader.ReadElementContentAsString();
                            break;

                        case "taxable":
                            this.Taxable = reader.ReadElementContentAsBoolean();
                            break;

                        case "start_date":
                            this.StartDate = reader.ReadElementContentAsDateTime();
                            break;

                        case "end_date":
                           DateTime endDate;
                           if (DateTime.TryParse(reader.ReadElementContentAsString(), out endDate))
                                this.EndDate = endDate;
                            break;

                        case "created_at":
                            this.CreatedAt = reader.ReadElementContentAsDateTime();
                            break;

                    }
                }
            }
        }

        
        internal void WriteXml(XmlTextWriter xmlWriter)
        {
            xmlWriter.WriteStartElement("adjustment"); 
            xmlWriter.WriteElementString("description", this.Description);
            xmlWriter.WriteElementString("unit_amount_in_cents", this.UnitAmountInCents.ToString());
            xmlWriter.WriteElementString("currency", this.Currency);
            xmlWriter.WriteElementString("quantity", this.Quantity.ToString());
            xmlWriter.WriteElementString("accounting_code", this.AccountingCode);
            xmlWriter.WriteEndElement(); 
        }

        #endregion
    }
}
