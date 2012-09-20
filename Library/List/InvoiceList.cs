using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Net;

namespace Recurly
{
    public class InvoiceList : RecurlyList<Invoice>
    {

        internal override void ReadXml(XmlTextReader reader)
        {

            while (reader.Read())
            {
                if (reader.Name.Equals("invoices") &&
                    reader.NodeType == XmlNodeType.EndElement)
                    break;

                if (reader.NodeType == XmlNodeType.Element)
                {
                    this.Add(new Invoice(reader));
                    break;
                }
            }

        }

        public static InvoiceList GetInvoices(string accountCode)
        {
            InvoiceList list = new InvoiceList();
            list.BaseUrl = "/accounts/" + System.Uri.EscapeUriString(accountCode) + "/invoices";
            HttpStatusCode statusCode = Client.PerformRequest(Client.HttpRequestMethod.Get, list.BaseUrl, new Client.ReadXmlListDelegate(list.ReadXmlList));

            return list;
        }

        public static InvoiceList GetInvoices()
        {
            InvoiceList list = new InvoiceList();
            list.BaseUrl = Invoice.UrlPrefix;
            HttpStatusCode statusCode = Client.PerformRequest(Client.HttpRequestMethod.Get, list.BaseUrl, new Client.ReadXmlListDelegate(list.ReadXmlList));

            return list;
        }

        public static InvoiceList GetInvoices(Invoice.InvoiceState state)
        {
            InvoiceList list = new InvoiceList();
            list.BaseUrl = Invoice.UrlPrefix + "?state=" + state.ToString();
            HttpStatusCode statusCode = Client.PerformRequest(Client.HttpRequestMethod.Get, list.BaseUrl, new Client.ReadXmlListDelegate(list.ReadXmlList));

            return list;
        }
    }

}