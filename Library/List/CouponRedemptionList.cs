﻿using System.Xml;

namespace Recurly
{
    public class CouponRedemptionList : RecurlyList<CouponRedemption>
    {

        protected internal CouponRedemptionList()
        {
        }

        protected internal CouponRedemptionList(string baseUrl) : base(Client.HttpRequestMethod.Get, baseUrl)
        {
        }

        public override RecurlyList<CouponRedemption> Start
        {
            get { return HasStartPage() ? new CouponRedemptionList(StartUrl) : RecurlyList.Empty<CouponRedemption>(); }
        }

        public override RecurlyList<CouponRedemption> Next
        {
            get { return HasNextPage() ? new CouponRedemptionList(NextUrl) : RecurlyList.Empty<CouponRedemption>(); }
        }

        public override RecurlyList<CouponRedemption> Prev
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