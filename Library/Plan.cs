using System;
using System.Collections.Generic;
using System.Net;
using System.Xml;

namespace Recurly
{
    public class Plan : RecurlyEntity
    {
        public enum IntervalUnit
        {
            Days,
            Months
        }

        public string PlanCode { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string SuccessUrl { get; set; }
        public string CancelUrl { get; set; }

        public bool? DisplayDonationAmounts { get; set; }
        public bool? DisplayQuantity { get; set; }
        public bool? DisplayPhoneNumber { get; set; }
        public bool? BypassHostedConfirmation { get; set; }

        public string UnitName { get; set; }
        public string PaymentPageTOSLink { get; set; }

        public int? PlanIntervalLength { get; set; }
        public IntervalUnit PlanIntervalUnit { get; set; }

        public int? TrialIntervalLength { get; set; }
        public IntervalUnit TrialIntervalUnit { get; set; }

        public string AccountingCode { get; set; }
        public string SetupFeeAccountingCode { get; set; }

        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }

        public int? TotalBillingCycles { get; set; }

        public bool? TaxExempt { get; set; }

        public string TaxCode { get; set; }

        public bool? TrialRequiresBillingInfo { get; set; }

        public Adjustment.RevenueSchedule? RevenueScheduleType { get; set; }
        public Adjustment.RevenueSchedule? SetupFeeRevenueScheduleType { get; set; }

        private AddOnList _addOns;

        public RecurlyList<AddOn> AddOns
        {
            get
            {
                if (_addOns == null)
                {
                    var url = UrlPrefix + Uri.EscapeDataString(PlanCode) + "/add_ons/";
                    _addOns = new AddOnList(url);
                }
                return _addOns;
            }
        }

        private Dictionary<string, int> _unitAmountInCents;
        /// <summary>
        /// A dictionary of currencies and values for the subscription amount
        /// </summary>
        public Dictionary<string, int> UnitAmountInCents
        {
            get { return _unitAmountInCents ?? (_unitAmountInCents = new Dictionary<string, int>()); }
        }

        private Dictionary<string, int> _setupFeeInCents;
        /// <summary>
        /// A dictionary of currency and values for the setup fee
        /// </summary>
        public Dictionary<string, int> SetupFeeInCents
        {
            get { return _setupFeeInCents ?? (_setupFeeInCents = new Dictionary<string, int>()); }
        }

        internal const string UrlPrefix = "/plans/";

        #region Constructors
        internal Plan()
        {
        }

        internal Plan(XmlTextReader xmlReader)
        {
            ReadXml(xmlReader);
        }

        public Plan(string planCode, string name)
        {
            PlanCode = planCode;
            Name = name;
        }

        #endregion

        /// <summary>
        /// Create a new plan in Recurly
        /// </summary>
        public void Create()
        {
            Client.Instance.PerformRequest(Client.HttpRequestMethod.Post,
                UrlPrefix,
                WriteXml,
                ReadXml);
        }

        /// <summary>
        /// Update an existing plan in Recurly
        /// </summary>
        public void Update()
        {
            Client.Instance.PerformRequest(Client.HttpRequestMethod.Put,
                UrlPrefix + Uri.EscapeDataString(PlanCode),
                WriteXml);
        }

        /// <summary>
        /// Deletes this plan, making it inactive
        /// </summary>
        public void Deactivate()
        {
            Client.Instance.PerformRequest(Client.HttpRequestMethod.Delete, UrlPrefix + Uri.EscapeDataString(PlanCode));
        }

        /// <summary>
        /// Returns an new add on associated with this plan.
        /// </summary>
        /// <param name="addOnCode"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public AddOn NewAddOn(string addOnCode, string name)
        {
            var a = new AddOn(PlanCode, addOnCode, name);
            return a;
        }

        public AddOn GetAddOn(string addOnCode)
        {
            var addOn = new AddOn();

            var status = Client.Instance.PerformRequest(Client.HttpRequestMethod.Get,
                UrlPrefix + Uri.EscapeDataString(PlanCode) + "/add_ons/" + Uri.EscapeDataString(addOnCode),
                addOn.ReadXml);

            if (status != HttpStatusCode.OK) return null;

            // PlanCode is needed to update the AddOn
            // TODO: need a cleaner way of getting the plan code from xml
            //       should be using the hrefs of the resources
            addOn.PlanCode = PlanCode;

            return addOn;
        }

        #region Read and Write XML documents

        internal void ReadXmlSetupFee(XmlTextReader reader)
        {

            while (reader.Read())
            {
                if (reader.Name == "setup_fee_in_cents" && reader.NodeType == XmlNodeType.EndElement)
                    break;

                if (reader.NodeType == XmlNodeType.Element)
                {
                    SetupFeeInCents.Add(reader.Name, reader.ReadElementContentAsInt());
                }
            }
        }

