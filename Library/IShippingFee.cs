using System;

namespace Recurly
{
    public interface IShippingFee : IRecurlyEntity, IEquatable<object>, IEquatable<IShippingFee>
    {
        IShippingAddress ShippingAddress { get; set; }
        long? ShippingAddressId { get; set; }
        int? ShippingAmountInCents { get; set; }
        string ShippingMethodCode { get; set; }

        int GetHashCode();
        string ToString();
    }
}