using System;
using System.Net;
using System.Xml;

namespace Recurly
{
    public class Invoice
    {
        // The currently valid Invoice States
        public enum InvoiceState
        {
            Open,
            Collected,
            Failed,
            PastDue
        }

        public string AccountCode { get; private set; }
        public string Uuid { get; protected set; }
        public InvoiceState State { get; protected set; }
        public int InvoiceNumber { get; private set; }
        public string PONumber { get; private set; }
        public string VatNumber { get; private set; }
        public int SubtotalInCents { get; private set; }
        public int TaxInCents { get; protected set; }
        public int TotalInCents { get; protected set; }
        public string Currency { get; protected set; }
        public DateTime CreatedAt { get; private set; }

        public AdjustmentList Adjustments { get; private set; }
        public TransactionList Transactions { get; private set; }

        internal const string UrlPrefix = "/invoices/";

        internal Invoice()
        {
            Adjustments = new AdjustmentList();
            Transactions = new TransactionList();
        }

        internal Invoice(XmlTextReader reader)
            : this()
        {
            ReadXml(reader);
        }

        /// <summary>
        /// Look up an Invoice.
        /// </summary>
        /// <param name="invoiceNumber">Invoice Number</param>
        /// <returns></returns>
        public static Invoice Get(int invoiceNumber)
        {
            var invoice = new Invoice();

            var statusCode = Client.PerformRequest(Client.HttpRequestMethod.Get,
                UrlPrefix + invoiceNumber,
                invoice.ReadXml);

            return statusCode == HttpStatusCode.NotFound ? null : invoice;
        }

        /// <summary>
        /// Returns a PDF representation of an invoice
        /// </summary>
        /// <param name="acceptLanguage">Language for invoice, defaults to en-US.</param>
        /// <returns></returns>
        public byte[] GetPdf(string acceptLanguage = "en-US")
        {
            return Client.PerformDownloadRequest(UrlPrefix + InvoiceNumber,
               "application/pdf", acceptLanguage);
        }

        /// <summary>
        /// Marks an invoice as paid successfully
        /// </summary>
        public void MarkSuccessful()
        {
            Client.PerformRequest(Client.HttpRequestMethod.Put,
                UrlPrefix + InvoiceNumber + "/mark_successful",
                ReadXml);

        }

        /// <summary>
        /// Marks an invoice as failed collection
        /// </summary>
        public void MarkFailed()
        {
            Client.PerformRequest(Client.HttpRequestMethod.Put,
               UrlPrefix + InvoiceNumber + "/mark_failed",
               ReadXml);

        }

        /// <summary>
        /// Create an Invoice if there are outstanding charges on an account. If there are no outstanding
        /// charges, null is returned.
        /// </summary>
        /// <param name="accountCode">Account code</param>
        /// <returns></returns>
        public static Invoice Create(string accountCode)
        {
            var invoice = new Invoice();

            var statusCode = Client.PerformRequest(Client.HttpRequestMethod.Post,
                "/accounts/" + Uri.EscapeUriString(accountCode) + UrlPrefix,
                invoice.ReadXml);

            return (int)statusCode == ValidationException.HttpStatusCode ? null : invoice;
        }

        /// <summary>
        /// Returns the active coupon redemption on this invoice
        /// </summary>
        /// <returns></returns>
        public CouponRedemption GetCoupon()
        {
            var cr = new CouponRedemption();

            var statusCode = Client.PerformRequest(Client.HttpRequestMethod.Get,
                UrlPrefix + InvoiceNumber + "/redemption",
                cr.ReadXml);

            return statusCode == HttpStatusCode.NotFound ? null : cr;
        }


        #region Read and Write XML documents

        internal void ReadXml(XmlTextReader reader)
        {
            while (reader.Read())
            {
                // End of invoice element, get out of here
                if (reader.Name == "invoice" && reader.NodeType == XmlNodeType.EndElement)
                    break;

                if (reader.NodeType != XmlNodeType.Element) continue;

                switch (reader.Name)
                {
                    case "account":
                        var href = reader.GetAttribute("href");
                        AccountCode = Uri.UnescapeDataString(href.Substring(href.LastIndexOf("/") + 1));
                        break;

                    case "uuid":
                        Uuid = reader.ReadElementContentAsString();
                        break;

                    case "state":
                        State = reader.ReadElementContentAsString().ParseAsEnum<InvoiceState>();
                        break;

                    case "invoice_number":
                        int invNumber;
                        if (Int32.TryParse(reader.ReadElementContentAsString(), out invNumber))
                            InvoiceNumber = invNumber;
                        break;

                    case "po_number":
                        PONumber = reader.ReadElementContentAsString();
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
                        CreatedAt = reader.ReadElementContentAsDateTime();
                        break;

                    case "line_items":
                        Adjustments.ReadXml(reader);
                        break;

                    case "transactions":
                        Transactions.ReadXml(reader);
                        break;

                }
            }
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
            return Uuid.GetHashCode();
        }

        #endregion
    }
}