        internal void ReadXmlUnitAmount(XmlTextReader reader)
        {

            while (reader.Read())
            {
                if (reader.Name == "unit_amount_in_cents" && reader.NodeType == XmlNodeType.EndElement)
                    break;

                if (reader.NodeType == XmlNodeType.Element)
                {
                    UnitAmountInCents.Add(reader.Name, reader.ReadElementContentAsInt());
                }
            }
        }

        internal override void ReadXml(XmlTextReader reader)
        {
            UnitAmountInCents.Clear();
            SetupFeeInCents.Clear();

            while (reader.Read())
            {
                // End of account element, get out of here
                if (reader.Name == "plan" && reader.NodeType == XmlNodeType.EndElement)
                    break;

                if (reader.NodeType != XmlNodeType.Element) continue;

                switch (reader.Name)
                {
                    case "plan_code":
                        PlanCode = reader.ReadElementContentAsString();
                        break;

                    case "name":
                        Name = reader.ReadElementContentAsString();
                        break;

                    case "description":
                        Description = reader.ReadElementContentAsString();
                        break;

                    case "success_url":
                        SuccessUrl = reader.ReadElementContentAsString();
                        break;

                    case "cancel_url":
                        CancelUrl = reader.ReadElementContentAsString();
                        break;

                    case "display_donation_amounts":
                        DisplayDonationAmounts = reader.ReadElementContentAsBoolean();
                        break;

                    case "display_quantity":
                        DisplayQuantity = reader.ReadElementContentAsBoolean();
                        break;

                    case "display_phone_number":
                        DisplayPhoneNumber = reader.ReadElementContentAsBoolean();
                        break;

                    case "bypass_hosted_confirmation":
                        BypassHostedConfirmation = reader.ReadElementContentAsBoolean();
                        break;

                    case "unit_name":
                        UnitName = reader.ReadElementContentAsString();
                        break;

                    case "payment_page_tos_link":
                        PaymentPageTOSLink = reader.ReadElementContentAsString();
                        break;

                    case "plan_interval_length":
                        PlanIntervalLength = reader.ReadElementContentAsInt();
                        break;

                    case "plan_interval_unit":
                        PlanIntervalUnit = reader.ReadElementContentAsString().ParseAsEnum<IntervalUnit>();
                        break;

                    case "trial_interval_length":
                        TrialIntervalLength = reader.ReadElementContentAsInt();
                        break;

                    case "trial_interval_unit":
                        TrialIntervalUnit = reader.ReadElementContentAsString().ParseAsEnum<IntervalUnit>();
                        break;

                    case "accounting_code":
                        AccountingCode = reader.ReadElementContentAsString();
                        break;

                    case "setup_fee_accounting_code":
                        SetupFeeAccountingCode = reader.ReadElementContentAsString();
                        break;

                    case "created_at":
                        CreatedAt = reader.ReadElementContentAsDateTime();
                        break;

                    case "updated_at":
                        UpdatedAt = reader.ReadElementContentAsDateTime();
                        break;

                    case "tax_exempt":
                        TaxExempt = reader.ReadElementContentAsBoolean();
                        break;

                    case "tax_code":
                        TaxCode = reader.ReadElementContentAsString();
                        break;

                    case "unit_amount_in_cents":
                        ReadXmlUnitAmount(reader);
                        break;

                    case "setup_fee_in_cents":
                        ReadXmlSetupFee(reader);
                        break;

                    case "total_billing_cycles":
                        int totalBillingCycles;
                        if (int.TryParse(reader.ReadElementContentAsString(), out totalBillingCycles))
                            TotalBillingCycles = totalBillingCycles;
                        break;

                    case "trial_requires_billing_info":
                        bool b;
                        if (bool.TryParse(reader.ReadElementContentAsString(), out b))
                            TrialRequiresBillingInfo = b;
                        break;

                    case "revenue_schedule_type":
                        var revenueScheduleType = reader.ReadElementContentAsString();
                        if (!revenueScheduleType.IsNullOrEmpty())
                            RevenueScheduleType = revenueScheduleType.ParseAsEnum<Adjustment.RevenueSchedule>();
                        break;

                    case "setup_fee_revenue_schedule_type":
                        var setupFeeRevenueScheduleType = reader.ReadElementContentAsString();
                        if (!setupFeeRevenueScheduleType.IsNullOrEmpty())
                            SetupFeeRevenueScheduleType = setupFeeRevenueScheduleType.ParseAsEnum<Adjustment.RevenueSchedule>();
                        break;
                }
            }
        }

