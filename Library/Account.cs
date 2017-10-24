using System;
using System.Collections.Generic;
using System.Net;
using System.Xml;

namespace Recurly
{
    /// <summary>
    /// An account in Recurly.
    ///
    /// https://dev.recurly.com/docs/get-account
    /// </summary>
    public class Account : RecurlyEntity
    {

        // The currently valid account states
        // Corrected to allow multiple states, per https://dev.recurly.com/docs/get-account
        [Flags]
        public enum AccountState : short
        {
            Closed = 1,
            Active = 2,
            PastDue = 4
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
        public string VatNumber { get; set; }
        public bool? TaxExempt { get; set; }
        public string EntityUseCode { get; set; }
        public string AcceptLanguage { get; set; }
        public string CcEmails { get; set; }
        public string HostedLoginToken { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }
        public bool VatLocationValid { get; private set; }
        public Address Address { get; set; }
        public bool HasLiveSubscription { get; private set; }
        public bool HasActiveSubscription { get; private set; }
        public bool HasFutureSubscription { get; private set; }
        public bool HasCanceledSubscription { get; private set; }
        public bool HasPastDueInvoice { get; private set; }

        private BillingInfo _billingInfo;

        public BillingInfo BillingInfo
        {
            get
            {
                if (null != _billingInfo)
                    return _billingInfo;

                try
                {
                    _billingInfo = BillingInfo.Get(AccountCode);
                }
                catch (NotFoundException)
                {
                    _billingInfo = null;
                }

                return _billingInfo;
            }
            set
            {
                _billingInfo = value;
            }
        }

        private AccountBalance _balance;

        public AccountBalance Balance
        {
            get
            {
                if (_balance != null)
                    return _balance;

                try
                {
                    _balance = AccountBalance.Get(AccountCode);
                }
                catch (NotFoundException)
                {
                    _balance = null;
                }

                return _balance;
            }
            set { _balance = value; }
        }

        /// <summary>
        /// List of shipping addresses
        /// </summary>
        public List<ShippingAddress> ShippingAddresses
        {
            get { return _shippingAddresses ?? (_shippingAddresses = new List<ShippingAddress>()); }
            set { _shippingAddresses = value; }
        }
        private List<ShippingAddress> _shippingAddresses;

        internal const string UrlPrefix = "/accounts/";

        public Account(string accountCode)
        {
            AccountCode = accountCode;
        }

        /// <summary>
        /// Creates a new account with required billing information
        /// </summary>
        /// <param name="accountCode"></param>
        /// <param name="billingInfo"></param>
        public Account(string accountCode, BillingInfo billingInfo)
        {
            AccountCode = accountCode;
            _billingInfo = billingInfo;
        }

        internal Account(XmlTextReader xmlReader)
        {
            ReadXml(xmlReader);
        }

        internal Account(XmlTextReader xmlReader, string xmlName)
        {
            ReadXml(xmlReader, xmlName);
        }

        internal Account()
        { }

        /// <summary>
        /// Delete an account's billing info.
        /// </summary>
        public void DeleteBillingInfo()
        {
            Client.Instance.PerformRequest(Client.HttpRequestMethod.Delete,
                UrlPrefix + Uri.EscapeUriString(AccountCode) + "/billing_info");
            _billingInfo = null;
        }

        /// <summary>
        /// Create a new account in Recurly
        /// </summary>
        public void Create()
        {
            // POST /accounts
            Client.Instance.PerformRequest(Client.HttpRequestMethod.Post, UrlPrefix, WriteXml, ReadXml);
        }

        /// <summary>
        /// Update an existing account in Recurly
        /// </summary>
        public void Update()
        {
            // PUT /accounts/<account code>
            Client.Instance.PerformRequest(Client.HttpRequestMethod.Put,
                UrlPrefix + Uri.EscapeUriString(AccountCode),
                WriteXml);
        }

        /// <summary>
        /// Close the account and cancel any active subscriptions (if there is one).
        /// Note: This does not create a refund for any time remaining.
        /// </summary>
        public void Close()
        {
            Accounts.Close(AccountCode);
            if (State.Is(AccountState.Active))
                State ^= AccountState.Active;
            State |= AccountState.Closed;
        }

        /// <summary>
        /// Reopen an existing account in Recurly
        /// </summary>
        public void Reopen()
        {
            Accounts.Reopen(AccountCode);
            if (State.Is(AccountState.Closed))
                State ^= AccountState.Closed;
            State |= AccountState.Active;
        }

        /// <summary>
        /// Posts pending charges on an account
        /// </summary>
        public Invoice InvoicePendingCharges(Invoice invoice = null)
        {
            var i = invoice ?? new Invoice();
            Client.Instance.PerformRequest(Client.HttpRequestMethod.Post,
                UrlPrefix + Uri.EscapeUriString(AccountCode) + "/invoices",
                i.WriteXml,
                i.ReadXml);

            return i;
        }

