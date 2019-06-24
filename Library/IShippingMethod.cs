using System;

namespace Recurly
{
    public interface IShippingMethod : IRecurlyEntity, IEquatable<object>, IEquatable<IShippingMethod>
    {
        string AccountingCode { get; set; }
        string Code { get; set; }
        DateTime CreatedAt { get; }
        string Name { get; set; }
        string TaxCode { get; set; }
        DateTime UpdatedAt { get; }

        int GetHashCode();
        string ToString();
    }
}