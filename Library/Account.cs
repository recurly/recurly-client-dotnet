using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Xml;

namespace Recurly
{
    /// <summary>
    /// An account in Recurly.
    /// 
    /// http://docs.recurly.com/api/accounts
    /// </summary>
    public class Account
    {

        // The currently valid account states
        public enum AccountState : short
        {
            Active,
            Closed,
            Past_Due
        }


        /// <summary>
        /// Account Code or unique ID for the account in Recurly
        /// </summary>
        public string AccountCode { get; private set; }
        public AccountState State { get; private set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CompanyName { get; set; }
        public string AcceptLanguage { get; set; }
        public string HostedLoginToken { get; private set; }
        public DateTime CreatedAt { get; private set; }

        private BillingInfo _billingInfo;

        public BillingInfo BillingInfo
        {
            get
            {
                if (null == _billingInfo)
                {
                    _billingInfo = BillingInfo.Get(this.AccountCode);
                }

                return _billingInfo;
            }
            set
            {
                _billingInfo = value;
            }
        }

        internal const string UrlPrefix = "/accounts/";

        public Account(string accountCode)
        {
            this.AccountCode = accountCode;
        }

        internal Account(XmlTextReader xmlReader)
        {
            this.ReadXml(xmlReader);
        }

        private Account()
        { }

        /// <summary>
        /// Lookup a Recurly account
        /// </summary>
        /// <param name="accountCode"></param>
        /// <returns></returns>
        public static Account Get(string accountCode)
        {
            Account account = new Account();

            HttpStatusCode statusCode = Client.PerformRequest(Client.HttpRequestMethod.Get,
                UrlPrefix + System.Web.HttpUtility.UrlEncode(accountCode),
                new Client.ReadXmlDelegate(account.ReadXml)).StatusCode;

            if (statusCode == HttpStatusCode.NotFound)
                return null;

            return account;
        }

        /// <summary>
        /// Lists all accounts: active, closed, past due
        /// </summary>
        /// <returns></returns>
        public static List<Account> List()
        {
            return List(null);
        }

        /// <summary>
        /// Lists accounts, limited to state
        /// </summary>
        /// <param name="state">Account state to retrieve</param>
        /// <returns></returns>
        public static List<Account> List(AccountState state)
        {
            return List(state.ToString());
        }
        
        /// <summary>
        /// Create a new account in Recurly
        /// </summary>
        public void Create()
        {
            Client.PerformRequest(Client.HttpRequestMethod.Post,
                UrlPrefix,
                new Client.WriteXmlDelegate(this.WriteXml));
        }

        /// <summary>
        /// Update an existing account in Recurly
        /// </summary>
        public void Update()
        {
            Client.PerformRequest(Client.HttpRequestMethod.Put,
                UrlPrefix + System.Web.HttpUtility.UrlEncode(this.AccountCode),
                new Client.WriteXmlDelegate(this.WriteXml));
        }

        /// <summary>
        /// Close the account and cancel any active subscriptions (if there is one).
        /// Note: This does not create a refund for any time remaining.
        /// </summary>
        public void Close()
        {
            Close(this.AccountCode);
            this.State = AccountState.Closed;

        }

        /// <summary>
        /// Close the account and cancel any active subscriptions (if there is one).
        /// Note: This does not create a refund for any time remaining.
        /// </summary>
        /// <param name="id">Account Code</param>
        public static void Close(string accountCode)
        {
            Client.PerformRequest(Client.HttpRequestMethod.Delete, UrlPrefix + System.Web.HttpUtility.UrlEncode(accountCode));
        }

        /// <summary>
        /// Reopen an existing account in Recurly
        /// </summary>
        public void Reopen()
        {
            Reopen(this.AccountCode);
            this.State = AccountState.Active;
        }

        /// <summary>
        /// Reopen an existing account in recurly.
        /// </summary>
        /// <param name="accountCode">Account Code</param>
        public static void Reopen(string accountCode)
        {
            Client.PerformRequest(Client.HttpRequestMethod.Put,
                UrlPrefix + System.Web.HttpUtility.UrlEncode(accountCode) + "/reopen");
        }

        /// <summary>
        /// Gets all adjustments for this account
        /// </summary>
        /// <returns></returns>
        public RecurlyList<Adjustment> GetAdjustments()
        {
            throw new NotSupportedException("Not yet implemented");
        }

        /// <summary>
        /// Gets all adjustments for this account, by type
        /// </summary>
        /// <param name="type">Adjustment type to retrieve</param>
        /// <returns></returns>
        public RecurlyList<Adjustment> GetAdjustments(Adjustment.AdjustmentType type)
        {
            throw new NotSupportedException("Not yet implemented");
        }



        /// <summary>
        /// Lookup the active coupon for this account.
        /// </summary>
        /// <returns></returns>
        public Coupon GetActiveCoupon()
        {
            return Coupon.Get(this.AccountCode);
        }

        
        /// <summary>
        /// Returns a list of invoices for this account
        /// </summary>
        /// <returns></returns>
        public RecurlyList<Invoice> GetInvoices()
        {
            return Invoice.GetInvoices(this.AccountCode);
        }

        /// <summary>
        /// Returns a list of invoices in a specific state
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        public RecurlyList<Invoice> GetInvoices(Invoice.InvoiceState state)
        {
            throw new NotSupportedException("Not yet supported.");
        }

      

        /// <summary>
        /// Returns a list of subscriptions for this account
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        public RecurlyList<Subscription> GetSubscriptions(Subscription.SubstriptionState state = Subscription.SubstriptionState.All)
        {
            RecurlyList<Subscription> l = new RecurlyList<Subscription>();
            HttpStatusCode statusCode = Client.PerformRequest(Client.HttpRequestMethod.Get,
                UrlPrefix + System.Web.HttpUtility.UrlEncode(this.AccountCode) + "/subscriptions/"
                + "state=" + state.ToString(),
                new Client.ReadXmlDelegate(l.ReadXml)).StatusCode;

            if (statusCode == HttpStatusCode.NotFound)
                return null;

            return l;
        }

       
        /// <summary>
        /// Returns a list of transactions for this account, by transaction type
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        public RecurlyList<Transaction> GetTransactions(Transaction.TransactionState state = Transaction.TransactionState.All,
            Transaction.TransactionType type = Transaction.TransactionType.All)
        {
            RecurlyList<Transaction> l = new RecurlyList<Transaction>();
            HttpStatusCode statusCode = Client.PerformRequest(Client.HttpRequestMethod.Get,
                UrlPrefix + System.Web.HttpUtility.UrlEncode(this.AccountCode) + "/transactions/"
                + "state=" + state.ToString() + 
                "&type=" + type.ToString(),
                new Client.ReadXmlDelegate(l.ReadXml)).StatusCode;

            if (statusCode == HttpStatusCode.NotFound)
                return null;

            return l;
        }

        /// <summary>
        /// Returns a new adjustment (credit or charge) for this account
        /// </summary>
        /// <param name="description"></param>
        /// <param name="unitAmountInCents"></param>
        /// <param name="currency"></param>
        /// <param name="quantity"></param>
        /// <returns></returns>
        public Adjustment CreateAdjustment(string description, int unitAmountInCents, string currency, int quantity=1)
        {
            return new Adjustment(this.AccountCode, description, currency, unitAmountInCents, quantity);
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

                        case "state":
                            this.State = (AccountState)Enum.Parse(typeof(AccountState), reader.ReadElementContentAsString(), true);
                            break;

                        case "username":
                            this.Username = reader.ReadElementContentAsString();
                            break;

                        case "email":
                            this.Email = reader.ReadElementContentAsString();
                            break;

                        case "first_name":
                            this.FirstName = reader.ReadElementContentAsString();
                            break;

                        case "last_name":
                            this.LastName = reader.ReadElementContentAsString();
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

                        case "created_at":
                            this.CreatedAt = reader.ReadElementContentAsDateTime();
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
            if (obj is Account)
                return Equals((Account)obj);
            else
                return false;
        }

        public bool Equals(Account account)
        {
            return this.AccountCode == account.AccountCode;
        }

        public override int GetHashCode()
        {
            return this.AccountCode.GetHashCode();
        }

        #endregion

        #region Helpers
        private static List<Account> List(string state)
        {
            var accounts = new List<Account>();

            Client.ReadXmlDelegate read = delegate(XmlTextReader reader)
            {
                while (reader.Read())
                {
                    if (reader.Name == "account" && reader.NodeType == XmlNodeType.Element)
                        accounts.Add(new Account(reader));

                    if (reader.Name == "accounts" && reader.NodeType == XmlNodeType.EndElement)
                        break;
                }
            };

            var url = UrlPrefix;

            if (state != null)
            {
                url += "?state=" + state;
            }

            Client.PerformPageRequests(url, read);

            return accounts;
        }

        #endregion
    }
}
