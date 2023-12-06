using System;
using System.Net;
using System.Xml;

namespace Recurly
{
    public class ExternalPaymentPhase : RecurlyEntity
    {
        public DateTime StartedAt { get; private set; }
        public DateTime EndsAt { get; private set; }
        public int StartingBillingPeriodIndex { get; private set; }
        public int EndingBillingPeriodIndex { get; private set; }
        public string OfferType { get; private set; }
        public string OfferName { get; private set; }
        public int PeriodCount { get; private set; }
        public string PeriodLength { get; private set; }
        public decimal Amount { get; private set; }
        public string Currency { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }

        internal const string UrlPrefix = "/external_payment_phases/";

        internal ExternalPaymentPhase()
        {
        }
        internal ExternalPaymentPhase(XmlTextReader reader)
        {
            ReadXml(reader);
        }
        #region Read XML documents

        internal override void ReadXml(XmlTextReader reader)
        {
            while (reader.Read())
            {
                DateTime dateVal;

                if (reader.Name == "external_payment_phase" && reader.NodeType == XmlNodeType.EndElement)
                    break;

                if (reader.NodeType != XmlNodeType.Element) continue;

                switch (reader.Name)
                {
                    case "started_at":
                        if (DateTime.TryParse(reader.ReadElementContentAsString(), out dateVal))
                            StartedAt = dateVal; ;
                        break;

                    case "ends_at":
                        if (DateTime.TryParse(reader.ReadElementContentAsString(), out dateVal))
                            EndsAt = dateVal; ;
                        break;

                    case "starting_billing_period_index":
                        StartingBillingPeriodIndex = reader.ReadElementContentAsInt();
                        break;

                    case "ending_billing_period_index":
                        EndingBillingPeriodIndex = reader.ReadElementContentAsInt();
                        break;

                    case "offer_type":
                        OfferType = reader.ReadElementContentAsString();
                        break;

                    case "offer_name":
                        OfferName = reader.ReadElementContentAsString();
                        break;

                    case "period_count":
                        PeriodCount = reader.ReadElementContentAsInt();
                        break;

                    case "period_length":
                        PeriodLength = reader.ReadElementContentAsString();
                        break;

                    case "amount":
                        Amount = reader.ReadElementContentAsDecimal();
                        break;

                    case "currency":
                        Currency = reader.ReadElementContentAsString();
                        break;

                    case "updated_at":
                        if (DateTime.TryParse(reader.ReadElementContentAsString(), out dateVal))
                            UpdatedAt = dateVal; ;
                        break;

                    case "created_at":
                        if (DateTime.TryParse(reader.ReadElementContentAsString(), out dateVal))
                            CreatedAt = dateVal; ;
                        break;

                }
            }
        }

        internal override void WriteXml(XmlTextWriter writer)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Object Overrides

        public override string ToString()
        {
            return "Recurly External Payment Phase: " + StartedAt + " " + EndsAt + " " + StartingBillingPeriodIndex + " " + EndingBillingPeriodIndex + " " + OfferType + " " + OfferName + " " + PeriodCount + " " + PeriodLength + " " + Amount + " " + Currency + " " + CreatedAt + " " + UpdatedAt;
        }

        #endregion
    }

    public sealed class ExternalPaymentPhases
    {
        /// <summary>
        /// Returns a list of recurly external_payment_phases
        /// </summary>
        /// <returns></returns>
        public static RecurlyList<ExternalPaymentPhase> List()
        {
            return List(null);
        }
        /// <summary>
        /// Returns a list of recurly external_payment_phases
        /// </summary>
        /// <param name="filter">FilterCriteria used to apply server side sorting and filtering</param>
        /// <returns></returns>
        public static RecurlyList<ExternalPaymentPhase> List(FilterCriteria filter)
        {
            filter = filter ?? FilterCriteria.Instance;
            var parameters = filter.ToNamedValueCollection();
            return new ExternalPaymentPhaseList(ExternalPaymentPhase.UrlPrefix + "?" + parameters.ToString());
        }
        public static ExternalPaymentPhase Get(string uuid)
        {
            if (string.IsNullOrWhiteSpace(uuid))
            {
                return null;
            }
            var externalPaymentPhase = new ExternalPaymentPhase();
            var statusCode = Client.Instance.PerformRequest(Client.HttpRequestMethod.Get,
                ExternalPaymentPhase.UrlPrefix + Uri.EscapeDataString(uuid),
                externalPaymentPhase.ReadXml);

            return statusCode == HttpStatusCode.NotFound ? null : externalPaymentPhase;
        }
    }
}
