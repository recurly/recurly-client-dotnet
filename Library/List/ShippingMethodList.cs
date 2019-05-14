using System;
using System.Collections.Specialized;
using System.Net;
using System.Web;
using System.Xml;

namespace Recurly
{
    public class ShippingMethodList : RecurlyList<ShippingMethod>
    {
        internal ShippingMethodList()
        {
        }

        internal ShippingMethodList(string baseUrl) : base(Client.HttpRequestMethod.Get, baseUrl)
        {
        }

        public override RecurlyList<ShippingMethod> Start
        {
            get { return HasStartPage() ? new ShippingMethodList(StartUrl) : RecurlyList.Empty<ShippingMethod>(); }
        }

        public override RecurlyList<ShippingMethod> Next
        {
            get { return HasNextPage() ? new ShippingMethodList(NextUrl) : RecurlyList.Empty<ShippingMethod>(); }
        }

        public override RecurlyList<ShippingMethod> Prev
        {
            get { return HasPrevPage() ? new ShippingMethodList(PrevUrl) : RecurlyList.Empty<ShippingMethod>(); }
        }

        internal override void ReadXml(XmlTextReader reader)
        {
            while (reader.Read())
            {
                if ((reader.Name == "shipping_methods") && reader.NodeType == XmlNodeType.EndElement)
                    break;

                if (reader.NodeType == XmlNodeType.Element && reader.Name == "shipping_method")
                {
                    Add(new ShippingMethod(reader));
                }
            }
        }

        public void ReadFromLocation(HttpWebResponse response)
        {
            var url = new Uri(response.Headers["Location"]);
            NameValueCollection qscoll = HttpUtility.ParseQueryString(url.Query);
            PerPage = int.Parse(qscoll.Get("per_page"));

            BaseUrl = url.Scheme + "://" + url.Host + ":" + url.Port + url.AbsolutePath + "?cursor=" + qscoll.Get("cursor");

            GetItems();
        }
    }
}
