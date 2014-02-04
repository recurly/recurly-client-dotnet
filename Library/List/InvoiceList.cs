using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Net;

namespace Recurly
{
    public class InvoiceList : RecurlyList<Invoice>
    {

        internal InvoiceList(string baseUrl)
            : base(Client.HttpRequestMethod.Get, baseUrl)
        {
        }

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
            return new InvoiceList("/accounts/" + System.Uri.EscapeUriString(accountCode) + "/invoices");
        }

        public static InvoiceList GetInvoices()
        {
            return new InvoiceList(Invoice.UrlPrefix);
        }

        public static InvoiceList GetInvoices(Invoice.InvoiceState state)
        {
            return new InvoiceList(Invoice.UrlPrefix + "?state=" + state.ToString().EnumNameToTransportCase());
        }
    }

}