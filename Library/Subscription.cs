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
            All      = 0,
            Active   = 1,
            Canceled = 2,
            Expired  = 4,
            Future   = 8,
            InTrial  = 16,
            Live     = 32,
            PastDue  = 64,
            Pending  = 128,
            Open     = 256,
            Failed   = 512,
            Paused   = 1024
        }

        public enum RefundType : short
        {
            Full,
            Partial,
            None
        }

        public IAddress Address
        {
            get { return _address ?? (_address = new Address()); }
            set { _address = value; }
        }
        private IAddress _address;

        private string _accountCode;
        public string AccountCode => _accountCode;

        private IAccount _account;
        /// <summary>
        /// Account in Recurly
        /// </summary>
        public IAccount Account
        {
            get { return _account ?? (_account = Accounts.Get(_accountCode)); }
        }

        private string _invoiceNumber;
        private IInvoice _invoice;
        /// <summary>
        /// </summary>
        public IInvoice Invoice
        {
            get { return _invoice ?? (_invoice = Invoices.Get(_invoiceNumber)); }
        }

        public InvoiceCollection InvoiceCollection { get; private set; }

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

        /// <summary>
        /// List of custom fields
        /// </summary>
        public List<CustomField> CustomFields
        {
            get { return _customFields ?? (_customFields = new List<CustomField>()); }
            set { _customFields = value; }
        }
        private List<CustomField> _customFields;

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

        private ICoupon _coupon;
        private string _couponCode;

        private ICoupon[] _coupons;
        private string[] _couponCodes;

        /// <summary>
        /// Optional coupon for the subscription
        /// </summary>
        public ICoupon Coupon
        {
            get
            {
                if (string.IsNullOrWhiteSpace(_couponCode))
                {
                    return null;
                }

                return _coupon ?? (_coupon = Recurly.Coupons.Get(_couponCode));
            }
            set
            {
                _coupon = value;
                _couponCode = value.CouponCode;
            }
        }

        /// <summary>
        /// Optional coupons for the subscription
        /// </summary>
        public ICoupon[] Coupons
        {
            get {
                if (_coupons == null)
                {
                    _coupons = new ICoupon[_couponCodes.Length];
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
        public IInvoice InvoicePreview { get; private set; }
        public int? TotalBillingCycles { get; set; }
        public int? RemainingBillingCycles { get; set; }
        public int? RemainingPauseCycles { get; private set; }
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
        public string GatewayCode { get; set; }

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

        /// <summary>
        /// Determines whether subscriptions to this plan should auto-renew term at the end of the current term or expire.
        /// Defaults to true.
        /// </summary>
        public bool? AutoRenew { get; set; }

        /// <summary>
        /// Determines the renewal subscription term.
        /// Defaults to plans total billing cycles value unless
        /// overwritten when creating the subscription or editing subscription. 
        /// </summary>
        public int? RenewalBillingCycles { get; set; }

        /// <summary>
        /// Previously named first_renewal_date. Forces the subscriptions next billing period start date.
        /// Subsequent billing period start dates will be offset from this date.
        /// The first invoice will be prorated appropriately so that the customer pays
        /// for the portion of the first billing period for which the subscription applies. 
        /// </summary>
        public DateTime FirstBillDate { get; private set; }

        /// <summary>
        /// Previously named next_renewal_date. Specifies a future date that 
        /// the subscriptions next billing period should be billed.
        /// </summary>
        public DateTime NextBillDate { get; private set; }

        /// <summary>
        /// Start date of the subscriptions current term. Will equal the future start
        /// date if subscription was created in the future state.
        /// </summary>
        public DateTime CurrentTermStartedAt { get; private set; }

        /// <summary>
        /// End date of the subscriptions current term. Will be nil
        /// if subscription has future start date.
        /// </summary>
        public DateTime CurrentTermEndsAt { get; private set; }

        public Adjustment.RevenueSchedule? RevenueScheduleType { get; set; }

        /// <summary>
        /// Unique code associated with the recurring shipping fees for this subscription.
        /// Required if ShippingAmountInCents is specified.
        /// </summary>
        public string ShippingMethodCode { get; set; }

        /// <summary>
        /// Specifies the amount of recurring shipping fees for this subscription.
        /// Required if ShippingMethodCode is specified.
        /// </summary>
        public int? ShippingAmountInCents { get; set; }

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
        public Subscription(IAccount account, Plan plan, string currency)
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
        public Subscription(IAccount account, Plan plan, string currency, string couponCode)
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
        /// Cancel an active subscription.  The subscription will not renew, but will continue to be active
        /// through the remainder of the current term.
        /// </summary>
        public void Cancel()
        {
            Client.Instance.PerformRequest(Client.HttpRequestMethod.Put,
                UrlPrefix + Uri.EscapeDataString(Uuid) + "/cancel",
                ReadXml);
        }

        /// <summary>
        /// Reactivate a canceled subscription.  The subscription will renew at the end of its current term.
        /// </summary>
        public void Reactivate()
        {
            Client.Instance.PerformRequest(Client.HttpRequestMethod.Put,
                UrlPrefix + Uri.EscapeDataString(Uuid) + "/reactivate",
                ReadXml);
        }

        /// <summary>
        /// Terminates the subscription immediately.
        /// </summary>
        /// <param name="refund"></param>
        public void Terminate(RefundType refund)
        {
            Client.Instance.PerformRequest(Client.HttpRequestMethod.Put,
                UrlPrefix + Uri.EscapeDataString(Uuid) + "/terminate?refund=" + refund.ToString().EnumNameToTransportCase(),
                ReadXml);
        }

        /// <summary>
        /// Transforms this object into a preview Subscription applied to the account.
        /// </summary>
        public void Preview()
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

        /// <summary>
        /// For an active subscription, this will pause the subscription until the specified date.
        /// </summary>
        /// <param name="nextRenewalDate">The specified time the subscription will be postponed</param>
        /// <param name="bulk">bulk = false (default) or true to bypass the 60 second wait while postponing</param>
        public void Postpone(DateTime nextRenewalDate, bool bulk = false)
        {
            var dateString = nextRenewalDate.ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ssZ");

            Client.Instance.PerformRequest(Client.HttpRequestMethod.Put,
                UrlPrefix + Uri.EscapeDataString(Uuid) + "/postpone?next_renewal_date=" + dateString + "&bulk=" + bulk.ToString().ToLower(),
                ReadXml);
        }

        public void Pause(int remainingPauseCycles)
        {
            RemainingPauseCycles = remainingPauseCycles;
            Client.Instance.PerformRequest(Client.HttpRequestMethod.Put,
                UrlPrefix + Uri.EscapeDataString(Uuid) + "/pause",
                WritePauseXml,
                ReadXml);
        }

        public void Resume()
        {
            Client.Instance.PerformRequest(Client.HttpRequestMethod.Put,
                UrlPrefix + Uri.EscapeDataString(Uuid) + "/resume",
                ReadXml);
        }

        public bool UpdateNotes(Dictionary<string, string> notes)
        {
            Client.Instance.PerformRequest(Client.HttpRequestMethod.Put,
                UrlPrefix + Uri.EscapeDataString(Uuid) + "/notes",
                WriteSubscriptionNotesXml(notes),
                ReadXml);
            if (notes.ContainsKey("CustomerNotes"))
                CustomerNotes = notes["CustomerNotes"];

            if (notes.ContainsKey("TermsAndConditions"))
                TermsAndConditions = notes["TermsAndConditions"];

            if (notes.ContainsKey("VatReverseChargeNotes"))
                VatReverseChargeNotes = notes["VatReverseChargeNotes"];

            if (notes.ContainsKey("GatewayCode"))
                GatewayCode = notes["GatewayCode"];

            return true;
        }

        public IRecurlyList<CouponRedemption> GetRedemptions()
        {
            var coupons = new CouponRedemptionList();
            var statusCode = Client.Instance.PerformRequest(Client.HttpRequestMethod.Get,
                UrlPrefix + Uri.EscapeDataString(Uuid) + "/redemptions/",
                coupons.ReadXmlList);

            return statusCode == HttpStatusCode.NotFound ? null : coupons;
        }

        /// <summary>
        /// Request that an update to a subscription take place
        /// </summary>
        /// <param name="uuid">The uuid of the subscription to be changed</param>
        /// <param name="change">A subscription change object listing what to change about the subscription</param>
        public static Subscription ChangeSubscription(String uuid, SubscriptionChange change)
        {
            if (uuid.IsNullOrEmpty())
            {
                throw new ArgumentException("uuid cannot be null or empty");
            }

            if (change == null)
            {
                throw new ArgumentException("change cannot be null or empty");
            }

            var subscription = new Subscription();

            var statusCode = Client.Instance.PerformRequest(Client.HttpRequestMethod.Put,
                UrlPrefix + Uri.EscapeDataString(uuid),
                change.WriteChangeSubscriptionXml,
                subscription.ReadXml);

            return statusCode == HttpStatusCode.NotFound ? null : subscription;
        }

        /// <summary>
        /// Preview the changes associated with the current subscription
        /// </summary>
        /// <param name="uuid">The uuid of the subscription to be changed</param>
        /// <param name="change">A subscription change object listing what to change about the subscription</param>
        public static Subscription PreviewChange(String uuid, SubscriptionChange change)
        {
            if (uuid.IsNullOrEmpty())
            {
                throw new Recurly.RecurlyException("Must have an existing subscription to preview changes.");
            }

            var previewSubscription = new Subscription();

            var statusCode = Client.Instance.PerformRequest(Client.HttpRequestMethod.Post,
                UrlPrefix + Uri.EscapeDataString(uuid) + "/preview",
                change.WriteChangeSubscriptionXml,
                previewSubscription.ReadPreviewXml);

            return statusCode == HttpStatusCode.NotFound ? null : previewSubscription;
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
                Int32 pauseCycles;

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

                    case "invoice":
                        href = reader.GetAttribute("href");
                        if (!href.IsNullOrEmpty())
                            _invoiceNumber = Uri.UnescapeDataString(href.Substring(href.LastIndexOf("/") + 1));
                        else
                            InvoicePreview = new Invoice(reader);
                        break;

                    case "invoice_collection":
                        InvoiceCollection = new InvoiceCollection(reader);
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

                    case "remaining_pause_cycles":
                        if (Int32.TryParse(reader.ReadElementContentAsString(), out pauseCycles))
                            RemainingPauseCycles = pauseCycles;
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

                    case "gateway_code":
                        GatewayCode = reader.ReadElementContentAsString();
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

                    case "revenue_schedule_type":
                        var revenueScheduleType = reader.ReadElementContentAsString();
                        if (!revenueScheduleType.IsNullOrEmpty())
                            RevenueScheduleType = revenueScheduleType.ParseAsEnum<Adjustment.RevenueSchedule>();
                        break;

                    case "auto_renew":
                        bool b;
                        if (bool.TryParse(reader.ReadElementContentAsString(), out b))
                            AutoRenew = b;
                        break;

                    case "renewal_billing_cycles":
                        int i;
                        if (int.TryParse(reader.ReadElementContentAsString(), out i))
                            RenewalBillingCycles = i;
                        break;

                    case "current_term_started_at":
                        if (DateTime.TryParse(reader.ReadElementContentAsString(), out dateVal))
                            CurrentTermStartedAt = dateVal;
                        break;

                    case "current_term_ends_at":
                        if (DateTime.TryParse(reader.ReadElementContentAsString(), out dateVal))
                            CurrentTermEndsAt = dateVal;
                        break;

                    case "first_bill_date":
                        if (DateTime.TryParse(reader.ReadElementContentAsString(), out dateVal))
                            FirstBillDate = dateVal;
                        break;

                    case "next_bill_date":
                        if (DateTime.TryParse(reader.ReadElementContentAsString(), out dateVal))
                            NextBillDate = dateVal;
                        break;

                    case "shipping_method_code":
                        ShippingMethodCode = reader.ReadElementContentAsString();
                        break;

                    case "shipping_amount_in_cents":
                        ShippingAmountInCents = reader.ReadElementContentAsInt();
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

        internal void WritePauseXml(XmlTextWriter xmlWriter)
        {
            xmlWriter.WriteStartElement("subscription"); // Start: subscription
            xmlWriter.WriteElementString("remaining_pause_cycles", RemainingPauseCycles.Value.AsString());
            xmlWriter.WriteEndElement();
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
                Recurly.Account.WriteXml(xmlWriter, Account);
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

            if (RemainingBillingCycles.HasValue)
                xmlWriter.WriteElementString("remaining_billing_cycles", RemainingBillingCycles.Value.AsString());

            if (AutoRenew.HasValue)
                xmlWriter.WriteElementString("auto_renew", AutoRenew.Value.AsString());

            if (RenewalBillingCycles.HasValue)
                xmlWriter.WriteElementString("renewal_billing_cycles", RenewalBillingCycles.Value.AsString());

            xmlWriter.WriteIfCollectionHasAny("custom_fields", CustomFields);

            if (!ShippingMethodCode.IsNullOrEmpty())
                xmlWriter.WriteElementString("shipping_method_code", ShippingMethodCode);

            if (ShippingAmountInCents.HasValue)
                xmlWriter.WriteElementString("shipping_amount_in_cents", ShippingAmountInCents.Value.AsString());

            xmlWriter.WriteEndElement(); // End: subscription
        }

        internal Client.WriteXmlDelegate WriteSubscriptionNotesXml(Dictionary<string, string> notes)
        {
            return delegate(XmlTextWriter xmlWriter)
            {
                xmlWriter.WriteStartElement("subscription"); // Start: subscription

                if (notes.ContainsKey("CustomerNotes"))
                    xmlWriter.WriteElementString("customer_notes", notes["CustomerNotes"]);

                if (notes.ContainsKey("TermsAndConditions"))
                    xmlWriter.WriteElementString("terms_and_conditions", notes["TermsAndConditions"]);

                if (notes.ContainsKey("VatReverseChargeNotes"))
                    xmlWriter.WriteElementString("vat_reverse_charge_notes", notes["VatReverseChargeNotes"]);

                if (notes.ContainsKey("GatewayCode"))
                    xmlWriter.WriteElementString("gateway_code", notes["GatewayCode"]);

                xmlWriter.WriteIfCollectionHasAny("custom_fields", CustomFields);

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
        public static IRecurlyList<Subscription> List(Subscription.SubscriptionState state = Subscription.SubscriptionState.Live)
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
        public static IRecurlyList<Subscription> List(Subscription.SubscriptionState state, FilterCriteria filter)
        {
            filter = filter ?? FilterCriteria.Instance;
            var parameters = filter.ToNamedValueCollection();
            parameters["state"] = state.ToString().EnumNameToTransportCase();
            return new SubscriptionList(Subscription.UrlPrefix + "?" + parameters.ToString());
        }

        public static Subscription Get(string uuid)
        {
            if (string.IsNullOrWhiteSpace(uuid))
            {
                return null;
            }

            var s = new Subscription();
            var statusCode = Client.Instance.PerformRequest(Client.HttpRequestMethod.Get,
                Subscription.UrlPrefix + Uri.EscapeDataString(uuid),
                s.ReadXml);

            return statusCode == HttpStatusCode.NotFound ? null : s;
        }
    }
}
