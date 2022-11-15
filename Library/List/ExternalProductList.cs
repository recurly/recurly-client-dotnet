using System.Xml;

namespace Recurly
{
    public class ExternalProductList : RecurlyList<ExternalProduct>
    {
        internal ExternalProductList(string baseUrl) : base(Client.HttpRequestMethod.Get, baseUrl)
        {
        }

        public override RecurlyList<ExternalProduct> Start
        {
            get { return HasStartPage() ? new ExternalProductList(StartUrl) : RecurlyList.Empty<ExternalProduct>(); }
        }

        public override RecurlyList<ExternalProduct> Next
        {
            get { return HasNextPage() ? new ExternalProductList(NextUrl) : RecurlyList.Empty<ExternalProduct>(); }
        }

        public override RecurlyList<ExternalProduct> Prev
        {
            get { return HasPrevPage() ? new ExternalProductList(PrevUrl) : RecurlyList.Empty<ExternalProduct>(); }
        }

        internal override void ReadXml(XmlTextReader reader)
        {
            while (reader.Read())
            {
                if (reader.Name == "external_products" && reader.NodeType == XmlNodeType.EndElement)
                    break;

                if (reader.NodeType == XmlNodeType.Element && reader.Name == "external_product")
                {
                    Add(new ExternalProduct(reader));
                }
            }
        }
    }
}