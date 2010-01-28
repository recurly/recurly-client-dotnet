using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Xml;

namespace Recurly
{
    public class RecurlySubscription : RecurlyClient
    {
        /// <summary>
        /// Account in Recurly
        /// </summary>
        public RecurlyAccount Account { get; private set; }
        public int? Quantity { get; set; }
        public string PlanCode { get; set; }

        public enum ChangeTimeframe
        {
            Now,
            Renewal
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

            HttpStatusCode statusCode = PerformRequest(HttpRequestMethod.Get,
                SubscriptionUrl(account.AccountCode),
                new ReadXmlDelegate(sub.ReadXml));

            if (statusCode == HttpStatusCode.NotFound)
                return null;

            return sub;
        }


        public void Create()
        {
            HttpStatusCode statusCode = PerformRequest(HttpRequestMethod.Post,
                SubscriptionUrl(this.Account.AccountCode),
                new WriteXmlDelegate(WriteSubscriptionXml),
                null);
            // TODO: read subscription details
        }

        public void ChangeSubscription(ChangeTimeframe timeframe)
        {
            WriteXmlDelegate writeXmlDelegate;

            if (timeframe == ChangeTimeframe.Now)
                writeXmlDelegate = new WriteXmlDelegate(WriteChangeSubscriptionNowXml);
            else
                writeXmlDelegate = new WriteXmlDelegate(WriteChangeSubscriptionAtRenewalXml);

            HttpStatusCode statusCode = PerformRequest(HttpRequestMethod.Put,
                SubscriptionUrl(this.Account.AccountCode),
                writeXmlDelegate);
        }

        /// <summary>
        /// Cancel an active subscription.  The subscription will not renew, but will continue to be active
        /// through the remainder of the current term.
        /// </summary>
        /// <param name="accountCode">Subscriber's Account Code</param>
        public static void CancelSubscription(string accountCode)
        {
            PerformRequest(HttpRequestMethod.Delete, SubscriptionUrl(accountCode));
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
                    switch (reader.Name)
                    {
                        case "account":
                            this.Account = new RecurlyAccount(reader);
                            break;

                        case "plan_code":
                            this.PlanCode = reader.ReadElementContentAsString();
                            break;

                        case "quantity":
                            this.Quantity = reader.ReadElementContentAsInt();
                            break;

                        case "unit_amount_in_cents":
                            this.UnitAmountInCents = reader.ReadElementContentAsInt();
                            break;
                    }
                }
            }
        }

        protected void WriteSubscriptionXml(XmlTextWriter xmlWriter)
        {
            xmlWriter.WriteStartElement("subscription"); // Start: subscription

            xmlWriter.WriteElementString("plan_code", this.PlanCode);

            if (this.Quantity.HasValue)
                xmlWriter.WriteElementString("quantity", this.Quantity.Value.ToString());

            if (this.UnitAmountInCents.HasValue)
                xmlWriter.WriteElementString("unit_amount_in_cents", this.UnitAmountInCents.Value.ToString());

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
