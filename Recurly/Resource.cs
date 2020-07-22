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

        public void SetResponse(Response response)
        {
            _response = response;
        }

    }
}
