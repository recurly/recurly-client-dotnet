using System;
using System.Xml;

namespace Recurly
{
    public class PlanRampPricing : RecurlyEntity
    {
        /// <summary>3-letter ISO 4217 currency code.</summary>
        public string Currency { get; set; }

        /// <summary>Represents the price for the Ramp Interval.</summary>
        public int UnitAmountInCents { get; set; }

        public PlanRampPricing() { }

        public PlanRampPricing(string currencyCode, int unitAmountInCents)
        {
            Currency = currencyCode;
            UnitAmountInCents = unitAmountInCents;
        }

        internal override void WriteXml(XmlTextWriter xmlWriter)
        {
            throw new NotImplementedException();
        }

        internal override void ReadXml(XmlTextReader xmlWriter)
        {
            throw new NotImplementedException();
        }
    }
}
