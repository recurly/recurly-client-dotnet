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
            Now,
            Renewal
        }

        public enum RefundType : short
        {
            Full,
            Partial,
            None
        }



        /// <summary>
        /// Account in Recurly
        /// </summary>
        public Account Account { get; private set; }

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

        public string UUID { get; private set; }

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
        public RecurlyList<AddOn> AddOns { get; set; }

        public int? TotalBillingCycles { get; set; }
        public DateTime FirstRenewalDate { get; set; }

        private const string UrlPrefix = "/subscription/";

        internal Subscription()
        {
            _isPendingSubscription = false;
        }

        internal Subscription(XmlTextReader reader)
        {
            this.ReadXml(reader);
        }

        public Subscription(Account account)
        {
            this.Account = account;
            this.Quantity = 1;
        }


       

        public static Subscription Get(string uuid)
        {
            Subscription s = new Subscription();
            HttpStatusCode statusCode = Client.PerformRequest(Client.HttpRequestMethod.Get,
                UrlPrefix,
                new Client.ReadXmlDelegate(s.ReadXml)).StatusCode;

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

            if (timeframe == ChangeTimeframe.Now)
                writeXmlDelegate = new Client.WriteXmlDelegate(WriteChangeSubscriptionNowXml);
            else
                writeXmlDelegate = new Client.WriteXmlDelegate(WriteChangeSubscriptionAtRenewalXml);

            Client.PerformRequest(Client.HttpRequestMethod.Put,
                UrlPrefix + System.Web.HttpUtility.UrlEncode(this.UUID),
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
            Client.PerformRequest(Client.HttpRequestMethod.Put, UrlPrefix + System.Web.HttpUtility.UrlEncode(this.UUID) + "/cancel");
        }

        /// <summary>
        /// Reactivate a canceled subscription.  The subscription will renew at the end of its current term.
        /// </summary>
        /// <param name="accountCode">Subscriber's Account Code</param>
        public void Reactivate()
        {
            Client.PerformRequest(Client.HttpRequestMethod.Put, UrlPrefix + System.Web.HttpUtility.UrlEncode(this.UUID) + "/reactivate");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nextRenewalDate"></param>
        public void Terminate(RefundType refund)
        {
            Client.PerformRequest(Client.HttpRequestMethod.Put, UrlPrefix + System.Web.HttpUtility.UrlEncode(this.UUID) + "/terminate?refund=" +
                refund.ToString() );
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="nextRenewalDate"></param>
        public void Postpone(DateTime nextRenewalDate)
        {
            Client.PerformRequest(Client.HttpRequestMethod.Put,
                UrlPrefix + System.Web.HttpUtility.UrlEncode(this.UUID) + "/postpone?next_renewal_date=" +
                nextRenewalDate.ToString("c"));
        }

        /// <summary>
        /// Returns a list of recurly subscriptions
        /// 
        /// A subscription will belong to more than one state.
        /// </summary>
        /// <param name="state">State of subscriptions to return, defaults to "live"</param>
        /// <returns></returns>
        public static RecurlyList<Subscription> GetSubscriptions(SubstriptionState state = SubstriptionState.Live)
        {
            RecurlyList<Subscription> l = new RecurlyList<Subscription>();
            HttpStatusCode statusCode = Client.PerformRequest(Client.HttpRequestMethod.Get,
                UrlPrefix + "?state=" + System.Web.HttpUtility.UrlEncode(state.ToString()),
                new Client.ReadXmlDelegate(l.ReadXml)).StatusCode;

            if (statusCode == HttpStatusCode.NotFound)
                return null;

            return l;
        }


        #region Read and Write XML documents

        internal void ReadPlanXml(XmlTextReader reader)
        {
            while (reader.Read())
            {
                // End of account element, get out of here
                if (reader.Name == "plan" && reader.NodeType == XmlNodeType.EndElement)
                    break;

                if (reader.NodeType == XmlNodeType.Element)
                {
                    switch (reader.Name)
                    {
                        case "plan_code":
                            this._planCode = reader.ReadElementContentAsString();
                            break;
                            // case "plan_name":
                    }
                }
            }
        }

        internal void ReadXml(XmlTextReader reader)
        {
            while (reader.Read())
            {
                // End of subscription element, get out of here
                if (reader.Name == "subscription" && reader.NodeType == XmlNodeType.EndElement)
                    break;

                if (reader.NodeType == XmlNodeType.Element)
                {
                    DateTime dateVal;
                    switch (reader.Name)
                    {
                        case "account":
                            this.Account = new Account(reader);
                            break;

                        case "plan":
                            ReadPlanXml(reader);
                            break;

                        case "uuid":
                            this.UUID = reader.ReadElementContentAsString();
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
                                this.AddOns = new RecurlyList<AddOn>();
                            this.AddOns.ReadXml(reader);

                            break;

                        case "pending_subscription":
                            Subscription s = new Subscription(reader);
                            s._isPendingSubscription = true;
                            this.PendingSubscription = s;
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

            if (null != this.FirstRenewalDate)
                xmlWriter.WriteElementString("first_renewal_date", this.FirstRenewalDate.ToString("s"));


            this.Account.WriteXml(xmlWriter);

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

            xmlWriter.WriteElementString("timeframe", timeframe.ToString());
            xmlWriter.WriteElementString("quantity", this.Quantity.ToString());



            if (!String.IsNullOrEmpty(this._planCode))
                xmlWriter.WriteElementString("plan_code", this._planCode);

            
            if (this.UnitAmountInCents.HasValue)
                xmlWriter.WriteElementString("unit_amount_in_cents", this.UnitAmountInCents.Value.ToString());

            xmlWriter.WriteEndElement(); // End: subscription
        }

        #endregion
    }
}
