using System.Xml;

namespace Recurly
{
    public class InvoiceList : RecurlyList<Invoice>
    {

        internal InvoiceList()
        {

        }

        internal InvoiceList(string baseUrl)
            : base(Client.HttpRequestMethod.Get, baseUrl)
        {
        }

        public override RecurlyList<Invoice> Start
        {
            get { return HasStartPage() ? new InvoiceList(StartUrl) : RecurlyList.Empty<Invoice>(); }
        }

        public override RecurlyList<Invoice> Next
        {
            get { return HasNextPage() ? new InvoiceList(NextUrl) : RecurlyList.Empty<Invoice>(); }
        }

        public override RecurlyList<Invoice> Prev
        {
            get { return HasPrevPage() ? new InvoiceList(PrevUrl) : RecurlyList.Empty<Invoice>(); }
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