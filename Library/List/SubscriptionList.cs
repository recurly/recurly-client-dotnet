using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Net;

namespace Recurly
{
    public class SubscriptionList : RecurlyList<Subscription>
    {

        internal SubscriptionList(string baseUrl)
            : base(Client.HttpRequestMethod.Get, baseUrl)
        {
        }

        internal override void ReadXml(XmlTextReader reader)
        {
            while (reader.Read())
            {
                if (reader.Name.Equals("subscriptions") &&
                    reader.NodeType == XmlNodeType.EndElement)
                    break;

                if (reader.NodeType == XmlNodeType.Element && reader.Name.Equals("subscription"))
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
        public static SubscriptionList GetSubscriptions(Subscription.SubscriptionState state = Subscription.SubscriptionState.Live)
        {
            return new SubscriptionList(Subscription.UrlPrefix + "?state=" + System.Uri.EscapeUriString(state.ToString()));
        }

    }

}