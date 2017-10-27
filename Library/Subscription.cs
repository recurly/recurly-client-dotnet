using System;
using System.Collections.Generic;
using System.Net;
using System.Xml;

namespace Recurly
{

    /// <summary>
    /// Represents subscriptions for accounts
    /// </summary>
    public class Subscription : RecurlyEntity
    {
        // changed to flags based on https://dev.recurly.com/docs/list-subscriptions saying Subscriptions can be in multiple states
        [Flags]
        // The currently valid Subscription States
        public enum SubscriptionState : short
        {
            All = 0,
            Active = 1,
            Canceled = 2,
            Expired = 4,
            Future = 8,
            InTrial = 16,
            Live = 32,
            PastDue = 64,
            Pending = 128,
            Open    = 256,
            Failed  = 512,
        }

        public enum ChangeTimeframe : short
        {
            Now,
            Renewal
        }

        public enum RefundType : short
        {
            Full,
            Partial,
            None
        }

        public Address Address
        {
            get { return _address ?? (_address = new Address()); }
            set { _address = value; }
        }
        private Address _address;

        private string _accountCode;
        private Account _account;
        /// <summary>
        /// Account in Recurly
        /// </summary>
        public Account Account
        {
            get { return _account ?? (_account = Accounts.Get(_accountCode)); }
        }

        private string _invoiceNumber;
        private Invoice _invoice;
        /// <summary>
        /// </summary>
        public Invoice Invoice
        {
            get { return _invoice ?? (_invoice = Invoices.Get(_invoiceNumber)); }
        }

        private Plan _plan;

        public Plan Plan
        {
            get { return _plan ?? (_plan = Plans.Get(PlanCode)); }
            set
            {
                _plan = value;
                PlanCode = value.PlanCode;
            }
        }

        public string PlanCode { get; private set; }

        private ShippingAddress _shippingAddress;

        public ShippingAddress ShippingAddress
        {
            get { return _shippingAddress; }
            set
            {
                if (value.Id.HasValue)
                {
                    ShippingAddressId = value.Id.Value;
                }
                _shippingAddress = value;
            }
        }

        public long? ShippingAddressId { get; set; }

        public string Uuid { get; private set; }

        public SubscriptionState State { get; private set; }

        /// <summary>
        /// Unit amount per quantity.  Leave null to keep as is. Set to override plan's default amount.
        /// </summary>
        public int? UnitAmountInCents { get; set; }

        public string Currency { get; set; }
        public int Quantity { get; set; }

        public bool? Bulk { get; set; }

        /// <summary>
        /// Date the subscription was last updated.
        /// </summary>
        public DateTime? UpdatedAt { get; private set; }
        /// <summary>
        /// Date the subscription started.
        /// </summary>
        public DateTime? ActivatedAt { get; private set; }
        /// <summary>
        /// If set, the date the subscriber canceled their subscription.
        /// </summary>
        public DateTime? CanceledAt { get; private set; }
        /// <summary>
        /// If set, the subscription will expire/terminate on this date.
        /// </summary>
        public DateTime? ExpiresAt { get; private set; }
        /// <summary>
        /// Date the current invoice period started.
        /// </summary>
        public DateTime? CurrentPeriodStartedAt { get; private set; }
        /// <summary>
        /// The subscription is paid until this date. Next invoice date.
        /// </summary>
        public DateTime? CurrentPeriodEndsAt { get; private set; }
        /// <summary>
        /// Date the trial started, if the subscription has a trial.
        /// </summary>
        public DateTime? TrialPeriodStartedAt { get; private set; }
        /// <summary>
        /// Date the Bank Account has been authorized for this subscription
        /// </summary>
        public DateTime? BankAccountAuthorizedAt { get; set; }

        /// <summary>
        /// Date the trial ends, if the subscription has/had a trial.
        ///
        /// This may optionally be set on new subscriptions to specify an exact time for the
        /// subscription to commence.  The subscription will be active and in "trial" until
        /// this date.
        /// </summary>
        public DateTime? TrialPeriodEndsAt
        {
            get { return _trialPeriodEndsAt; }
            set
            {
                if (ActivatedAt.HasValue)
                    throw new InvalidOperationException("Cannot set TrialPeriodEndsAt on existing subscriptions.");

                _trialPeriodEndsAt = value;
            }
        }
        private DateTime? _trialPeriodEndsAt;

