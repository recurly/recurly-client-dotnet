using System;
using System.Collections.Generic;
using System.Net;
using System.Xml;

namespace Recurly
{

    public class DunningInterval : RecurlyEntity
    {
        public int Days { get; set; }

        public string EmailTemplate { get; set; }

        internal DunningInterval()
        {
        }

        internal DunningInterval(XmlTextReader reader) : this()
        {
            ReadXml(reader);
        }

        internal override void ReadXml(XmlTextReader reader)
        {
            while (reader.Read())
            {
                if (reader.Name == "interval" && reader.NodeType == XmlNodeType.EndElement)
                    break;

                if (reader.NodeType != XmlNodeType.Element) continue;

                switch (reader.Name)
                {
                    case "days":
                        Days = reader.ReadElementContentAsInt();
                        break;
                    case "email_template":
                        EmailTemplate = reader.ReadElementContentAsString();
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
