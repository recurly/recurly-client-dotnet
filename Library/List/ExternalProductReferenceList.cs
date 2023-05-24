using System.Xml;

namespace Recurly
{
    public class ExternalProductReferenceList : RecurlyList<ExternalProductReference>
    {
        internal ExternalProductReferenceList(string baseUrl) : base(Client.HttpRequestMethod.Get, baseUrl)
        {
        }

        public override RecurlyList<ExternalProductReference> Start
        {
            get { return HasStartPage() ? new ExternalProductReferenceList(StartUrl) : RecurlyList.Empty<ExternalProductReference>(); }
        }

        public override RecurlyList<ExternalProductReference> Next
        {
            get { return HasNextPage() ? new ExternalProductReferenceList(NextUrl) : RecurlyList.Empty<ExternalProductReference>(); }
        }

        public override RecurlyList<ExternalProductReference> Prev
        {
            get { return HasPrevPage() ? new ExternalProductReferenceList(PrevUrl) : RecurlyList.Empty<ExternalProductReference>(); }
        }

        internal override void ReadXml(XmlTextReader reader)
        {
            while (reader.Read())
            {
                if (reader.Name == "external_product_references" && reader.NodeType == XmlNodeType.EndElement)
                    break;

                if (reader.NodeType == XmlNodeType.Element && reader.Name == "external_product_reference")
                {
                    Add(new ExternalProductReference(reader));
                }
            }
        }
    }
}