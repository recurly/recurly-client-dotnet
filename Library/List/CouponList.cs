using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Net;

namespace Recurly
{
    public class CouponList : RecurlyList<Coupon>
    {

        internal override void ReadXml(XmlTextReader reader)
        {

            while (reader.Read())
            {
                if (reader.Name.Equals("coupons") &&
                    reader.NodeType == XmlNodeType.EndElement)
                    break;

                if (reader.NodeType == XmlNodeType.Element && reader.Name.Equals("coupon"))
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
            l.BaseUrl = Coupon.UrlPrefix + (state != Coupon.CouponState.all ? "?state=" + state.ToString() : "");
            HttpStatusCode statusCode = Client.PerformRequest(Client.HttpRequestMethod.Get, l.BaseUrl, new Client.ReadXmlListDelegate(l.ReadXmlList));

            if (statusCode == HttpStatusCode.NotFound)
                return null;

            return l;
        }


    }

}