        /// <summary>
        /// If set, the subscription will begin in the future on this date.
        /// The subscription will apply the setup fee and trial period, unless the plan has no trial.
        /// </summary>
        public DateTime? StartsAt { get; set; }

        /// <summary>
        /// Represents pending changes to the subscription
        /// </summary>
        public Subscription PendingSubscription { get; private set; }
        public string NoBillingInfoReason { get; private set; }

        /// <summary>
        /// If true, this is a "pending subscription" object and no changes are allowed
        /// </summary>
        private bool IsPendingSubscription { get; set; }

        private Coupon _coupon;
        private string _couponCode;

        private Coupon[] _coupons;
        private string[] _couponCodes;

        /// <summary>
        /// Optional coupon for the subscription
        /// </summary>
        public Coupon Coupon
        {
            get { return _coupon ?? (_coupon = Recurly.Coupons.Get(_couponCode)); }
            set
            {
                _coupon = value;
                _couponCode = value.CouponCode;
            }
        }

        /// <summary>
        /// Optional coupons for the subscription
        /// </summary>
        public Coupon[] Coupons
        {
            get {
                if (_coupons == null)
                {
                    _coupons = new Coupon[_couponCodes.Length];
                }

                if ( _coupons.Length == 0)
                {

                    for (int i = 0; i<_couponCodes.Length; i++)
                    {
                        _coupons[i] = Recurly.Coupons.Get(_couponCodes[i]);
                    }
                }

                return _coupons;
            }
            set {
                _coupons = value;
                _couponCodes = new string[_coupons.Length];
                for (int i = 0; i<_coupons.Length; i++)
                {
                    _couponCodes[i] = _coupons[i].CouponCode;
                }
            }
        }

        /// <summary>
        /// List of add ons for this subscription
        /// </summary>
        public SubscriptionAddOnList AddOns
        {
            get { return _addOns ?? (_addOns = new SubscriptionAddOnList(this)); }
            set { _addOns = value; }
        }
        private SubscriptionAddOnList _addOns;

        /// <summary>
        /// The invoice generated when calling the Preview method
        /// </summary>
        public Invoice InvoicePreview { get; private set; }
        public int? TotalBillingCycles { get; set; }
        public int? RemainingBillingCycles { get; private set; }
        public DateTime? FirstRenewalDate { get; set; }

        internal const string UrlPrefix = "/subscriptions/";

        public string CollectionMethod { get; set; }
        public int? NetTerms { get; set; }
        public string PoNumber { get; set; }

        /// <summary>
        /// Amount of tax or VAT within the transaction, in cents.
        /// </summary>
        public int? TaxInCents { get; private set; }

        /// <summary>
        /// Tax type as "vat" for VAT or "usst" for US Sales Tax.
        /// </summary>
        public string TaxType { get; private set; }

        /// <summary>
        /// Tax rate that will be applied to this subscription.
        /// </summary>
        public decimal? TaxRate { get; private set; }

        /// <summary>
        /// Determines if this object exists in the Recurly API
        /// </summary>
        internal bool _saved;

        internal bool _preview;

        public string CustomerNotes { get; set; }
        public string TermsAndConditions { get; set; }
        public string VatReverseChargeNotes { get; set; }
        /// <summary>
        /// True if the subscription started from a gift card.
        /// </summary>
        public bool StartedWithGiftCard { get; private set; }
        /// <summary>
        /// The timestamp representing when the subscription was converted from a gift card.
        /// </summary>
        public DateTime? ConvertedAt { get; private set; }

        /// <summary>
        /// Optionally set true to denote that this subscription was imported from a trial.
        /// </summary>
        public bool? ImportedTrial { get; set; }

        public Adjustment.RevenueSchedule? RevenueScheduleType { get; set; }

        internal Subscription()
        {
            IsPendingSubscription = false;
        }

        internal Subscription(XmlTextReader reader)
        {
            ReadXml(reader);
        }

        /// <summary>
        /// Creates a new subscription object
        /// </summary>
        /// <param name="account"></param>
        /// <param name="plan"></param>
        /// <param name="currency"></param>
        public Subscription(Account account, Plan plan, string currency)
        {
            _accountCode = account.AccountCode;
            _account = account;
            Plan = plan;
            Currency = currency;
            Quantity = 1;
        }

