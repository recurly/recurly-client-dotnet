using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Xml;

namespace Recurly
{
    public class RecurlyPlan
    {
        public string PlanCode { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public int UnitAmountInCents { get; private set; }
        public int PlanIntervalLength { get; private set; }
        public int TrialIntervalLength { get; private set; }
        public IntervalUnit PlanIntervalUnit { get; private set; }

        public enum IntervalUnit
        {
            Days,
            Months
        }

        private const string UrlPrefix = "/company/plans/";

        public static RecurlyPlan Get(string planCode)
        {
            RecurlyPlan plan = new RecurlyPlan();

            HttpStatusCode statusCode = RecurlyClient.PerformRequest(RecurlyClient.HttpRequestMethod.Get,
                UrlPrefix + System.Web.HttpUtility.UrlEncode(planCode),
                new RecurlyClient.ReadXmlDelegate(plan.ReadXml));

            if (statusCode == HttpStatusCode.NotFound)
                return null;

            return plan;
        }

        public override string ToString()
        {
            return "Recurly Plan: " + this.PlanCode;
        }

        internal void ReadXml(XmlTextReader reader)
        {
            while (reader.Read())
            {
                // End of account element, get out of here
                if (reader.Name == "plan" && reader.NodeType == XmlNodeType.EndElement)
                    break;

                if (reader.NodeType == XmlNodeType.Element)
                {
                    switch (reader.Name)
                    {
                        case "plan_code":
                            this.PlanCode = reader.ReadElementContentAsString();
                            break;

                        case "description":
                            this.Description = reader.ReadElementContentAsString();
                            break;

                        case "name":
                            this.Name = reader.ReadElementContentAsString();
                            break;

                        case "unit_amount_in_cents":
                            this.UnitAmountInCents = reader.ReadElementContentAsInt();
                            break;

                        case "plan_interval_length":
                            this.PlanIntervalLength = reader.ReadElementContentAsInt();
                            break;

                        case "plan_interval_unit":
                            string unit = reader.ReadElementContentAsString();
                            this.PlanIntervalUnit = (unit == "days" ? IntervalUnit.Days : IntervalUnit.Months);
                            break;

                        case "trial_interval_length":
                            this.TrialIntervalLength = reader.ReadElementContentAsInt();
                            break;
                    }
                }
            }
        }
    }
}