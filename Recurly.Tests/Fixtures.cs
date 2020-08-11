using System;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Recurly.Tests
{
    public class MyResource : Resource
    {
        [JsonProperty("my_string")]
        public string MyString { get; set; }

        [JsonProperty("my_decimal")]
        public decimal? MyDecimal { get; set; }

        [JsonProperty("my_int")]
        public int? MyInt { get; set; }

        [JsonProperty("my_date_time")]
        public DateTime? MyDateTime { get; set; }

        [JsonProperty("my_sub_resource")]
        public MySubResource MySubResource { get; set; }

        [JsonProperty("my_array_string")]
        public List<string> MyArrayString { get; set; }

        [JsonProperty("my_array_sub_resource")]
        public List<MySubResource> MyArraySubResource { get; set; }
    }

    public class MySubResource : Resource
    {
        [JsonProperty("my_string")]
        public string MyString { get; set; }
    }

    public class MyResourceCreate : Request
    {
        [JsonProperty("my_string")]
        public string MyString { get; set; }
    }

    public class MyApiError : Recurly.Errors.ApiError
    {
        public MyApiError() { }
        public MyApiError(string message) : base(message) { }
        public MyApiError(string message, Exception inner) : base(message, inner) { }
    }

}
