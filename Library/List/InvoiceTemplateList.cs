using System;
using System.Collections.Specialized;
using System.Net;
using System.Web;
using System.Xml;

namespace Recurly
{
    public class InvoiceTemplateList : RecurlyList<InvoiceTemplate>
    {
        internal InvoiceTemplateList()
        {
        }

        internal InvoiceTemplateList(string baseUrl) : base(Client.HttpRequestMethod.Get, baseUrl)
        {
        }

        public override RecurlyList<InvoiceTemplate> Start
        {
            get { return HasStartPage() ? new InvoiceTemplateList(StartUrl) : RecurlyList.Empty<InvoiceTemplate>(); }
        }

        public override RecurlyList<InvoiceTemplate> Next
        {
            get { return HasNextPage() ? new InvoiceTemplateList(NextUrl) : RecurlyList.Empty<InvoiceTemplate>(); }
        }

        public override RecurlyList<InvoiceTemplate> Prev
        {
            get { return HasPrevPage() ? new InvoiceTemplateList(PrevUrl) : RecurlyList.Empty<InvoiceTemplate>(); }
        }

        internal override void ReadXml(XmlTextReader reader)
        {
            while (reader.Read())
            {
                if (reader.Name == "invoice_templates" && reader.NodeType == XmlNodeType.EndElement)
                    break;

                if (reader.NodeType == XmlNodeType.Element && reader.Name == "invoice_template")
                {
                    Add(new InvoiceTemplate(reader));
                }
            }
        }
    }
}
