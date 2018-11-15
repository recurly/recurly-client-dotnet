using System;
using Newtonsoft.Json;

namespace Recurly {
    public class ApiError : Exception {
        [JsonProperty("type")]
        public string Type { get; set; }

        public ApiError(string message) : base(message) {}

        public ApiError(string message, Exception inner) : base(message, inner)
        {
        }
    }
}