using System;
using System.Collections.Generic;
using System.Net;
using System.Xml;
using System.Text;

namespace Recurly
{
    public class RecurlyInvoiceList : List<RecurlyInvoice>
    {
        internal RecurlyInvoiceList()
        { }

        private const string UrlPostfix = "/invoices";

        public static RecurlyInvoice[] GetInvoices(string accountCode, int pageNumber = 1)
        {
            RecurlyInvoiceList invoiceList = new RecurlyInvoiceList();

            HttpStatusCode statusCode = RecurlyClient.PerformRequest(RecurlyClient.HttpRequestMethod.Get,
                AccountInvoicesUrl(accountCode, pageNumber),
                new RecurlyClient.ReadXmlDelegate(invoiceList.ReadXml));

            if (statusCode == HttpStatusCode.NotFound)
                return null;

            return invoiceList.ToArray();
        }

        private static string AccountInvoicesUrl(string accountCode, int pageNumber)
        {
            return RecurlyAccount.UrlPrefix + System.Web.HttpUtility.UrlEncode(accountCode) + UrlPostfix + "?page=" + pageNumber;
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
                            this.Add(new RecurlyInvoice(reader));
                            break;
                    }
                }
            }
        }
    }
}