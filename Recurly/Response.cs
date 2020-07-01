using System.Collections.Generic;
using System.Net;
using RestSharp;

namespace Recurly
{
    public class Response
    {
        public string RawResponse { get; set; }
        public HttpStatusCode StatusCode { get; set; }

        public IList<Parameter> Headers { get; set; }

        public Response() { }

        public static Response Build(IRestResponse resp)
        {
            return new Response()
            {
                RawResponse = resp.Content,
                StatusCode = resp.StatusCode,
                Headers = resp.Headers
            };
        }

    }
}
