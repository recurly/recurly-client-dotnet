using System;

namespace Recurly
{
    public interface INote : IRecurlyEntity
    {
        string AccountCode { get; }
        DateTime CreatedAt { get; }
        string Message { get; }
    }
}