using System;
using System.Collections.Generic;
using System.Net;
using System.Xml;

namespace Recurly
{
    public class Coupon : RecurlyEntity
    {
        public enum CouponState : short
        {
            All = 0,
            Redeemable,
            Expired,
            Inactive,
            MaxedOut
        }

        public enum CouponDiscountType
        {
            Percent,
            Dollars
        }

        public RecurlyList<CouponRedemption> Redemptions { get; private set; }

        public string CouponCode { get; set; }
        public string Name { get; set; }
        public string HostedDescription { get; set; }
        public string InvoiceDescription { get; set; }
        public DateTime? RedeemByDate { get; set; }
        public bool? SingleUse { get; set; }
        public int? AppliesForMonths { get; set; }
        public int? MaxRedemptions { get; set; }
        public bool? AppliesToAllPlans { get; set; }

        public CouponDiscountType DiscountType { get; private set; }
        public CouponState State { get; private set; }

        /// <summary>
        /// A dictionary of currencies and discounts
        /// </summary>
        public Dictionary<string, int> DiscountInCents { get; private set; }
        public int? DiscountPercent { get; private set; }

        /// <summary>
        /// A list of plans to limit the coupon
        /// </summary>

        private List<string> _plans;

        public List<string> Plans
        {
            get { return _plans ?? (_plans = new List<string>()); }
        }

        public DateTime CreatedAt { get; private set; }


        #region Constructors

        internal Coupon()
        {
        }

        internal Coupon(XmlTextReader xmlReader)
        {
            ReadXml(xmlReader);
        }

        /// <summary>
        /// Creates a coupon, discounted by a fixed amount
        /// </summary>
        /// <param name="couponCode"></param>
        /// <param name="name"></param>
        /// <param name="discountInCents">dictionary of currencies and discounts</param>
        public Coupon(string couponCode, string name, Dictionary<string, int> discountInCents)
        {
            CouponCode = couponCode;
            Name = name;
            DiscountInCents = discountInCents;
            DiscountType = CouponDiscountType.Dollars;
        }

        /// <summary>
        /// Creates a coupon, discounted by percentage
        /// </summary>
        /// <param name="couponCode"></param>
        /// <param name="name"></param>
        /// <param name="discountPercent"></param>
        public Coupon(string couponCode, string name, int discountPercent)
        {
            CouponCode = couponCode;
            Name = name;
            DiscountPercent = discountPercent;
            DiscountType = CouponDiscountType.Percent;
        }

        #endregion

        internal const string UrlPrefix = "/coupons/";

        /// <summary>
        /// Creates this coupon.
        /// </summary>
        public void Create()
        {
            Client.Instance.PerformRequest(Client.HttpRequestMethod.Post,
                UrlPrefix, 
                WriteXml,
                ReadXml);
        }

        /// <summary>
        /// Deactivates this coupon.
        /// </summary>
        public void Deactivate()
        {
            Client.Instance.PerformRequest(Client.HttpRequestMethod.Delete,
                UrlPrefix + Uri.EscapeUriString(CouponCode));
        }


        #region Read and Write XML documents

        internal override void ReadXml(XmlTextReader reader)
        {
            while (reader.Read())
            {
                // End of coupon element, get out of here
                if (reader.Name == "coupon" && reader.NodeType == XmlNodeType.EndElement)
                    break;

                if (reader.NodeType != XmlNodeType.Element) continue;

                DateTime date;
                int m;
                switch (reader.Name)
                {
                    case "coupon_code":
                        CouponCode = reader.ReadElementContentAsString();
                        break;
                     
                    case "name":
                        Name = reader.ReadElementContentAsString();
                        break;

                    case "state":
                        State = reader.ReadElementContentAsString().ParseAsEnum<CouponState>();
                        break;

                    case "discount_type":
                        DiscountType = reader.ReadElementContentAsString().ParseAsEnum<CouponDiscountType>();
                        break;

                    case "discount_percent":
                        DiscountPercent = reader.ReadElementContentAsInt();
                        break;

                    case "redeem_by_date":
                        if (DateTime.TryParse(reader.ReadElementContentAsString(), out date))
                            RedeemByDate = date;
                        break;

                    case "single_use":
                        SingleUse = reader.ReadElementContentAsBoolean();
                        break;

                    case "applies_for_months":
                        if (int.TryParse(reader.ReadElementContentAsString(), out m))
                            AppliesForMonths = m;
                        break;

                    case "max_redemptions":
                        if (int.TryParse(reader.ReadElementContentAsString(), out m))
                            MaxRedemptions = m;
                        break;

                    case "applies_to_all_plans":
                        AppliesToAllPlans = reader.ReadElementContentAsBoolean();
                        break;

                    case "created_at":
                        if (DateTime.TryParse(reader.ReadElementContentAsString(), out date))
                            CreatedAt = date;
                        break;

                    case "plan_codes":
                        ReadXmlPlanCodes(reader);
                        break;

                    case "discount_in_cents":
                        ReadXmlDiscounts(reader);
                        break;
                        
                }
            }
        }

