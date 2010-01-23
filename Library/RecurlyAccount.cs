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

            HttpStatusCode statusCode = PerformRequest(HttpRequestMethod.Get,
                UrlPrefix + System.Web.HttpUtility.UrlEncode(accountCode),
                new ReadXmlDelegate(account.ReadXml));

            if (statusCode == HttpStatusCode.NotFound)
                return null;

            return account;
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
                    }
                }
            }
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