        /// <summary>
        /// Previews a new invoice for the pending charges on an account
        /// </summary>
        public Invoice PreviewInvoicePendingCharges(Invoice invoice = null)
        {
            var i = invoice ?? new Invoice();
            Client.Instance.PerformRequest(Client.HttpRequestMethod.Post,
                UrlPrefix + Uri.EscapeUriString(AccountCode) + "/invoices/preview",
                i.WriteXml,
                i.ReadXml);

            return i;
        }

        /// <summary>
        /// Gets all adjustments for this account, by type
        /// </summary>
        /// <param name="type">Adjustment type to retrieve. Optional, default: All.</param>
        /// <param name="state">State of the Adjustments to retrieve. Optional, default: Any.</param>
        /// <returns></returns>
        public RecurlyList<Adjustment> GetAdjustments(Adjustment.AdjustmentType type = Adjustment.AdjustmentType.All,
            Adjustment.AdjustmentState state = Adjustment.AdjustmentState.Any)
        {
            var adjustments = new AdjustmentList();
            var statusCode = Client.Instance.PerformRequest(Client.HttpRequestMethod.Get,
                UrlPrefix + Uri.EscapeUriString(AccountCode) + "/adjustments/"
                + Build.QueryStringWith(Adjustment.AdjustmentState.Any == state ? "" : "state=" + state.ToString().EnumNameToTransportCase())
                .AndWith(Adjustment.AdjustmentType.All == type ? "" : "type=" + type.ToString().EnumNameToTransportCase())
                , adjustments.ReadXmlList);

            return statusCode == HttpStatusCode.NotFound ? null : adjustments;
        }

        /// <summary>
        /// Gets all shipping addresses
        /// </summary>
        /// <returns></returns>
        public RecurlyList<ShippingAddress> GetShippingAddresses()
        {
            var shippingAddresses = new ShippingAddressList(this);
            var statusCode = Client.Instance.PerformRequest(Client.HttpRequestMethod.Get,
                UrlPrefix + Uri.EscapeUriString(AccountCode) + "/shipping_addresses/",
                shippingAddresses.ReadXmlList);

            return statusCode == HttpStatusCode.NotFound ? null : shippingAddresses;
        }

        /// <summary>
        /// Returns a list of invoices for this account
        /// </summary>
        /// <returns></returns>
        public RecurlyList<Invoice> GetInvoices()
        {
            return Invoices.List(AccountCode);
        }

        /// <summary>
        /// Returns a list of subscriptions for this account
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        public RecurlyList<Subscription> GetSubscriptions(Subscription.SubscriptionState state = Subscription.SubscriptionState.All)
        {
            return new SubscriptionList(UrlPrefix + Uri.EscapeUriString(AccountCode) + "/subscriptions/"
                + Build.QueryStringWith(state.Equals(Subscription.SubscriptionState.All) ? "" : "state=" + state.ToString().EnumNameToTransportCase()));
        }

        /// <summary>
        /// Returns a list of transactions for this account, by transaction type
        /// </summary>
        /// <param name="state">Transactions of this state will be retrieved. Optional, default: All.</param>
        /// <param name="type">Transactions of this type will be retrieved. Optional, default: All.</param>
        /// <returns></returns>
        public RecurlyList<Transaction> GetTransactions(TransactionList.TransactionState state = TransactionList.TransactionState.All,
            TransactionList.TransactionType type = TransactionList.TransactionType.All)
        {
            return new TransactionList(UrlPrefix + Uri.EscapeUriString(AccountCode) + "/transactions/"
                 + Build.QueryStringWith(state != TransactionList.TransactionState.All ? "state=" + state.ToString().EnumNameToTransportCase() : "")
                   .AndWith(type != TransactionList.TransactionType.All ? "type=" + type.ToString().EnumNameToTransportCase() : ""));
        }

        public RecurlyList<Note> GetNotes()
        {
            return new NoteList(UrlPrefix + Uri.EscapeUriString(AccountCode) + "/notes/");
        }

        /// <summary>
        /// Returns a new adjustment (credit or charge) for this account
        /// </summary>
        /// <param name="currency">Currency, 3-letter ISO code.</param>
        /// <param name="unitAmountInCents">Positive amount for a charge, negative amount for a credit. Max 10,000,000.</param>
        /// <param name="description">Description of the adjustment for the invoice.</param>
        /// <param name="quantity">Quantity, defaults to 1.</param>
        /// <param name="accountingCode">Accounting code. Max of 20 characters.</param>
        /// <param name="taxExempt"></param>
        /// <returns></returns>
        public Adjustment NewAdjustment(string currency, int unitAmountInCents, string description = "", int quantity = 1, string accountingCode = "", bool taxExempt = false)
        {
            // TODO All of the properties should be settable
            return new Adjustment(AccountCode, description, currency, unitAmountInCents, quantity, accountingCode, taxExempt);
        }

