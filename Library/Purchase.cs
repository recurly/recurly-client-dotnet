using System;
using System.Collections.Generic;
using System.Net;
using System.Xml;

namespace Recurly
{
    public class Purchase : RecurlyEntity
    {
        public Invoice.Collection CollectionMethod { get; set; }
        public Account Account { get; set; }
        public string Currency { get; set; }
        public string PoNumber { get; set; }
        public int? NetTerms { get; set; }

        /// <summary>
        /// List of subscriptions to apply to this purchase
        /// </summary>
        public List<Subscription> Subscriptions
        {
            get { return _subscriptions ?? (_subscriptions = new List<Subscription>()); }
            set { _subscriptions = value; }
        }
        private List<Subscription> _subscriptions;

        /// <summary>
        /// List of adjustments to apply to this purchase
        /// </summary>
        public List<Adjustment> Adjustments
        {
            get { return _adjustments ?? (_adjustments = new List<Adjustment>()); }
            set { _adjustments = value; }
        }
        private List<Adjustment> _adjustments;

        /// <summary>
        /// List of coupon codes to apply to this purchase
        /// </summary>
        public List<string> CouponCodes
        {
            get { return _couponCodes ?? (_couponCodes = new List<string>()); }
            set { _couponCodes = value; }
        }
        private List<string> _couponCodes;

        #region Constructors

        internal Purchase()
        {
        }

        internal Purchase(XmlTextReader xmlReader)
        {
            ReadXml(xmlReader);
        }

        /// <summary>
        /// Creates a purchase instance
        /// </summary>
        /// <param name="accountCode"></param>
        /// <param name="currency"></param>
        public Purchase(string accountCode, string currency)
        {
            Account = new Account(accountCode);
            Currency = currency;
        }

        /// <summary>
        /// Creates a purchase instance
        /// </summary>
        /// <param name="account"></param>
        /// <param name="currency"></param>
        public Purchase(Account account, string currency)
        {
            Account = account;
            Currency = currency;
        }

        #endregion

        internal const string UrlPrefix = "/purchases/";

        /// <summary>
        /// Creates and invoices this purchase.
        /// </summary>
        public static Invoice Invoice(Purchase purchase)
        {
            var invoice = new Invoice();

            Client.Instance.PerformRequest(Client.HttpRequestMethod.Post,
                UrlPrefix, 
                purchase.WriteXml,
                invoice.ReadXml);

            return invoice;
        }

        /// <summary>
        /// Previews the invoice for this purchase. Runs validations but not transactions.
        /// </summary>
        public static Invoice Preview(Purchase purchase)
        {
            var invoice = new Invoice();

            Client.Instance.PerformRequest(Client.HttpRequestMethod.Post,
                UrlPrefix + "preview/",
                purchase.WriteXml,
                invoice.ReadXml);

            return invoice;
        }

        #region Read and Write XML documents

        internal override void WriteXml(XmlTextWriter xmlWriter)
        {
            xmlWriter.WriteStartElement("purchase"); // Start: purchase

            xmlWriter.WriteElementString("collection_method", CollectionMethod.ToString().EnumNameToTransportCase());
            if (NetTerms.HasValue)
                xmlWriter.WriteElementString("net_terms", NetTerms.Value.ToString());

            xmlWriter.WriteElementString("currency", Currency);

            Account.WriteXml(xmlWriter);

            if (Adjustments.HasAny())
            {
                xmlWriter.WriteStartElement("adjustments"); // Start: adjustments
                foreach (var adjustment in Adjustments)
                {
                    adjustment.WriteXml(xmlWriter);
                }
                xmlWriter.WriteEndElement(); // End: adjustments
            }

            if (Subscriptions.HasAny())
            {
                xmlWriter.WriteStartElement("subscriptions"); // Start: subscriptions
                foreach (var subscription in Subscriptions)
                {
                    subscription.WriteEmbeddedSubscriptionXml(xmlWriter);
                }
                xmlWriter.WriteEndElement(); // End: subscriptions
            }

            if (CouponCodes.HasAny())
            {
                xmlWriter.WriteStartElement("coupon_codes"); // Start: coupon_codes
                foreach (var code in CouponCodes)
                {
                    xmlWriter.WriteElementString("coupon_code", code);
                }
                xmlWriter.WriteEndElement(); // End: coupon_codes
            }

            xmlWriter.WriteEndElement(); // End: purchase
        }

        internal override void ReadXml(XmlTextReader reader)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
