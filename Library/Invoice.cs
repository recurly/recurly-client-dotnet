using System;
using System.Net;
using System.Xml;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Recurly
{
    public class Invoice : RecurlyEntity
    {
        // The currently valid Invoice States
        public enum InvoiceState
        {
            Paid,
            Failed,
            PastDue,
            Processing,
            Pending,
            Closed,
            Open,
            Voided
        }

        public enum RefundMethod
        {
            CreditFirst,
            TransactionFirst
        }

        public enum Collection
        {
            Automatic,
            Manual
        }

        public string AccountCode { get; private set; }
        public int OriginalInvoiceNumber { get; private set; }
        public string OriginalInvoiceNumberPrefix { get; private set; }
        public string Uuid { get; protected set; }
        public InvoiceState State { get; protected set; }
        public int InvoiceNumber { get; private set; }
        public string InvoiceNumberPrefix { get; private set; }
        public string PoNumber { get; set; }
        public string VatNumber { get; private set; }
        public int SubtotalInCents { get; private set; }
        public int TaxInCents { get; protected set; }
        public int TotalInCents { get; protected set; }
        public string Currency { get; protected set; }
        public int? NetTerms { get; set; }
        public Collection CollectionMethod { get; set; }
        public DateTime? CreatedAt { get; private set; }
        public DateTime? UpdatedAt { get; private set; }
        public DateTime? ClosedAt { get; private set; }

        public Address Address
        {
            get { return _address ?? (_address = new Address()); }
            set { _address = value; }
        }
        private Address _address;

        public ShippingAddress ShippingAddress { get; private set; }

        /// <summary>
        /// Tax type as "vat" for VAT or "usst" for US Sales Tax.
        /// </summary>
        public string TaxType { get; private set; }
        public string TaxRegion { get; private set; }
        public decimal? TaxRate { get; private set; }

        public RecurlyList<Adjustment> Adjustments { get; private set; }
        public RecurlyList<Transaction> Transactions { get; private set; }

        public string CustomerNotes { get; set; }
        public string TermsAndConditions { get; set; }
        public string VatReverseChargeNotes { get; set; }
        public DateTime? AttemptNextCollectionAt { get; set; }
        public string RecoveryReason { get; set; }
        public string AllLineItemsLink { get; set; }

        public int SubtotalBeforeDiscountInCents { get; set; }
        public int? DiscountInCents { get; set; }
        public int? BalanceInCents { get; set; }
        public DateTime? DueOn { get; set; }
        public string Type { get; set; }
        public string Origin { get; set; }

        internal const string UrlPrefix = "/invoices/";

        public Invoice()
        {
            Adjustments = new AdjustmentList();
            Transactions = new TransactionList();
        }

        internal Invoice(XmlTextReader reader)
            : this()
        {
            ReadXml(reader);
        }

        private string memberUrl()
        {
            return UrlPrefix + InvoiceNumberWithPrefix();
        }

        public string InvoiceNumberWithPrefix()
        {
            return InvoiceNumberPrefix + Convert.ToString(InvoiceNumber);
        }

        public string OriginalInvoiceNumberWithPrefix()
        {
            return OriginalInvoiceNumberPrefix + Convert.ToString(OriginalInvoiceNumber);
        }

        /// <summary>
        /// Returns a PDF representation of an invoice
        /// </summary>
        /// <param name="acceptLanguage">Language for invoice, defaults to en-US.</param>
        /// <returns></returns>
        public byte[] GetPdf(string acceptLanguage = "en-US")
        {
            return Client.Instance.PerformDownloadRequest(memberUrl(), "application/pdf", acceptLanguage);
        }

        public SubscriptionList GetSubscriptions()
        {
            var url = this.memberUrl() + "/subscriptions";
            return new SubscriptionList(url);
        }

        /// <summary>
        /// Post an invoice on an account using it's pending charges
        /// </summary>
        public void Create(string accountCode)
        {
            Client.Instance.PerformRequest(Client.HttpRequestMethod.Post,
                "/accounts/" + Uri.EscapeDataString(accountCode) + Invoice.UrlPrefix,
                WriteXml,
                ReadXml);
        }

        /// <summary>
        /// Preview an invoice on an account using it's pending charges
        /// </summary>
        public void Preview(string accountCode)
        {
            Client.Instance.PerformRequest(Client.HttpRequestMethod.Post,
                "/accounts/" + Uri.EscapeDataString(accountCode) + Invoice.UrlPrefix + "preview",
                WriteXml,
                ReadXml);
        }

        /// <summary>
        /// Marks an invoice as paid successfully
        /// </summary>
        public void MarkSuccessful()
        {
            Client.Instance.PerformRequest(Client.HttpRequestMethod.Put, memberUrl() + "/mark_successful", ReadXml);
        }

        /// <summary>
        /// Voids an invoice
        /// </summary>
        public void Void()
        {
            Client.Instance.PerformRequest(Client.HttpRequestMethod.Put, memberUrl() + "/void", ReadXml);
        }

        /// <summary>
        /// Marks an invoice as failed. This returns a
        /// new invoice collection and does not update the
        /// this invoice object.
        /// </summary>
        /// <returns>New Invoice Collection</returns>
        public InvoiceCollection MarkFailed()
        {
            var collection = new InvoiceCollection();
            Client.Instance.PerformRequest(
                Client.HttpRequestMethod.Put,
                memberUrl() + "/mark_failed",
                collection.ReadXml);
            return collection;
        }

        /// <summary>
        /// Returns the active coupon redemption on this invoice
        /// </summary>
        /// <returns></returns>
        public CouponRedemption GetRedemption()
        {
            var redemptionList = GetRedemptions();
            return redemptionList.HasAny() ? redemptionList[0] : null;
        }

        public RecurlyList<CouponRedemption> GetRedemptions()
        {
            var coupons = new CouponRedemptionList();
            var statusCode = Client.Instance.PerformRequest(Client.HttpRequestMethod.Get,
                memberUrl() + "/redemptions/",
                coupons.ReadXmlList);

            return statusCode == HttpStatusCode.NotFound ? null : coupons;
        }

        public Invoice GetOriginalInvoice()
        {
            return Invoices.Get(OriginalInvoiceNumberWithPrefix());
        }

        /// <summary>
        /// If enabled, allows specific line items and/or quantities to be refunded.
        /// </summary>
        /// <param name="adjustment"></param>
        /// <param name="prorate"></param>
        /// <param name="quantity"></param>
        /// <returns>new Invoice object</returns>
        public Invoice Refund(Adjustment adjustment, bool prorate = false, int quantity = 0, RefundMethod method = RefundMethod.CreditFirst)
        {
            var adjustments = new List<Adjustment>();
            adjustments.Add(adjustment);

            return Refund(adjustments, prorate, quantity, method);
        }

        public Invoice Refund(IEnumerable<Adjustment> adjustments, bool prorate = false, int quantity = 0, RefundMethod method = RefundMethod.CreditFirst)
        {
            var refunds = new RefundList(adjustments, prorate, quantity, method);
            var invoice = new Invoice();

            var response = Client.Instance.PerformRequest(Client.HttpRequestMethod.Post,
                memberUrl() + "/refund",
                refunds.WriteXml,
                invoice.ReadXml);

            if (HttpStatusCode.Created == response || HttpStatusCode.OK == response)
                return invoice;
            else
                return null;
        }

        public Invoice RefundAmount(int amountInCents, RefundMethod method = RefundMethod.CreditFirst)
        {
            var refundInvoice = new Invoice();
            var refund = new OpenAmountRefund(amountInCents, method);
               
            var response = Client.Instance.PerformRequest(Client.HttpRequestMethod.Post,
                memberUrl() + "/refund",
                refund.WriteXml,
                refundInvoice.ReadXml);

            if (HttpStatusCode.Created == response || HttpStatusCode.OK == response)
                return refundInvoice;
            else
                return null;
        }

        #region Read and Write XML documents

        internal override void ReadXml(XmlTextReader reader)
        {
            ReadXml(reader, "invoice");
        }

        internal void ReadXml(XmlTextReader reader, string nodeName)
        {
            while (reader.Read())
            {
                // End of invoice element, get out of here
                if (reader.Name == nodeName && reader.NodeType == XmlNodeType.EndElement)
                    break;

                if (reader.NodeType != XmlNodeType.Element) continue;

                DateTime dt;
                int m;

                switch (reader.Name)
                {
                    case "account":
                        var accountHref = reader.GetAttribute("href");
                        AccountCode = Uri.UnescapeDataString(accountHref.Substring(accountHref.LastIndexOf("/") + 1));
                        break;

                    case "original_invoice":
                        var originalInvoiceHref = reader.GetAttribute("href");
                        var invoiceNumber = Uri.UnescapeDataString(originalInvoiceHref.Substring(originalInvoiceHref.LastIndexOf("/") + 1));
                        MatchCollection matches = Regex.Matches(invoiceNumber, "([^\\d]{2})(\\d+)");
                        
                        if (matches.Count == 1) 
                        {
                            OriginalInvoiceNumberPrefix = matches[0].Groups[1].Value;
                            OriginalInvoiceNumber = int.Parse(matches[0].Groups[2].Value);
                        } 
                        else
                        {
                            OriginalInvoiceNumber = int.Parse(invoiceNumber);
                        }
                        break;

                    case "uuid":
                        Uuid = reader.ReadElementContentAsString();
                        break;

                    case "state":
                        var state = reader.ReadElementContentAsString();
                        if (!state.IsNullOrEmpty()) 
                            State = state.ParseAsEnum<InvoiceState>();
                        break;

                    case "invoice_number":
                        if (Int32.TryParse(reader.ReadElementContentAsString(), out m))
                            InvoiceNumber = m;
                        break;

                    case "invoice_number_prefix":
                        InvoiceNumberPrefix = reader.ReadElementContentAsString();
                        break;

                    case "po_number":
                        PoNumber = reader.ReadElementContentAsString();
                        break;

                    case "vat_number":
                        VatNumber = reader.ReadElementContentAsString();
                        break;

                    case "subtotal_in_cents":
                        SubtotalInCents = reader.ReadElementContentAsInt();
                        break;

                    case "tax_in_cents":
                        TaxInCents = reader.ReadElementContentAsInt();
                        break;

                    case "total_in_cents":
                        TotalInCents = reader.ReadElementContentAsInt();
                        break;

                    case "currency":
                        Currency = reader.ReadElementContentAsString();
                        break;

                    case "created_at":
                        if (DateTime.TryParse(reader.ReadElementContentAsString(), out dt))
                            CreatedAt = dt;
                        break;

                    case "updated_at":
                        if (DateTime.TryParse(reader.ReadElementContentAsString(), out dt))
                            UpdatedAt = dt;
                        break;                    

                    case "closed_at":
                        if (DateTime.TryParse(reader.ReadElementContentAsString(), out dt))
                            ClosedAt = dt;
                        break;

                    case "tax_type":
                        TaxType = reader.ReadElementContentAsString();
                        break;

                    case "tax_rate":
                        TaxRate = reader.ReadElementContentAsDecimal();
                        break;

                    case "tax_region":
                        TaxRegion = reader.ReadElementContentAsString();
                        break;

                    case "net_terms":
                        if (int.TryParse(reader.ReadElementContentAsString(), out m))
                            NetTerms = m;
                        break;

                    case "collection_method":
                        var method = reader.ReadElementContentAsString();
                        if (!method.IsNullOrEmpty())
                            CollectionMethod = method.ParseAsEnum<Collection>();
                        break;

                    case "customer_notes":
                        CustomerNotes = reader.ReadElementContentAsString();
                        break;

                    case "terms_and_conditions":
                        TermsAndConditions = reader.ReadElementContentAsString();
                        break;

                    case "vat_reverse_charge_notes":
                        VatReverseChargeNotes = reader.ReadElementContentAsString();
                        break;

                    case "line_items":
                        // overrite existing value with the Recurly API response
                        Adjustments = new AdjustmentList();
                        Adjustments.ReadXml(reader);
                        break;

                    case "transactions":
                        // overrite existing value with the Recurly API response
                        Transactions = new TransactionList();
                        Transactions.ReadXml(reader);
                        break;

                    case "address":
                        Address = new Address(reader);
                        break;

                    case "shipping_address":
                        ShippingAddress = new ShippingAddress(reader);
                        break;

                    case "subtotal_before_discount_in_cents":
                        if (int.TryParse(reader.ReadElementContentAsString(), out m))
                            SubtotalBeforeDiscountInCents = m;
                        break;

                    case "discount_in_cents":
                        if (int.TryParse(reader.ReadElementContentAsString(), out m))
                            DiscountInCents = m;
                        break;

                    case "balance_in_cents":
                        if (int.TryParse(reader.ReadElementContentAsString(), out m))
                            BalanceInCents = m;
                        break;

                    case "due_on":
                        if (DateTime.TryParse(reader.ReadElementContentAsString(), out dt))
                            DueOn = dt;
                        break;

                    case "type":
                        Type = reader.ReadElementContentAsString();
                        break;

                    case "origin":
                        Origin = reader.ReadElementContentAsString();
                        break;

                    case "attempt_next_collection_at":
                        if (DateTime.TryParse(reader.ReadElementContentAsString(), out dt))
                            AttemptNextCollectionAt = dt;
                        break;

                    case "recovery_reason":
                        RecoveryReason = reader.ReadElementContentAsString();
                        break;

                    case "all_line_items":
                        AllLineItemsLink = reader.ReadElementContentAsString();
                        break;

                }
            }
        }

        internal override void WriteXml(XmlTextWriter xmlWriter)
        {
            xmlWriter.WriteStartElement("invoice"); // Start: invoice

            xmlWriter.WriteElementString("customer_notes", CustomerNotes);
            xmlWriter.WriteElementString("terms_and_conditions", TermsAndConditions);
            xmlWriter.WriteElementString("vat_reverse_charge_notes", VatReverseChargeNotes);
            xmlWriter.WriteElementString("po_number", PoNumber);

            if (CollectionMethod == Collection.Manual)
            {
                xmlWriter.WriteElementString("collection_method", "manual");

                if (NetTerms.HasValue)
                    xmlWriter.WriteElementString("net_terms", NetTerms.Value.AsString());
            }
            else if (CollectionMethod == Collection.Automatic)
            {
                xmlWriter.WriteElementString("collection_method", "automatic");
            }
           
            xmlWriter.WriteEndElement(); // End: invoice
        }

        #endregion

        #region Object Overrides

        public override string ToString()
        {
            return "Recurly Invoice: " + Uuid;
        }

        public override bool Equals(object obj)
        {
            var invoice = obj as Invoice;
            return invoice != null && Equals(invoice);
        }

        public bool Equals(Invoice invoice)
        {
            return Uuid == invoice.Uuid;
        }

        public override int GetHashCode()
        {
            return Uuid?.GetHashCode() ?? 0;
        }

        #endregion
    }

    public sealed class Invoices
    {
        public static RecurlyList<Invoice> List(string accountCode)
        {
            return new InvoiceList("/accounts/" + Uri.EscapeDataString(accountCode) + "/invoices");
        }

        public static RecurlyList<Invoice> List()
        {
            return new InvoiceList(Invoice.UrlPrefix);
        }

        public static RecurlyList<Invoice> List(Invoice.InvoiceState state)
        {
            return new InvoiceList(Invoice.UrlPrefix + "?state=" + state.ToString().EnumNameToTransportCase());
        }

        public static RecurlyList<Invoice> List(Invoice.InvoiceState state, FilterCriteria filter)
        {
            filter = filter ?? FilterCriteria.Instance;
            var parameters = filter.ToNamedValueCollection();
            parameters["state"] = state.ToString().EnumNameToTransportCase();
            return new InvoiceList(Invoice.UrlPrefix + "?" + parameters.ToString());
        }

        public static RecurlyList<Invoice> List(FilterCriteria filter)
        {
            filter = filter ?? FilterCriteria.Instance;
            var parameters = filter.ToNamedValueCollection();
            return new InvoiceList(Invoice.UrlPrefix + "?" + parameters.ToString());
        }

        /// <summary>
        /// Look up an Invoice.
        /// </summary>
        /// <param name="invoiceNumber">Invoice Number</param>
        /// <returns></returns>
        public static Invoice Get(int invoiceNumber)
        {
            return Get(Convert.ToString(invoiceNumber));
        }

        /// <summary>
        /// Look up an Invoice.
        /// </summary>
        /// <param name="invoiceNumber">Invoice Number</param>
        /// <returns></returns>
        public static Invoice Get(string invoiceNumberWithPrefix)
        {
            var invoice = new Invoice();
            
            var statusCode = Client.Instance.PerformRequest(Client.HttpRequestMethod.Get,
                Invoice.UrlPrefix + invoiceNumberWithPrefix,
                invoice.ReadXml);

            return statusCode == HttpStatusCode.NotFound ? null : invoice;
        }

        /// <summary>
        /// Create an Invoice if there are outstanding charges on an account. If there are no outstanding
        /// charges, null is returned.
        /// </summary>
        /// <param name="accountCode">Account code</param>
        /// <returns></returns>
        [Obsolete("Deprecated, please use the Create instance method on the Invoice object")] 
        public static Invoice Create(string accountCode)
        {
            var invoice = new Invoice();

            var statusCode = Client.Instance.PerformRequest(Client.HttpRequestMethod.Post,
                "/accounts/" + Uri.EscapeDataString(accountCode) + Invoice.UrlPrefix,
                invoice.ReadXml);

            return (int)statusCode == ValidationException.HttpStatusCode ? null : invoice;
        }
    }
}
