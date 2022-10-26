using System;
using System.Collections.Generic;
using System.Net;
using System.Xml;

namespace Recurly
{

    /// <summary>
    /// A Customer Permission in Recurly.
    /// </summary>
    public class CustomerPermission : RecurlyEntity
    {
        public string Id { get; private set; }

        public string Code { get; private set; }

        public string Name { get; private set; }

        public string Description { get; private set; }

        internal CustomerPermission() { }

        internal CustomerPermission(XmlTextReader reader) : this()
        {
            ReadXml(reader);
        }

        internal override void ReadXml(XmlTextReader reader)
        {
            while (reader.Read())
            {
                if (reader.Name == "customer_permission" && reader.NodeType == XmlNodeType.EndElement)
                    break;

                if (reader.NodeType != XmlNodeType.Element) continue;

                switch (reader.Name)
                {
                    case "id":
                        Id = reader.ReadElementContentAsString();
                        break;

                    case "code":
                        Code = reader.ReadElementContentAsString();
                        break;

                    case "name":
                        Name = reader.ReadElementContentAsString();
                        break;

                    case "description":
                        Description = reader.ReadElementContentAsString();
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
