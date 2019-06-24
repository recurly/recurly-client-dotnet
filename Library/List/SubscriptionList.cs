using System.Xml;

namespace Recurly
{
    public class SubscriptionList : RecurlyList<ISubscription>
    {
        internal SubscriptionList(string baseUrl) : base(Client.HttpRequestMethod.Get, baseUrl)
        {
        }

        public override IRecurlyList<ISubscription> Start
        {
            get { return HasStartPage() ? new SubscriptionList(StartUrl) : RecurlyList.Empty<ISubscription>(); }
        }

        public override IRecurlyList<ISubscription> Next
        {
            get { return HasNextPage() ? new SubscriptionList(NextUrl) : RecurlyList.Empty<ISubscription>(); }
        }

        public override IRecurlyList<ISubscription> Prev
        {
            get { return HasPrevPage() ? new SubscriptionList(PrevUrl) : RecurlyList.Empty<ISubscription>(); }
        }

        internal override void ReadXml(XmlTextReader reader)
        {
            while (reader.Read())
            {
                if (reader.Name == "subscriptions" && reader.NodeType == XmlNodeType.EndElement)
                    break;

                if (reader.NodeType == XmlNodeType.Element && reader.Name == "subscription")
                {
                    Add(new Subscription(reader));
                }
            }
        }
    }
}