using System.Xml;

namespace Recurly
{
    public class InvoiceList : RecurlyList<IInvoice>
    {

        internal InvoiceList()
        {

        }

        internal InvoiceList(string baseUrl)
            : base(Client.HttpRequestMethod.Get, baseUrl)
        {
        }

        public override IRecurlyList<IInvoice> Start
        {
            get { return HasStartPage() ? new InvoiceList(StartUrl) : RecurlyList.Empty<IInvoice>(); }
        }

        public override IRecurlyList<IInvoice> Next
        {
            get { return HasNextPage() ? new InvoiceList(NextUrl) : RecurlyList.Empty<IInvoice>(); }
        }

        public override IRecurlyList<IInvoice> Prev
        {
            get { return HasPrevPage() ? new InvoiceList(PrevUrl) : RecurlyList.Empty<IInvoice>(); }
        }

        internal override void ReadXml(XmlTextReader reader)
        {
            ReadXml(reader, "invoices", "invoice");
        }

        internal void ReadXml(XmlTextReader reader, string listName, string elementName)
        {

            while (reader.Read())
            {
                if (reader.Name == listName && reader.NodeType == XmlNodeType.EndElement)
                    break;

                if (reader.NodeType == XmlNodeType.Element && reader.Name == elementName)
                {
                    Add(new Invoice(reader));
                }
            }

        }
    }

}