using System;
using System.Net;
using Recurly.Configuration;

namespace Recurly.Test
{
    internal class TestClient : Client
    {
        public TestClient(Settings settings) : base(settings)
        {
        }

        protected override HttpStatusCode PerformRequest(HttpRequestMethod method, string urlPath, WriteXmlDelegate writeXmlDelegate,
            ReadXmlDelegate readXmlDelegate, ReadXmlListDelegate readXmlListDelegate)
        {
            throw new NotImplementedException();
        }
    }
}
