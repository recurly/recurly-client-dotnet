using System;
using System.Collections.Generic;
using System.Net;
using System.Xml;

namespace Recurly
{

    /// <summary>
    /// Represents subscriptions for accounts
    /// </summary>
    public class SubscriptionChange
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
            xmlWriter.WriteStartElement("subscription"); // Start: subscription

            xmlWriter.WriteElementString("timeframe", TimeFrame.ToString().EnumNameToTransportCase());

            if (Quantity.HasValue)
                xmlWriter.WriteElementString("quantity", Quantity.ToString());

            xmlWriter.WriteStringIfValid("plan_code", PlanCode);

            if (AddOns != null)
                xmlWriter.WriteIfCollectionHasAny("subscription_add_ons", AddOns);

            xmlWriter.WriteStringIfValid("coupon_code", CouponCode);

            if (UnitAmountInCents.HasValue)
                xmlWriter.WriteElementString("unit_amount_in_cents", UnitAmountInCents.Value.AsString());

            xmlWriter.WriteStringIfValid("collection_method", CollectionMethod);

            if (NetTerms.HasValue)
                xmlWriter.WriteElementString("net_terms", NetTerms.Value.AsString());

            if (PoNumber != null)
                xmlWriter.WriteElementString("po_number", PoNumber);

            if (ImportedTrial.HasValue)
                xmlWriter.WriteElementString("imported_trial", ImportedTrial.Value.ToString().ToLower());

            if (RevenueScheduleType.HasValue)
                xmlWriter.WriteElementString("revenue_schedule_type", RevenueScheduleType.Value.ToString().EnumNameToTransportCase());

            if (RemainingBillingCycles.HasValue)
                xmlWriter.WriteElementString("remaining_billing_cycles", RemainingBillingCycles.Value.AsString());

            if (AutoRenew.HasValue)
                xmlWriter.WriteElementString("auto_renew", AutoRenew.Value.AsString());

            if (RenewalBillingCycles.HasValue)
                xmlWriter.WriteElementString("renewal_billing_cycles", RenewalBillingCycles.Value.AsString());

            xmlWriter.WriteIfCollectionHasAny("custom_fields", CustomFields);

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
