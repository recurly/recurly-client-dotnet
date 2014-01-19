using System;
using System.Xml;


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
            var cr = new CouponRedemption {AccountCode = accountCode, Currency = currency};

            var statusCode = Client.PerformRequest(Client.HttpRequestMethod.Post,
               "/coupons/" + Uri.EscapeUriString(couponCode) + "/redeem",
               cr.WriteXml,
               cr.ReadXml);

            return cr;

        }

        /// <summary>
        /// Removes a coupon from an account
        /// </summary>
        public void Delete()
        {
            var statusCode = Client.PerformRequest(Client.HttpRequestMethod.Delete,
                "/accounts/" + Uri.EscapeUriString(AccountCode) + "/redemption" );
            AccountCode = null;
            CouponCode = null;
            Currency = null;
        }



        #region Read and Write XML documents

        internal void ReadXml(XmlTextReader reader)
        {
            while (reader.Read())
            {
                // End of coupon element, get out of here
                if (reader.Name == "coupon" && reader.NodeType == XmlNodeType.EndElement)
                    break;

                if (reader.NodeType != XmlNodeType.Element) continue;

                string href;
                switch (reader.Name)
                {
                    case "account":
                        href = reader.GetAttribute("href");
                        AccountCode = Uri.UnescapeDataString(href.Substring(href.LastIndexOf("/") + 1));
                        break;

                    case "coupon":
                        href = reader.GetAttribute("href");
                        CouponCode =Uri.UnescapeDataString( href.Substring(href.LastIndexOf("/") + 1));
                        break;

                    case "single_use":
                        SingleUse = reader.ReadElementContentAsBoolean();
                        break;

                    case "total_discounted_in_cents":
                        int discountInCents;
                        if (Int32.TryParse(reader.ReadElementContentAsString(), out discountInCents))
                            TotalDiscountedInCents = discountInCents;
                        break;

                    case "currency":
                        Currency = reader.ReadElementContentAsString();
                        break;

                    case "state":
                        State = reader.ReadElementContentAsString();
                        break;

                    case "created_at":
                        DateTime date;
                        if (DateTime.TryParse(reader.ReadElementContentAsString(), out date))
                            CreatedAt = date;
                        break;

                }
            }
        }

        internal void WriteXml(XmlTextWriter xmlWriter)
        {
            xmlWriter.WriteStartElement("redemption"); // Start: coupon

            xmlWriter.WriteElementString("account_code", AccountCode);
            xmlWriter.WriteElementString("currency", Currency);

            xmlWriter.WriteEndElement(); // End: coupon
        }

        #endregion

        #region Object Overrides

        public override string ToString()
        {
            return "Recurly Account Coupon Redemption: " + CouponCode + " " + AccountCode;
        }

        public override bool Equals(object obj)
        {
            var redemption = obj as CouponRedemption;
            return redemption != null && Equals(redemption);
        }

        public bool Equals(CouponRedemption coupon)
        {
            return AccountCode == coupon.AccountCode && CouponCode == coupon.CouponCode;
        }

        public override int GetHashCode()
        {
            return (AccountCode + CouponCode).GetHashCode();
        }

        #endregion

        
    }
}
