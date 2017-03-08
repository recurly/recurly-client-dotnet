using System.Xml;

namespace Recurly
{
    public class UsageList : RecurlyList<Usage>
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

        public override RecurlyList<Usage> Start
        {
            get { return HasStartPage() ? new UsageList(StartUrl) : RecurlyList.Empty<Usage>(); }
        }

        public override RecurlyList<Usage> Next
        {
            get { return HasNextPage() ? new UsageList(NextUrl) : RecurlyList.Empty<Usage>(); }
        }

        public override RecurlyList<Usage> Prev
        {
            get { return HasPrevPage() ? new UsageList(PrevUrl) : RecurlyList.Empty<Usage>(); }
        }

        internal override void ReadXml(XmlTextReader reader)
        {
            while (reader.Read())
            {
                if (reader.Name == "usages" && reader.NodeType == XmlNodeType.EndElement)
                    break;

                if (reader.NodeType == XmlNodeType.Element && reader.Name == "usage")
                {
                    Add(new Usage(reader));
                }
            }
        }
    }
}
