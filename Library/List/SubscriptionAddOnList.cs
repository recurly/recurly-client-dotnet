using System.Xml;

namespace Recurly
{
    public class SubscriptionAddOnList : RecurlyList<SubscriptionAddOn>
    {
        public SubscriptionAddOnList()
        {
        }

        public SubscriptionAddOnList(string url) : base(Client.HttpRequestMethod.Get, url)
        {
        }

        public override RecurlyList<SubscriptionAddOn> Start
        {
            get { return HasStartPage() ? new SubscriptionAddOnList(StartUrl) : RecurlyList.Empty<SubscriptionAddOn>(); }
        }

        public override RecurlyList<SubscriptionAddOn> Next
        {
            get { return HasNextPage() ? new SubscriptionAddOnList(NextUrl) : RecurlyList.Empty<SubscriptionAddOn>(); }
        }

        public override RecurlyList<SubscriptionAddOn> Prev
        {
            get { return HasPrevPage() ? new SubscriptionAddOnList(PrevUrl) : RecurlyList.Empty<SubscriptionAddOn>(); }
        }

        internal override void ReadXml(XmlTextReader reader)
        {
            while (reader.Read())
            {
                if (reader.Name == "subscription_add_ons" && reader.NodeType == XmlNodeType.EndElement)
                    break;

                if (reader.NodeType == XmlNodeType.Element && reader.Name == "subscription_add_on")
                {
                    Add(new SubscriptionAddOn(reader));
                }
            }
        }
    }
}
