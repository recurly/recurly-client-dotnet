﻿using System;
using System.Collections.Generic;
using System.Net;
using System.Xml;

namespace Recurly
{
    public class Purchase : RecurlyEntity, IPurchase
    {
        /// <summary>
        /// The collection method for the invoice (Automatic or Manual)
        /// </summary>
        public Invoice.Collection CollectionMethod { get; set; }

        /// <summary>
        /// An account object. This can be an existing account or a new account.
        /// </summary>
        public IAccount Account { get; set; }

        /// <summary>
        /// The 3 letter currency code for the invoice transactions.
        /// </summary>
        public string Currency { get; set; }

        /// <summary>
        /// A po number for the resulting invoice.
        /// </summary>
        public string PoNumber { get; set; }

        /// <summary>
        /// The net terms for the invoice.
        /// </summary>
        public int? NetTerms { get; set; }

        /// <summary>
        /// A gift card redemption code to apply to this purchase.
        /// </summary>
        public string GiftCardRedemptionCode { get; set; }

        /// <summary>
        /// List of subscriptions to apply to this purchase
        /// </summary>
        public List<ISubscription> Subscriptions
        {
            get { return _subscriptions ?? (_subscriptions = new List<ISubscription>()); }
            set { _subscriptions = value; }
        }
        private List<ISubscription> _subscriptions;

        /// <summary>
        /// List of adjustments to apply to this purchase
        /// </summary>
        public List<IAdjustment> Adjustments
        {
            get { return _adjustments ?? (_adjustments = new List<IAdjustment>()); }
            set { _adjustments = value; }
        }
        private List<IAdjustment> _adjustments;

        /// <summary>
        /// List of shipping fees to apply to this purchase
        /// </summary>
        public List<IShippingFee> ShippingFees
        {
            get { return _shippingFees ?? (_shippingFees = new List<IShippingFee>()); }
            set { _shippingFees = value; }
        }

        private List<IShippingFee> _shippingFees;

        /// <summary>
        /// List of coupon codes to apply to this purchase
        /// </summary>
        public List<string> CouponCodes
        {
            get { return _couponCodes ?? (_couponCodes = new List<string>()); }
            set { _couponCodes = value; }
        }
        private List<string> _couponCodes;

        /// <summary>
        /// Optional notes field. This will default to the Customer Notes 
        /// text specified on the Invoice Settings page in your Recurly admin.
        /// Custom notes made on an invoice for a one time charge will
        /// not carry over to subsequent invoices.
        /// </summary>
        public string CustomerNotes { get; set; }

        /// <summary>
        /// Optional Terms and Conditions field. This will default to the
        /// Terms and Conditions text specified on the Invoice Settings page
        /// in your Recurly admin. Custom notes will stay with a subscription
        /// on all renewals.
        /// </summary>
        public string TermsAndConditions { get; set; }

        /// <summary>
        /// Optional VAT Reverse Charge Notes only appear if you have EU VAT
        /// enabled or are using your own Avalara AvaTax account and the customer
        /// is in the EU, has a VAT number, and is in a different country than
        /// your own. This will default to the VAT Reverse Charge Notes text
        /// specified on the Tax Settings page in your Recurly admin, unless
        /// custom notes were created with the original subscription. Custom
        /// notes will stay with a subscription on all renewals.
        /// </summary>
        public string VatReverseChargeNotes { get; set; }

        /// <summary>
        /// Setting this property sets the shipping address for all
        /// items in the Purchase. It can't be used if you are embedding
        /// a new shipping address in the Account object.
        /// </summary>
        public long? ShippingAddressId { get; set; }

        /// <summary>
        /// Optional gateway identifier for this purchase.
        /// </summary>
        public string GatewayCode { get; set; }

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
        /// <param name="accountCode">An account code of an existing account</param>
        /// <param name="currency">The 3 letter currency code for the invoice transactions</param>
        public Purchase(string accountCode, string currency)
        {
            Account = new Account(accountCode);
            Currency = currency;
        }

        /// <summary>
        /// Creates a purchase instance
        /// </summary>
        /// <param name="account">An account object. This can be an existing account or a new account</param>
        /// <param name="currency">The 3 letter currency code for the invoice transactions</param>
        public Purchase(IAccount account, string currency)
        {
            Account = account;
            Currency = currency;
        }

        #endregion

        internal const string UrlPrefix = "/purchases/";

        /// <summary>
        /// Creates and invoices this purchase.
        /// </summary>
        public static IInvoiceCollection Invoice(IPurchase purchase)
        {
            var collection = new InvoiceCollection();

            Client.Instance.PerformRequest(Client.HttpRequestMethod.Post,
                UrlPrefix,
                xml => WriteXml(xml, purchase),
                collection.ReadXml);

            return collection;
        }

