using System.Collections.Generic;
using System.Net;

namespace Recurly.Test.Fixtures
{
    public class FixtureResponse
    {
        public HttpStatusCode StatusCode { get; set; }
        public Dictionary<string, string> Headers { get; set; }
        public string Xml { get; set; }

        public FixtureResponse()
        {
            Headers = new Dictionary<string, string>();
        }

        public void AddHeader(KeyValuePair<string, string> header)
        {
            Headers[header.Key] = header.Value;
        }
    }
}