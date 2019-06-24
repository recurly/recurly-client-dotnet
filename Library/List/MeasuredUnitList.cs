using System.Xml;

namespace Recurly
{
    public class MeasuredUnitList : RecurlyList<IMeasuredUnit>
    {
        internal MeasuredUnitList(string baseUrl) : base(Client.HttpRequestMethod.Get, baseUrl)
        {
        }

        public override IRecurlyList<IMeasuredUnit> Start
        {
            get { return HasStartPage() ? new MeasuredUnitList(StartUrl) : RecurlyList.Empty<IMeasuredUnit>(); }
        }

        public override IRecurlyList<IMeasuredUnit> Next
        {
            get { return HasNextPage() ? new MeasuredUnitList(NextUrl) : RecurlyList.Empty<IMeasuredUnit>(); }
        }

        public override IRecurlyList<IMeasuredUnit> Prev
        {
            get { return HasPrevPage() ? new MeasuredUnitList(PrevUrl) : RecurlyList.Empty<IMeasuredUnit>(); }
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