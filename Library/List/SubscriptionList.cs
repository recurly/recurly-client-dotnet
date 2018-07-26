using System.Xml;

namespace Recurly
{
    public class SubscriptionList : RecurlyList<Subscription>
    {
        internal SubscriptionList(string baseUrl) : base(Client.HttpRequestMethod.Get, baseUrl)
        {
        }

        public static SubscriptionList Continue(string continuationToken)
        {
            return new SubscriptionList(continuationToken);
        }

        public override RecurlyList<Subscription> Start
        {
            get { return HasStartPage() ? new SubscriptionList(StartUrl) : RecurlyList.Empty<Subscription>(); }
        }

        public override RecurlyList<Subscription> Next
        {
            get { return HasNextPage() ? new SubscriptionList(NextUrl) : RecurlyList.Empty<Subscription>(); }
        }

        public override RecurlyList<Subscription> Prev
        {
            get { return HasPrevPage() ? new SubscriptionList(PrevUrl) : RecurlyList.Empty<Subscription>(); }
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