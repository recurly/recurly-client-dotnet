using System.Diagnostics.CodeAnalysis;

namespace Recurly
{
    [ExcludeFromCodeCoverage]
    public class Resource
    {
        private Response _response;

        public Response GetResponse()
        {
            return _response;
        }

        internal void SetResponse(Response response)
        {
            _response = response;
        }

    }
}