        /// <summary>
        /// Creates a new subscription object, with coupon
        /// </summary>
        /// <param name="account"></param>
        /// <param name="plan"></param>
        /// <param name="currency"></param>
        /// <param name="couponCode"></param>
        public Subscription(Account account, Plan plan, string currency, string couponCode)
        {
            _accountCode = account.AccountCode;
            _account = account;
            Plan = plan;
            Currency = currency;
            Quantity = 1;
            _couponCode = couponCode;
        }

        public Subscription(string planCode)
        {
            PlanCode = planCode;
            Quantity = 1;
        }

        /// <summary>
        /// Creates a new subscription on Recurly
        /// </summary>
        public void Create()
        {
            Client.Instance.PerformRequest(Client.HttpRequestMethod.Post,
                UrlPrefix,
                WriteSubscriptionXml,
                ReadXml);
        }

        /// <summary>
        /// Request that an update to a subscription take place
        /// </summary>
        /// <param name="timeframe">when the update should occur: now (default) or at renewal</param>
        public void ChangeSubscription(ChangeTimeframe timeframe)
        {
            Client.WriteXmlDelegate writeXmlDelegate;

            if (ChangeTimeframe.Renewal == timeframe)
                writeXmlDelegate = WriteChangeSubscriptionAtRenewalXml;
            else
                writeXmlDelegate = WriteChangeSubscriptionNowXml;

            Client.Instance.PerformRequest(Client.HttpRequestMethod.Put,
                UrlPrefix + Uri.EscapeUriString(Uuid),
                writeXmlDelegate,
                ReadXml);
        }

        public void ChangeSubscription()
        {
            ChangeSubscription(ChangeTimeframe.Now);
        }

        /// <summary>
        /// Cancel an active subscription.  The subscription will not renew, but will continue to be active
        /// through the remainder of the current term.
        /// </summary>
        public void Cancel()
        {
            Client.Instance.PerformRequest(Client.HttpRequestMethod.Put,
                UrlPrefix + Uri.EscapeUriString(Uuid) + "/cancel",
                ReadXml);
        }

        /// <summary>
        /// Reactivate a canceled subscription.  The subscription will renew at the end of its current term.
        /// </summary>
        public void Reactivate()
        {
            Client.Instance.PerformRequest(Client.HttpRequestMethod.Put,
                UrlPrefix + Uri.EscapeUriString(Uuid) + "/reactivate",
                ReadXml);
        }

        /// <summary>
        /// Terminates the subscription immediately.
        /// </summary>
        /// <param name="refund"></param>
        public void Terminate(RefundType refund)
        {
            Client.Instance.PerformRequest(Client.HttpRequestMethod.Put,
                UrlPrefix + Uri.EscapeUriString(Uuid) + "/terminate?refund=" + refund.ToString().EnumNameToTransportCase(),
                ReadXml);
        }

        /// <summary>
        /// Transforms this object into a preview Subscription applied to the account.
        /// </summary>
        /// <param name="timeframe">ChangeTimeframe.Now (default) or at Renewal</param>
        public void Preview(ChangeTimeframe timeframe)
        {
            if (_saved)
            {
                throw new Recurly.RecurlyException("Cannot preview an existing subscription.");
            }

            Client.Instance.PerformRequest(Client.HttpRequestMethod.Post,
                UrlPrefix + "preview",
                WriteSubscriptionXml,
                ReadXml);

            // this method does not save the object
            _saved = false;
        }

        public void Preview()
        {
            Preview(ChangeTimeframe.Now);
        }

        /// <summary>
        /// Preview the changes associated with the current subscription
        /// </summary>
        /// <param name="timeframe">ChangeTimeframe.Now (default) or at Renewal</param>
        public virtual Subscription PreviewChange(ChangeTimeframe timeframe)
        {
            if (!_saved)
            {
                throw new Recurly.RecurlyException("Must have an existing subscription to preview changes.");
            }

            Client.WriteXmlDelegate writeXmlDelegate;

            if (ChangeTimeframe.Renewal == timeframe)
                writeXmlDelegate = WriteChangeSubscriptionAtRenewalXml;
            else
                writeXmlDelegate = WriteChangeSubscriptionNowXml;

            var previewSubscription = new Subscription();

            var statusCode = Client.Instance.PerformRequest(Client.HttpRequestMethod.Post,
                UrlPrefix + Uri.EscapeUriString(Uuid) + "/preview",
                writeXmlDelegate,
                previewSubscription.ReadPreviewXml);

            return statusCode == HttpStatusCode.NotFound ? null : previewSubscription;
        }

