using System;
using System.Collections.Generic;
using System.Globalization;
using System.Xml;

namespace Recurly
{
    public class SubscriptionRampInterval : RecurlyEntity
    {
        /// <summary>Represents the billing cycle where a ramp interval starts.</summary>
        public int StartingBillingCycle { get; set; }

        /// <summary>Represents the price for the ramp interval.</summary>
        public int UnitAmountInCents { get; set; }

        /// <summary>A readonly element that represents how many billing cycles are left in a ramp interval.</summary>
        public int? RemainingBillingCycles { get { return _remainingBillingCycles; } }

        private int? _remainingBillingCycles;

        #region Constructors
        public SubscriptionRampInterval() { }

        public SubscriptionRampInterval(int startingBillingCycle, int unitAmountInCents)
        {
            StartingBillingCycle = startingBillingCycle;
            UnitAmountInCents = unitAmountInCents;
        }

        public SubscriptionRampInterval(XmlTextReader reader)
        {
            ReadXml(reader);
        }
        #endregion


        #region Read and Write XML documents
        internal override void ReadXml(XmlTextReader reader)
        {
            while (reader.Read())
            {
                if (reader.Name == "ramp_interval" && reader.NodeType == XmlNodeType.EndElement)
                    break;

                if (reader.NodeType != XmlNodeType.Element) continue;

                switch (reader.Name)
                {
                    case "starting_billing_cycle":
                        StartingBillingCycle = reader.ReadElementContentAsInt();
                        break;

                    case "unit_amount_in_cents":
                        UnitAmountInCents = reader.ReadElementContentAsInt();
                        break;

                    case "remaining_billing_cycles":
                        string elementContent = reader.ReadElementContentAsString();
                        _remainingBillingCycles = !elementContent.IsNullOrWhiteSpace() ? int.Parse(elementContent) : (int?)null;
                        break;
                }
            }
        }

        internal override void WriteXml(XmlTextWriter xmlWriter)
        {
            xmlWriter.WriteStartElement("ramp_interval");
            xmlWriter.WriteElementString("starting_billing_cycle", StartingBillingCycle.ToString());
            xmlWriter.WriteElementString("unit_amount_in_cents", UnitAmountInCents.ToString());
            xmlWriter.WriteEndElement();
        }
        #endregion
    }
}