        /// <summary>
        /// Redeems a coupon on this account
        /// </summary>
        /// <param name="couponCode"></param>
        /// <param name="currency"></param>
        /// <returns></returns>
        public CouponRedemption RedeemCoupon(string couponCode, string currency, string subscriptionUuid = null)
        {
            return CouponRedemption.Redeem(AccountCode, couponCode, currency, subscriptionUuid);
        }

        /// <summary>
        /// Returns all active coupon redemptions on this account
        /// </summary>
        /// <returns></returns>
        public RecurlyList<CouponRedemption> GetActiveRedemptions()
        {
            var redemptions = new CouponRedemptionList();

            var statusCode = Client.Instance.PerformRequest(Client.HttpRequestMethod.Get,
                UrlPrefix + Uri.EscapeUriString(AccountCode) + "/redemptions",
                redemptions.ReadXmlList);

            return statusCode == HttpStatusCode.NotFound ? null : redemptions;
        }

        /// <summary>
        /// Returns the first active coupon redemptions on this account
        /// </summary>
        /// <returns></returns>
        public CouponRedemption GetActiveRedemption()
        {
            var activeRedemptions = GetActiveRedemptions();

            if (activeRedemptions == null || activeRedemptions.Count <= 0)
            {
                return null;
            }

            return activeRedemptions.ToArray()[0];
        }

        #region Read and Write XML documents

        internal override void ReadXml(XmlTextReader reader)
        {
            ReadXml(reader, "account");
        }

        internal void ReadXml(XmlTextReader reader, string xmlName)
        {
            while (reader.Read())
            {
                if (reader.Name == xmlName && reader.NodeType == XmlNodeType.EndElement)
                    break;

                if (reader.NodeType != XmlNodeType.Element) continue;

                switch (reader.Name)
                {
                    case "account_code":
                        AccountCode = reader.ReadElementContentAsString();
                        break;

                    case "state":
                        // TODO investigate in case of incoming data representing multiple states, as https://dev.recurly.com/docs/get-account says is possible
                        State = reader.ReadElementContentAsString().ParseAsEnum<AccountState>();
                        break;

                    case "username":
                        Username = reader.ReadElementContentAsString();
                        break;

                    case "email":
                        Email = reader.ReadElementContentAsString();
                        break;

                    case "first_name":
                        FirstName = reader.ReadElementContentAsString();
                        break;

                    case "last_name":
                        LastName = reader.ReadElementContentAsString();
                        break;

                    case "company_name":
                        CompanyName = reader.ReadElementContentAsString();
                        break;

                    case "vat_number":
                        VatNumber = reader.ReadElementContentAsString();
                        break;

                    case "tax_exempt":
                        TaxExempt = reader.ReadElementContentAsBoolean();
                        break;

                    case "entity_use_code":
                        EntityUseCode = reader.ReadElementContentAsString();
                        break;

                    case "accept_language":
                        AcceptLanguage = reader.ReadElementContentAsString();
                        break;

                    case "cc_emails":
                        CcEmails = reader.ReadElementContentAsString();
                        break;

                    case "hosted_login_token":
                        HostedLoginToken = reader.ReadElementContentAsString();
                        break;

                    case "created_at":
                        CreatedAt = reader.ReadElementContentAsDateTime();
                        break;

                    case "updated_at":
                        UpdatedAt = reader.ReadElementContentAsDateTime();
                        break;

                    case "address":
                        Address = new Address(reader);
                        break;

                    case "vat_location_valid":
                        if (reader.GetAttribute("nil") == null)
                        {
                            VatLocationValid = reader.ReadElementContentAsBoolean();
                        }
                        break;

                    case "has_live_subscription":
                        bool a;
                        if (bool.TryParse(reader.ReadElementContentAsString(), out a))
                            HasLiveSubscription = a;
                        break;

                    case "has_active_subscription":
                        bool b;
                        if (bool.TryParse(reader.ReadElementContentAsString(), out b))
                            HasActiveSubscription = b;
                        break;

                    case "has_future_subscription":
                        bool c;
                        if (bool.TryParse(reader.ReadElementContentAsString(), out c))
                            HasFutureSubscription = c;
                        break;

                    case "has_canceled_subscription":
                        bool d;
                        if (bool.TryParse(reader.ReadElementContentAsString(), out d))
                            HasCanceledSubscription = d;
                        break;

                    case "has_past_due_invoice":
                        bool e;
                        if (bool.TryParse(reader.ReadElementContentAsString(), out e))
                            HasPastDueInvoice = e;
                        break;
                }
            }
        }