        public virtual Subscription PreviewChange()
        {
            return PreviewChange(ChangeTimeframe.Now);
        }

        /// <summary>
        /// For an active subscription, this will pause the subscription until the specified date.
        /// </summary>
        /// <param name="nextRenewalDate">The specified time the subscription will be postponed</param>
        /// <param name="bulk">bulk = false (default) or true to bypass the 60 second wait while postponing</param>
        public void Postpone(DateTime nextRenewalDate, bool bulk = false)
        {
            Client.Instance.PerformRequest(Client.HttpRequestMethod.Put,
                UrlPrefix + Uri.EscapeUriString(Uuid) + "/postpone?next_renewal_date=" + nextRenewalDate.ToString("s") + "&bulk=" + bulk.ToString().ToLower(),
                ReadXml);
        }

        public bool UpdateNotes(Dictionary<string, string> notes)
        {
            Client.Instance.PerformRequest(Client.HttpRequestMethod.Put,
                UrlPrefix + Uri.EscapeUriString(Uuid) + "/notes",
                WriteSubscriptionNotesXml(notes),
                ReadXml);

            CustomerNotes = notes["CustomerNotes"];
            TermsAndConditions = notes["TermsAndConditions"];
            VatReverseChargeNotes = notes["VatReverseChargeNotes"];

            return true;
        }

        public RecurlyList<CouponRedemption> GetRedemptions()
        {
            var coupons = new CouponRedemptionList();
            var statusCode = Client.Instance.PerformRequest(Client.HttpRequestMethod.Get,
                UrlPrefix + Uri.EscapeUriString(Uuid) + "/redemptions/",
                coupons.ReadXmlList);

            return statusCode == HttpStatusCode.NotFound ? null : coupons;
        }

        #region Read and Write XML documents

        internal void ReadPlanXml(XmlTextReader reader)
        {
            while (reader.Read())
            {
                if (reader.Name == "plan" && reader.NodeType == XmlNodeType.EndElement)
                    break;

                if (reader.NodeType != XmlNodeType.Element) continue;

                switch (reader.Name)
                {
                    case "plan_code":
                        PlanCode = reader.ReadElementContentAsString();
                        break;
                }
            }
        }

        internal void ReadPreviewXml(XmlTextReader reader)
        {
            _preview = true;
            ReadXml(reader);
        }