        internal void ReadXmlPlanCodes(XmlTextReader reader)
        {
            while (reader.Read())
            {
                if (reader.Name == "plan_codes" && reader.NodeType == XmlNodeType.EndElement)
                    break;

                if (reader.NodeType != XmlNodeType.Element) continue;
                switch (reader.Name)
                {
                    case "plan_code":
                        Plans.Add(reader.ReadElementContentAsString());
                        break;

                }
            }
        }

        internal void ReadXmlDiscounts(XmlTextReader reader)
        {            
            DiscountInCents = new Dictionary<string, int>();

            while (reader.Read())
            {
                if (reader.Name == "discount_in_cents" && reader.NodeType == XmlNodeType.EndElement)
                    break;

                if (reader.NodeType == XmlNodeType.Element)
                {
                    DiscountInCents.Add(reader.Name, reader.ReadElementContentAsInt());
                }
            }
        }

        internal override void WriteXml(XmlTextWriter xmlWriter)
        {
            xmlWriter.WriteStartElement("coupon"); // Start: coupon

            xmlWriter.WriteElementString("coupon_code", CouponCode);
            xmlWriter.WriteElementString("name", Name);
            xmlWriter.WriteElementString("hosted_description", HostedDescription);
            xmlWriter.WriteElementString("invoice_description", InvoiceDescription);

            if (RedeemByDate.HasValue)
                xmlWriter.WriteElementString("redeem_by_date", RedeemByDate.Value.ToString("s"));

            if (SingleUse.HasValue)
                xmlWriter.WriteElementString("single_use", SingleUse.Value.AsString());

            if (AppliesForMonths.HasValue)
                xmlWriter.WriteElementString("applies_for_months", AppliesForMonths.Value.AsString());

            if (AppliesToAllPlans.HasValue)
                xmlWriter.WriteElementString("applies_to_all_plans", AppliesToAllPlans.Value.AsString());

            if(MaxRedemptions.HasValue)
                xmlWriter.WriteElementString("max_redemptions", MaxRedemptions.Value.AsString());

            xmlWriter.WriteElementString("discount_type", DiscountType.ToString().EnumNameToTransportCase());

            if (CouponDiscountType.Percent == DiscountType && DiscountPercent.HasValue)
                xmlWriter.WriteElementString("discount_percent", DiscountPercent.Value.AsString());

            if (CouponDiscountType.Dollars == DiscountType)
            {
                xmlWriter.WriteIfCollectionHasAny("discount_in_cents", DiscountInCents, pair => pair.Key,
                    pair => pair.Value.AsString());
            }

            xmlWriter.WriteIfCollectionHasAny("plan_codes", Plans, s => "plan_code", s => s);

            xmlWriter.WriteEndElement(); // End: coupon
        }

        #endregion

        #region Object Overrides

        public override string ToString()
        {
            return "Recurly Account Coupon: " + CouponCode;
        }

        public override bool Equals(object obj)
        {
            var coupon = obj as Coupon;
            return coupon != null && Equals(coupon);
        }

        public bool Equals(Coupon coupon)
        {
            return CouponCode == coupon.CouponCode;
        }

        public override int GetHashCode()
        {
            return CouponCode.GetHashCode();
        }

        #endregion
    }

    public sealed class Coupons
    {
        /// <summary>
        /// Look up a coupon
        /// </summary>
        /// <param name="couponCode">Coupon code</param>
        /// <returns></returns>
        public static Coupon Get(string couponCode)
        {
            var coupon = new Coupon();

            var statusCode = Client.Instance.PerformRequest(Client.HttpRequestMethod.Get,
                Coupon.UrlPrefix + Uri.EscapeUriString(couponCode),
                coupon.ReadXml);

            return statusCode == HttpStatusCode.NotFound ? null : coupon;
        }

        /// <summary>
        /// Lists coupons, limited to state
        /// </summary>
        /// <param name="state">Account state to retrieve</param>
        /// <returns></returns>
        public static RecurlyList<Coupon> List(Coupon.CouponState state = Coupon.CouponState.All)
        {
            return new CouponList(Coupon.UrlPrefix + (state != Coupon.CouponState.All ? "?state=" + state.ToString().EnumNameToTransportCase() : ""));
        }
    }
}
