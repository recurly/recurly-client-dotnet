using System.Xml;

namespace Recurly
{
    public class MeasuredUnitList : RecurlyList<MeasuredUnit>
    {
        internal MeasuredUnitList(string baseUrl) : base(Client.HttpRequestMethod.Get, baseUrl)
        {
        }

        public override IRecurlyList<MeasuredUnit> Start
        {
            get { return HasStartPage() ? new MeasuredUnitList(StartUrl) : RecurlyList.Empty<MeasuredUnit>(); }
        }

        public override IRecurlyList<MeasuredUnit> Next
        {
            get { return HasNextPage() ? new MeasuredUnitList(NextUrl) : RecurlyList.Empty<MeasuredUnit>(); }
        }

        public override IRecurlyList<MeasuredUnit> Prev
        {
            get { return HasPrevPage() ? new MeasuredUnitList(PrevUrl) : RecurlyList.Empty<MeasuredUnit>(); }
        }

        internal override void ReadXml(XmlTextReader reader)
        {
            while (reader.Read())
            {
                if (reader.Name == "measured_units" && reader.NodeType == XmlNodeType.EndElement)
                    break;

                if (reader.NodeType == XmlNodeType.Element && reader.Name == "measured_unit")
                {
                    Add(new MeasuredUnit(reader));
                }
            }
        }
    }
}