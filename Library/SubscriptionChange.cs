using System;
using System.Collections.Generic;
using System.Net;
using System.Xml;

namespace Recurly
{

    /// <summary>
    /// Represents subscriptions for accounts
    /// </summary>
    public class SubscriptionChange : ISubscriptionChange
    {
        public enum ChangeTimeframe : short
        {
            Now,
            Renewal,
            BillDate
        }

        public ChangeTimeframe TimeFrame { get; set; }

        public string PlanCode { get; set; }

        /// <summary>
        /// List of custom fields
        /// </summary>
        public List<CustomField> CustomFields
        {
            get { return _customFields ?? (_customFields = new List<CustomField>()); }
            set { _customFields = value; }
        }
        private List<CustomField> _customFields;

        /// <summary>
        /// Unit amount per quantity.  Leave null to keep as is. Set to override plan's default amount.
        /// </summary>
        public int? UnitAmountInCents { get; set; }

        public int? Quantity { get; set; }

        /// <summary>
        /// List of add ons for this subscription
        /// </summary>
        public SubscriptionAddOnList AddOns { get; set; }

        /// <summary>
        /// The coupon code you want to redeem in the update.
        /// Only allowed if timeframe is now and you change something about the subscription that creates an invoice.
        /// </summary>
        public string CouponCode { get; set; }

        public int? RemainingBillingCycles { get; set; }

        public string CollectionMethod { get; set; }

        public int? NetTerms { get; set; }

        public string PoNumber { get; set; }

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

        public Adjustment.RevenueSchedule? RevenueScheduleType { get; set; }

        /// <summary>
        /// Optionally set true to indicate if the subscription is to be treated as an import
        /// for data analysis or a real trial. This value can only be changed on a trial subscription
        /// and is persisted for its lifetime.
        /// </summary>
        public bool? ImportedTrial { get; set; }

        /// <summary>
        /// Creates a new subscription change object
        /// </summary>
        public SubscriptionChange() { }

        #region Write XML documents

        internal void WriteChangeSubscriptionXml(XmlTextWriter xmlWriter)
        {
            WriteChangeSubscriptionXml(xmlWriter, this);
        }

        internal static void WriteChangeSubscriptionXml(XmlTextWriter xmlWriter, ISubscriptionChange subscription)
        {
            xmlWriter.WriteStartElement("subscription"); // Start: subscription

            xmlWriter.WriteElementString("timeframe", subscription.TimeFrame.ToString().EnumNameToTransportCase());

            if (subscription.Quantity.HasValue)
                xmlWriter.WriteElementString("quantity", subscription.Quantity.ToString());

            xmlWriter.WriteStringIfValid("plan_code", subscription.PlanCode);

            if (subscription.AddOns != null)
                xmlWriter.WriteIfCollectionHasAny("subscription_add_ons", subscription.AddOns);

            xmlWriter.WriteStringIfValid("coupon_code", subscription.CouponCode);

            if (subscription.UnitAmountInCents.HasValue)
                xmlWriter.WriteElementString("unit_amount_in_cents", subscription.UnitAmountInCents.Value.AsString());

            xmlWriter.WriteStringIfValid("collection_method", subscription.CollectionMethod);

            if (subscription.NetTerms.HasValue)
                xmlWriter.WriteElementString("net_terms", subscription.NetTerms.Value.AsString());

            if (subscription.PoNumber != null)
                xmlWriter.WriteElementString("po_number", subscription.PoNumber);

            if (subscription.ImportedTrial.HasValue)
                xmlWriter.WriteElementString("imported_trial", subscription.ImportedTrial.Value.ToString().ToLower());

            if (subscription.RevenueScheduleType.HasValue)
                xmlWriter.WriteElementString("revenue_schedule_type", subscription.RevenueScheduleType.Value.ToString().EnumNameToTransportCase());

            if (subscription.RemainingBillingCycles.HasValue)
                xmlWriter.WriteElementString("remaining_billing_cycles", subscription.RemainingBillingCycles.Value.AsString());

            if (subscription.AutoRenew.HasValue)
                xmlWriter.WriteElementString("auto_renew", subscription.AutoRenew.Value.AsString());

            if (subscription.RenewalBillingCycles.HasValue)
                xmlWriter.WriteElementString("renewal_billing_cycles", subscription.RenewalBillingCycles.Value.AsString());

            xmlWriter.WriteIfCollectionHasAny("custom_fields", subscription.CustomFields);

            xmlWriter.WriteEndElement(); // End: subscription
        }
        #endregion


        #region Object Overrides

        public override string ToString()
        {
            return "Recurly SubscriptionChange";
        }

        #endregion
    }
}
