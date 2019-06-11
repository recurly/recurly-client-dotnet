namespace Recurly
{
    public interface IAccountAcquisition : IRecurlyEntity
    {
        string AccountCode { get; }
        string Campaign { get; set; }
        AccountAcquisition.AccountAcquisitionChannel? Channel { get; set; }
        int? CostInCents { get; set; }
        string Currency { get; set; }
        string SubChannel { get; set; }

        void Create();
        bool Equals(IAccountAcquisition accountAcquisition);
        bool Equals(object obj);
        int GetHashCode();
        string ToString();
        void Update();
    }
}