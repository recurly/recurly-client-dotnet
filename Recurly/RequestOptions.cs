using System;
using System.Collections.Generic;

namespace Recurly
{
    public class RequestOptions
    {
        public Dictionary<string, string> Headers { get; private set; }

        public string AcceptLanguage
        {
            get
            {
                return Headers["Accept-Language"];
            }
            set
            {
                AddHeader("Accept-Language", value);
            }
        }

        // User-Agent, Content-Type, Accept, and Authorization are not overridable.
        private readonly IList<string> RestrictedHeaders = new List<string> {
            "User-Agent",
            "Content-Type",
            "Accept",
            "Authorization",
            "Idempotency-Key",
        }.AsReadOnly();


        public RequestOptions()
        {
            Headers = new Dictionary<string, string>();
        }

        public void AddHeader(string name, string value)
        {
            if (RestrictedHeaders.Contains(name))
            {
                throw new ArgumentException($"{name} is a restricted header.");
            }
            Headers.Add(name, value);
        }
    }
}