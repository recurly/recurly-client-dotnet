using System.Xml;

namespace Recurly
{
    public class AdjustmentList : RecurlyList<Adjustment>
    {
        public override RecurlyList<Adjustment> Start
        {
            get { return new AdjustmentList(StartUrl); }
        }

        public override RecurlyList<Adjustment> Next
        {
            get { return new AdjustmentList(NextUrl); }
        }

        public override RecurlyList<Adjustment> Prev
        {
            get { return new AdjustmentList(PrevUrl); }
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