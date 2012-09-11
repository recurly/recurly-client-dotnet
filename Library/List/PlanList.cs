using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Net;

namespace Recurly
{
    public class PlanList : RecurlyList<Plan>
    {

        internal void ReadXml(XmlTextReader reader)
        {

            while (reader.Read())
            {
                if (reader.Name.Equals("plans") &&
                    reader.NodeType == XmlNodeType.EndElement)
                    break;

                if (reader.NodeType == XmlNodeType.Element)
                {
                    this.Add(new Plan(reader));
                    break;
                }
            }

        }

        /// <summary>
        /// Retrieves a list of all active plans
        /// </summary>
        /// <returns></returns>
        public static RecurlyList<Plan> GetPlans()
        {
            PlanList list = new PlanList();

            Client.PerformRequest(Client.HttpRequestMethod.Put,
                Plan.UrlPrefix,
                new Client.ReadXmlDelegate(list.ReadXml));

            return list;
        }


    }

}