using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Recurly
{
    public class ShippingAddress : RecurlyEntity, IShippingAddress
    {
        public long? Id { get; private set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string VatNumber { get; set; }
        public string Nickname { get; set; }
        public string Email { get; set; }
        public string CompanyName { get; set; }

        internal ShippingAddress(XmlTextReader reader)
        {
            ReadXml(reader);
        }

        public ShippingAddress() { }

        internal static void ReadXml(XmlTextReader reader, IShippingAddress address)
        {
            var recurlyAddress = address as ShippingAddress;
            if (recurlyAddress != null)
                recurlyAddress.ReadXml(reader);
        }

        internal override void ReadXml(XmlTextReader reader)
        {
            while (reader.Read())
            {
                if (reader.Name == "shipping_address" && reader.NodeType == XmlNodeType.EndElement)
                    break;

                if (reader.NodeType != XmlNodeType.Element) continue;

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

                    case "company_name":
                        CompanyName = reader.ReadElementContentAsString();
                        break;

                    case "first_name":
                        FirstName = reader.ReadElementContentAsString();
                        break;

                    case "last_name":
                        LastName = reader.ReadElementContentAsString();
                        break;

                    case "nickname":
                        Nickname = reader.ReadElementContentAsString();
                        break;

                    case "email":
                        Email = reader.ReadElementContentAsString();
                        break;

                    case "vat_number":
                        VatNumber = reader.ReadElementContentAsString();
                        break;

                    case "id":
                        Id = reader.ReadElementContentAsLong();
                        break;
                }
            }
        }

        internal static void WriteXml(XmlTextWriter xmlWriter, IShippingAddress address)
        {
            xmlWriter.WriteStartElement("shipping_address");

            xmlWriter.WriteElementString("address1", address.Address1);
            xmlWriter.WriteElementString("address2", address.Address2);
            xmlWriter.WriteElementString("city", address.City);
            xmlWriter.WriteElementString("state", address.State);
            xmlWriter.WriteElementString("zip", address.Zip);
            xmlWriter.WriteElementString("country", address.Country);
            xmlWriter.WriteElementString("phone", address.Phone);
            xmlWriter.WriteElementString("first_name", address.FirstName);
            xmlWriter.WriteElementString("last_name", address.LastName);
            xmlWriter.WriteElementString("vat_number", address.VatNumber);
            xmlWriter.WriteElementString("nickname", address.Nickname);
            xmlWriter.WriteElementString("email", address.Email);

            xmlWriter.WriteEndElement();
        }

        internal override void WriteXml(XmlTextWriter xmlWriter)
        {
            WriteXml(xmlWriter, this);
        }
    }
}
