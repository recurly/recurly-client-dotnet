using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace Recurly
{
    public class RecurlyCreditCard
    {
        /// <summary>
        /// Credit card number
        /// </summary>
        public string Number { get; set; }
        /// <summary>
        /// 3 or 4 digit CVV code.  Do not log or save this number!
        /// </summary>
        public string VerificationValue { get; set; }
        public int ExpirationMonth { get; set; }
        public int ExpirationYear { get; set; }

        public string LastFour { get; private set; }
        public string CreditCardType { get; private set; }

        internal void ReadXml(XmlTextReader reader)
        {
            while (reader.Read())
            {
                // End of credit_card element, get out of here
                if (reader.Name == "credit_card" && reader.NodeType == XmlNodeType.EndElement)
                    break;

                if (reader.NodeType == XmlNodeType.Element)
                {
                    switch (reader.Name)
                    {
                        case "year":
                            this.ExpirationYear = reader.ReadElementContentAsInt();
                            break;

                        case "month":
                            this.ExpirationMonth = reader.ReadElementContentAsInt();
                            break;

                        case "last_four":
                            this.LastFour = reader.ReadElementContentAsString();
                            break;

                        case "type":
                            this.CreditCardType = reader.ReadElementContentAsString();
                            break;
                    }
                }
            }
        }

        internal void WriteXml(XmlTextWriter xmlWriter)
        {
            xmlWriter.WriteStartElement("credit_card"); // Start: credit_card

            xmlWriter.WriteElementString("number", this.Number);
            xmlWriter.WriteElementString("verification_value", this.VerificationValue);
            xmlWriter.WriteElementString("month", this.ExpirationMonth.ToString());
            xmlWriter.WriteElementString("year", this.ExpirationYear.ToString());

            xmlWriter.WriteEndElement(); // End: credit_card
        }
    }
}
