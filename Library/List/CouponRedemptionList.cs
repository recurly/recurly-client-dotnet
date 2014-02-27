using System.Xml;

namespace Recurly
{
    public class CouponRedemptionList : RecurlyList<CouponRedemption>
    {
        public override RecurlyList<CouponRedemption> Start
        {
            get { throw new System.NotImplementedException(); }
        }

        public override RecurlyList<CouponRedemption> Next
        {
            get { throw new System.NotImplementedException(); }
        }

        public override RecurlyList<CouponRedemption> Prev
        {
            get { throw new System.NotImplementedException(); }
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