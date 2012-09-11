using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Net;

namespace Recurly
{
    public class InvoiceList : RecurlyList<Invoice>
    {

        internal void ReadXml(XmlTextReader reader)
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
            HttpStatusCode statusCode = Client.PerformRequest(Client.HttpRequestMethod.Get,
                Invoice.UrlPrefix + System.Uri.EscapeUriString(accountCode),
                new Client.ReadXmlDelegate(list.ReadXml)).StatusCode;

            return list;
        }

    }

}