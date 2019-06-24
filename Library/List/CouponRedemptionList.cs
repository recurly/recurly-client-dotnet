using System.Xml;

namespace Recurly
{
    public class CouponRedemptionList : RecurlyList<ICouponRedemption>
    {

        internal CouponRedemptionList()
        {
        }

        internal CouponRedemptionList(string baseUrl) : base(Client.HttpRequestMethod.Get, baseUrl)
        {
        }

        public override IRecurlyList<ICouponRedemption> Start
        {
            get { return HasStartPage() ? new CouponRedemptionList(StartUrl) : RecurlyList.Empty<ICouponRedemption>(); }
        }

        public override IRecurlyList<ICouponRedemption> Next
        {
            get { return HasNextPage() ? new CouponRedemptionList(NextUrl) : RecurlyList.Empty<ICouponRedemption>(); }
        }

        public override IRecurlyList<ICouponRedemption> Prev
        {
            get { return HasPrevPage() ? new CouponRedemptionList(PrevUrl) : RecurlyList.Empty<ICouponRedemption>(); }
        }

        internal override void ReadXml(XmlTextReader reader)
        {
            while (reader.Read())
            {
                if (reader.Name == "redemptions" && reader.NodeType == XmlNodeType.EndElement)
                    break;

                if (reader.NodeType == XmlNodeType.Element && reader.Name == "redemption")
                {
                    Add(new CouponRedemption(reader));
                }
            }
        }
    }
}