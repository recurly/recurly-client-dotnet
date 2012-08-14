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
            Charge,
            Credit
        }

        private string _accountCode;
        public string UUID { get; protected set; }
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

        private const string UrlPrefix = "/adjustments/";


        #region Constructors

        internal Adjustment()
        {
            this.Quantity = 1;
        }

        internal Adjustment(XmlTextReader xmlReader)
        {
            ReadXml(xmlReader);
        }

        #endregion

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
                            this._accountCode = href.Substring(href.LastIndexOf("/") + 1);
                            break;

                        case "uuid":
                            this.UUID = reader.ReadElementContentAsString();
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

        /// <summary>
        /// XML root node name. Override for "credit" or "charge".
        /// </summary>
        private string XmlRootNodeName
        {
            get
            {
                return UnitAmountInCents <= 0 ? "credit" : "charge";
            }
        }

        internal void WriteXml(XmlTextWriter xmlWriter)
        {
            xmlWriter.WriteStartElement(XmlRootNodeName); // Start: charge

            xmlWriter.WriteElementString("unit_amount_in_cents", this.UnitAmountInCents.ToString());
            xmlWriter.WriteElementString("description", this.Description);
            xmlWriter.WriteElementString("quantity", this.Quantity.ToString());

            xmlWriter.WriteEndElement(); // End: charge
        }

        #endregion
    }
}
