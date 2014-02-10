﻿using System.Xml;

namespace Recurly
{
    public class CouponList : RecurlyList<Coupon>
    {
        internal CouponList(string baseUrl) : base(Client.HttpRequestMethod.Get, baseUrl)
        {
        }

        public override RecurlyList<Coupon> Start
        {
            get { return new CouponList(StartUrl); }
        }

        public override RecurlyList<Coupon> Next
        {
            get { return new CouponList(NextUrl); }
        }

        public override RecurlyList<Coupon> Prev
        {
            get { return new CouponList(PrevUrl); }
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