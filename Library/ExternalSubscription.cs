using System;
using System.Collections.Generic;
using System.Net;
using System.Xml;

namespace Recurly
{

    /// <summary>
    /// Represents external_subscriptions for accounts
    /// </summary>
    public class ExternalSubscription : RecurlyEntity
    {
        private string _accountCode;
        public string AccountCode => _accountCode;

        private Account _account;
        public Account Account
        {
            get { return _account ?? (_account = Accounts.Get(_accountCode)); }
            internal set { _account = value; }
        }

        public string ExternalId { get; set; }
        public string AppIdentifier { get; private set; }
        public string State { get; set; }
        public bool? AutoRenew { get; set; }
        public int Quantity { get; set; }
        public ExternalProductReference ExternalProductReference { get; private set; }
        public DateTime? LastPurchased { get; private set; }
        public DateTime? ActivatedAt { get; private set; }
        public DateTime? ExpiresAt { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }

        internal const string UrlPrefix = "/external_subscriptions/";

        internal ExternalSubscription()
        {
        }

        internal ExternalSubscription(XmlTextReader reader)
        {
            ReadXml(reader);
        }

        #region Read XML documents

        internal void ReadExternalProductReferenceXml(XmlTextReader reader)
        {
            ExternalProductReference = new ExternalProductReference(reader);
        }

        internal override void ReadXml(XmlTextReader reader)
        {
            while (reader.Read())
            {
                string href;
                DateTime dateVal;

                if (reader.Name == "external_subscription" && reader.NodeType == XmlNodeType.EndElement)
                    break;

                if (reader.NodeType != XmlNodeType.Element) continue;

                switch (reader.Name)
                {
                    case "account":
                        href = reader.GetAttribute("href");
                        if (null != href)
                            _accountCode = Uri.UnescapeDataString(href.Substring(href.LastIndexOf("/") + 1));
                        break;

                    case "external_id":
                        ExternalId = reader.ReadElementContentAsString();
                        break;

                    case "external_product_reference":
                        ReadExternalProductReferenceXml(reader);
                        break;

                    case "last_purchased":
                        if (DateTime.TryParse(reader.ReadElementContentAsString(), out dateVal))
                            LastPurchased = dateVal;
                        break;

                    case "state":
                        State = reader.ReadElementContentAsString();
                        break;

                    case "auto_renew":
                        bool b;
                        if (bool.TryParse(reader.ReadElementContentAsString(), out b))
                            AutoRenew = b;
                        break;

                    case "app_identifier":
                        AppIdentifier = reader.ReadElementContentAsString();
                        break;

                    case "quantity":
                        Quantity = reader.ReadElementContentAsInt();
                        break;

                    case "activated_at":
                        if (DateTime.TryParse(reader.ReadElementContentAsString(), out dateVal))
                            ActivatedAt = dateVal;
                        break;

                    case "expires_at":
                        if (DateTime.TryParse(reader.ReadElementContentAsString(), out dateVal))
                            ExpiresAt = dateVal;
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
    }

    public sealed class ExternalSubscriptions
    {
        /// <summary>
        /// Returns a list of recurly external_subscriptions
        /// </summary>
        /// <returns></returns>
        public static RecurlyList<ExternalSubscription> List()
        {
            return List(null);
        }

        /// <summary>
        /// Returns a list of recurly external_products
        ///
        /// A external_product will belong to more than one state.
        /// </summary>
        /// <param name="filter">FilterCriteria used to apply server side sorting and filtering</param>
        /// <returns></returns>
        public static RecurlyList<ExternalSubscription> List(FilterCriteria filter)
        {
            filter = filter ?? FilterCriteria.Instance;
            var parameters = filter.ToNamedValueCollection();
            return new ExternalSubscriptionList(ExternalSubscription.UrlPrefix + "?" + parameters.ToString());
        }

        public static ExternalSubscription Get(string uuid)
        {
            if (string.IsNullOrWhiteSpace(uuid))
            {
                return null;
            }
            var externalSubscription = new ExternalSubscription();
            var statusCode = Client.Instance.PerformRequest(Client.HttpRequestMethod.Get,
                ExternalSubscription.UrlPrefix + Uri.EscapeDataString(uuid),
                externalSubscription.ReadXml);

            return statusCode == HttpStatusCode.NotFound ? null : externalSubscription;
        }
    }
}
