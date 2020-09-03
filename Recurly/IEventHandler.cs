using System;

namespace Recurly
{
    public interface IEventHandler
    {
        void OnRequest(Http.Request request);
        void OnResponse(Http.Response response);
    }
}
