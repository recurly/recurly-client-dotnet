﻿using System;
using System.Collections.Generic;
using System.Net;
using System.Xml;

namespace Recurly
{
    public class Plan
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

        public int PlanIntervalLength { get; set; }
        public IntervalUnit PlanIntervalUnit { get; set; }

        public int TrialIntervalLength { get; set; }
        public IntervalUnit TrialIntervalUnit { get; set; }

        public string AccountingCode { get; set; }

        public DateTime CreatedAt { get; private set; }

        public int? TotalBillingCycles { get; set; }

        public AddOnList AddOns { get; private set; }


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
        /// Retrieves a Plan
        /// </summary>
        /// <param name="planCode"></param>
        /// <returns></returns>
        public static Plan Get(string planCode)
        {
            var plan = new Plan();

            var statusCode = Client.Instance.PerformRequest(Client.HttpRequestMethod.Get,
                UrlPrefix + Uri.EscapeUriString(planCode),
                plan.ReadXml);

            return statusCode == HttpStatusCode.NotFound ? null : plan;
        }

        /// <summary>
        /// Create a new plan in Recurly
        /// </summary>
        public void Create()
        {
            Client.Instance.PerformRequest(Client.HttpRequestMethod.Post,
                UrlPrefix,
                WriteXml);
        }

        /// <summary>
        /// Update an existing plan in Recurly
        /// </summary>
        public void Update()
        {
            Client.Instance.PerformRequest(Client.HttpRequestMethod.Put,
                UrlPrefix + Uri.EscapeUriString(PlanCode),
                WriteXml);
        }

        /// <summary>
        /// Deletes this plan, making it inactive
        /// </summary>
        public void Deactivate()
        {
            Client.Instance.PerformRequest(Client.HttpRequestMethod.Delete, UrlPrefix + Uri.EscapeUriString(PlanCode));
        }


        

        /// <summary>
        /// Returns an new add on associated with this plan.
        /// </summary>
        /// <param name="addOnCode"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public AddOn CreateAddOn(string addOnCode, string name)
        {
            var a = new AddOn(PlanCode, addOnCode, name);
            return a;
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

        internal void ReadXml(XmlTextReader reader)
        {
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

                    case "created_at":
                        CreatedAt = reader.ReadElementContentAsDateTime();
                        break;

                    case "unit_amount_in_cents":
                        ReadXmlUnitAmount(reader);
                        break;

                    case "setup_fee_in_cents":
                        ReadXmlSetupFee(reader);
                        break;
                }
            }
        }

        internal void WriteXml(XmlTextWriter xmlWriter)
        {
            xmlWriter.WriteStartElement("plan");

            xmlWriter.WriteElementString("plan_code", PlanCode);
            xmlWriter.WriteElementString("name", Name);
            xmlWriter.WriteStringIfValid("description", Description);
            xmlWriter.WriteStringIfValid("accounting_code", AccountingCode);
            if (PlanIntervalLength > 0)
            {
                xmlWriter.WriteElementString("plan_interval_unit", PlanIntervalUnit.ToString().EnumNameToTransportCase());
                xmlWriter.WriteElementString("plan_interval_length", PlanIntervalLength.AsString());
            }
            if (TrialIntervalLength > 0)
            {
                xmlWriter.WriteElementString("trial_interval_unit", TrialIntervalUnit.ToString().EnumNameToTransportCase());
                xmlWriter.WriteElementString("trial_interval_length", TrialIntervalLength.AsString());
            }
            if (null !=  SetupFeeInCents &&  _setupFeeInCents.Count > 0)
            {
                xmlWriter.WriteStartElement("setup_fee_in_cents");
                foreach (var d in SetupFeeInCents)
                {
                    xmlWriter.WriteElementString(d.Key, d.Value.ToString());
                }
                xmlWriter.WriteEndElement();
            }

            if (null != UnitAmountInCents && _unitAmountInCents.Count > 0)
            {
                xmlWriter.WriteStartElement("unit_amount_in_cents");
                foreach (KeyValuePair<string, int> d in UnitAmountInCents)
                {
                    xmlWriter.WriteElementString(d.Key, d.Value.AsString());
                }
                xmlWriter.WriteEndElement();
            }

            if (TotalBillingCycles.HasValue && TotalBillingCycles > 0)
                xmlWriter.WriteElementString("total_billing_cycles", TotalBillingCycles.Value.AsString());

            xmlWriter.WriteStringIfValid("unit_name", UnitName);

            if (DisplayDonationAmounts.HasValue)
                xmlWriter.WriteElementString("display_donation_amounts", DisplayDonationAmounts.Value.ToString());

            if (DisplayQuantity.HasValue)
                xmlWriter.WriteElementString("display_quantity", DisplayQuantity.Value.ToString());

            if (DisplayPhoneNumber.HasValue)
                xmlWriter.WriteElementString("display_phone_number", DisplayPhoneNumber.Value.ToString());

            if (BypassHostedConfirmation.HasValue)
                xmlWriter.WriteElementString("bypass_hosted_confirmation", BypassHostedConfirmation.Value.ToString());

            xmlWriter.WriteStringIfValid("success_url", SuccessUrl);
            xmlWriter.WriteStringIfValid("cancel_url", CancelUrl);

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
            return PlanCode.GetHashCode();
        }

        #endregion
    }
}