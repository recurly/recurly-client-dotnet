using System;
using System.Collections.Generic;
using System.Net;
using System.Xml;

namespace Recurly
{

    /// <summary>
    /// An item in Recurly.
    ///
    /// </summary>
    public class Item : RevRecEntity
    {
        public string ItemCode { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string ExternalSku { get; set; }

        public string AccountingCode { get; set; }

        public string RevenueScheduleType { get; set; }

        public string State { get; private set; }

        public List<CustomField> CustomFields
        {
            get { return _customFields ?? (_customFields = new List<CustomField>()); }
            set { _customFields = value; }
        }
        private List<CustomField> _customFields;

        public DateTime? CreatedAt { get; private set; }

        public DateTime? UpdatedAt { get; private set; }

        public DateTime? DeletedAt { get; private set; }

        internal const string UrlPrefix = "/items/";

        #region Constructors

        public Item()
        {
        }

        internal Item(XmlTextReader xmlReader)
        {
            ReadXml(xmlReader);
        }

        // internal Item(XmlTextReader xmlReader, string xmlName)
        // {
        //     ReadXml(xmlReader, xmlName);
        // }

        public Item(string itemCode, string name)
        {
            ItemCode = itemCode;
            Name = name;
        }

        #endregion

        /// <summary>
        /// Create a new Item in Recurly
        /// </summary>
        public void Create()
        {
            Client.Instance.PerformRequest(Client.HttpRequestMethod.Post,
                UrlPrefix,
                WriteXml,
                ReadXml);
        }

        /// <summary>
        /// Update an existing account in Recurly
        /// </summary>
        public void Update()
        {
            // PUT /items/<item_code>
            Client.Instance.PerformRequest(Client.HttpRequestMethod.Put,
                UrlPrefix + Uri.EscapeDataString(ItemCode),
                WriteXml);
        }

        public void Deactivate()
        {
            Client.Instance.PerformRequest(Client.HttpRequestMethod.Delete, UrlPrefix + Uri.EscapeDataString(ItemCode));
        }

        public void Reactivate()
        {
            Client.Instance.PerformRequest(Client.HttpRequestMethod.Put,
            UrlPrefix + Uri.EscapeDataString(ItemCode) + "/reactivate",
            ReadXml);
        }

        internal override void ReadXml(XmlTextReader reader)
        {
            while (reader.Read())
            {
                if (reader.Name == "item" && reader.NodeType == XmlNodeType.EndElement)
                    break;

                if (reader.NodeType != XmlNodeType.Element) continue;

                ReadRevRecNode(reader);

                switch (reader.Name)
                {
                    case "item_code":
                        ItemCode = reader.ReadElementContentAsString();
                        break;

                    case "name":
                        Name = reader.ReadElementContentAsString();
                        break;

                    case "description":
                        Description = reader.ReadElementContentAsString();
                        break;
                }
            }
        }

        internal override void WriteXml(XmlTextWriter xmlWriter)
        {
            xmlWriter.WriteStartElement("item");

            xmlWriter.WriteElementString("item_code", ItemCode);
            xmlWriter.WriteElementString("name", Name);
            xmlWriter.WriteStringIfValid("description", Description);
            xmlWriter.WriteStringIfValid("external_sku", ExternalSku);
            xmlWriter.WriteStringIfValid("accounting_code", AccountingCode);
            xmlWriter.WriteStringIfValid("revenue_schedule_type", RevenueScheduleType);
            WriteRevRecNodes(xmlWriter);
            xmlWriter.WriteStringIfValid("state", State);
            xmlWriter.WriteIfCollectionHasAny("custom_fields", CustomFields);

            xmlWriter.WriteEndElement();
        }
    }

    public sealed class Items
    {
        internal const string UrlPrefix = "/items/";

        /// <summary>
        /// Retrieves a list of all active items
        /// </summary>
        /// <returns></returns>
        public static RecurlyList<Item> List()
        {
            return List(null);
        }

        public static RecurlyList<Item> List(FilterCriteria filter)
        {
            filter = filter == null ? FilterCriteria.Instance : filter;
            return new ItemList(Item.UrlPrefix + "?" + filter.ToNamedValueCollection().ToString());
        }

        public static Item Get(string itemCode)
        {
            if (string.IsNullOrWhiteSpace(itemCode))
            {
                return null;
            }

            var item = new Item();

            var statusCode = Client.Instance.PerformRequest(Client.HttpRequestMethod.Get,
              UrlPrefix + Uri.EscapeDataString(itemCode),
              item.ReadXml);

            return statusCode == HttpStatusCode.NotFound ? null : item;
        }

    }

}
