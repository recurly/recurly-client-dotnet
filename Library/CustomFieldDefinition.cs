using System;
using System.Net;
using System.Runtime.Serialization;
using System.Xml;

namespace Recurly
{
    public class CustomFieldDefinition : RecurlyEntity
    {
        /// <summary>
        /// The currently valid related_types
        /// </summary>
        public enum CustomFieldType
        {
            [EnumMember(Value = "account")]
            Account,

            [EnumMember(Value = "charge")]
            Charge,

            [EnumMember(Value = "item")]
            Item,

            [EnumMember(Value = "plan")]
            Plan,

            [EnumMember(Value = "subscription")]
            Subscription,

            [EnumMember(Value = "")]
            All,
        }

        public string Id { get; private set; }
        public CustomFieldType RelatedType { get; set; }
        public string Name { get; set; }
        public string UserAccess { get; set; }
        public string DisplayName { get; set; }
        public string Tooltip { get; set; }
        public DateTime? CreatedAt { get; private set; }
        public DateTime? UpdatedAt { get; private set; }

        internal const string UrlPrefix = "/custom_field_definitions";

        #region Constructors

        public CustomFieldDefinition() { }

        internal CustomFieldDefinition(XmlTextReader reader) : this()
        {
            ReadXml(reader);
        }

        #endregion

        #region Read and Write XML documents
        internal override void ReadXml(XmlTextReader reader)
        {
            while (reader.Read())
            {
                if (reader.Name == "custom_field_definition" && reader.NodeType == XmlNodeType.EndElement)
                    break;

                if (reader.NodeType != XmlNodeType.Element) continue;
                switch (reader.Name)
                {
                    case "id":
                        Id = reader.ReadElementContentAsString();
                        break;

                    case "related_type":
                        RelatedType = reader.ReadElementContentAsString().ParseAsEnum<CustomFieldType>();
                        break;

                    case "name":
                        Name = reader.ReadElementContentAsString();
                        break;

                    case "user_access":
                        UserAccess = reader.ReadElementContentAsString();
                        break;

                    case "display_name":
                        DisplayName = reader.ReadElementContentAsString();
                        break;

                    case "tooltip":
                        Tooltip = reader.ReadElementContentAsString();
                        break;

                    case "created_at":
                        CreatedAt = reader.ReadElementContentAsDateTime();
                        break;

                    case "updated_at":
                        UpdatedAt = reader.ReadElementContentAsDateTime();
                        break;
                }
            }
        }

        internal override void WriteXml(XmlTextWriter xmlWriter)
        {
            throw new NotImplementedException();
        }

        #endregion


        /// <summary>
        /// Gets a single Custom Field Definition by Id
        /// </summary>
        /// <param name="id">The Id of the Custom Field Definition to Fetch. Required</param>
        public static CustomFieldDefinition Get(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return null;
            }

            var customFieldDefinition = new CustomFieldDefinition();
            // GET /custom_field_definitions/<custom_field_definition_id>
            var statusCode = Client.Instance.PerformRequest(Client.HttpRequestMethod.Get,
                UrlPrefix + "/" + Uri.EscapeDataString(id),
                customFieldDefinition.ReadXml);

            return statusCode == HttpStatusCode.NotFound ? null : customFieldDefinition;
        }
    }

    public sealed class CustomFieldDefinitions
    {
        /// <summary>
        /// Gets a list of all Custom Field Definitions by Type
        /// </summary>
        /// <param name="relatedType">The Type of Custom Field Definition to Fetch. Optional, default: All.</param>
        public static RecurlyList<CustomFieldDefinition> List(CustomFieldDefinition.CustomFieldType relatedType = CustomFieldDefinition.CustomFieldType.All)
        {
            var param = (relatedType == CustomFieldDefinition.CustomFieldType.All) ? "/" : "?related_type=" + relatedType.ToString().EnumNameToTransportCase();
            // GET /custom_field_definitions?related_type=relatedType
            return new CustomFieldDefinitionList(CustomFieldDefinition.UrlPrefix + param);
        }
    }
}
