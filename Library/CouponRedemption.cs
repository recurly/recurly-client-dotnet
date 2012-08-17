using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Net;


namespace Recurly
{
    /// <summary>
    /// Represents an instance where a coupon has been redeemed for a subscription
    /// </summary>
    public class CouponRedemption
    {

        public string AccountCode { get; set; }
        public string CouponCode { get; private set; }
        public string Currency { get; set; }

        public bool SingleUse { get; private set; }
        public int TotalDiscountedInCents { get; private set; }

        public DateTime CreatedAt { get; private set; }

        public string State { get; private set; }

        private const string UrlPrefix = "/accounts/";
        private const string UrlPostfix = "/redemption";

        internal CouponRedemption(XmlTextReader reader)
            : this()
        {
            ReadXml(reader);
        }

        internal CouponRedemption()
        {

        }


        /// <summary>
        /// Redeem an active coupon for an account
        /// </summary>
        /// <param name="accountCode"></param>
        /// <param name="currency"></param>
        internal static CouponRedemption Redeem(string accountCode, string couponCode, string currency)
        {
            CouponRedemption cr = new CouponRedemption();

            cr.AccountCode = accountCode;
            cr.Currency = currency;

            HttpStatusCode statusCode = Client.PerformRequest(Client.HttpRequestMethod.Post,
               "/coupons/" + System.Uri.EscapeUriString(couponCode) + "/redeem",
               new Client.WriteXmlDelegate(cr.WriteXml),
               new Client.ReadXmlDelegate(cr.ReadXml)).StatusCode;

            return cr;

        }

        /// <summary>
        /// Removes a coupon from an account
        /// </summary>
        public void Delete()
        {
            HttpStatusCode statusCode = Client.PerformRequest(Client.HttpRequestMethod.Delete,
                "/accounts/" + System.Uri.EscapeUriString(this.AccountCode) + "/redemption" ).StatusCode;
            this.AccountCode = null;
            this.CouponCode = null;
            this.Currency = null;
        }



        #region Read and Write XML documents

        internal void ReadXml(XmlTextReader reader)
        {
            string href;

            while (reader.Read())
            {
                // End of coupon element, get out of here
                if (reader.Name == "coupon" && reader.NodeType == XmlNodeType.EndElement)
                    break;

                if (reader.NodeType == XmlNodeType.Element)
                {
                    switch (reader.Name)
                    {
                        case "account":
                            href = reader.GetAttribute("href");
                            this.AccountCode = Uri.UnescapeDataString(href.Substring(href.LastIndexOf("/") + 1));
                            break;

                        case "coupon":
                            href = reader.GetAttribute("href");
                            this.CouponCode =Uri.UnescapeDataString( href.Substring(href.LastIndexOf("/") + 1));
                            break;

                        case "single_use":
                            this.SingleUse = reader.ReadElementContentAsBoolean();
                            break;

                        case "total_discounted_in_cents":
                            int discountInCents;
                            if (Int32.TryParse(reader.ReadElementContentAsString(), out discountInCents))
                                this.TotalDiscountedInCents = discountInCents;
                            break;

                        case "currency":
                            this.Currency = reader.ReadElementContentAsString();
                            break;

                        case "state":
                            this.State = reader.ReadElementContentAsString();
                            break;

                        case "created_at":
                            DateTime date;
                            if (DateTime.TryParse(reader.ReadElementContentAsString(), out date))
                                this.CreatedAt = date;
                            break;

                    }
                }
            }
        }

        internal void WriteXml(XmlTextWriter xmlWriter)
        {
            xmlWriter.WriteStartElement("redemption"); // Start: coupon

            xmlWriter.WriteElementString("account_code", this.AccountCode);
            xmlWriter.WriteElementString("currency", this.Currency);

            xmlWriter.WriteEndElement(); // End: coupon
        }

        #endregion

        #region Object Overrides

        public override string ToString()
        {
            return "Recurly Account Coupon Redemption: " + this.CouponCode + " " + this.AccountCode;
        }

        public override bool Equals(object obj)
        {
            if (obj is CouponRedemption)
                return Equals((CouponRedemption)obj);
            else
                return false;
        }

        public bool Equals(CouponRedemption coupon)
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
