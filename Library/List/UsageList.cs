using System.Xml;

namespace Recurly
{
    public class UsageList : RecurlyList<Usage>
    {
        public UsageList(string url) : base(Client.HttpRequestMethod.Get, url)
        {
        }

        internal override void ReadXml(XmlTextReader reader)
        {
            while (reader.Read())
            {
                if ((reader.Name == "usages") && reader.NodeType == XmlNodeType.EndElement)
                    break;

                if (reader.NodeType == XmlNodeType.Element && reader.Name == "usage")
                {
                    Add(new Usage(reader));
                }
            }
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
    }
}
