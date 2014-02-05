using System.Xml;

namespace Recurly
{
    public class PlanList : RecurlyList<Plan>
    {
        internal PlanList(string baseUrl) : base(Client.HttpRequestMethod.Get, baseUrl)
        {
        }

        public override RecurlyList<Plan> Start
        {
            get { return new PlanList(StartUrl); }
        }

        public override RecurlyList<Plan> Next
        {
            get { return new PlanList(NextUrl); }
        }

        public override RecurlyList<Plan> Prev
        {
            get { return new PlanList(PrevUrl); }
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

        /// <summary>
        /// Retrieves a list of all active plans
        /// </summary>
        /// <returns></returns>
        public static PlanList GetPlans()
        {
            return new PlanList(Plan.UrlPrefix);
        }
    }
}