        internal override void WriteXml(XmlTextWriter xmlWriter)
        {
            WriteXml(xmlWriter, "account");
        }

        internal void WriteXml(XmlTextWriter xmlWriter, string xmlName)
        {
            xmlWriter.WriteStartElement(xmlName); // Start: account

            xmlWriter.WriteElementString("account_code", AccountCode);
            xmlWriter.WriteStringIfValid("username", Username);
            xmlWriter.WriteStringIfValid("email", Email);
            xmlWriter.WriteStringIfValid("first_name", FirstName);
            xmlWriter.WriteStringIfValid("last_name", LastName);
            xmlWriter.WriteStringIfValid("company_name", CompanyName);
            xmlWriter.WriteStringIfValid("accept_language", AcceptLanguage);
            xmlWriter.WriteStringIfValid("vat_number", VatNumber);
            xmlWriter.WriteStringIfValid("entity_use_code", EntityUseCode);
            xmlWriter.WriteStringIfValid("cc_emails", CcEmails);

            xmlWriter.WriteIfCollectionHasAny("shipping_addresses", ShippingAddresses);

            if (TaxExempt.HasValue)
                xmlWriter.WriteElementString("tax_exempt", TaxExempt.Value.AsString());

            if (_billingInfo != null)
                _billingInfo.WriteXml(xmlWriter);

            if (Address != null)
                Address.WriteXml(xmlWriter);

            xmlWriter.WriteEndElement(); // End: account
        }
        /// <summary>
        /// This serializer is used for redeeming a gift card on
        /// this account.
        /// </summary>
        /// <param name="xmlWriter"></param>
        internal void WriteGiftCardRedeemXml(XmlTextWriter xmlWriter)
        {
            xmlWriter.WriteStartElement("recipient_account"); // Start: recipient_account
            xmlWriter.WriteElementString("account_code", AccountCode);
            xmlWriter.WriteEndElement(); // End: recipient_account
        }

        #endregion

        #region Object Overrides

        public override string ToString()
        {
            return "Recurly Account: " + AccountCode;
        }

        public override bool Equals(object obj)
        {
            var a = obj as Account;
            return a != null && Equals(a);
        }

        public bool Equals(Account account)
        {
            return account != null && AccountCode == account.AccountCode;
        }

        public override int GetHashCode()
        {
            return AccountCode?.GetHashCode() ?? 0;
        }

        #endregion
    }

    public sealed class Accounts
    {
        internal const string UrlPrefix = "/accounts/";

        /// <summary>
        /// Lookup a Recurly account
        /// </summary>
        /// <param name="accountCode"></param>
        /// <returns></returns>
        public static Account Get(string accountCode)
        {
            var account = new Account();
            // GET /accounts/<account code>
            var statusCode = Client.Instance.PerformRequest(Client.HttpRequestMethod.Get,
                UrlPrefix + Uri.EscapeUriString(accountCode),
                account.ReadXml);

            return statusCode == HttpStatusCode.NotFound ? null : account;
        }

        /// <summary>
        /// Close the account and cancel any active subscriptions (if there is one).
        /// Note: This does not create a refund for any time remaining.
        /// </summary>
        /// <param name="accountCode">Account Code</param>
        public static void Close(string accountCode)
        {
            // DELETE /accounts/<account code>
            Client.Instance.PerformRequest(Client.HttpRequestMethod.Delete,
                Account.UrlPrefix + Uri.EscapeUriString(accountCode));
        }

        /// <summary>
        /// Reopen an existing account in recurly.
        /// </summary>
        /// <param name="accountCode">Account Code</param>
        public static void Reopen(string accountCode)
        {
            // PUT /accounts/<account code>/reopen
            Client.Instance.PerformRequest(Client.HttpRequestMethod.Put,
                Account.UrlPrefix + Uri.EscapeUriString(accountCode) + "/reopen");
        }

        /// <summary>
        /// Lists accounts, limited to state
        /// </summary>
        /// <param name="state">Account state to retrieve</param>
        /// <returns></returns>
        public static RecurlyList<Account> List(Account.AccountState state = Account.AccountState.Active)
        {
            return List(state, null);
        }

        /// <summary>
        /// Lists accounts, limited to state
        /// </summary>
        /// <param name="state">Account state to retrieve</param>
        /// <param name="filter">FilterCriteria used to apply server side sorting and filtering</param>
        /// <returns></returns>
        public static RecurlyList<Account> List(Account.AccountState state, FilterCriteria filter)
        {
            filter = filter ?? FilterCriteria.Instance;
            var parameters = filter.ToNamedValueCollection();
            parameters["state"] = state.ToString().EnumNameToTransportCase();
            return new AccountList(Account.UrlPrefix + "?" + parameters.ToString());
        }
    }
}
