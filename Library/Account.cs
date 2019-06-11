using Recurly.Extensions;
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
    public class Account : RecurlyEntity, IAccount
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
        public string ExemptionCertificate { get; set; }
        public string EntityUseCode { get; set; }
        public string AcceptLanguage { get; set; }
        public string CcEmails { get; set; }
        public string HostedLoginToken { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }
        public DateTime? ClosedAt { get; private set; }
        public bool VatLocationValid { get; private set; }
        public IAddress Address { get; set; }
        public bool HasLiveSubscription { get; private set; }
        public bool HasActiveSubscription { get; private set; }
        public bool HasFutureSubscription { get; private set; }
        public bool HasCanceledSubscription { get; private set; }
        public bool HasPastDueInvoice { get; private set; }
        public string PreferredLocale { get; set; }
        public string ParentAccountCode { get; set; }

        private IAccountAcquisition _accountAcquisition;

        public IAccountAcquisition AccountAcquisition
        {
            get
            {
                if (_accountAcquisition != null)
                    return _accountAcquisition;

                try
                {
                    _accountAcquisition = Recurly.AccountAcquisition.Get(AccountCode);
                }
                catch (NotFoundException)
                {
                    _accountAcquisition = null;
                }
                return _accountAcquisition;
            }
            set
            {
                _accountAcquisition = value;
            }
        }

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

        private IAccountBalance _balance;

        public IAccountBalance Balance
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

        /// <summary>
        /// List of custom fields
        /// </summary>
        public List<CustomField> CustomFields
        {
            get { return _customFields ?? (_customFields = new List<CustomField>()); }
            set { _customFields = value; }
        }
        private List<CustomField> _customFields;

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
        /// Remove an account's acquisition data.
        /// </summary>
        public void DeleteAccountAcquisition()
        {
            Client.Instance.PerformRequest(Client.HttpRequestMethod.Delete,
                UrlPrefix + Uri.EscapeDataString(AccountCode) + "/acquisition");
            _accountAcquisition = null;
        }

        /// <summary>
        /// Delete an account's billing info.
        /// </summary>
        public void DeleteBillingInfo()
        {
            Client.Instance.PerformRequest(Client.HttpRequestMethod.Delete,
                UrlPrefix + Uri.EscapeDataString(AccountCode) + "/billing_info");
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
                UrlPrefix + Uri.EscapeDataString(AccountCode),
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
        public InvoiceCollection InvoicePendingCharges(IInvoice invoice = null)
        {
            invoice = invoice ?? new Invoice();
            var collection = new InvoiceCollection();
            Client.Instance.PerformRequest(Client.HttpRequestMethod.Post,
                UrlPrefix + Uri.EscapeDataString(AccountCode) + "/invoices",
                invoice.TryWriteXml,
                collection.ReadXml);

            return collection;
        }

        /// <summary>
        /// Previews a new invoice for the pending charges on an account
        /// </summary>
        public InvoiceCollection PreviewInvoicePendingCharges(IInvoice invoice = null)
        {
            invoice = invoice ?? new Invoice(); 
            var collection = new InvoiceCollection();
            Client.Instance.PerformRequest(Client.HttpRequestMethod.Post,
                UrlPrefix + Uri.EscapeDataString(AccountCode) + "/invoices/preview",
                invoice.TryWriteXml,
                collection.ReadXml);

            return collection;
        }

        /// <summary>
        /// Gets all adjustments for this account, by type
        /// </summary>
        /// <param name="type">Adjustment type to retrieve. Optional, default: All.</param>
        /// <param name="state">State of the Adjustments to retrieve. Optional, default: Any.</param>
        /// <returns></returns>
        public IRecurlyList<Adjustment> GetAdjustments(Adjustment.AdjustmentType type = Adjustment.AdjustmentType.All,
            Adjustment.AdjustmentState state = Adjustment.AdjustmentState.Any)
        {
            var adjustments = new AdjustmentList();
            var statusCode = Client.Instance.PerformRequest(Client.HttpRequestMethod.Get,
                UrlPrefix + Uri.EscapeDataString(AccountCode) + "/adjustments/"
                + Build.QueryStringWith(Adjustment.AdjustmentState.Any == state ? "" : "state=" + state.ToString().EnumNameToTransportCase())
                .AndWith(Adjustment.AdjustmentType.All == type ? "" : "type=" + type.ToString().EnumNameToTransportCase())
                , adjustments.ReadXmlList);

            return statusCode == HttpStatusCode.NotFound ? null : adjustments;
        }

        /// <summary>
        /// Gets all adjustments for this account
        /// </summary>
        /// <param name="filter">Optional filter criteria</param>
        /// <param name="type">Adjustment type to retrieve. Optional, default: All.</param>
        /// <param name="state">State of the Adjustments to retrieve. Optional, default: Any.</param>
        /// <returns></returns>
        public IRecurlyList<Adjustment> GetAdjustments(FilterCriteria filter, Adjustment.AdjustmentType type = Adjustment.AdjustmentType.All,
            Adjustment.AdjustmentState state = Adjustment.AdjustmentState.Any)
        {
            var adjustments = new AdjustmentList();
            filter = filter ?? FilterCriteria.Instance;
            var parameters = filter.ToNamedValueCollection();
            if (type != Adjustment.AdjustmentType.All) {
                parameters["type"] = type.ToString().EnumNameToTransportCase();
            }
            if (state != Adjustment.AdjustmentState.Any)
            {
                parameters["state"] = state.ToString().EnumNameToTransportCase();
            }


            var statusCode = Client.Instance.PerformRequest(Client.HttpRequestMethod.Get,
                UrlPrefix + Uri.EscapeDataString(AccountCode) + "/adjustments/"
                + "?" + parameters.ToString()
                , adjustments.ReadXmlList);

            return statusCode == HttpStatusCode.NotFound ? null : adjustments;
        }


        /// <summary>
        /// Gets all shipping addresses
        /// </summary>
        /// <returns></returns>
        public IRecurlyList<ShippingAddress> GetShippingAddresses()
        {
            var shippingAddresses = new ShippingAddressList(this);
            var statusCode = Client.Instance.PerformRequest(Client.HttpRequestMethod.Get,
                UrlPrefix + Uri.EscapeDataString(AccountCode) + "/shipping_addresses/",
                shippingAddresses.ReadXmlList);

            return statusCode == HttpStatusCode.NotFound ? null : shippingAddresses;
        }

        /// <summary>
        /// Returns a list of invoices for this account
        /// </summary>
        /// <returns></returns>
        public IRecurlyList<IInvoice> GetInvoices()
        {
            return Invoices.List(AccountCode);
        }

        /// <summary>
        /// Returns a list of subscriptions for this account
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        public IRecurlyList<Subscription> GetSubscriptions(Subscription.SubscriptionState state = Subscription.SubscriptionState.All)
        {
            return new SubscriptionList(UrlPrefix + Uri.EscapeDataString(AccountCode) + "/subscriptions/"
                + Build.QueryStringWith(state.Equals(Subscription.SubscriptionState.All) ? "" : "state=" + state.ToString().EnumNameToTransportCase()));
        }

        /// <summary>
        /// Returns a list of transactions for this account, by transaction type
        /// </summary>
        /// <param name="state">Transactions of this state will be retrieved. Optional, default: All.</param>
        /// <param name="type">Transactions of this type will be retrieved. Optional, default: All.</param>
        /// <returns></returns>
        public IRecurlyList<Transaction> GetTransactions(TransactionList.TransactionState state = TransactionList.TransactionState.All,
            TransactionList.TransactionType type = TransactionList.TransactionType.All)
        {
            return new TransactionList(UrlPrefix + Uri.EscapeDataString(AccountCode) + "/transactions/"
                 + Build.QueryStringWith(state != TransactionList.TransactionState.All ? "state=" + state.ToString().EnumNameToTransportCase() : "")
                   .AndWith(type != TransactionList.TransactionType.All ? "type=" + type.ToString().EnumNameToTransportCase() : ""));
        }

        public IRecurlyList<Note> GetNotes()
        {
            return new NoteList(UrlPrefix + Uri.EscapeDataString(AccountCode) + "/notes/");
        }

        public IAccount GetParentAccount()
        {
            if (ParentAccountCode == null) return null;
            var parent = new Account(ParentAccountCode);
            var statusCode = Client.Instance.PerformRequest(Client.HttpRequestMethod.Get,
                UrlPrefix + Uri.EscapeDataString(ParentAccountCode),
                parent.ReadXml);

            return statusCode == HttpStatusCode.NotFound ? null : parent;
        }

        public IRecurlyList<IAccount> GetChildAccounts()
        {
            return new AccountList(UrlPrefix + Uri.EscapeDataString(AccountCode) + "/child_accounts");
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
        public IRecurlyList<CouponRedemption> GetActiveRedemptions()
        {
            var redemptions = new CouponRedemptionList();

            var statusCode = Client.Instance.PerformRequest(Client.HttpRequestMethod.Get,
                UrlPrefix + Uri.EscapeDataString(AccountCode) + "/redemptions",
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

        /// <summary>
        /// Creates a shipping address
        /// </summary>
        /// <param name="shippingAddress"></param>
        /// <returns>ShippingAddress object</returns>
        public ShippingAddress CreateShippingAddress(ShippingAddress shippingAddress)
        {
            var statusCode = Client.Instance.PerformRequest(Client.HttpRequestMethod.Post,
                UrlPrefix + Uri.EscapeDataString(AccountCode) + "/shipping_addresses",
                shippingAddress.WriteXml,
                shippingAddress.ReadXml);

            return statusCode == HttpStatusCode.Created ? shippingAddress : null;
        }

        /// <summary>
        /// Gets all shipping addresses
        /// </summary>
        /// <param name="shippingAddress"></param>
        /// <returns>ShippingAddress object</returns>
        public ShippingAddress UpdateShippingAddress(ShippingAddress shippingAddress)
        {
            var shippingAddressId = shippingAddress.Id;
            var statusCode = Client.Instance.PerformRequest(Client.HttpRequestMethod.Put,
                UrlPrefix + Uri.EscapeDataString(AccountCode) + "/shipping_addresses/" + shippingAddressId,
                shippingAddress.WriteXml,
                shippingAddress.ReadXml);

            return statusCode == HttpStatusCode.OK ? shippingAddress : null;
        }

        /// <summary>
        /// Deletes a shipping address
        /// </summary>
        public void DeleteShippingAddress(long shippingAddressId)
        {
            var statusCode = Client.Instance.PerformRequest(Client.HttpRequestMethod.Delete,
                UrlPrefix + Uri.EscapeDataString(AccountCode) + "/shipping_addresses/" + shippingAddressId);
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

                DateTime dt;

                switch (reader.Name)
                {
                   
                    case "account_code":
                        AccountCode = reader.ReadElementContentAsString();
                        break;

                    case "parent_account_code":
                        ParentAccountCode = reader.ReadElementContentAsString();
                        break;

                    case "billing_info":
                       var href = reader.GetAttribute("href");
                       if (null == href)
                       {
                           BillingInfo = new BillingInfo(reader);
                       }    
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

                    case "exemption_certificate":
                        ExemptionCertificate = reader.ReadElementContentAsString();
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

                    case "closed_at":
                        if (DateTime.TryParse(reader.ReadElementContentAsString(), out dt))
                            ClosedAt = dt;
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

                    case "preferred_locale":
                        PreferredLocale = reader.ReadElementContentAsString();
                        break;

                    case "custom_fields":
                        CustomFields = new List<CustomField>();
                        while (reader.Read())
                        {
                            if (reader.Name == "custom_fields" && reader.NodeType == XmlNodeType.EndElement)
                                break;

                            if (reader.NodeType == XmlNodeType.Element && reader.Name == "custom_field")
                            {
                                CustomFields.Add(new CustomField(reader));
                            }
                        }
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
            WriteXml(xmlWriter, xmlName, this);
        }

        internal static void WriteXml(XmlTextWriter xmlWriter, IAccount account)
        {
            WriteXml(xmlWriter, "account", account);
        }

        internal static void WriteXml(XmlTextWriter xmlWriter, string xmlName, IAccount account)
        {
            xmlWriter.WriteStartElement(xmlName); // Start: account

            xmlWriter.WriteElementString("account_code", account.AccountCode);
            xmlWriter.WriteStringIfValid("username", account.Username);
            xmlWriter.WriteStringIfValid("email", account.Email);
            xmlWriter.WriteStringIfValid("first_name", account.FirstName);
            xmlWriter.WriteStringIfValid("last_name", account.LastName);
            xmlWriter.WriteStringIfValid("company_name", account.CompanyName);
            xmlWriter.WriteStringIfValid("accept_language", account.AcceptLanguage);
            xmlWriter.WriteStringIfValid("vat_number", account.VatNumber);
            xmlWriter.WriteStringIfValid("entity_use_code", account.EntityUseCode);
            xmlWriter.WriteStringIfValid("cc_emails", account.CcEmails);
            xmlWriter.WriteStringIfValid("preferred_locale", account.PreferredLocale);

            xmlWriter.WriteIfCollectionHasAny("shipping_addresses", account.ShippingAddresses);
            xmlWriter.WriteIfCollectionHasAny("custom_fields", account.CustomFields);

            // Clear the parent account by writing empty string. Null should not clear parent.
            if (account.ParentAccountCode != null)
                xmlWriter.WriteElementString("parent_account_code", account.ParentAccountCode);

            if (account.TaxExempt.HasValue)
                xmlWriter.WriteElementString("tax_exempt", account.TaxExempt.Value.AsString());

            xmlWriter.WriteStringIfValid("exemption_certificate", account.ExemptionCertificate);

            //if(_accountAcquisition != null)
            //    _accountAcquisition.WriteXml(xmlWriter);

            //if (_billingInfo != null)
            //    _billingInfo.WriteXml(xmlWriter);

            if (account.Address != null)
                account.Address.TryWriteXml(xmlWriter);

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

        public bool Equals(IAccount account)
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
        public static IAccount Get(string accountCode)
        {
            if (string.IsNullOrWhiteSpace(accountCode))
            {
                return null;
            }

            var account = new Account();
            // GET /accounts/<account code>
            var statusCode = Client.Instance.PerformRequest(Client.HttpRequestMethod.Get,
                UrlPrefix + Uri.EscapeDataString(accountCode),
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
                Account.UrlPrefix + Uri.EscapeDataString(accountCode));
        }

        /// <summary>
        /// Reopen an existing account in recurly.
        /// </summary>
        /// <param name="accountCode">Account Code</param>
        public static void Reopen(string accountCode)
        {
            // PUT /accounts/<account code>/reopen
            Client.Instance.PerformRequest(Client.HttpRequestMethod.Put,
                Account.UrlPrefix + Uri.EscapeDataString(accountCode) + "/reopen");
        }

        /// <summary>
        /// Lists accounts, limited to state
        /// </summary>
        /// <param name="state">Account state to retrieve</param>
        /// <returns></returns>
        public static IRecurlyList<IAccount> List(Account.AccountState state = Account.AccountState.Active)
        {
            return List(state, null);
        }

        /// <summary>
        /// Lists accounts, limited to state
        /// </summary>
        /// <param name="state">Account state to retrieve</param>
        /// <param name="filter">FilterCriteria used to apply server side sorting and filtering</param>
        /// <returns></returns>
        public static IRecurlyList<IAccount> List(Account.AccountState state, FilterCriteria filter)
        {
            filter = filter ?? FilterCriteria.Instance;
            var parameters = filter.ToNamedValueCollection();
            parameters["state"] = state.ToString().EnumNameToTransportCase();
            return new AccountList(Account.UrlPrefix + "?" + parameters.ToString());
        }
    }
}