        internal override void ReadXml(XmlTextReader reader)
        {
            _saved = true;

            string href;

            while (reader.Read())
            {
                if (reader.Name == "subscription" && reader.NodeType == XmlNodeType.EndElement)
                    break;

                if (reader.NodeType != XmlNodeType.Element) continue;

                DateTime dateVal;
                Int32 billingCycles;

                switch (reader.Name)
                {
                    case "account":
                        href = reader.GetAttribute("href");
                        if (null != href)
                            _accountCode = Uri.UnescapeDataString(href.Substring(href.LastIndexOf("/") + 1));
                        break;

                    case "plan":
                        ReadPlanXml(reader);
                        break;

                    case "uuid":
                        Uuid = reader.ReadElementContentAsString();
                        break;

                    case "state":
                        State = reader.ReadElementContentAsString().ParseAsEnum<SubscriptionState>();
                        break;

                    case "unit_amount_in_cents":
                        UnitAmountInCents = reader.ReadElementContentAsInt();
                        break;

                    case "currency":
                        Currency = reader.ReadElementContentAsString();
                        break;

                    case "quantity":
                        Quantity = reader.ReadElementContentAsInt();
                        break;

                    case "activated_at":
                        if (DateTime.TryParse(reader.ReadElementContentAsString(), out dateVal))
                            ActivatedAt = dateVal;
                        break;

                    case "canceled_at":
                        if (DateTime.TryParse(reader.ReadElementContentAsString(), out dateVal))
                            CanceledAt = dateVal;
                        break;

                    case "expires_at":
                        if (DateTime.TryParse(reader.ReadElementContentAsString(), out dateVal))
                            ExpiresAt = dateVal;
                        break;

                    case "updated_at":
                        if (DateTime.TryParse(reader.ReadElementContentAsString(), out dateVal))
                            UpdatedAt = dateVal; ;
                        break;

                    case "current_period_started_at":
                        if (DateTime.TryParse(reader.ReadElementContentAsString(), out dateVal))
                            CurrentPeriodStartedAt = dateVal;
                        break;

                    case "current_period_ends_at":
                        if (DateTime.TryParse(reader.ReadElementContentAsString(), out dateVal))
                            CurrentPeriodEndsAt = dateVal;
                        break;

                    case "trial_started_at":
                        if (DateTime.TryParse(reader.ReadElementContentAsString(), out dateVal))
                            TrialPeriodStartedAt = dateVal;
                        break;

                    case "trial_ends_at":
                        if (DateTime.TryParse(reader.ReadElementContentAsString(), out dateVal))
                            _trialPeriodEndsAt = dateVal;
                        break;

                    case "bank_account_authorized_at":
                        if (DateTime.TryParse(reader.ReadElementContentAsString(), out dateVal))
                            BankAccountAuthorizedAt = dateVal;
                        break;

                    case "subscription_add_ons":
                        // overwrite existing list with what came back from Recurly
                        AddOns = new SubscriptionAddOnList(this);
                        AddOns.ReadXml(reader);
                        break;

                    case "invoice":
                        href = reader.GetAttribute("href");
                        if (!href.IsNullOrEmpty())
                            _invoiceNumber = Uri.UnescapeDataString(href.Substring(href.LastIndexOf("/") + 1));
                        else
                            InvoicePreview = new Invoice(reader);
                        break;

                    case "pending_subscription":
                        PendingSubscription = new Subscription { IsPendingSubscription = true };
                        PendingSubscription.ReadPendingSubscription(reader);
                        // TODO test all returned properties are read
                        break;

                    case "collection_method":
                        CollectionMethod = reader.ReadElementContentAsString();
                        break;

                    case "net_terms":
                        NetTerms = reader.ReadElementContentAsInt();
                        break;

                    case "po_number":
                        PoNumber = reader.ReadElementContentAsString();
                        break;

                    case "total_billing_cycles":
                        if (Int32.TryParse(reader.ReadElementContentAsString(), out billingCycles))
                            TotalBillingCycles = billingCycles;
                        break;

                    case "remaining_billing_cycles":
                        if (Int32.TryParse(reader.ReadElementContentAsString(), out billingCycles))
                            RemainingBillingCycles = billingCycles;
                        break;

                    case "tax_in_cents":
                        TaxInCents = reader.ReadElementContentAsInt();
                        break;

                    case "tax_type":
                        TaxType = reader.ReadElementContentAsString();
                        break;

                    case "tax_rate":
                        TaxRate = reader.ReadElementContentAsDecimal();
                        break;

                    case "customer_notes":
                        CustomerNotes = reader.ReadElementContentAsString();
                        break;

                    case "terms_and_conditions":
                        TermsAndConditions = reader.ReadElementContentAsString();
                        break;

                    case "vat_reverse_charge_notes":
                        VatReverseChargeNotes = reader.ReadElementContentAsString();
                        break;

                    case "address":
                        Address = new Address(reader);
                        break;
                    case "started_with_gift":
                        StartedWithGiftCard = reader.ReadElementContentAsBoolean();
                        break;
                    case "converted_at":
                        DateTime date;
                        if (DateTime.TryParse(reader.ReadElementContentAsString(), out date))
                        {
                            ConvertedAt = date;
                        }
                        break;
                    case "no_billing_info_reason":
                        NoBillingInfoReason = reader.ReadElementContentAsString();
                        break;
                    case "imported_trial":
                        ImportedTrial = reader.ReadElementContentAsBoolean();
                        break;

                    case "revenue_schedule_tye":
                        RevenueScheduleType = reader.ReadElementContentAsString().ParseAsEnum<Adjustment.RevenueSchedule>();
                        break;
                }
            }
        }

        internal override void WriteXml(XmlTextWriter writer)
        {
            throw new NotImplementedException();
        }

