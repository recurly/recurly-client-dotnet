using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Net;

namespace Recurly
{
    public class CouponRedemptionList : RecurlyList<CouponRedemption>
    {

        internal override void ReadXml(XmlTextReader reader)
        {
            while (reader.Read())
            {
                if (reader.Name.Equals("redemptions") &&
                    reader.NodeType == XmlNodeType.EndElement)
                    break;

                if (reader.NodeType == XmlNodeType.Element && reader.Name.Equals("redemption"))
                {
                    this.Add(new CouponRedemption(reader));
                }
            }

        }
    }
}