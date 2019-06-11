using System.Xml;

namespace Recurly
{
    public class AdjustmentList : RecurlyList<Adjustment>
    {
        public override IRecurlyList<Adjustment> Start
        {
            get { return HasStartPage() ? new AdjustmentList(StartUrl) : RecurlyList.Empty<Adjustment>(); }
        }

        public override IRecurlyList<Adjustment> Next
        {
            get { return HasNextPage() ? new AdjustmentList(NextUrl) : RecurlyList.Empty<Adjustment>(); }
        }

        public override IRecurlyList<Adjustment> Prev
        {
            get { return HasPrevPage() ? new AdjustmentList(PrevUrl) : RecurlyList.Empty<Adjustment>(); }
        }

        public AdjustmentList()
        {
        }

        public AdjustmentList(string url) : base(Client.HttpRequestMethod.Get, url)
        {
        }

        internal override void ReadXml(XmlTextReader reader)
        {
            while (reader.Read())
            {
                if ((reader.Name == "adjustments" || reader.Name == "line_items") && reader.NodeType == XmlNodeType.EndElement)
                    break;

                if (reader.NodeType == XmlNodeType.Element && reader.Name == "adjustment")
                {
                    Add(new Adjustment(reader));
                }
            }
        }
    }
}