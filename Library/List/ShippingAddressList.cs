using System.Xml;

namespace Recurly
{
    public class ShippingAddressList : RecurlyList<IShippingAddress>
    {
        private IAccount _accountn;

        public ShippingAddressList(IAccount account)
        {
            _accountn = account;
        }

        public ShippingAddressList(string url) : base(Client.HttpRequestMethod.Get, url)
        {
        }

        public override IRecurlyList<IShippingAddress> Start
        {
            get { return HasStartPage() ? new ShippingAddressList(StartUrl) : RecurlyList.Empty<IShippingAddress>(); }
        }

        public override IRecurlyList<IShippingAddress> Next
        {
            get { return HasNextPage() ? new ShippingAddressList(NextUrl) : RecurlyList.Empty<IShippingAddress>(); }
        }

        public override IRecurlyList<IShippingAddress> Prev
        {
            get { return HasPrevPage() ? new ShippingAddressList(PrevUrl) : RecurlyList.Empty<IShippingAddress>(); }
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

        public new void Add(IShippingAddress address)
        {
            base.Add(address);
        }
    }
}
