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

        public static RecurlyInvoice[] GetInvoices(string accountCode)
        {
            RecurlyInvoiceList invoiceList = new RecurlyInvoiceList();

            HttpStatusCode statusCode = RecurlyClient.PerformRequest(RecurlyClient.HttpRequestMethod.Get,
                RecurlyCharge.ChargesUrl(accountCode),
                new RecurlyClient.ReadXmlDelegate(invoiceList.ReadXml));

            if (statusCode == HttpStatusCode.NotFound)
                return null;

            return invoiceList.ToArray();
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