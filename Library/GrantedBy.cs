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
        SubscriptionList Subscriptions {get; set;}

        ItemList Items { get; set; }

        // TODO: it could be helpful to merchants to make this public, something to think about.
        // This is where i think it would be nice to understand what other clients libs are doing?  Are they just exposing a list of key/value pairs to the merchant devs via the client?
        // Or are they getting the data OR providing a way to get the data?  Some alignment would be really nice here.
        private List<string> SubscriptionIds
        {
            get { return _subscriptionIds ?? (_subscriptionIds = new List<string>()); }
            set { _subscriptionIds = value; }
        }

        private List<string> _subscriptionIds;

        // TODO: it could be helpful to merchants to make this public, something to think about
        private List<string> ItemIds
        {
            get { return _itemIds ?? (_itemIds = new List<string>()); }
            set { _itemIds = value; }
        }

        private List<string> _itemIds;

        internal GrantedBy()
        {
        }

        internal GrantedBy(XmlTextReader reader) : this()
        {
            ReadXml(reader);
        }

        internal override void ReadXml(XmlTextReader reader)
        {
            while (reader.Read())
            {
                if (reader.Name == "granted_by" && reader.NodeType == XmlNodeType.EndElement)
                    break;

                if (reader.NodeType != XmlNodeType.Element) continue;


                if (reader.Name == "subscription")
                {
                    var subscriptionHref = reader.GetAttribute("href");
                    string subscriptionId = subscriptionHref.Substring(subscriptionHref.LastIndexOf("/") + 1);
                    SubscriptionIds.Add(subscriptionId);
                }

                // TODO: add items part
                //if (reader.Name == "item")
                //{
                //    GrantedBys.Add(new GrantedBy(reader));
                //}
            }
        }

        //// TODO: Get SubscriptionList from id list and set to Subscriptions
        //public RecurlyList<Subscription> GetSubscriptions(Subscription.SubscriptionState state = Subscription.SubscriptionState.All)
        //{
        //    // TODO: Get SubscriptionList from id list and set to Subscriptions
        //    return new SubscriptionList(UrlPrefix + Uri.EscapeDataString(AccountCode) + "/subscriptions/"
        //        + Build.QueryStringWith(state.Equals(Subscription.SubscriptionState.All) ? "" : "state=" + state.ToString().EnumNameToTransportCase()));
        //}

        //// TODO: Get ItemList from id list and set to Items
        //public RecurlyList<Item> GetItems(FilterCriteria filter)
        //{
        //    filter = filter == null ? FilterCriteria.Instance : filter;
        //    return new ItemList(Item.UrlPrefix + "?" + filter.ToNamedValueCollection().ToString());
        //}

        internal override void WriteXml(XmlTextWriter writer)
        {
            throw new NotImplementedException();
        }
    }
}
