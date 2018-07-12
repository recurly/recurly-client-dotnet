using RestSharp.Deserializers;
using System.Collections.Generic;

namespace Recurly {
    public class Pager<T> {
        [DeserializeAs(Name = "has_more")]
        public bool HasMore { get; set; }

        [DeserializeAs(Name = "data")]
        public List<T> Data { get; set; }

        public Pager() {}
    }
}