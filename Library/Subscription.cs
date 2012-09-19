using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Xml;

namespace Recurly
{

    /// <summary>
    /// Represents subscriptions for accounts
    /// </summary>
    public class Subscription
    {

        // The currently valid Subscription States
        public enum SubstriptionState : short
        {
            All = 0,
            Active,
            Canceled,
            Expired,
            Future,
            In_Trial,
            Live,
            Past_Due
        }

        public enum ChangeTimeframe : short
        {
            now,
            renewal
        }

        public enum RefundType : short
        {
            full,
            partial,
            none
        }


        private string _accountCode;
        private Account _account;
        /// <summary>
        /// Account in Recurly
        /// </summary>
        public Account Account
        {
            get
            {
                if (null == _account)
                {
                    _account = Account.Get(this._accountCode);
                }

                return _account;
            }
        }


        private Plan _plan;
        private string _planCode;

        public Plan Plan
        {
            get
            {
                if (null == _plan)
                {
                    _plan = Plan.Get(this._planCode);
                }

                return _plan;
            }
            set
            {
                _plan = value;
                _planCode = value.PlanCode;
            }
        }

        public string Uuid { get; private set; }

        public SubstriptionState State { get; private set; }

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
            get { return this._trialPeriodEndsAt; }
            set
            {
                if (this.ActivatedAt.HasValue)
                    throw new InvalidOperationException("Cannot set TrialPeriodEndsAt on existing subscriptions.");
                if (value.HasValue && (value < DateTime.UtcNow))
                    throw new ArgumentException("TrialPeriodEndsAt must occur in the future.");

                this._trialPeriodEndsAt = value;
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
        /// If true, this is a "pending subscripition" object and no changes are allowed
        /// </summary>
        private bool _isPendingSubscription { get; set; }


        /// <summary>
        /// Optional coupon for the subscription
        /// </summary>
        public Coupon Coupon { get; set; }

        /// <summary>
        /// List of add ons for this subscription
        /// </summary>
        public AddOnList AddOns { get; set; }

        public int? TotalBillingCycles { get; set; }
        public DateTime? FirstRenewalDate { get; set; }

        internal const string UrlPrefix = "/subscriptions/";

        internal Subscription()
        {
            _isPendingSubscription = false;
        }

        internal Subscription(XmlTextReader reader)
        {
            this.ReadXml(reader);
        }

        public Subscription(Account account, Plan plan, string currency)
        {
            this._accountCode = account.AccountCode;
            this._account = account;
            this.Plan = plan;
            this.Currency = currency;
            this.Quantity = 1;
        }


        public static Subscription Get(string uuid)
        {
            Subscription s = new Subscription();
            HttpStatusCode statusCode = Client.PerformRequest(Client.HttpRequestMethod.Get,
                UrlPrefix + System.Uri.EscapeUriString(uuid),
                new Client.ReadXmlDelegate(s.ReadXml));

            if (statusCode == HttpStatusCode.NotFound)
                return null;

            return s;

        }


        public void Create()
        {
            Client.PerformRequest(Client.HttpRequestMethod.Post,
                UrlPrefix,
                new Client.WriteXmlDelegate(WriteSubscriptionXml),
                new Client.ReadXmlDelegate(this.ReadXml));
        }

        /// <summary>
        /// Request that an update to a subscription take place
        /// </summary>
        /// <param name="timeframe">when the update should occur: now or at renewal</param>
        public void ChangeSubscription(ChangeTimeframe timeframe)
        {
            Client.WriteXmlDelegate writeXmlDelegate;

            if (timeframe == ChangeTimeframe.now)
                writeXmlDelegate = new Client.WriteXmlDelegate(WriteChangeSubscriptionNowXml);
            else
                writeXmlDelegate = new Client.WriteXmlDelegate(WriteChangeSubscriptionAtRenewalXml);

            Client.PerformRequest(Client.HttpRequestMethod.Put,
                UrlPrefix + System.Uri.EscapeUriString(this.Uuid),
                writeXmlDelegate,
                new Client.ReadXmlDelegate(this.ReadXml));
        }

        /// <summary>
        /// Cancel an active subscription.  The subscription will not renew, but will continue to be active
        /// through the remainder of the current term.
        /// </summary>
        /// <param name="accountCode">Subscriber's Account Code</param>
        public void Cancel()
        {
            Client.PerformRequest(Client.HttpRequestMethod.Put, UrlPrefix + System.Uri.EscapeUriString(this.Uuid) + "/cancel",
                new Client.ReadXmlDelegate(this.ReadXml));
        }

        /// <summary>
        /// Reactivate a canceled subscription.  The subscription will renew at the end of its current term.
        /// </summary>
        /// <param name="accountCode">Subscriber's Account Code</param>
        public void Reactivate()
        {
            Client.PerformRequest(Client.HttpRequestMethod.Put, UrlPrefix + System.Uri.EscapeUriString(this.Uuid) + "/reactivate",
                new Client.ReadXmlDelegate(this.ReadXml));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nextRenewalDate"></param>
        public void Terminate(RefundType refund)
        {
            Client.PerformRequest(Client.HttpRequestMethod.Put, UrlPrefix + System.Uri.EscapeUriString(this.Uuid) + "/terminate?refund=" +
                refund.ToString(),
                 new Client.ReadXmlDelegate(this.ReadXml));
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="nextRenewalDate"></param>
        public void Postpone(DateTime nextRenewalDate)
        {
            Client.PerformRequest(Client.HttpRequestMethod.Put,
                UrlPrefix + System.Uri.EscapeUriString(this.Uuid) + "/postpone?next_renewal_date=" +
                nextRenewalDate.ToString("yyyy-MM-dd"),
                 new Client.ReadXmlDelegate(this.ReadXml));
        }

       


        #region Read and Write XML documents

        internal void ReadPlanXml(XmlTextReader reader)
        {
            while (reader.Read())
            {
                if (reader.Name == "plan" && reader.NodeType == XmlNodeType.EndElement)
                    break;

                if (reader.NodeType == XmlNodeType.Element)
                {
                    switch (reader.Name)
                    {
                        case "plan_code":
                            this._planCode = reader.ReadElementContentAsString();
                            break;
                    }
                }
            }
        }

        internal void ReadXml(XmlTextReader reader)
        {
            string href;

            while (reader.Read())
            {
                if (reader.Name == "subscription" && reader.NodeType == XmlNodeType.EndElement)
                    break;

                if (reader.NodeType == XmlNodeType.Element)
                {
                    DateTime dateVal;
                    switch (reader.Name)
                    {
                        case "account":
                             href = reader.GetAttribute("href");
                            if (null != href)
                                this._accountCode = Uri.UnescapeDataString(href.Substring(href.LastIndexOf("/") + 1));
                            break;

                        case "plan":
                            ReadPlanXml(reader);
                            break;

                        case "uuid":
                            this.Uuid = reader.ReadElementContentAsString();
                            break;

                        case "state":
                            this.State = (SubstriptionState)Enum.Parse(typeof(SubstriptionState), reader.ReadElementContentAsString(), true);
                            break;

                        case "unit_amount_in_cents":
                            this.UnitAmountInCents = reader.ReadElementContentAsInt();
                            break;

                        case "currency":
                            this.Currency = reader.ReadElementContentAsString();
                            break;

                        case "quantity":
                            this.Quantity = reader.ReadElementContentAsInt();
                            break;

                        case "activated_at":
                            if (DateTime.TryParse(reader.ReadElementContentAsString(), out dateVal))
                                this.ActivatedAt = dateVal;
                            break;

                        case "canceled_at":
                            if (DateTime.TryParse(reader.ReadElementContentAsString(), out dateVal))
                                this.CanceledAt = dateVal;
                            break;

                        case "expires_at":
                            if (DateTime.TryParse(reader.ReadElementContentAsString(), out dateVal))
                                this.ExpiresAt = dateVal;
                            break;

                        case "current_period_started_at":
                            if (DateTime.TryParse(reader.ReadElementContentAsString(), out dateVal))
                                this.CurrentPeriodStartedAt = dateVal;
                            break;

                        case "current_period_ends_at":
                            if (DateTime.TryParse(reader.ReadElementContentAsString(), out dateVal))
                                this.CurrentPeriodEndsAt = dateVal;
                            break;

                        case "trial_started_at":
                            if (DateTime.TryParse(reader.ReadElementContentAsString(), out dateVal))
                                this.TrialPeriodStartedAt = dateVal;
                            break;

                        case "trial_ends_at":
                            if (DateTime.TryParse(reader.ReadElementContentAsString(), out dateVal))
                                this._trialPeriodEndsAt = dateVal;
                            break;

                        case "subscription_add_ons":
                            if (null == this.AddOns)
                                this.AddOns = new AddOnList();
                            this.AddOns.ReadXml(reader);

                            break;

                        case "pending_subscription":
                            this.PendingSubscription = new Subscription();
                            this.PendingSubscription._isPendingSubscription = true;
                            this.PendingSubscription.ReadPendingSubscription(reader);
                            break;
                    }
                }
            }
        }

        protected void ReadPendingSubscription(XmlTextReader reader)
        {
            while (reader.Read())
            {
                if (reader.Name == "pending_subscription" && reader.NodeType == XmlNodeType.EndElement)
                    break;

                if (reader.NodeType == XmlNodeType.Element)
                {
                    switch (reader.Name)
                    {
                        case "plan":
                            ReadPlanXml(reader);
                            break;

                        case "unit_amount_in_cents":
                            this.UnitAmountInCents = reader.ReadElementContentAsInt();
                            break;

                        case "quantity":
                            this.Quantity = reader.ReadElementContentAsInt();
                            break;

                        case "subscription_add_ons":
                            if (null == this.AddOns)
                                this.AddOns = new AddOnList();
                            this.AddOns.ReadXml(reader);

                            break;
                    }
                }
            }
        }

        protected void WriteSubscriptionXml(XmlTextWriter xmlWriter)
        {
            xmlWriter.WriteStartElement("subscription"); // Start: subscription

            xmlWriter.WriteElementString("plan_code", this._planCode);
            
            // <account> and billing info
            Account.WriteXml(xmlWriter);

            if (null != this.AddOns)
            {
                xmlWriter.WriteStartElement("subscription_add_ons");
                foreach (AddOn i in this.AddOns)
                {
                    i.WriteXml(xmlWriter);
                }
                xmlWriter.WriteEndElement();
            }


            if (null != this.Coupon)
                xmlWriter.WriteElementString("coupon_code", this.Coupon.CouponCode);

            if (this.UnitAmountInCents.HasValue)
                xmlWriter.WriteElementString("unit_amount_in_cents", this.UnitAmountInCents.Value.ToString());

            xmlWriter.WriteElementString("currency", this.Currency);
            xmlWriter.WriteElementString("quantity", this.Quantity.ToString());

            if (this.TrialPeriodEndsAt.HasValue)
                xmlWriter.WriteElementString("trial_ends_at", this.TrialPeriodEndsAt.Value.ToString("s"));

            if (this.StartsAt.HasValue)
                xmlWriter.WriteElementString("starts_at", this.StartsAt.Value.ToString("s"));

            if (this.TotalBillingCycles.HasValue)
                xmlWriter.WriteElementString("total_billing_cycles", this.TotalBillingCycles.Value.ToString());

            if (this.FirstRenewalDate.HasValue)
                xmlWriter.WriteElementString("first_renewal_date", this.FirstRenewalDate.Value.ToString("s"));


            this.Account.WriteXml(xmlWriter);

            xmlWriter.WriteEndElement(); // End: subscription
        }

        protected void WriteChangeSubscriptionNowXml(XmlTextWriter xmlWriter)
        {
            WriteChangeSubscriptionXml(xmlWriter, ChangeTimeframe.now);
        }

        protected void WriteChangeSubscriptionAtRenewalXml(XmlTextWriter xmlWriter)
        {
            WriteChangeSubscriptionXml(xmlWriter, ChangeTimeframe.renewal);
        }

        protected void WriteChangeSubscriptionXml(XmlTextWriter xmlWriter, ChangeTimeframe timeframe)
        {
            xmlWriter.WriteStartElement("subscription"); // Start: subscription

            xmlWriter.WriteElementString("timeframe", timeframe.ToString());
            xmlWriter.WriteElementString("quantity", this.Quantity.ToString());



            if (!String.IsNullOrEmpty(this._planCode))
                xmlWriter.WriteElementString("plan_code", this._planCode);

            
            if (this.UnitAmountInCents.HasValue)
                xmlWriter.WriteElementString("unit_amount_in_cents", this.UnitAmountInCents.Value.ToString());

            xmlWriter.WriteEndElement(); // End: subscription
        }

        #endregion


        #region Object Overrides

        public override string ToString()
        {
            return "Recurly Subscription: " + this.Uuid;
        }

        public override bool Equals(object obj)
        {
            if (obj is Subscription)
                return Equals((Subscription)obj);
            else
                return false;
        }

        public bool Equals(Subscription subscription)
        {
            return this.Uuid == subscription.Uuid;
        }

        public override int GetHashCode()
        {
            return this.Uuid.GetHashCode();
        }

        #endregion
    }
}
