using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Recurly
{
    public class MeasuredUnit : RecurlyEntity {

        public string DisplayName { get; set; }
        public string Description { get; set; }
        public string Name { get; set; } 
        public long Id { get; private set; }

        internal const string UrlPrefix = "/measured_units/";

        internal MeasuredUnit()
        {
        }

        internal MeasuredUnit(XmlTextReader reader)
            : this()
        {
            ReadXml(reader);
        }

        public MeasuredUnit(String name, String displayName, String description)
        {
            Name = name;
            DisplayName = displayName;
            Description = description;
        }

        private string memberUrl()
        {
            return UrlPrefix + Id;
        }

        /// <summary>
        /// Create a new measured unit in Recurly
        /// </summary>
        public void Create()
        {
            Client.Instance.PerformRequest(Client.HttpRequestMethod.Post,
                UrlPrefix,
                WriteXml,
                ReadXml);
        }

        /// <summary>
        /// Update an existing measured unit in Recurly
        /// </summary>
        public void Update()
        {
            Client.Instance.PerformRequest(Client.HttpRequestMethod.Put,
                UrlPrefix + Uri.EscapeDataString(Id.ToString()),
                WriteXml);
        }

        /// <summary>
        /// Deletes this measured unit
        /// </summary>
        public void Delete()
        {
            Client.Instance.PerformRequest(Client.HttpRequestMethod.Delete,
                UrlPrefix + Uri.EscapeDataString(Id.ToString()));
        }

        #region Read and Write XML documents

        internal override void ReadXml(XmlTextReader reader)
        {
            while (reader.Read())
            {
                // End of invoice element, get out of here
                if (reader.Name == "measured_unit" && reader.NodeType == XmlNodeType.EndElement)
                    break;

                if (reader.NodeType != XmlNodeType.Element) continue;

                switch (reader.Name)
                {
                    case "id":
                        Id = Convert.ToInt64(reader.ReadElementContentAsString());
                        break;
             
                    case "display_name":
                        DisplayName = reader.ReadElementContentAsString();
                        break;

                    case "description":
                        Description = reader.ReadElementContentAsString();
                        break;

                    case "name":
                        Name = reader.ReadElementContentAsString();
                        break;
                }
            }
        }

        internal override void WriteXml(XmlTextWriter xmlWriter)
        {
            xmlWriter.WriteStartElement("measured_unit");

            xmlWriter.WriteElementString("name", Name);
            xmlWriter.WriteElementString("display_name", DisplayName);
            xmlWriter.WriteStringIfValid("description", Description);
  
            xmlWriter.WriteEndElement();
        }

        #endregion

        #region Object Overrides

        public override string ToString()
        {
            return "Recurly Measured Unit: " + Id;
        }

        public override bool Equals(object obj)
        {
            var invoice = obj as Invoice;
            return invoice != null && Equals(invoice);
        }

        public bool Equals(MeasuredUnit measuredUnit)
        {
            return Id == measuredUnit.Id;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        #endregion
    }

    public sealed class MeasuredUnits
    {
        /// <summary>
        /// Lists measured units
        /// </summary>
        public static RecurlyList<MeasuredUnit> List()
        {
            return new MeasuredUnitList("/measured_units/");
        }

        /// <summary>
        /// Look up a Measured Unit.
        /// </summary>
        /// <param name="measuredUnitId">MeasuredUnit id</param>
        /// <returns></returns>
        public static MeasuredUnit Get(long measuredUnitId)
        {
            var measuredUnit = new MeasuredUnit();

            var statusCode = Client.Instance.PerformRequest(Client.HttpRequestMethod.Get,
                MeasuredUnit.UrlPrefix + measuredUnitId,
                measuredUnit.ReadXml);

            return statusCode == HttpStatusCode.NotFound ? null : measuredUnit;
        }
    }
}
