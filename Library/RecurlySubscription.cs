using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Xml;

namespace Recurly
{
    public class RecurlySubscription
    {
        /// <summary>
        /// Account in Recurly
        /// </summary>
        public RecurlyAccount Account { get; private set; }
        public int? Quantity { get; set; }
        public string PlanCode { get; set; }
        public string CouponCode { get; set; }
        public string State { get; private set; }

        // Additional information
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
            get { return this.trialPeriodEndsAt; }
            set
            {
                if (this.ActivatedAt.HasValue)
                    throw new InvalidOperationException("Cannot set TrialPeriodEndsAt on existing subscriptions.");
                if (value.HasValue && (value < DateTime.UtcNow))
                    throw new ArgumentException("TrialPeriodEndsAt must occur in the future.");

                this.trialPeriodEndsAt = value;
            }
        }
        private DateTime? trialPeriodEndsAt;

        // TODO: Read pending subscription information

        public enum ChangeTimeframe
        {
            Now,
            Renewal
        }

        public enum RefundType
        {
            Full,
            Partial,
            None
        }

        /// <summary>
        /// Unit amount per quantity.  Leave null to keep as is. Set to override plan's default amount.
        /// </summary>
        public int? UnitAmountInCents { get; set; }

        private const string UrlPrefix = "/accounts/";
        private const string UrlPostfix = "/subscription";



        public RecurlySubscription(RecurlyAccount account)
        {
            this.Account = account;
            this.Quantity = 1;
        }

        private static string SubscriptionUrl(string accountCode)
        {
            return UrlPrefix + System.Web.HttpUtility.UrlEncode(accountCode) + UrlPostfix;
        }

        public static RecurlySubscription Get(string accountCode)
        {
            return Get(new RecurlyAccount(accountCode));
        }

        public static RecurlySubscription Get(RecurlyAccount account)
        {
            RecurlySubscription sub = new RecurlySubscription(account);

            HttpStatusCode statusCode = RecurlyClient.PerformRequest(RecurlyClient.HttpRequestMethod.Get,
                SubscriptionUrl(account.AccountCode),
                new RecurlyClient.ReadXmlDelegate(sub.ReadXml));

            if (statusCode == HttpStatusCode.NotFound)
                return null;

            return sub;
        }


        public void Create()
        {
            HttpStatusCode statusCode = RecurlyClient.PerformRequest(RecurlyClient.HttpRequestMethod.Post,
                SubscriptionUrl(this.Account.AccountCode),
                new RecurlyClient.WriteXmlDelegate(WriteSubscriptionXml),
                new RecurlyClient.ReadXmlDelegate(this.ReadXml));
        }

        public void ChangeSubscription(ChangeTimeframe timeframe)
        {
            RecurlyClient.WriteXmlDelegate writeXmlDelegate;

            if (timeframe == ChangeTimeframe.Now)
                writeXmlDelegate = new RecurlyClient.WriteXmlDelegate(WriteChangeSubscriptionNowXml);
            else
                writeXmlDelegate = new RecurlyClient.WriteXmlDelegate(WriteChangeSubscriptionAtRenewalXml);

            HttpStatusCode statusCode = RecurlyClient.PerformRequest(RecurlyClient.HttpRequestMethod.Put,
                SubscriptionUrl(this.Account.AccountCode),
                writeXmlDelegate,
                new RecurlyClient.ReadXmlDelegate(this.ReadXml));
        }

        /// <summary>
        /// Cancel an active subscription.  The subscription will not renew, but will continue to be active
        /// through the remainder of the current term.
        /// </summary>
        /// <param name="accountCode">Subscriber's Account Code</param>
        public static void CancelSubscription(string accountCode)
        {
            RecurlyClient.PerformRequest(RecurlyClient.HttpRequestMethod.Delete, SubscriptionUrl(accountCode));
        }

        /// <summary>
        /// Reactivate a canceled subscription.  The subscription will renew at the end of its current term.
        /// </summary>
        /// <param name="accountCode">Subscriber's Account Code</param>
        public static void ReactivateSubscription(string accountCode)
        {
            RecurlyClient.PerformRequest(RecurlyClient.HttpRequestMethod.Post, SubscriptionUrl(accountCode) + "/reactivate");
        }

        /// <summary>
        /// Immediately terminate the subscription and issue a refund.  The refund can be for the full amount
        /// or prorated until its paid-thru date.  If you need to refund a specific amount, please issue a
        /// refund against the individual transaction instead.
        /// </summary>
        /// <param name="accountCode">Subscriber's Account Code</param>
        /// <param name="refundType"></param>
        public static void RefundSubscription(string accountCode, RefundType refundType)
        {
            string refundTypeParameter = refundType.ToString().ToLower();

            string refundUrl = String.Format("{0}?refund={1}",
                SubscriptionUrl(accountCode),
                refundTypeParameter);

            RecurlyClient.PerformRequest(RecurlyClient.HttpRequestMethod.Delete, refundUrl);
        }

        /// <summary>
        /// Terminate the subscription immediately and do not issue a refund.
        /// </summary>
        /// <param name="accountCode"></param>
        public static void TerminateSubscription(string accountCode)
        {
            RefundSubscription(accountCode, RefundType.None);
        }

        #region Read and Write XML documents

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
                            this.Account = new RecurlyAccount(reader);
                            break;

                        case "plan_code":
                            this.PlanCode = reader.ReadElementContentAsString();
                            break;

                        case "state":
                            this.State = reader.ReadElementContentAsString();
                            break;

                        case "quantity":
                            this.Quantity = reader.ReadElementContentAsInt();
                            break;

                        case "unit_amount_in_cents":
                            this.UnitAmountInCents = reader.ReadElementContentAsInt();
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
                                this.trialPeriodEndsAt = dateVal;
                            break;

                        case "pending_subscription":
                            // TODO: Parse pending subscription
                            break;
                    }
                }
            }
        }

        protected void WriteSubscriptionXml(XmlTextWriter xmlWriter)
        {
            xmlWriter.WriteStartElement("subscription"); // Start: subscription

            xmlWriter.WriteElementString("plan_code", this.PlanCode);

            if (!String.IsNullOrEmpty(this.CouponCode))
                xmlWriter.WriteElementString("coupon_code", this.CouponCode);

            if (this.Quantity.HasValue)
                xmlWriter.WriteElementString("quantity", this.Quantity.Value.ToString());

            if (this.UnitAmountInCents.HasValue)
                xmlWriter.WriteElementString("unit_amount_in_cents", this.UnitAmountInCents.Value.ToString());

            if (this.TrialPeriodEndsAt.HasValue)
                xmlWriter.WriteElementString("trial_ends_at", this.TrialPeriodEndsAt.Value.ToString("s"));

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

            xmlWriter.WriteElementString("timeframe",
                (timeframe == ChangeTimeframe.Now ? "now" : "renewal"));

            if (!String.IsNullOrEmpty(this.PlanCode))
                xmlWriter.WriteElementString("plan_code", this.PlanCode);

            if (this.Quantity.HasValue)
                xmlWriter.WriteElementString("quantity", this.Quantity.Value.ToString());

            if (this.UnitAmountInCents.HasValue)
                xmlWriter.WriteElementString("unit_amount_in_cents", this.UnitAmountInCents.Value.ToString());

            xmlWriter.WriteEndElement(); // End: subscription
        }

        #endregion
    }
}