        internal override void WriteXml(XmlTextWriter xmlWriter)
        {
            xmlWriter.WriteStartElement("plan");

            xmlWriter.WriteElementString("plan_code", PlanCode);
            xmlWriter.WriteElementString("name", Name);
            xmlWriter.WriteStringIfValid("description", Description);
            xmlWriter.WriteStringIfValid("accounting_code", AccountingCode);
            xmlWriter.WriteStringIfValid("setup_fee_accounting_code", SetupFeeAccountingCode);
            if (PlanIntervalLength.HasValue)
            {
                xmlWriter.WriteElementString("plan_interval_unit", PlanIntervalUnit.ToString().EnumNameToTransportCase());
                xmlWriter.WriteElementString("plan_interval_length", PlanIntervalLength.Value.AsString());
            }
            if (TrialIntervalLength.HasValue)
            {
                xmlWriter.WriteElementString("trial_interval_unit", TrialIntervalUnit.ToString().EnumNameToTransportCase());
                xmlWriter.WriteElementString("trial_interval_length", TrialIntervalLength.Value.AsString());
            }

            xmlWriter.WriteIfCollectionHasAny("setup_fee_in_cents", SetupFeeInCents, pair => pair.Key, pair => pair.Value.AsString());

            xmlWriter.WriteIfCollectionHasAny("unit_amount_in_cents", UnitAmountInCents, pair => pair.Key, pair => pair.Value.AsString());

            if (TotalBillingCycles.HasValue && TotalBillingCycles > 0)
                xmlWriter.WriteElementString("total_billing_cycles", TotalBillingCycles.Value.AsString());

            xmlWriter.WriteStringIfValid("unit_name", UnitName);

            if (DisplayDonationAmounts.HasValue)
                xmlWriter.WriteElementString("display_donation_amounts", DisplayDonationAmounts.Value.AsString());

            if (DisplayQuantity.HasValue)
                xmlWriter.WriteElementString("display_quantity", DisplayQuantity.Value.AsString());

            if (DisplayPhoneNumber.HasValue)
                xmlWriter.WriteElementString("display_phone_number", DisplayPhoneNumber.Value.AsString());

            if (BypassHostedConfirmation.HasValue)
                xmlWriter.WriteElementString("bypass_hosted_confirmation", BypassHostedConfirmation.Value.AsString());

            if (TaxExempt.HasValue)
                xmlWriter.WriteElementString("tax_exempt", TaxExempt.Value.AsString());

            if (TrialRequiresBillingInfo.HasValue)
                xmlWriter.WriteElementString("trial_requires_billing_info", TrialRequiresBillingInfo.Value.AsString());

            xmlWriter.WriteStringIfValid("success_url", SuccessUrl);
            xmlWriter.WriteStringIfValid("cancel_url", CancelUrl);

            if (RevenueScheduleType.HasValue)
                xmlWriter.WriteElementString("revenue_schedule_type", RevenueScheduleType.Value.ToString().EnumNameToTransportCase());

            if (SetupFeeRevenueScheduleType.HasValue)
                xmlWriter.WriteElementString("setup_fee_revenue_schedule_type", SetupFeeRevenueScheduleType.Value.ToString().EnumNameToTransportCase());

            xmlWriter.WriteEndElement();
        }


        #endregion

        #region Object Overrides

        public override string ToString()
        {
            return "Recurly Plan: " + PlanCode;
        }

        public override bool Equals(object obj)
        {
            var plan = obj as Plan;
            return plan != null && Equals(plan);
        }

        public bool Equals(Plan plan)
        {
            return PlanCode == plan.PlanCode;
        }

        public override int GetHashCode()
        {
            return PlanCode?.GetHashCode() ?? 0;
        }

        #endregion
    }

    public sealed class Plans
    {
        /// <summary>
        /// Retrieves a list of all active plans
        /// </summary>
        /// <returns></returns>
        public static RecurlyList<Plan> List()
        {
            return List(null);
        }

        /// <summary>
        /// Lists accounts, limited to state
        /// </summary>
        /// <param name="state">Account state to retrieve</param>
        /// <param name="filter">FilterCriteria used to apply server side sorting and filtering</param>
        /// <returns></returns>
        public static RecurlyList<Plan> List(FilterCriteria filter)
        {
            filter = filter == null ? FilterCriteria.Instance : filter;
            return new PlanList(Plan.UrlPrefix + "?" + filter.ToNamedValueCollection().ToString());
        }

        /// <summary>
        /// Retrieves a Plan
        /// </summary>
        /// <param name="planCode"></param>
        /// <returns></returns>
        public static Plan Get(string planCode)
        {
            var plan = new Plan();

            var statusCode = Client.Instance.PerformRequest(Client.HttpRequestMethod.Get,
                Plan.UrlPrefix + Uri.EscapeDataString(planCode),
                plan.ReadXml);

            return statusCode == HttpStatusCode.NotFound ? null : plan;
        }
    }
}
