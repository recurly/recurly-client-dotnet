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

        public string uuid { get; protected set; }
        public int AmountInCents { get; protected set; }
        public int Quantity { get; protected set; }
        public DateTime StartDate { get; protected set; }
        public DateTime? EndDate { get; protected set; }
        public string Description { get; protected set; }

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
                if ((reader.Name == "charge" || reader.Name == "credit" || reader.Name == "line_item") &&
                    reader.NodeType == XmlNodeType.EndElement)
                    break;

                if (reader.NodeType == XmlNodeType.Element)
                {
                    DateTime date;
                    switch (reader.Name)
                    {
                        case "id":
                            this.Id = reader.ReadElementContentAsString();
                            break;

                        case "start_date":
                            if (DateTime.TryParse(reader.ReadElementContentAsString(), out date))
                                this.StartDate = date;
                            break;

                        case "end_date":
                            if (DateTime.TryParse(reader.ReadElementContentAsString(), out date))
                                this.EndDate = date;
                            break;

                        case "amount_in_cents":
                            int amount;
                            if (Int32.TryParse(reader.ReadElementContentAsString(), out amount))
                                this.AmountInCents = amount;
                            break;

                        case "quantity":
                            int quantity;
                            if (Int32.TryParse(reader.ReadElementContentAsString(), out quantity))
                                this.Quantity = quantity;
                            break;

                        case "description":
                            this.Description = reader.ReadElementContentAsString();
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
                return AmountInCents <= 0 ? "credit" : "charge";
            }
        }

        internal void WriteXml(XmlTextWriter xmlWriter)
        {
            xmlWriter.WriteStartElement(XmlRootNodeName); // Start: charge

            xmlWriter.WriteElementString("amount_in_cents", this.AmountInCents.ToString());
            xmlWriter.WriteElementString("description", this.Description);
            xmlWriter.WriteElementString("quantity", this.Quantity.ToString());

            xmlWriter.WriteEndElement(); // End: charge
        }

        #endregion
    }
}
