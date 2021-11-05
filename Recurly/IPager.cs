using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Recurly
{
    public interface IPager<T> : IEnumerable<T>
    {
        bool HasMore { get; }
        List<T> Data { get; }

        IPager<T> FetchNextPage();
        Task<IPager<T>> FetchNextPageAsync(CancellationToken cancellationToken = default);
    }
}