        /// <summary>
        /// Previews the invoice for this purchase. Runs validations but not transactions.
        /// </summary>
        public static IInvoiceCollection Preview(IPurchase purchase)
        {
            var collection = new InvoiceCollection();

            Client.Instance.PerformRequest(Client.HttpRequestMethod.Post,
                UrlPrefix + "preview/",
                xml => WriteXml(xml, purchase),
                collection.ReadXml);

            return collection;
        }

        /// <summary>
        /// Generate an authorized invoice for the purchase. Runs validations
        /// but does not run any transactions. This endpoint will create a
        /// pending purchase that can be activated at a later time once payment
        /// has been completed on an external source (e.g. Adyen's Hosted
        /// Payment Pages).
        /// </summary>
        public static IInvoiceCollection Authorize(IPurchase purchase)
        {
            var collection = new InvoiceCollection();

            Client.Instance.PerformRequest(Client.HttpRequestMethod.Post,
                UrlPrefix + "authorize/",
                xml => WriteXml(xml, purchase),
                collection.ReadXml);

            return collection;
        }

        /// <summary>
        /// Use for Adyen HPP transaction requests. Runs validations
        /// but does not run any transactions.
        /// </summary>
        public static IInvoiceCollection Pending(IPurchase purchase)
        {
            var collection = new InvoiceCollection();

            Client.Instance.PerformRequest(Client.HttpRequestMethod.Post,
                UrlPrefix + "pending/",
                xml => WriteXml(xml, purchase),
                collection.ReadXml);

            return collection;
        }

        #region Read and Write XML documents

        internal static void WriteXml(XmlTextWriter xmlWriter, IPurchase purchase)
        {
            var recurlyPurchase = purchase as Purchase;
            if (recurlyPurchase != null)
                recurlyPurchase.WriteXml(xmlWriter);
        }

        internal override void WriteXml(XmlTextWriter xmlWriter)
        {
            xmlWriter.WriteStartElement("purchase"); // Start: purchase

            xmlWriter.WriteElementString("collection_method", CollectionMethod.ToString().EnumNameToTransportCase());

            if (NetTerms.HasValue)
                xmlWriter.WriteElementString("net_terms", NetTerms.Value.ToString());

            if (PoNumber != null)
                xmlWriter.WriteElementString("po_number", PoNumber);

            xmlWriter.WriteElementString("currency", Currency);

            if (ShippingAddressId.HasValue)
                xmlWriter.WriteElementString("shipping_address_id", ShippingAddressId.Value.ToString());

            Recurly.Account.WriteXml(xmlWriter, Account);

            if (Adjustments.HasAny())
            {
                xmlWriter.WriteStartElement("adjustments"); // Start: adjustments
                foreach (var adjustment in Adjustments)
                {
                    Adjustment.WriteEmbeddedXml(xmlWriter, adjustment);
                }
                xmlWriter.WriteEndElement(); // End: adjustments
            }

            if (Subscriptions.HasAny())
            {
                xmlWriter.WriteStartElement("subscriptions"); // Start: subscriptions
                foreach (var subscription in Subscriptions)
                {
                    Subscription.WriteEmbeddedSubscriptionXml(xmlWriter, subscription);
                }
                xmlWriter.WriteEndElement(); // End: subscriptions
            }

            if (ShippingFees.HasAny())
            {
                xmlWriter.WriteStartElement("shipping_fees"); // Start: shipping_fees
                foreach (var shippingFee in ShippingFees)
                {
                    ShippingFee.WriteEmbeddedXml(xmlWriter, shippingFee);
                }
                xmlWriter.WriteEndElement(); // End: shipping_fees
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

            if (GiftCardRedemptionCode != null)
            {
                var gc = new GiftCard(GiftCardRedemptionCode);
                gc.WriteRedemptionXml(xmlWriter);
            }

            if (CustomerNotes != null)
                xmlWriter.WriteElementString("customer_notes", CustomerNotes);

            if (TermsAndConditions != null)
                xmlWriter.WriteElementString("terms_and_conditions", TermsAndConditions);

            if (VatReverseChargeNotes != null)
                xmlWriter.WriteElementString("vat_reverse_charge_notes", VatReverseChargeNotes);

            if (GatewayCode != null)
                xmlWriter.WriteElementString("gateway_code", GatewayCode);

            xmlWriter.WriteEndElement(); // End: purchase
        }

        internal override void ReadXml(XmlTextReader reader)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
