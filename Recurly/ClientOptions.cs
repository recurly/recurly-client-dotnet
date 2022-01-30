using System;
using System.Collections.Generic;

namespace Recurly
{
    public class ClientOptions
    {
        public enum Regions { US, EU }

        public Regions Region { get; set; }

        private static readonly Dictionary<Regions, string> _RegionUrlMap = new Dictionary<Regions, string>()
        {
            { Regions.US, "https://v3.recurly.com/" },
            { Regions.EU, "https://v3.eu.recurly.com/" }
        };

        public ClientOptions()
        {
            Region = Regions.US;
        }

        public string BaseUrl
        {
            get
            {
                return _RegionUrlMap[Region];
            }
        }
    }
}