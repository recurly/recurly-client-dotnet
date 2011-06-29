using System;
using System.Collections.Generic;
using System.Net;
using System.Xml;
using System.Text;

namespace Recurly
{
    public class RecurlyInvoice
    {
        public string Id { get; private set; }
        public string AccountCode { get; private set; }
        public DateTime Date { get; private set; }
        public int Number { get; private set; }
        public RecurlyLineItemList LineItems { get; private set; }
        public RecurlyTransactionList Payments { get; private set; }

        private const string UrlPrefix = "/invoices/";

        internal RecurlyInvoice()
        {
            LineItems = new RecurlyLineItemList();
            Payments = new RecurlyTransactionList();
        }

        internal RecurlyInvoice(XmlTextReader reader) : this()
        {
            ReadXml(reader);
        }

        /// <summary>
        /// Look up an Invoice.
        /// </summary>
        /// <param name="invoiceId">Invoice ID</param>
        /// <returns></returns>
        public static RecurlyInvoice Get(string invoiceId)
        {
            RecurlyInvoice invoice = new RecurlyInvoice();

            HttpStatusCode statusCode = RecurlyClient.PerformRequest(RecurlyClient.HttpRequestMethod.Get,
                UrlPrefix + System.Web.HttpUtility.UrlEncode(invoiceId),
                new RecurlyClient.ReadXmlDelegate(invoice.ReadXml));

            if (statusCode == HttpStatusCode.NotFound)
                return null;

            return invoice;
        }

        /// <summary>
        /// Create an Invoice if there are outstanding charges on an account. If there are no outstanding
        /// charges, null is returned.
        /// </summary>
        /// <param name="accountCode">Account code</param>
        /// <returns></returns>
        public static RecurlyInvoice Create(string accountCode)
        {
            RecurlyInvoice invoice = new RecurlyInvoice();

            HttpStatusCode statusCode = RecurlyClient.PerformRequest(RecurlyClient.HttpRequestMethod.Post,
                "/accounts/" + System.Web.HttpUtility.UrlEncode(accountCode) + UrlPrefix,
                new RecurlyClient.ReadXmlDelegate(invoice.ReadXml));

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
                        case "id":
                            this.Id = reader.ReadElementContentAsString();
                            break;

                        case "account_code":
                            this.AccountCode = reader.ReadElementContentAsString();
                            break;

                        case "date":
                            DateTime date;
                            if (DateTime.TryParse(reader.ReadElementContentAsString(), out date))
                                this.Date = date;
                            break;

                        case "invoice_number":
                            int invNumber;
                            if (Int32.TryParse(reader.ReadElementContentAsString(), out invNumber))
                                this.Number = invNumber;
                            break;

                        case "line_items":
                            LineItems.ReadXml(reader);
                            break;

                        case "payments":
                            Payments.ReadXml(reader);
                            break;
                    }
                }
            }
        }

        #endregion

        #region Object Overrides

        public override string ToString()
        {
            return "Recurly Invoice: " + this.Id;
        }

        public override bool Equals(object obj)
        {
            if (obj is RecurlyInvoice)
                return Equals((RecurlyInvoice)obj);
            else
                return false;
        }

        public bool Equals(RecurlyInvoice invoice)
        {
            return this.Id == invoice.Id;
        }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }

        #endregion
    }
}