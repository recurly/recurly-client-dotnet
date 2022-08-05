using System;
using System.Runtime.Serialization;

namespace Recurly
{
    /// <summary>
    /// A fixed pricing model has the same price for each billing period.
    /// A ramp pricing model defines a set of Ramp Intervals, where a subscription changes price on
    /// a specified cadence of billing periods. The price change could be an increase or decrease.
    /// </summary>
    public enum PricingModelType
    {
        [EnumMember(Value = "fixed")]
        Fixed,

        [EnumMember(Value = "ramp")]
        Ramp,
    }
}
