using System;

namespace Recurly
{
    public interface IMeasuredUnit : IRecurlyEntity, IEquatable<IMeasuredUnit>, IEquatable<object>
    {
        string Description { get; set; }
        string DisplayName { get; set; }
        long Id { get; }
        string Name { get; set; }

        void Create();
        void Delete();
        int GetHashCode();
        string ToString();
        void Update();
    }
}