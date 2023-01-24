using System.Xml;

namespace Recurly
{
    public class CustomFieldDefinitionList : RecurlyList<CustomFieldDefinition>
    {
        public CustomFieldDefinitionList() { }

        public CustomFieldDefinitionList(string baseUrl) : base(Client.HttpRequestMethod.Get, baseUrl) { }

        public override RecurlyList<CustomFieldDefinition> Start
        {
            get { return HasStartPage() ? new CustomFieldDefinitionList(StartUrl) : RecurlyList.Empty<CustomFieldDefinition>(); }
        }

        public override RecurlyList<CustomFieldDefinition> Next
        {
            get { return HasNextPage() ? new CustomFieldDefinitionList(NextUrl) : RecurlyList.Empty<CustomFieldDefinition>(); }
        }

        public override RecurlyList<CustomFieldDefinition> Prev
        {
            get { return HasPrevPage() ? new CustomFieldDefinitionList(PrevUrl) : RecurlyList.Empty<CustomFieldDefinition>(); }
        }

        internal override void ReadXml(XmlTextReader reader)
        {
            while (reader.Read())
            {
                if ((reader.Name == "custom_field_definitions") && reader.NodeType == XmlNodeType.EndElement)
                    break;

                if (reader.NodeType == XmlNodeType.Element && reader.Name == "custom_field_definition")
                {
                    Add(new CustomFieldDefinition(reader));
                }
            }
        }
    }
}
