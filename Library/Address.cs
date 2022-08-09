﻿using System.Xml;

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

            if (FirstName != null)
                xmlWriter.WriteElementString("first_name", FirstName);
            if (LastName != null)
                xmlWriter.WriteElementString("last_name", LastName);
            if (NameOnAccount != null)
                xmlWriter.WriteElementString("name_on_account", NameOnAccount);
            if (Company != null)
                xmlWriter.WriteElementString("company", Company);
            if (Address1 != null)
                xmlWriter.WriteElementString("address1", Address1);
            if (Address2 != null)
                xmlWriter.WriteElementString("address2", Address2);
            if (City != null)
                xmlWriter.WriteElementString("city", City);
            if (State != null)
                xmlWriter.WriteElementString("state", State);
            if (Zip != null)
                xmlWriter.WriteElementString("zip", Zip);
            if (Country != null)
                xmlWriter.WriteElementString("country", Country);
            if (Phone != null)
                xmlWriter.WriteElementString("phone", Phone);

            xmlWriter.WriteEndElement();
        }

        public bool Equals(object that)
        {
            if (null == that)
                return false;
            if (object.ReferenceEquals(this, that))
                return true;
            if (this.GetType() != that.GetType())
                return false;
            return this.CompareMembers(that as Address);
        }

        private bool CompareMembers(Address that)
        {
            if (this.FirstName != that.FirstName) return false;
            if (this.LastName != that.LastName) return false;
            if (this.NameOnAccount != that.NameOnAccount) return false;
            if (this.Company != that.Company) return false;
            if (this.Address1 != that.Address1) return false;
            if (this.Address2 != that.Address2) return false;
            if (this.City != that.City) return false;
            if (this.State != that.State) return false;
            if (this.Zip != that.Zip) return false;
            if (this.Country != that.Country) return false;
            if (this.Phone != that.Phone) return false;
            return true;
        }

        public virtual object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
