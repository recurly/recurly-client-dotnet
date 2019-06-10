﻿using System.Xml;

namespace Recurly
{
    public class PlanList : RecurlyList<Plan>
    {
        protected internal PlanList(string baseUrl) : base(Client.HttpRequestMethod.Get, baseUrl)
        {
        }

        public override RecurlyList<Plan> Start
        {
            get { return HasStartPage() ? new PlanList(StartUrl) : RecurlyList.Empty<Plan>(); }
        }

        public override RecurlyList<Plan> Next
        {
            get { return HasNextPage() ? new PlanList(NextUrl) : RecurlyList.Empty<Plan>(); }
        }

        public override RecurlyList<Plan> Prev
        {
            get { return HasPrevPage() ? new PlanList(PrevUrl) : RecurlyList.Empty<Plan>(); }
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