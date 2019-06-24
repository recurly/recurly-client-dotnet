namespace Recurly
{
    public interface IInvoiceCollection : IRecurlyEntity
    {
        IInvoice ChargeInvoice { get; }
        IRecurlyList<IInvoice> CreditInvoices { get; }

        bool Equals(IInvoiceCollection collection);
        bool Equals(object obj);
        int GetHashCode();
        string ToString();
    }
}