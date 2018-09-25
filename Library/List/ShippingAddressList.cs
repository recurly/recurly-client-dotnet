using System.Xml;

namespace Recurly
{
    public class ShippingAddressList : RecurlyList<ShippingAddress>
    {
        private Account _accountn;

        public ShippingAddressList(Account account)
        {
            _accountn = account;
        }

        public ShippingAddressList(string url) : base(Client.HttpRequestMethod.Get, url)
        {
        }

        public override RecurlyList<ShippingAddress> Start
        {
            get { return HasStartPage() ? new ShippingAddressList(StartUrl) : RecurlyList.Empty<ShippingAddress>(); }
        }

        public override RecurlyList<ShippingAddress> Next
        {
            get { return HasNextPage() ? new ShippingAddressList(NextUrl) : RecurlyList.Empty<ShippingAddress>(); }
        }

        public override RecurlyList<ShippingAddress> Prev
        {
            get { return HasPrevPage() ? new ShippingAddressList(PrevUrl) : RecurlyList.Empty<ShippingAddress>(); }
        }

        public override bool includeEmptyTag()
        {
            return true;
        }

        internal override void ReadXml(XmlTextReader reader)
        {
            while (reader.Read())
            {
                if (reader.Name == "shipping_addresses" && reader.NodeType == XmlNodeType.EndElement)
                    break;

                if (reader.NodeType == XmlNodeType.Element && reader.Name == "shipping_address")
                {
                    Add(new ShippingAddress(reader));
                }
            }
        }

        public new void Add(ShippingAddress address)
        {
            base.Add(address);
        }
    }
}
