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
    public class RecurlyAccount : RecurlyClient
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

        private const string UrlPrefix = "/accounts/";

        public RecurlyAccount(string accountCode)
        {
            this.AccountCode = accountCode;
        }

        /// <summary>
        /// Lookup a Recurly account
        /// </summary>
        /// <param name="accountCode"></param>
        /// <returns></returns>
        public static RecurlyAccount Get(string accountCode)
        {
            HttpStatusCode statusCode;
            string accountXml = PerformRequest(HttpRequestMethod.Get, 
                UrlPrefix + System.Web.HttpUtility.UrlEncode(accountCode), out statusCode);

            if (statusCode == HttpStatusCode.NotFound)
                return null;

            return new RecurlyAccount(accountCode);
        }

        /// <summary>
        /// Create a new account in Recurly
        /// </summary>
        public void Create()
        {
            PerformRequest(HttpRequestMethod.Post, UrlPrefix, 
                new WriteXmlDelegate(this.WriteXml));
        }

        /// <summary>
        /// Update an existing account in Recurly
        /// </summary>
        public void Update()
        {
            PerformRequest(HttpRequestMethod.Put, UrlPrefix + System.Web.HttpUtility.UrlEncode(this.AccountCode),
                new WriteXmlDelegate(this.WriteXml));
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
            PerformRequest(HttpRequestMethod.Delete, UrlPrefix + System.Web.HttpUtility.UrlEncode(accountCode));
        }

        protected void WriteXml(XmlTextWriter xmlWriter)
        {
            xmlWriter.WriteStartElement("account"); // Start: account

            xmlWriter.WriteElementString("account_code", this.AccountCode);
            xmlWriter.WriteElementString("username", this.Username);
            xmlWriter.WriteElementString("email", this.Email);
            xmlWriter.WriteElementString("first_name", this.FirstName);
            xmlWriter.WriteElementString("last_name", this.LastName);
            xmlWriter.WriteElementString("company_name", this.CompanyName);

            xmlWriter.WriteEndAttribute(); // End: account
        }
    }
}
