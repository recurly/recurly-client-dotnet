using System;
using System.Collections.Generic;
using System.Xml;

namespace Recurly
{
    public class PlanRampInterval : RecurlyEntity
    {
        /// <summary>Represents the first billing cycle of a ramp.</summary>
        public int StartingBillingCycle { get; set; }

        /// <summary>Represents the price and currency code for the ramp interval.</summary>
        public List<PlanRampPricing> Currencies
        {
            get { return _currencies ?? (_currencies = new List<PlanRampPricing>()); }
            set { _currencies = value; }
        }

        private List<PlanRampPricing> _currencies;

        public PlanRampInterval() { }

        public PlanRampInterval(int startingBillingCycle, List<PlanRampPricing> currencies)
        {
            StartingBillingCycle = startingBillingCycle;
            Currencies = currencies;
        }

        internal PlanRampInterval(XmlTextReader xmlReader)
        {
            ReadXml(xmlReader);
        }

        internal void ReadXmlCurrencies(XmlTextReader reader)
        {
            while (reader.Read())
            {
                if (reader.Name == "unit_amount_in_cents" && reader.NodeType == XmlNodeType.EndElement)
                    break;

                if (reader.NodeType == XmlNodeType.Element)
                {
                    var currency = new PlanRampPricing()
                    {
                        Currency = reader.Name,
                        UnitAmountInCents = reader.ReadElementContentAsInt()
                    };
                    Currencies.Add(currency);
                }
            }
        }

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
                        ReadXmlCurrencies(reader);
                        break;
                }
            }
        }

        internal override void WriteXml(XmlTextWriter xmlWriter)
        {
            xmlWriter.WriteStartElement("ramp_interval");
            xmlWriter.WriteElementString("starting_billing_cycle", StartingBillingCycle.ToString());
            xmlWriter.WriteIfCollectionHasAny("unit_amount_in_cents", Currencies, pair => pair.Currency, pair => pair.UnitAmountInCents.ToString());
            xmlWriter.WriteEndElement();
        }
    }
}
