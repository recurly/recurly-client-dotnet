using System;
using System.Collections.Generic;
using System.Net;
using System.Xml;
using System.Text;

namespace Recurly
{
    public class RecurlyAccountCoupon
    {
        public string AccountCode { get; private set; }
        public string CouponCode { get; private set; }
        public string Name { get; private set; }
        public int? DiscountInCents { get; private set; }
        public int? DiscountPercent { get; private set; }
        public DateTime RedeemedAt { get; private set; }

        #region Constructors

        internal RecurlyAccountCoupon()
        {
        }

        internal RecurlyAccountCoupon(XmlTextReader xmlReader)
        {
            ReadXml(xmlReader);
        }

        #endregion

        private const string UrlPrefix = "/accounts/";
        private const string UrlPostfix = "/coupon";

        private static string CouponUrl(string accountCode)
        {
            return UrlPrefix + System.Web.HttpUtility.UrlEncode(accountCode) + UrlPostfix;
        }

        /// <summary>
        /// Look up a coupon for an account
        /// </summary>
        /// <param name="accountCode">Account code</param>
        /// <returns></returns>
        public static RecurlyAccountCoupon Get(string accountCode)
        {
            RecurlyAccountCoupon coupon = new RecurlyAccountCoupon();

            HttpStatusCode statusCode = RecurlyClient.PerformRequest(RecurlyClient.HttpRequestMethod.Get,
                CouponUrl(accountCode),
                new RecurlyClient.ReadXmlDelegate(coupon.ReadXml));

            if (statusCode == HttpStatusCode.NotFound)
                return null;

            return coupon;
        }

        /// <summary>
        /// Redeem a coupon on an account.
        /// </summary>
        /// <param name="accountCode"></param>
        /// <param name="couponCode"></param>
        /// <returns></returns>
        public static RecurlyAccountCoupon Redeem(string accountCode, string couponCode)
        {
            RecurlyAccountCoupon coupon = new RecurlyAccountCoupon();
            coupon.AccountCode = accountCode;
            coupon.CouponCode = couponCode;

            HttpStatusCode statusCode = RecurlyClient.PerformRequest(RecurlyClient.HttpRequestMethod.Post,
                CouponUrl(coupon.AccountCode),
                new RecurlyClient.WriteXmlDelegate(coupon.WriteXml),
                new RecurlyClient.ReadXmlDelegate(coupon.ReadXml));

            return coupon;
        }

        /// <summary>
        /// Remove the active coupon on an account.
        /// </summary>
        /// <param name="accountCode">Account code</param>
        public static void RemoveCoupon(string accountCode)
        {
            RecurlyClient.PerformRequest(RecurlyClient.HttpRequestMethod.Delete, CouponUrl(accountCode));
        }

        /// <summary>
        /// Remove this coupon from the account. It will no longer be applied to future invoices.
        /// </summary>
        public void Remove()
        {
            RemoveCoupon(this.AccountCode);
        }

        #region Read and Write XML documents

        internal void ReadXml(XmlTextReader reader)
        {
            while (reader.Read())
            {
                // End of coupon element, get out of here
                if (reader.Name == "coupon" && reader.NodeType == XmlNodeType.EndElement)
                    break;

                if (reader.NodeType == XmlNodeType.Element)
                {
                    switch (reader.Name)
                    {
                        case "coupon_code":
                            this.CouponCode = reader.ReadElementContentAsString();
                            break;

                        case "account_code":
                            this.AccountCode = reader.ReadElementContentAsString();
                            break;

                        case "name":
                            this.Name = reader.ReadElementContentAsString();
                            break;

                        case "redeemed_at":
                            DateTime date;
                            if (DateTime.TryParse(reader.ReadElementContentAsString(), out date))
                                this.RedeemedAt = date;
                            break;

                        case "discount_in_cents":
                            int discountInCents;
                            if (Int32.TryParse(reader.ReadElementContentAsString(), out discountInCents))
                                this.DiscountInCents = discountInCents;
                            break;

                        case "discount_percent":
                            int discountPercent;
                            if (Int32.TryParse(reader.ReadElementContentAsString(), out discountPercent))
                                this.DiscountPercent = discountPercent;
                            break;
                    }
                }
            }
        }

        internal void WriteXml(XmlTextWriter xmlWriter)
        {
            xmlWriter.WriteStartElement("coupon"); // Start: coupon

            xmlWriter.WriteElementString("coupon_code", this.CouponCode);

            xmlWriter.WriteEndElement(); // End: coupon
        }

        #endregion

        #region Object Overrides

        public override string ToString()
        {
            return "Recurly Account Coupon: " + this.CouponCode;
        }

        public override bool Equals(object obj)
        {
            if (obj is RecurlyAccountCoupon)
                return Equals((RecurlyAccountCoupon)obj);
            else
                return false;
        }

        public bool Equals(RecurlyAccountCoupon coupon)
        {
            return this.AccountCode == coupon.AccountCode && this.CouponCode == coupon.CouponCode;
        }

        public override int GetHashCode()
        {
            return (this.AccountCode + this.CouponCode).GetHashCode();
        }

        #endregion
    }
}
