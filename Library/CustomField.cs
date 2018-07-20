using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Recurly
{
    public class CustomField : RecurlyEntity
    {
        public string Name;
        public string Value;

        public CustomField() { }

        public CustomField(string name, string value)
        {
            Name = name;
            Value = value;
        }

        internal CustomField(XmlTextReader reader) : this()
        {
            ReadXml(reader);
        }

        internal override void ReadXml(XmlTextReader reader)
        {
            while (reader.Read())
            {
                // End of custom_field element, get out of here
                if (reader.Name == "custom_field" && reader.NodeType == XmlNodeType.EndElement)
                    break;

                if (reader.NodeType != XmlNodeType.Element) continue;

                switch (reader.Name)
                {
                    case "name":
                        Name = reader.ReadElementContentAsString();
                        break;
                    case "value":
                        Value = reader.ReadElementContentAsString();
                        break;
                }
            }
        }

        internal override void WriteXml(XmlTextWriter xmlWriter)
        {
            xmlWriter.WriteStartElement("custom_field");

            xmlWriter.WriteElementString("name", Name);
            xmlWriter.WriteElementString("value", Value);

            xmlWriter.WriteEndElement();
        }
    }
}
