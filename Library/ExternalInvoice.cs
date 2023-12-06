using System;
using System.Collections.Generic;
using System.Net;
using System.Xml;

namespace Recurly
{
    /// <summary>
    /// An invoice from an external resource that is not managed by the Recurly platform and instead is managed by third-party platforms like Apple Store and Google Play.
    /// </summary>
    public class ExternalInvoice : RecurlyEntity
    {
        public enum ExternalInvoiceState
        {
            Paid //paid
        }
        private string _accountCode;
        public string AccountCode => _accountCode;

        private Account _account;
        public Account Account
        {
            get { return _account ?? (_account = Accounts.Get(_accountCode)); }
            internal set { _account = value; }
        }

        private string _externalSubscriptionUuid;
        public string ExternalSubscriptionUuid => _externalSubscriptionUuid;

        private ExternalSubscription _externalSubscription;
        public ExternalSubscription ExternalSubscription
        {
            get { return _externalSubscription ?? (_externalSubscription = ExternalSubscriptions.Get(_externalSubscriptionUuid)); }
            internal set { _externalSubscription = value; }
        }

        private string _externalPaymentPhaseUuid;
        public string ExternalPaymentPhaseUuid => _externalPaymentPhaseUuid;

        private ExternalPaymentPhase _externalPaymentPhase;
        public ExternalPaymentPhase ExternalPaymentPhase
        {
            get { return _externalPaymentPhase ?? (_externalPaymentPhase = ExternalPaymentPhases.Get(_externalPaymentPhaseUuid)); }
            internal set { _externalPaymentPhase = value; }
        }
        public string ExternalId { get; private set; }
        public ExternalInvoiceState State { get; private set; }
        public decimal Total { get; private set; }
        /// <summary>
        /// List of external charges
        /// </summary>
        public List<ExternalCharge> ExternalCharges
        {
            get { return _externalCharges ?? (_externalCharges = new List<ExternalCharge>()); }
            set { _externalCharges = value; }
        }
        private List<ExternalCharge> _externalCharges;
        public string Currency { get; private set; }
        public DateTime PurchasedAt { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }
        internal const string UrlPrefix = "/external_invoices/";
        internal ExternalInvoice()
        {
        }
        internal ExternalInvoice(XmlTextReader reader)
        {
            ReadXml(reader);
        }
        #region Read XML documents

        internal override void ReadXml(XmlTextReader reader)
        {
            while (reader.Read())
            {
                string href;
                DateTime dateVal;

                if (reader.Name == "external_invoice" && reader.NodeType == XmlNodeType.EndElement)
                    break;

                if (reader.NodeType != XmlNodeType.Element) continue;

                switch (reader.Name)
                {
                    case "account":
                        href = reader.GetAttribute("href");
                        if (null != href)
                            _accountCode = Uri.UnescapeDataString(href.Substring(href.LastIndexOf("/") + 1));
                        break;

                    case "external_subscription":
                        href = reader.GetAttribute("href");
                        if (null != href)
                            _externalSubscriptionUuid = Uri.UnescapeDataString(href.Substring(href.LastIndexOf("/") + 1));
                        break;

                    case "external_payment_phase":
                        href = reader.GetAttribute("href");
                        if (null != href)
                            _externalPaymentPhaseUuid = Uri.UnescapeDataString(href.Substring(href.LastIndexOf("/") + 1));
                        break;

                    case "external_id":
                        ExternalId = reader.ReadElementContentAsString();
                        break;

                    case "state":
                        State = reader.ReadElementContentAsString().ParseAsEnum<ExternalInvoiceState>();
                        break;

                    case "total":
                        Total = reader.ReadElementContentAsDecimal();
                        break;

                    case "currency":
                        Currency = reader.ReadElementContentAsString();
                        break;

                    case "purchased_at":
                        if (DateTime.TryParse(reader.ReadElementContentAsString(), out dateVal))
                            PurchasedAt = dateVal;
                        break;

                    case "updated_at":
                        if (DateTime.TryParse(reader.ReadElementContentAsString(), out dateVal))
                            UpdatedAt = dateVal; ;
                        break;

                    case "created_at":
                        if (DateTime.TryParse(reader.ReadElementContentAsString(), out dateVal))
                            CreatedAt = dateVal; ;
                        break;

                    case "line_items":
                        ExternalCharges = new List<ExternalCharge>();
                        while (reader.Read())
                        {
                            if (reader.Name == "line_items" && reader.NodeType == XmlNodeType.EndElement)
                                break;

                            if (reader.NodeType == XmlNodeType.Element && reader.Name == "external_charge")
                            {
                                ExternalCharges.Add(new ExternalCharge(reader));
                            }
                        }
                        break;
                }
            }
        }

        internal override void WriteXml(XmlTextWriter writer)
        {
            throw new NotImplementedException();
        }

        #endregion
    }

    public sealed class ExternalInvoices
    {
        /// <summary>
        /// Returns a list of recurly external_invoices
        /// </summary>
        /// <returns></returns>
        public static RecurlyList<ExternalInvoice> List()
        {
            return List(null);
        }
        /// <summary>
        /// Returns a list of recurly external_invoices
        /// </summary>
        /// <param name="filter">FilterCriteria used to apply server side sorting and filtering</param>
        /// <returns></returns>
        public static RecurlyList<ExternalInvoice> List(FilterCriteria filter)
        {
            filter = filter ?? FilterCriteria.Instance;
            var parameters = filter.ToNamedValueCollection();
            return new ExternalInvoiceList(ExternalInvoice.UrlPrefix + "?" + parameters.ToString());
        }
        public static ExternalInvoice Get(string uuid)
        {
            if (string.IsNullOrWhiteSpace(uuid))
            {
                return null;
            }
            var externalInvoice = new ExternalInvoice();
            var statusCode = Client.Instance.PerformRequest(Client.HttpRequestMethod.Get,
                ExternalInvoice.UrlPrefix + Uri.EscapeDataString(uuid),
                externalInvoice.ReadXml);

            return statusCode == HttpStatusCode.NotFound ? null : externalInvoice;
        }
    }
}
