using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Recurly {
    public class ApiError : Resource {

        [JsonProperty("type")]
        public ApiErrorTypes Type { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        public ApiError() {

        }
    }
}