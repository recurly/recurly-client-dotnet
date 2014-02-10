using System.Xml;

namespace Recurly
{
    public class InvoiceList : RecurlyList<Invoice>
    {

        internal InvoiceList(string baseUrl)
            : base(Client.HttpRequestMethod.Get, baseUrl)
        {
        }

        public override RecurlyList<Invoice> Start
        {
            get { return new InvoiceList(StartUrl); }
        }

        public override RecurlyList<Invoice> Next
        {
            get { return new InvoiceList(NextUrl); }
        }

        public override RecurlyList<Invoice> Prev
        {
            get { return new InvoiceList(PrevUrl); }
        }

        internal override void ReadXml(XmlTextReader reader)
        {

            while (reader.Read())
            {
                if (reader.Name == "invoices" && reader.NodeType == XmlNodeType.EndElement)
                    break;

                if (reader.NodeType == XmlNodeType.Element)
                {
                    Add(new Invoice(reader));
                    break;
                }
            }

        }
    }

}