using System;

namespace Recurly
{
    public interface IInvoiceCollection : IRecurlyEntity, IEquatable<object>, IEquatable<IInvoiceCollection>
    {
        IInvoice ChargeInvoice { get; }
        IRecurlyList<IInvoice> CreditInvoices { get; }

        int GetHashCode();
        string ToString();
    }
}