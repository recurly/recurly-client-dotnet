using System;
using System.Xml;

namespace Recurly
{
    public class InvoiceDisplayAddress : RecurlyEntity
    {
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }

        internal InvoiceDisplayAddress(XmlTextReader reader)
        {
            ReadXml(reader);
        }

        public InvoiceDisplayAddress() { }

        internal override void ReadXml(XmlTextReader reader)
        {
            while (reader.Read())
            {
                if (reader.Name == "invoice_display_address" && reader.NodeType == XmlNodeType.EndElement)
                    break;

                if (reader.NodeType != XmlNodeType.Element)
                    continue;

                switch (reader.Name)
                {
                    case "address1":
                        Address1 = reader.ReadElementContentAsString();
                        break;
                    case "address2":
                        Address2 = reader.ReadElementContentAsString();
                        break;
                    case "city":
                        City = reader.ReadElementContentAsString();
                        break;
                    case "state":
                        State = reader.ReadElementContentAsString();
                        break;
                    case "zip":
                        Zip = reader.ReadElementContentAsString();
                        break;
                    case "country":
                        Country = reader.ReadElementContentAsString();
                        break;
                    case "phone":
                        Phone = reader.ReadElementContentAsString();
                        break;
                }
            }
        }

        internal override void WriteXml(XmlTextWriter writer)
        {
            throw new NotImplementedException();
        }
    }
}
