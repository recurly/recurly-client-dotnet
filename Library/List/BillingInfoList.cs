using System.Xml;

namespace Recurly
{
    public class BillingInfoList : RecurlyList<BillingInfo>
    {
        private Account _account;

        public BillingInfoList(Account account)
        {
            _account = account;
        }

        public BillingInfoList(string url) : base(Client.HttpRequestMethod.Get, url)
        {
        }

        public override RecurlyList<BillingInfo> Start
        {
            get { return HasStartPage() ? new BillingInfoList(StartUrl) : RecurlyList.Empty<BillingInfo>(); }
        }

        public override RecurlyList<BillingInfo> Next
        {
            get { return HasNextPage() ? new BillingInfoList(NextUrl) : RecurlyList.Empty<BillingInfo>(); }
        }

        public override RecurlyList<BillingInfo> Prev
        {
            get { return HasPrevPage() ? new BillingInfoList(PrevUrl) : RecurlyList.Empty<BillingInfo>(); }
        }

        public override bool includeEmptyTag()
        {
            return true;
        }

        internal override void ReadXml(XmlTextReader reader)
        {
            while (reader.Read())
            {
                if (reader.Name == "billing_infos" && reader.NodeType == XmlNodeType.EndElement)
                    break;

                if (reader.NodeType == XmlNodeType.Element && reader.Name == "billing_info")
                {
                    Add(new BillingInfo(reader));
                }
            }
        }

        public new void Add(BillingInfo billing_info)
        {
            base.Add(billing_info);
        }
    }
}
