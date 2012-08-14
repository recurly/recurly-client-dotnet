using System;
using System.Collections.Generic;
using System.Net;
using System.Xml;
using System.Text;

namespace Recurly
{
    public class RecurlyInvoiceList : List<Invoice>
    {
        internal RecurlyInvoiceList()
        { }

        private const string UrlPostfix = "/invoices";

        public static Invoice[] GetInvoices(string accountCode, int pageNumber = 1)
        {
            RecurlyInvoiceList invoiceList = new RecurlyInvoiceList();

            HttpStatusCode statusCode = Client.PerformRequest(Client.HttpRequestMethod.Get,
                AccountInvoicesUrl(accountCode, pageNumber),
                new Client.ReadXmlDelegate(invoiceList.ReadXml)).StatusCode;

            if (statusCode == HttpStatusCode.NotFound)
                return null;

            return invoiceList.ToArray();
        }

        private static string AccountInvoicesUrl(string accountCode, int pageNumber)
        {
            return Account.UrlPrefix + System.Web.HttpUtility.UrlEncode(accountCode) + UrlPostfix + "?page=" + pageNumber;
        }

        internal void ReadXml(XmlTextReader reader)
        {
            while (reader.Read())
            {
                // End of invoices element, get out of here
                if (reader.Name == "invoices" && reader.NodeType == XmlNodeType.EndElement)
                    break;

                if (reader.NodeType == XmlNodeType.Element)
                {
                    switch (reader.Name)
                    {
                        case "invoice":
                            this.Add(new Invoice(reader));
                            break;
                    }
                }
            }
        }
    }
}
