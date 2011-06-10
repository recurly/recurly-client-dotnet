using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Xml;

namespace Recurly
{
    /// <summary>
    /// An account in Recurly.
    /// </summary>
    public class RecurlyAccount
    {
        /// <summary>
        /// Account Code or unique ID for the account in Recurly
        /// </summary>
        public string AccountCode { get; private set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CompanyName { get; set; }
        public RecurlyBillingInfo BillingInfo { get; set; }
        public string AcceptLanguage { get; set; }
        public string HostedLoginToken { get; private set; }

        internal const string UrlPrefix = "/accounts/";

        public RecurlyAccount(string accountCode)
        {
            this.AccountCode = accountCode;
        }

        internal RecurlyAccount(XmlTextReader xmlReader)
        {
            this.ReadXml(xmlReader);
        }

        private RecurlyAccount()
        { }

        /// <summary>
        /// Lookup a Recurly account
        /// </summary>
        /// <param name="accountCode"></param>
        /// <returns></returns>
        public static RecurlyAccount Get(string accountCode)
        {
            RecurlyAccount account = new RecurlyAccount();

            HttpStatusCode statusCode = RecurlyClient.PerformRequest(RecurlyClient.HttpRequestMethod.Get,
                UrlPrefix + System.Web.HttpUtility.UrlEncode(accountCode),
                new RecurlyClient.ReadXmlDelegate(account.ReadXml));

            if (statusCode == HttpStatusCode.NotFound)
                return null;

            return account;
        }

        /// <summary>
        /// Create a new account in Recurly
        /// </summary>
        public void Create()
        {
            RecurlyClient.PerformRequest(RecurlyClient.HttpRequestMethod.Post, 
                UrlPrefix,
                new RecurlyClient.WriteXmlDelegate(this.WriteXml));
        }

        /// <summary>
        /// Update an existing account in Recurly
        /// </summary>
        public void Update()
        {
            RecurlyClient.PerformRequest(RecurlyClient.HttpRequestMethod.Put, 
                UrlPrefix + System.Web.HttpUtility.UrlEncode(this.AccountCode),
                new RecurlyClient.WriteXmlDelegate(this.WriteXml));
        }

        /// <summary>
        /// Close the account and cancel any active subscriptions (if there is one).
        /// Note: This does not create a refund for any time remaining.
        /// </summary>
        public void CloseAccount()
        {
            CloseAccount(this.AccountCode);
        }

        /// <summary>
        /// Close the account and cancel any active subscriptions (if there is one).
        /// Note: This does not create a refund for any time remaining.
        /// </summary>
        /// <param name="id">Account Code</param>
        public static void CloseAccount(string accountCode)
        {
            RecurlyClient.PerformRequest(RecurlyClient.HttpRequestMethod.Delete, UrlPrefix + System.Web.HttpUtility.UrlEncode(accountCode));
        }

        /// <summary>
        /// Lookup the active coupon for this account.
        /// </summary>
        /// <returns></returns>
        public RecurlyAccountCoupon GetActiveCoupon()
        {
            return RecurlyAccountCoupon.Get(this.AccountCode);
        }

        /// <summary>
        /// Redeem a coupon on the account.
        /// </summary>
        /// <param name="couponCode"></param>
        /// <returns></returns>
        public RecurlyAccountCoupon RedeemCoupon(string couponCode)
        {
            return RecurlyAccountCoupon.Redeem(this.AccountCode, couponCode);
        }

        #region Read and Write XML documents

        internal void ReadXml(XmlTextReader reader)
        {
            while (reader.Read())
            {
                // End of account element, get out of here
                if (reader.Name == "account" && reader.NodeType == XmlNodeType.EndElement)
                    break;

                if (reader.NodeType == XmlNodeType.Element)
                {
                    switch (reader.Name)
                    {
                        case "account_code":
                            this.AccountCode = reader.ReadElementContentAsString();
                            break;

                        case "username":
                            this.Username = reader.ReadElementContentAsString();
                            break;

                        case "first_name":
                            this.FirstName = reader.ReadElementContentAsString();
                            break;

                        case "last_name":
                            this.LastName = reader.ReadElementContentAsString();
                            break;

                        case "email":
                            this.Email = reader.ReadElementContentAsString();
                            break;

                        case "company_name":
                            this.CompanyName = reader.ReadElementContentAsString();
                            break;

                        case "accept_language":
                            this.AcceptLanguage = reader.ReadElementContentAsString();
                            break;

                        case "hosted_login_token":
                            this.HostedLoginToken = reader.ReadElementContentAsString();
                            break;
                    }
                }
            }
        }

        internal void WriteXml(XmlTextWriter xmlWriter)
        {
            xmlWriter.WriteStartElement("account"); // Start: account

            xmlWriter.WriteElementString("account_code", this.AccountCode);
            xmlWriter.WriteElementString("username", this.Username);
            xmlWriter.WriteElementString("email", this.Email);
            xmlWriter.WriteElementString("first_name", this.FirstName);
            xmlWriter.WriteElementString("last_name", this.LastName);
            xmlWriter.WriteElementString("company_name", this.CompanyName);
            xmlWriter.WriteElementString("accept_language", this.AcceptLanguage);

            if (this.BillingInfo != null)
                this.BillingInfo.WriteXml(xmlWriter);

            xmlWriter.WriteEndElement(); // End: account
        }

        #endregion

        #region Object Overrides

        public override string ToString()
        {
            return "Recurly Account: " + this.AccountCode;
        }

        public override bool Equals(object obj)
        {
            if (obj is RecurlyAccount)
                return Equals((RecurlyAccount)obj);
            else
                return false;
        }

        public bool Equals(RecurlyAccount account)
        {
            return this.AccountCode == account.AccountCode;
        }

        public override int GetHashCode()
        {
            return this.AccountCode.GetHashCode();
        }

        #endregion
    }
}