namespace Recurly
{
    public interface IRefund : IRecurlyEntity
    {
        bool Prorate { get; }
        int Quantity { get; }
        string Uuid { get; }
    }
}