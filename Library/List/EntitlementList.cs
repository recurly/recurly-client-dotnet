using System;
using System.Collections.Specialized;
using System.Net;
using System.Web;
using System.Xml;

namespace Recurly
{
    public class EntitlementList : RecurlyList<Entitlement>
    {
        internal EntitlementList(string baseUrl) : base(Client.HttpRequestMethod.Get, baseUrl)
        {
        }

        public override RecurlyList<Entitlement> Start
        {
            get { return HasStartPage() ? new EntitlementList(StartUrl) : RecurlyList.Empty<Entitlement>(); }
        }

        public override RecurlyList<Entitlement> Next
        {
            get { return HasNextPage() ? new EntitlementList(NextUrl) : RecurlyList.Empty<Entitlement>(); }
        }

        public override RecurlyList<Entitlement> Prev
        {
            get { return HasPrevPage() ? new EntitlementList(PrevUrl) : RecurlyList.Empty<Entitlement>(); }
        }

        public override bool includeEmptyTag()
        {
            return true;
        }

        internal override void ReadXml(XmlTextReader reader)
        {
            while (reader.Read())
            {
                if (reader.Name == "entitlements" && reader.NodeType == XmlNodeType.EndElement)
                    break;

                if (reader.NodeType == XmlNodeType.Element && reader.Name == "entitlement")
                {
                    Add(new Entitlement(reader));
                }
            }
        }
    }
}
