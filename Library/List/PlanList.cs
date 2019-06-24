using System.Xml;

namespace Recurly
{
    public class PlanList : RecurlyList<IPlan>
    {
        internal PlanList(string baseUrl) : base(Client.HttpRequestMethod.Get, baseUrl)
        {
        }

        public override IRecurlyList<IPlan> Start
        {
            get { return HasStartPage() ? new PlanList(StartUrl) : RecurlyList.Empty<IPlan>(); }
        }

        public override IRecurlyList<IPlan> Next
        {
            get { return HasNextPage() ? new PlanList(NextUrl) : RecurlyList.Empty<IPlan>(); }
        }

        public override IRecurlyList<IPlan> Prev
        {
            get { return HasPrevPage() ? new PlanList(PrevUrl) : RecurlyList.Empty<IPlan>(); }
        }

        internal override void ReadXml(XmlTextReader reader)
        {
            while (reader.Read())
            {
                if (reader.Name == "plans" && reader.NodeType == XmlNodeType.EndElement)
                    break;

                if (reader.NodeType == XmlNodeType.Element && reader.Name == "plan")
                {
                    Add(new Plan(reader));
                }
            }
        }
    }
}