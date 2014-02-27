using System.Xml;

namespace Recurly
{
    public class CouponList : RecurlyList<Coupon>
    {
        internal CouponList(string baseUrl) : base(Client.HttpRequestMethod.Get, baseUrl)
        {
        }

        public override RecurlyList<Coupon> Start
        {
            get { return HasStartPage() ? new CouponList(StartUrl) : RecurlyList.Empty<Coupon>(); }
        }

        public override RecurlyList<Coupon> Next
        {
            get { return HasNextPage() ? new CouponList(NextUrl) : RecurlyList.Empty<Coupon>(); }
        }

        public override RecurlyList<Coupon> Prev
        {
            get { return HasPrevPage() ? new CouponList(PrevUrl) : RecurlyList.Empty<Coupon>(); }
        }

        internal override void ReadXml(XmlTextReader reader)
        {
            while (reader.Read())
            {
                if (reader.Name == "coupons" && reader.NodeType == XmlNodeType.EndElement)
                    break;

                if (reader.NodeType == XmlNodeType.Element && reader.Name == "coupon")
                {
                    Add(new Coupon(reader));
                }
            }
        }
    }
}