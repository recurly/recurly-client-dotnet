using System;
using System.Collections.Generic;
using System.Net;
using System.Xml;

namespace Recurly
{

    /// <summary>
    /// A general ledger account in Recurly.
    ///
    /// </summary>
    public class PerformanceObligation : RecurlyEntity
    {
        public string Id { get; private set; }

        public string Name { get; private set; }

        public DateTime? CreatedAt { get; private set; }

        public DateTime? UpdatedAt { get; private set; }

        internal const string UrlPrefix = "/performance_obligations/";

        #region Constructors

        public PerformanceObligation()
        {
        }

        internal PerformanceObligation(XmlTextReader xmlReader)
        {
            ReadXml(xmlReader);
        }

        #endregion

        internal override void ReadXml(XmlTextReader reader)
        {
            while (reader.Read())
            {
                DateTime dateVal;

                if (reader.Name == "performance_obligation" && reader.NodeType == XmlNodeType.EndElement)
                    break;

                if (reader.NodeType != XmlNodeType.Element) continue;

                switch (reader.Name)
                {
                    case "id":
                        Id = reader.ReadElementContentAsString();
                        break;

                    case "name":
                        Name = reader.ReadElementContentAsString();
                        break;

                    case "created_at":
                        if (DateTime.TryParse(reader.ReadElementContentAsString(), out dateVal))
                        {
                            CreatedAt = dateVal;
                        }
                        break;

                    case "updated_at":
                        if (DateTime.TryParse(reader.ReadElementContentAsString(), out dateVal))
                        {
                            UpdatedAt = dateVal;
                        }
                        break;
                }
            }
        }

        internal override void WriteXml(XmlTextWriter xmlWriter)
        {
            xmlWriter.WriteStartElement("performance_obligation");

            xmlWriter.WriteElementString("name", Name);

            xmlWriter.WriteEndElement();
        }
    }

    public sealed class PerformanceObligations
    {
        internal const string UrlPrefix = "/performance_obligations/";

        /// <summary>
        /// Retrieves a list of all general ledger accounts.
        /// </summary>
        /// <returns></returns>
        public static RecurlyList<PerformanceObligation> List()
        {
            return List(null);
        }

        public static RecurlyList<PerformanceObligation> List(FilterCriteria filter)
        {
            filter = filter == null ? FilterCriteria.Instance : filter;
            return new PerformanceObligationList(PerformanceObligation.UrlPrefix + "?" + filter.ToNamedValueCollection().ToString());
        }

        public static PerformanceObligation Get(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return null;
            }

            var pob = new PerformanceObligation();

            var statusCode = Client.Instance.PerformRequest(Client.HttpRequestMethod.Get,
              UrlPrefix + Uri.EscapeDataString(name),
              pob.ReadXml);

            return statusCode == HttpStatusCode.NotFound ? null : pob;
        }

    }

}
