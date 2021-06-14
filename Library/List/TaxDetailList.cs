using System.Xml;

namespace Recurly
{
    public class TaxDetailList : RecurlyList<TaxDetail>
    {
        public override RecurlyList<TaxDetail> Start
        {
            get { return HasStartPage() ? new TaxDetailList(StartUrl) : RecurlyList.Empty<TaxDetail>(); }
        }

        public override RecurlyList<TaxDetail> Next
        {
            get { return HasNextPage() ? new TaxDetailList(NextUrl) : RecurlyList.Empty<TaxDetail>(); }
        }

        public override RecurlyList<TaxDetail> Prev
        {
            get { return HasPrevPage() ? new TaxDetailList(PrevUrl) : RecurlyList.Empty<TaxDetail>(); }
        }

        public TaxDetailList()
        {
        }

        public TaxDetailList(string url) : base(Client.HttpRequestMethod.Get, url)
        {
        }

        internal override void ReadXml(XmlTextReader reader)
        {
            while (reader.Read())
            {
                if (reader.Name == "tax_details" && reader.NodeType == XmlNodeType.EndElement)
                    break;

                if (reader.NodeType == XmlNodeType.Element && reader.Name == "tax_detail")
                {
                    Add(new TaxDetail(reader));
                }
            }
        }
    }
}