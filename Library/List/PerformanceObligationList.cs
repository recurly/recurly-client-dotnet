using System.Xml;

namespace Recurly
{
    public class PerformanceObligationList : RecurlyList<PerformanceObligation>
    {
        internal PerformanceObligationList()
        {
        }

        internal PerformanceObligationList(string baseUrl) : base(Client.HttpRequestMethod.Get, baseUrl)
        {
        }

        public override RecurlyList<PerformanceObligation> Start
        {
            get { return HasStartPage() ? new PerformanceObligationList(StartUrl) : RecurlyList.Empty<PerformanceObligation>(); }
        }

        public override RecurlyList<PerformanceObligation> Next
        {
            get { return HasNextPage() ? new PerformanceObligationList(NextUrl) : RecurlyList.Empty<PerformanceObligation>(); }
        }

        public override RecurlyList<PerformanceObligation> Prev
        {
            get { return HasPrevPage() ? new PerformanceObligationList(PrevUrl) : RecurlyList.Empty<PerformanceObligation>(); }
        }

        internal override void ReadXml(XmlTextReader reader)
        {
            while (reader.Read())
            {
                if (reader.Name == "performance_obligations" && reader.NodeType == XmlNodeType.EndElement)
                    break;

                if (reader.NodeType == XmlNodeType.Element && reader.Name == "performance_obligation")
                {
                    Add(new PerformanceObligation(reader));
                }
            }
        }
    }
}