        protected void ReadPendingSubscription(XmlTextReader reader)
        {
            while (reader.Read())
            {
                if (reader.Name == "pending_subscription" && reader.NodeType == XmlNodeType.EndElement)
                    break;

                if (reader.NodeType != XmlNodeType.Element) continue;

                switch (reader.Name)
                {
                    case "plan":
                        ReadPlanXml(reader);
                        break;

                    case "unit_amount_in_cents":
                        UnitAmountInCents = reader.ReadElementContentAsInt();
                        break;

                    case "quantity":
                        Quantity = reader.ReadElementContentAsInt();
                        break;

                    case "subscription_add_ons":
                        AddOns = new SubscriptionAddOnList(this);
                        AddOns.ReadXml(reader);
                        break;
                }
            }
        }

        internal void WriteSubscriptionXml(XmlTextWriter xmlWriter)
        {
            WriteSubscriptionXml(xmlWriter, false);
        }

        internal void WriteEmbeddedSubscriptionXml(XmlTextWriter xmlWriter)
        {
            WriteSubscriptionXml(xmlWriter, true);
        }


        internal void WriteSubscriptionXml(XmlTextWriter xmlWriter, bool embedded)
        {
            xmlWriter.WriteStartElement("subscription"); // Start: subscription

            xmlWriter.WriteElementString("plan_code", PlanCode);

            if (!embedded)
            {
                // <account> and billing info
                Account.WriteXml(xmlWriter);
                xmlWriter.WriteElementString("currency", Currency);
                xmlWriter.WriteElementString("customer_notes", CustomerNotes);
                xmlWriter.WriteElementString("terms_and_conditions", TermsAndConditions);
                xmlWriter.WriteElementString("vat_reverse_charge_notes", VatReverseChargeNotes);
                xmlWriter.WriteElementString("po_number", PoNumber);
            }

            xmlWriter.WriteIfCollectionHasAny("subscription_add_ons", AddOns);

            xmlWriter.WriteStringIfValid("coupon_code", _couponCode);

            if (_couponCodes != null && _couponCodes.Length != 0) {
                xmlWriter.WriteStartElement("coupon_codes");
                foreach (var _coupon_code in _couponCodes)
                {
                    xmlWriter.WriteElementString("coupon_code", _coupon_code);
                }
                xmlWriter.WriteEndElement();
            }

            if (UnitAmountInCents.HasValue)
                xmlWriter.WriteElementString("unit_amount_in_cents", UnitAmountInCents.Value.AsString());

            xmlWriter.WriteElementString("quantity", Quantity.AsString());

            if (TrialPeriodEndsAt.HasValue)
                xmlWriter.WriteElementString("trial_ends_at", TrialPeriodEndsAt.Value.ToString("s"));

            if (BankAccountAuthorizedAt.HasValue)
                xmlWriter.WriteElementString("bank_account_authorized_at", BankAccountAuthorizedAt.Value.ToString("s"));

            if (StartsAt.HasValue)
                xmlWriter.WriteElementString("starts_at", StartsAt.Value.ToString("s"));

            if (TotalBillingCycles.HasValue)
                xmlWriter.WriteElementString("total_billing_cycles", TotalBillingCycles.Value.AsString());

            if (FirstRenewalDate.HasValue)
                xmlWriter.WriteElementString("first_renewal_date", FirstRenewalDate.Value.ToString("s"));

            if (Bulk.HasValue)
                xmlWriter.WriteElementString("bulk", Bulk.ToString().ToLower());

            if (CollectionMethod.Like("manual"))
            {
                xmlWriter.WriteElementString("collection_method", "manual");

                if (NetTerms.HasValue)
                    xmlWriter.WriteElementString("net_terms", NetTerms.Value.AsString());
            }
            else if (CollectionMethod.Like("automatic"))
                xmlWriter.WriteElementString("collection_method", "automatic");

            if (ShippingAddressId.HasValue)
            {
                xmlWriter.WriteElementString("shipping_address_id", ShippingAddressId.Value.ToString());
            }

            if (ImportedTrial.HasValue)
            {
                xmlWriter.WriteElementString("imported_trial", ImportedTrial.Value.ToString().ToLower());
            }

            if (RevenueScheduleType.HasValue)
                xmlWriter.WriteElementString("revenue_schedule_type", RevenueScheduleType.Value.ToString().EnumNameToTransportCase());

            xmlWriter.WriteEndElement(); // End: subscription
        }

        protected void WriteChangeSubscriptionNowXml(XmlTextWriter xmlWriter)
        {
            WriteChangeSubscriptionXml(xmlWriter, ChangeTimeframe.Now);
        }

