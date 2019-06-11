using System.Collections.Generic;

namespace Recurly
{
    public interface IAccountBalance : IRecurlyEntity
    {
        bool PastDue { get; }
        Dictionary<string, int> BalanceInCents { get; }
    }
}