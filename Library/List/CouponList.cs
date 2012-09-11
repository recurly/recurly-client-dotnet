using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Net;

namespace Recurly
{
    public class CouponList : RecurlyList<Coupon>
    {

        internal void ReadXml(XmlTextReader reader)
        {

            while (reader.Read())
            {
                if (reader.Name.Equals("coupons") &&
                    reader.NodeType == XmlNodeType.EndElement)
                    break;

                if (reader.NodeType == XmlNodeType.Element)
                {
                    this.Add(new Coupon(reader));
                }
            }

        }

        /// <summary>
        /// Lists coupons, limited to state
        /// </summary>
        /// <param name="state">Account state to retrieve</param>
        /// <returns></returns>
        public static CouponList List(Coupon.CouponState state = Coupon.CouponState.all)
        {
            CouponList l = new CouponList();
            HttpStatusCode statusCode = Client.PerformRequest(Client.HttpRequestMethod.Get,
                Coupon.UrlPrefix + (state != Coupon.CouponState.all ? "?state=" + state.ToString() : ""),
                new Client.ReadXmlDelegate(l.ReadXml));

            if (statusCode == HttpStatusCode.NotFound)
                return null;

            return l;
        }


    }

}