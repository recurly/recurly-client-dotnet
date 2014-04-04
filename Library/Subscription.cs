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
        // changed to flags based on http://docs.recurly.com/api/subscriptions saying Subscriptions can be in multiple states
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
            PastDue = 64
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

        private string _accountCode;
        private Account _account;
        /// <summary>
        /// Account in Recurly
        /// </summary>
        public Account Account
        {
            get { return _account ?? (_account = Accounts.Get(_accountCode)); }
        }

        private Plan _plan;
        private string _planCode; // TODO expose publicly, avoid need to hit API for the Plan

        public Plan Plan
        {
            get { return _plan ?? (_plan = Plans.Get(_planCode)); }
            set
            {
                _plan = value;
                _planCode = value.PlanCode;
            }
        }

        public string Uuid { get; private set; }

        public SubscriptionState State { get; private set; }

        /// <summary>
        /// Unit amount per quantity.  Leave null to keep as is. Set to override plan's default amount.
        /// </summary>
        public int? UnitAmountInCents { get; set; }

        public string Currency { get; set; }
        public int Quantity { get; set; }


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
                if (value.HasValue && (value < DateTime.UtcNow))
                    throw new ArgumentException("TrialPeriodEndsAt must occur in the future.");

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

        /// <summary>
        /// If true, this is a "pending subscription" object and no changes are allowed
        /// </summary>
        private bool IsPendingSubscription { get; set; }

        private Coupon _coupon;
        private string _couponCode;

        /// <summary>
        /// Optional coupon for the subscription
        /// </summary>
        public Coupon Coupon
        {
            get { return _coupon ?? (_coupon = Coupons.Get(_couponCode)); }
            set
            {
                _coupon = value;
                _couponCode = value.CouponCode;
            }
        }

        private List<SubscriptionAddOn> _addOns; 
        /// <summary>
        /// List of add ons for this subscription
        /// </summary>
        public List<SubscriptionAddOn> AddOns
        {
            get { return _addOns ?? (_addOns = new List<SubscriptionAddOn>()); }
            set { _addOns = value; }
        }

        public int? TotalBillingCycles { get; set; }
        public DateTime? FirstRenewalDate { get; set; }

        internal const string UrlPrefix = "/subscriptions/";

        public string CollectionMethod { get; set; }
        public int? NetTerms { get; set; }
        public string PoNumber { get; set; }

        /// <summary>
        /// Amount of tax or VAT within the transaction, in cents.
        /// </summary>
        public int? TaxInCents { get; private set; }

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
        /// <param name="timeframe">when the update should occur: now or at renewal</param>
        public void ChangeSubscription(ChangeTimeframe timeframe)
        {
            Client.WriteXmlDelegate writeXmlDelegate;

            if (timeframe == ChangeTimeframe.Now)
                writeXmlDelegate = WriteChangeSubscriptionNowXml;
            else
                writeXmlDelegate = WriteChangeSubscriptionAtRenewalXml;

            Client.Instance.PerformRequest(Client.HttpRequestMethod.Put,
                UrlPrefix + Uri.EscapeUriString(Uuid),
                writeXmlDelegate,
                ReadXml);
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

        public void Terminate(RefundType refund)
        {
            Client.Instance.PerformRequest(Client.HttpRequestMethod.Put,
                UrlPrefix + Uri.EscapeUriString(Uuid) + "/terminate?refund=" + refund.ToString().EnumNameToTransportCase(),
                ReadXml);
        }

        public void Preview()
        {
            Client.Instance.PerformRequest(Client.HttpRequestMethod.Post,
                UrlPrefix + "preview",
                WriteXml,
                ReadXml);
        }

        public void Postpone(DateTime nextRenewalDate)
        {
            Client.Instance.PerformRequest(Client.HttpRequestMethod.Put,
                UrlPrefix + Uri.EscapeUriString(Uuid) + "/postpone?next_renewal_date=" + nextRenewalDate.ToString("yyyy-MM-dd"),
                ReadXml);
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
                        _planCode = reader.ReadElementContentAsString();
                        break;
                }
            }
        }

        internal override void ReadXml(XmlTextReader reader)
        {
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

                    case "subscription_add_ons":
                        // overwrite existing list with what is in Recurly
                        AddOns.Clear();
                        var newList = new SubscriptionAddOnList();
                        newList.ReadXml(reader);
                        AddOns.AddRange(newList.All);
                        break;

                    case "pending_subscription":
                        PendingSubscription = new Subscription {IsPendingSubscription = true};
                        PendingSubscription.ReadPendingSubscription(reader);
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

                    case "tax_in_cents":
                        TaxInCents = reader.ReadElementContentAsInt();
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
                        var newList = new SubscriptionAddOnList();
                        newList.ReadXml(reader);
                        AddOns.AddRange(newList.All);
                        break;
                }
            }
        }

        protected void WriteSubscriptionXml(XmlTextWriter xmlWriter)
        {
            xmlWriter.WriteStartElement("subscription"); // Start: subscription

            xmlWriter.WriteElementString("plan_code", _planCode);

            xmlWriter.WriteElementString("currency", Currency);

            xmlWriter.WriteIfCollectionHasAny("subscription_add_ons", AddOns);

            xmlWriter.WriteStringIfValid("coupon_code", _couponCode);

            if (UnitAmountInCents.HasValue)
                xmlWriter.WriteElementString("unit_amount_in_cents", UnitAmountInCents.Value.AsString());

            xmlWriter.WriteElementString("quantity", Quantity.AsString());

            if (TrialPeriodEndsAt.HasValue)
                xmlWriter.WriteElementString("trial_ends_at", TrialPeriodEndsAt.Value.ToString("s"));

            if (StartsAt.HasValue)
                xmlWriter.WriteElementString("starts_at", StartsAt.Value.ToString("s"));

            if (TotalBillingCycles.HasValue)
                xmlWriter.WriteElementString("total_billing_cycles", TotalBillingCycles.Value.AsString());

            if (FirstRenewalDate.HasValue)
                xmlWriter.WriteElementString("first_renewal_date", FirstRenewalDate.Value.ToString("s"));

            if (CollectionMethod.Like("manual"))
            {
                xmlWriter.WriteElementString("collection_method", "manual");
                xmlWriter.WriteElementString("net_terms", NetTerms.Value.AsString());
                xmlWriter.WriteElementString("po_number", PoNumber);
            }

            // <account> and billing info
            Account.WriteXml(xmlWriter);

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
            xmlWriter.WriteStringIfValid("plan_code", _planCode);
            xmlWriter.WriteIfCollectionHasAny("subscription_add_ons", AddOns);
            xmlWriter.WriteStringIfValid("coupon_code", _couponCode);

            if (UnitAmountInCents.HasValue)
                xmlWriter.WriteElementString("unit_amount_in_cents", UnitAmountInCents.Value.AsString());

            if (CollectionMethod.Like("manual"))
            {
                xmlWriter.WriteElementString("collection_method", "manual");
                xmlWriter.WriteElementString("net_terms", NetTerms.Value.AsString());
                xmlWriter.WriteElementString("po_number", PoNumber);
            }

            xmlWriter.WriteEndElement(); // End: subscription
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
            return Uuid.GetHashCode();
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
            return new SubscriptionList(Subscription.UrlPrefix + "?state=" + state.ToString().EnumNameToTransportCase());
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
