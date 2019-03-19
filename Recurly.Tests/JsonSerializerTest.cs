using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
using Xunit;
using Recurly;
using Recurly.Resources;
using RestSharp;
using RestSharp.Authenticators;
using Moq;
using Newtonsoft.Json;

namespace Recurly.UnitTests
{
    internal class MyResource : Resource {
        [JsonProperty("my_string")]
        public string MyString { get; set; }

        [JsonProperty("my_float")]
        public float? MyFloat { get; set; }

        [JsonProperty("my_int")]
        public int? MyInt { get; set; }

        [JsonProperty("my_date_time")]
        public DateTime? MyDateTime { get; set; }
    }

    public class JsonSerializerTest
    {
        private JsonSerializer _jsonSerializer;

        public JsonSerializerTest()
        {
            _jsonSerializer = new JsonSerializer();
        }

        [Fact]
        public void Deserialize()
        {
            // make sure it can deserialize all primitive types and convert b/w snake and camel case
            var json = "{\"my_string\":\"benjamin\",\"my_float\":3.14,\"my_int\": 3}";
            var resource = _jsonSerializer.Deserialize<MyResource>(MockResourceResponse(json));
            Assert.Equal("benjamin", resource.MyString);
            Assert.Equal(3.14f, resource.MyFloat);
            Assert.Equal(3, resource.MyInt);
        }

        [Fact]
        public void DeserializeWithWrongType()
        {
            var json = "{\"my_string\":\"benjamin\",\"my_int\":\"49urj\"}";
            Assert.Throws<JsonReaderException>(() => _jsonSerializer.Deserialize<MyResource>(MockResourceResponse(json)));
        }

        [Fact]
        public void DeserializeWithNewUnrecognizedKey()
        {
            var json = "{\"my_string\":\"benjamin\",\"unrecognized\":\"unknown\"}";
            var resource = _jsonSerializer.Deserialize<MyResource>(MockResourceResponse(json));
            // It should ignore the the unrecognized new field but still parse other properties
            Assert.Equal("benjamin", resource.MyString);
        }

        [Fact]
        public void Serialize()
        {
            // make sure it can serialize all primitive types and convert b/w snake and camel case
            var resource = new MyResource() {
                MyString = "benjamin",
                MyFloat = 3.14f,
                MyInt = 3
            };
            var jsonStr = _jsonSerializer.Serialize(resource);
            var json = "{\"my_string\":\"benjamin\",\"my_float\":3.14,\"my_int\":3}";
            Assert.Equal(jsonStr, json);
        }
        private RestSharp.IRestResponse MockResourceResponse(string json) {
            var mockResponse =  new Mock<IRestResponse<Account>>();
            mockResponse.Setup(_ => _.StatusCode).Returns(System.Net.HttpStatusCode.OK);
            mockResponse.Setup(_ => _.Content).Returns(json);
            mockResponse.Setup(_ => _.Headers).Returns(new List<Parameter> {});
            return mockResponse.Object;
        }
    }
}