        protected void WriteChangeSubscriptionAtRenewalXml(XmlTextWriter xmlWriter)
        {
            WriteChangeSubscriptionXml(xmlWriter, ChangeTimeframe.Renewal);
        }

        protected void WriteChangeSubscriptionXml(XmlTextWriter xmlWriter, ChangeTimeframe timeframe)
        {
            xmlWriter.WriteStartElement("subscription"); // Start: subscription

            xmlWriter.WriteElementString("timeframe", timeframe.ToString().EnumNameToTransportCase());
            xmlWriter.WriteElementString("quantity", Quantity.AsString());
            xmlWriter.WriteStringIfValid("plan_code", PlanCode);
            xmlWriter.WriteIfCollectionHasAny("subscription_add_ons", AddOns);
            xmlWriter.WriteStringIfValid("coupon_code", _couponCode);

            if (_couponCodes != null && _couponCodes.Length != 0) {
                xmlWriter.WriteStartElement("coupon_codes");
                foreach (var _coupon_code in _couponCodes)
                {
                    xmlWriter.WriteElementString("coupon_code", _coupon_code);
                }
                xmlWriter.WriteEndElement();
            }


            if (UnitAmountInCents.HasValue)
                xmlWriter.WriteElementString("unit_amount_in_cents", UnitAmountInCents.Value.AsString());

            if (CollectionMethod.Like("manual"))
            {
                xmlWriter.WriteElementString("collection_method", "manual");
                xmlWriter.WriteElementString("net_terms", NetTerms.Value.AsString());
                xmlWriter.WriteElementString("po_number", PoNumber);
            }
            else if (CollectionMethod.Like("automatic"))
                xmlWriter.WriteElementString("collection_method", "automatic");

            xmlWriter.WriteEndElement(); // End: subscription
        }

        internal Client.WriteXmlDelegate WriteSubscriptionNotesXml(Dictionary<string, string> notes)
        {
            return delegate(XmlTextWriter xmlWriter)
            {
                xmlWriter.WriteStartElement("subscription"); // Start: subscription

                xmlWriter.WriteElementString("customer_notes", notes["CustomerNotes"]);
                xmlWriter.WriteElementString("terms_and_conditions", notes["TermsAndConditions"]);
                xmlWriter.WriteElementString("vat_reverse_charge_notes", notes["VatReverseChargeNotes"]);

                xmlWriter.WriteEndElement(); // End: subscription
            };
        }

        #endregion


        #region Object Overrides

        public override string ToString()
        {
            return "Recurly Subscription: " + Uuid;
        }

        public override bool Equals(object obj)
        {
            var sub = obj as Subscription;
            return sub != null && Equals(sub);
        }

        public bool Equals(Subscription subscription)
        {
            return Uuid == subscription.Uuid;
        }

        public override int GetHashCode()
        {
            return Uuid?.GetHashCode() ?? 0;
        }

        #endregion
    }

    public sealed class Subscriptions
    {
        /// <summary>
        /// Returns a list of recurly subscriptions
        ///
        /// A subscription will belong to more than one state.
        /// </summary>
        /// <param name="state">State of subscriptions to return, defaults to "live"</param>
        /// <returns></returns>
        public static RecurlyList<Subscription> List(Subscription.SubscriptionState state = Subscription.SubscriptionState.Live)
        {
            return List(state, null);
        }

        /// <summary>
        /// Returns a list of recurly subscriptions
        ///
        /// A subscription will belong to more than one state.
        /// </summary>
        /// <param name="state">State of subscriptions to return, defaults to "live"</param>
        /// <param name="filter">FilterCriteria used to apply server side sorting and filtering</param>
        /// <returns></returns>
        public static RecurlyList<Subscription> List(Subscription.SubscriptionState state, FilterCriteria filter)
        {
            filter = filter ?? FilterCriteria.Instance;
            var parameters = filter.ToNamedValueCollection();
            parameters["state"] = state.ToString().EnumNameToTransportCase();
            return new SubscriptionList(Subscription.UrlPrefix + "?" + parameters.ToString());
        }

        public static Subscription Get(string uuid)
        {
            var s = new Subscription();
            var statusCode = Client.Instance.PerformRequest(Client.HttpRequestMethod.Get,
                Subscription.UrlPrefix + Uri.EscapeUriString(uuid),
                s.ReadXml);

            return statusCode == HttpStatusCode.NotFound ? null : s;
        }
    }
}
