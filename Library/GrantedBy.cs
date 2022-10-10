using System;
using System.Collections.Generic;
using System.Net;
using System.Xml;

namespace Recurly
{
    /// <summary>
    /// Subscriptions and Items granting a Customer Permission in Recurly.
    ///
    /// </summary>
    public class GrantedBy : RecurlyEntity
    {
        internal GrantedBy()
        {
        }

        internal GrantedBy(XmlTextReader reader) : this()
        {
            ReadXml(reader);
        }

        internal override void ReadXml(XmlTextReader reader)
        {
        }

        internal override void WriteXml(XmlTextWriter writer)
        {

            throw new NotImplementedException();
        }
    }
}
