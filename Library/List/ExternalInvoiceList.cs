using System.Xml;

namespace Recurly
{
    public class ExternalInvoiceList : RecurlyList<ExternalInvoice>
    {
        internal ExternalInvoiceList(string baseUrl) : base(Client.HttpRequestMethod.Get, baseUrl)
        {
        }

        internal ExternalInvoiceList()
        {
        }
        public override RecurlyList<ExternalInvoice> Start
        {
            get { return HasStartPage() ? new ExternalInvoiceList(StartUrl) : RecurlyList.Empty<ExternalInvoice>(); }
        }

        public override RecurlyList<ExternalInvoice> Next
        {
            get { return HasNextPage() ? new ExternalInvoiceList(NextUrl) : RecurlyList.Empty<ExternalInvoice>(); }
        }

        public override RecurlyList<ExternalInvoice> Prev
        {
            get { return HasPrevPage() ? new ExternalInvoiceList(PrevUrl) : RecurlyList.Empty<ExternalInvoice>(); }
        }

        internal override void ReadXml(XmlTextReader reader)
        {
            while (reader.Read())
            {
                if (reader.Name == "external_invoices" && reader.NodeType == XmlNodeType.EndElement)
                    break;

                if (reader.NodeType == XmlNodeType.Element && reader.Name == "external_invoice")
                {
                    Add(new ExternalInvoice(reader));
                }
            }
        }
    }
}