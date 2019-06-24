using System;

namespace Recurly
{
    public interface IAccountAcquisition : IRecurlyEntity, IEquatable<object>, IEquatable<IAccountAcquisition>
    {
        string AccountCode { get; }
        string Campaign { get; set; }
        AccountAcquisition.AccountAcquisitionChannel? Channel { get; set; }
        int? CostInCents { get; set; }
        string Currency { get; set; }
        string SubChannel { get; set; }

        void Create();
        int GetHashCode();
        string ToString();
        void Update();
    }
}