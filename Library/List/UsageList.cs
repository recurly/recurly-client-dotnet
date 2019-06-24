using System.Xml;

namespace Recurly
{
    public class UsageList : RecurlyList<IUsage>
    {
        public enum UsageBillingState : short
        {
            All = 0,
            Unbilled,
            Billed
        }

        public enum UsageDateTimeType : short
        {
            All = 0,
            Usage,
            Recording
        }

        internal UsageList()
        {
        }

        internal UsageList(string baseUrl) : base(Client.HttpRequestMethod.Get, baseUrl)
        {
        }

        public override IRecurlyList<IUsage> Start
        {
            get { return HasStartPage() ? new UsageList(StartUrl) : RecurlyList.Empty<IUsage>(); }
        }

        public override IRecurlyList<IUsage> Next
        {
            get { return HasNextPage() ? new UsageList(NextUrl) : RecurlyList.Empty<IUsage>(); }
        }

        public override IRecurlyList<IUsage> Prev
        {
            get { return HasPrevPage() ? new UsageList(PrevUrl) : RecurlyList.Empty<IUsage>(); }
        }

        internal override void ReadXml(XmlTextReader reader)
        {
            while (reader.Read())
            {
                if (reader.Name == "usages" && reader.NodeType == XmlNodeType.EndElement)
                    break;

                if (reader.NodeType == XmlNodeType.Element && reader.Name == "usage")
                {
                    var href = reader.GetAttribute("href");
                    Add(new Usage(reader, href));
                }
            }
        }
    }
}
