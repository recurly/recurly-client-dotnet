using System.Xml;

namespace Recurly
{
    public class ExternalSubscriptionList : RecurlyList<ExternalSubscription>
    {
        internal ExternalSubscriptionList(string baseUrl) : base(Client.HttpRequestMethod.Get, baseUrl)
        {
        }

        public override RecurlyList<ExternalSubscription> Start
        {
            get { return HasStartPage() ? new ExternalSubscriptionList(StartUrl) : RecurlyList.Empty<ExternalSubscription>(); }
        }

        public override RecurlyList<ExternalSubscription> Next
        {
            get { return HasNextPage() ? new ExternalSubscriptionList(NextUrl) : RecurlyList.Empty<ExternalSubscription>(); }
        }

        public override RecurlyList<ExternalSubscription> Prev
        {
            get { return HasPrevPage() ? new ExternalSubscriptionList(PrevUrl) : RecurlyList.Empty<ExternalSubscription>(); }
        }

        internal override void ReadXml(XmlTextReader reader)
        {
            while (reader.Read())
            {
                if (reader.Name == "external_subscriptions" && reader.NodeType == XmlNodeType.EndElement)
                    break;

                if (reader.NodeType == XmlNodeType.Element && reader.Name == "external_subscription")
                {
                    Add(new ExternalSubscription(reader));
                }
            }
        }
    }
}