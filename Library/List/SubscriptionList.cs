using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Net;

namespace Recurly
{
    public class SubscriptionList : RecurlyList<Subscription>
    {

        internal void ReadXml(XmlTextReader reader)
        {

            while (reader.Read())
            {
                if (reader.Name.Equals("subscriptions") &&
                    reader.NodeType == XmlNodeType.EndElement)
                    break;

                if (reader.NodeType == XmlNodeType.Element)
                {
                    this.Add(new Subscription(reader));
                }
            }

        }

        /// <summary>
        /// Returns a list of recurly subscriptions
        /// 
        /// A subscription will belong to more than one state.
        /// </summary>
        /// <param name="state">State of subscriptions to return, defaults to "live"</param>
        /// <returns></returns>
        public static SubscriptionList GetSubscriptions(Subscription.SubstriptionState state = Subscription.SubstriptionState.Live)
        {
            SubscriptionList l = new SubscriptionList();
            HttpStatusCode statusCode = Client.PerformRequest(Client.HttpRequestMethod.Get,
                Subscription.UrlPrefix + "?state=" + System.Uri.EscapeUriString(state.ToString()),
                new Client.ReadXmlDelegate(l.ReadXml)).StatusCode;

            if (statusCode == HttpStatusCode.NotFound)
                return null;

            return l;
        }

    }

}