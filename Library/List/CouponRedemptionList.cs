using System.Xml;

namespace Recurly
{
    public class CouponRedemptionList : RecurlyList<CouponRedemption>
    {

        internal CouponRedemptionList()
        {
        }

        internal CouponRedemptionList(string baseUrl) : base(Client.HttpRequestMethod.Get, baseUrl)
        {
        }

        public override IRecurlyList<CouponRedemption> Start
        {
            get { return HasStartPage() ? new CouponRedemptionList(StartUrl) : RecurlyList.Empty<CouponRedemption>(); }
        }

        public override IRecurlyList<CouponRedemption> Next
        {
            get { return HasNextPage() ? new CouponRedemptionList(NextUrl) : RecurlyList.Empty<CouponRedemption>(); }
        }

        public override IRecurlyList<CouponRedemption> Prev
        {
            get { return HasPrevPage() ? new CouponRedemptionList(PrevUrl) : RecurlyList.Empty<CouponRedemption>(); }
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