using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Xml;

namespace Recurly
{
    public class AddOn
    {

        public string PlanCode {get; private set; }
        public string AddOnCode { get; set; }
        public string Name { get; set; }

        /// <summary>
        /// A dictionary of currencies and values for the add-on amount
        /// </summary>
        public Dictionary<string, int> UnitAmountInCents { get; set; }

        public int DefaultQuantity { get; set; }
        public bool? DisplayQuantityOnHostedPage { get; set; }
        public DateTime CreatedAt { get; private set; }


        private const string UrlPrefix = "/plans/";
        private const string UrlPostfix = "/add_ons/";

        #region Constructors
        internal AddOn()
        {
        }

        internal AddOn(XmlTextReader xmlReader)
        {
            ReadXml(xmlReader);
        }

        internal AddOn(string planCode, string addOnCode, string name)
        {
            this.PlanCode = planCode;
            this.AddOnCode = addOnCode;
            this.Name = name;
        }

        #endregion

        /// <summary>
        /// Creates an addon
        /// </summary>
        public void Create()
        {
            Client.PerformRequest(Client.HttpRequestMethod.Post,
                UrlPrefix + System.Uri.EscapeUriString(this.PlanCode) + UrlPostfix + System.Uri.EscapeUriString(this.AddOnCode),
                new Client.WriteXmlDelegate(this.WriteXml),
                new Client.ReadXmlDelegate(this.ReadXml));
        }

        /// <summary>
        /// Update an existing add on in Recurly
        /// </summary>
        public void Update()
        {
            Client.PerformRequest(Client.HttpRequestMethod.Put,
                UrlPrefix + System.Uri.EscapeUriString(this.PlanCode) + UrlPostfix + System.Uri.EscapeUriString(this.AddOnCode),
                new Client.WriteXmlDelegate(this.WriteXml),
                new Client.ReadXmlDelegate(this.ReadXml));
        }

        /// <summary>
        /// Deletes this add on, making it inactive
        /// </summary>
        public void Deactivate()
        {
            Client.PerformRequest(Client.HttpRequestMethod.Delete, UrlPrefix + System.Uri.EscapeUriString(this.PlanCode) +
                UrlPostfix + System.Uri.EscapeUriString(this.AddOnCode));
        }


        

        #region Read and Write XML documents

        internal void ReadXmlUnitAmount(XmlTextReader reader)
        {
            if (this.UnitAmountInCents == null)
                this.UnitAmountInCents = new Dictionary<string, int>();

            while (reader.Read())
            {
                if (reader.Name == "unit_amount_in_cents" && reader.NodeType == XmlNodeType.EndElement)
                    break;

                if (reader.NodeType == XmlNodeType.Element)
                {
                    this.UnitAmountInCents.Add(reader.Name, reader.ReadElementContentAsInt());
                }
            }
        }

        internal void ReadXml(XmlTextReader reader)
        {
            while (reader.Read())
            {
                // End of account element, get out of here
                if (reader.Name == "add_on" && reader.NodeType == XmlNodeType.EndElement)
                    break;

                if (reader.NodeType == XmlNodeType.Element)
                {
                    switch (reader.Name)
                    {

                        case "add_on_code":
                            this.AddOnCode = reader.ReadElementContentAsString();
                            break;

                        case "name":
                            this.Name = reader.ReadElementContentAsString();
                            break;

                        case "display_quantity_on_hosted_page":
                            this.DisplayQuantityOnHostedPage = reader.ReadElementContentAsBoolean();
                            break;

                        case "default_quantity":
                            this.DefaultQuantity = reader.ReadElementContentAsInt();
                            break;

                        case "created_at":
                            this.CreatedAt = reader.ReadElementContentAsDateTime();
                            break;

                        case "unit_amount_in_cents":
                            ReadXmlUnitAmount(reader);
                            break;

                    }
                }
            }
        }

        internal void WriteXml(XmlTextWriter xmlWriter)
        {
            xmlWriter.WriteStartElement("add_on");

            xmlWriter.WriteElementString("add_on_code", this.PlanCode);
            xmlWriter.WriteElementString("name", this.Name);

            if (null != this.UnitAmountInCents)
            {
                xmlWriter.WriteStartElement("unit_amount_in_cents");
                foreach (KeyValuePair<string, int> d in UnitAmountInCents)
                {
                    xmlWriter.WriteElementString(d.Key, d.Value.ToString());
                }
                xmlWriter.WriteEndElement();
            }

            xmlWriter.WriteEndElement();
        }


        #endregion

        #region Object Overrides

        public override string ToString()
        {
            return "Recurly Plan: " + this.PlanCode;
        }

        public override bool Equals(object obj)
        {
            if (obj is Plan)
                return Equals((Plan)obj);
            else
                return false;
        }

        public bool Equals(Plan plan)
        {
            return this.PlanCode == plan.PlanCode;
        }

        public override int GetHashCode()
        {
            return this.PlanCode.GetHashCode();
        }

        #endregion
    }
}
