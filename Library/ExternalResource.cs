using System;
using System.Collections.Generic;
using System.Net;
using System.Xml;

namespace Recurly
{

    /// <summary>
    /// An external resource in Recurly.
    ///
    /// </summary>
    public class ExternalResource : RecurlyEntity
    {
        public string ExternalObjectReference { get; set; }

        internal ExternalResource()
        {
        }

        internal ExternalResource(XmlTextReader reader)
        {
            ReadXml(reader);
        }

        internal override void ReadXml(XmlTextReader reader)
        {
            while (reader.Read())
            {
                if (reader.Name == "external_resource" && reader.NodeType == XmlNodeType.EndElement)
                    break;

                if (reader.NodeType != XmlNodeType.Element) continue;

                switch (reader.Name)
                {
                    case "external_object_reference":
                        ExternalObjectReference = reader.ReadElementContentAsString();
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
