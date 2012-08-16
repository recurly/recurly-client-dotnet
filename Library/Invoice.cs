using System;
using System.Collections.Generic;
using System.Net;
using System.Xml;
using System.Text;
using System.Diagnostics;

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
            Past_Due
        }

        public string AccountCode { get; private set; }
        public string UUID { get; protected set; }
        public InvoiceState State { get; protected set; }
        public int InvoiceNumber { get; private set; }
        public string PONumber { get; private set; }
        public string VatNumber { get; private set; }
        public int SubtotalInCents { get; private set; }
        public int TaxInCents {get; protected set; }
        public int TotalInCents { get; protected set; }
        public string Currency { get; protected set; }
        public DateTime CreatedAt { get; private set; }
        
        public RecurlyList<Adjustment> Adjustments { get; private set; }
        public RecurlyList<Transaction> Transactions { get; private set; }

        private const string UrlPrefix = "/invoices/";

        internal Invoice()
        {
            Adjustments = new RecurlyList<Adjustment>();
            Transactions = new RecurlyList<Transaction>();
        }

        internal Invoice(XmlTextReader reader)
            : this()
        {
            ReadXml(reader);
        }

        /// <summary>
        /// Look up an Invoice.
        /// </summary>
        /// <param name="invoiceId">Invoice ID</param>
        /// <returns></returns>
        public static Invoice Get(string invoiceId)
        {
            Invoice invoice = new Invoice();

            HttpStatusCode statusCode = Client.PerformRequest(Client.HttpRequestMethod.Get,
                UrlPrefix + System.Web.HttpUtility.UrlEncode(invoiceId),
                new Client.ReadXmlDelegate(invoice.ReadXml)).StatusCode;

            if (statusCode == HttpStatusCode.NotFound)
                return null;

            return invoice;
        }

        /// <summary>
        /// Returns a PDF representation of an invoice
        /// </summary>
        /// <param name="invoiceId"></param>
        /// <returns></returns>
        public static byte[] GetPdf(string invoiceId, string acceptLanguage )
        {
             return Client.PerformDownloadRequest(UrlPrefix + System.Web.HttpUtility.UrlEncode(invoiceId),
                "application/pdf", acceptLanguage);
        }


        internal static RecurlyList<Invoice> GetInvoices(string accountCode)
        {
            RecurlyList<Invoice> list = new RecurlyList<Invoice>();

            HttpStatusCode statusCode = Client.PerformRequest(Client.HttpRequestMethod.Get,
                UrlPrefix + System.Web.HttpUtility.UrlEncode(accountCode),
                new Client.ReadXmlDelegate(list.ReadXml)).StatusCode;

            return list;
        }

        /// <summary>
        /// Posts pending charges on an account
        /// </summary>
        public static void InvoicePendingCharges(string accountCode)
        {
            Client.PerformRequest(Client.HttpRequestMethod.Post,
                UrlPrefix + System.Web.HttpUtility.UrlEncode(accountCode) + "/invoices"
               );
        }

        /// <summary>
        /// Marks an invoice as paid successfully
        /// </summary>
        public void MarkSuccessful()
        {
            Client.PerformRequest(Client.HttpRequestMethod.Put,
                UrlPrefix + System.Web.HttpUtility.UrlEncode(InvoiceNumber.ToString()) + "/mark_successful"
               );
        }

        /// <summary>
        /// Marks an invoice as failed collection
        /// </summary>
        public void MarkFailed()
        {
            Client.PerformRequest(Client.HttpRequestMethod.Put,
               UrlPrefix + System.Web.HttpUtility.UrlEncode(InvoiceNumber.ToString()) + "/mark_failed"
              );
        }

        /// <summary>
        /// Create an Invoice if there are outstanding charges on an account. If there are no outstanding
        /// charges, null is returned.
        /// </summary>
        /// <param name="accountCode">Account code</param>
        /// <returns></returns>
        public static Invoice Create(string accountCode)
        {   
            Invoice invoice = new Invoice();

            HttpStatusCode statusCode = Client.PerformRequest(Client.HttpRequestMethod.Post,
                "/accounts/" + System.Web.HttpUtility.UrlEncode(accountCode) + UrlPrefix,
                new Client.ReadXmlDelegate(invoice.ReadXml)).StatusCode;

            if ((int)statusCode == ValidationException.HttpStatusCode)
                return null;

            return invoice;
        }

        #region Read and Write XML documents

        internal void ReadXml(XmlTextReader reader)
        {
            while (reader.Read())
            {
                // End of invoice element, get out of here
                if (reader.Name == "invoice" && reader.NodeType == XmlNodeType.EndElement)
                    break;

                if (reader.NodeType == XmlNodeType.Element)
                {
                    switch (reader.Name)
                    {
                        case "account":
                            string href = reader.GetAttribute("href");
                            this.AccountCode = href.Substring(href.LastIndexOf("/") + 1);
                            break;

                        case "uuid":
                            this.UUID = reader.ReadElementContentAsString();
                            break;

                        case "state":
                            this.State = (InvoiceState)Enum.Parse(typeof(InvoiceState), reader.ReadElementContentAsString(), true);
                            break;

                        case "invoice_number":
                            int invNumber;
                            if (Int32.TryParse(reader.ReadElementContentAsString(), out invNumber))
                                this.InvoiceNumber = invNumber;
                            break;

                        case "po_number":
                            this.PONumber = reader.ReadElementContentAsString();
                            break;

                        case "vat_number":
                            this.VatNumber = reader.ReadElementContentAsString();
                            break;

                        case "subtotal_in_cents":
                            this.SubtotalInCents = reader.ReadElementContentAsInt();
                            break;

                        case "tax_in_cents":
                            this.TaxInCents = reader.ReadElementContentAsInt();
                            break;

                        case "total_in_cents":
                            this.TotalInCents = reader.ReadElementContentAsInt();
                            break;

                        case "currency":
                            this.Currency = reader.ReadElementContentAsString();
                            break;

                        case "created_at":
                            this.CreatedAt = reader.ReadElementContentAsDateTime();
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
        }

        #endregion

        #region Object Overrides

        public override string ToString()
        {
            return "Recurly Invoice: " + this.UUID;
        }

        public override bool Equals(object obj)
        {
            if (obj is Invoice)
                return Equals((Invoice)obj);
            else
                return false;
        }

        public bool Equals(Invoice invoice)
        {
            return this.UUID == invoice.UUID;
        }

        public override int GetHashCode()
        {
            return this.UUID.GetHashCode();
        }

        #endregion
    }
}
