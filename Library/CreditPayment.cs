using System;
using System.Xml;

namespace Recurly
{
    /// <summary>
    /// Represents a credit payment
    /// </summary>
    public class CreditPayment : RecurlyEntity
    {
        public string Uuid { get; set; }
        public string Action { get; set; }
        public int UnitAmountInCents { get; set; }
        public string AppliedToInvoice { get; set; }
        public string Currency { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime VoidedAt { get; set; }

        #region Constructors

        internal CreditPayment()
        {
        }

        internal CreditPayment(XmlTextReader reader)
        {
            ReadXml(reader);
        }

        #endregion

        #region Read and Write XML documents

        internal override void ReadXml(XmlTextReader reader)
        {
            while (reader.Read())
            {
                // End of account element, get out of here
                if (reader.Name == "credit_payment" && reader.NodeType == XmlNodeType.EndElement)
                    break;

                if (reader.NodeType != XmlNodeType.Element) continue;

                DateTime dt;
                switch (reader.Name)
                { 
                    case "uuid":
                        Uuid = reader.ReadElementContentAsString();
                        break;
        
                    case "unit_amount_in_cents":
                        UnitAmountInCents = reader.ReadElementContentAsInt();
                        break;
   
                    case "currency":
                        Currency = reader.ReadElementContentAsString();
                        break;

                    case "action":
                        Action = reader.ReadElementContentAsString();
                        break;

                    case "applied_to_invoice":
                        AppliedToInvoice = reader.ReadElementContentAsString();
                        break;

                    case "created_at":
                        if (DateTime.TryParse(reader.ReadElementContentAsString(), out dt))
                            CreatedAt = dt;
                        break;

                    case "updated_at":
                        if(DateTime.TryParse(reader.ReadElementContentAsString(), out dt))
                            UpdatedAt = dt;
                        break;

                    case "voided_at":
                        if (DateTime.TryParse(reader.ReadElementContentAsString(), out dt))
                            VoidedAt = dt;
                        break;
                }
            }
        }

        internal override void WriteXml(XmlTextWriter xmlWriter)
        {
            throw new NotImplementedException();
        }

        #endregion
    }

    public class CreditPayments
    {
        internal const string UrlPrefix = "/credit_payments";

        /// <summary>
        /// Get a credit payment given a UUID
        /// </summary>
        /// <param name="uuid">The unique uuid of the credit payment</param>
        /// <returns>CreditPayment</returns>
        public static CreditPayment Get(string uuid)
        {
            var creditPayment = new CreditPayment();
            Client.Instance.PerformRequest(Client.HttpRequestMethod.Get,
                "/credit_payment/" + Uri.EscapeDataString(uuid),
                creditPayment.ReadXml);
            return creditPayment;
        }

        /// <summary>   
        /// Lists credit payments
        /// </summary>
        /// <param name="filter">FilterCriteria used to apply server side sorting and filtering</param>
        /// <returns></returns>
        public static RecurlyList<CreditPayment> List(FilterCriteria filter)
        {
            filter = filter ?? FilterCriteria.Instance;
            var parameters = filter.ToNamedValueCollection();
            return new CreditPaymentList(UrlPrefix + "?" + parameters.ToString());
        }
    }
}
