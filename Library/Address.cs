using System.Xml;

namespace Recurly
{
    public class Address : RecurlyEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NameOnAccount { get; set; }
        public string Company { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }

        internal Address(XmlTextReader reader)
        {
            ReadXml(reader);
        }

        public Address() { }

        internal override void ReadXml(XmlTextReader reader)
        {
            while (reader.Read())
            {
                if (reader.Name == "address" && reader.NodeType == XmlNodeType.EndElement)
                    break;

                if (reader.NodeType != XmlNodeType.Element) continue;

                switch (reader.Name)
                {
                    case "first_name":
                        FirstName = reader.ReadElementContentAsString();
                        break;

                    case "last_name":
                        LastName = reader.ReadElementContentAsString();
                        break;

                    case "name_on_account":
                        NameOnAccount = reader.ReadElementContentAsString();
                        break;

                    case "company":
                        Company = reader.ReadElementContentAsString();
                        break;

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

        internal override void WriteXml(XmlTextWriter xmlWriter)
        {
            xmlWriter.WriteStartElement("address");

            xmlWriter.WriteElementString("first_name", FirstName);
            xmlWriter.WriteElementString("last_name", LastName);
            xmlWriter.WriteElementString("name_on_account", NameOnAccount);
            xmlWriter.WriteElementString("company", Company);
            xmlWriter.WriteElementString("address1", Address1);
            xmlWriter.WriteElementString("address2", Address2);
            xmlWriter.WriteElementString("city", City);
            xmlWriter.WriteElementString("state", State);
            xmlWriter.WriteElementString("zip", Zip);
            xmlWriter.WriteElementString("country", Country);
            xmlWriter.WriteElementString("phone", Phone);

            xmlWriter.WriteEndElement();
        }
    }
}
