using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Moq;
using Newtonsoft.Json;
using Recurly;
using Recurly.Resources;
using RestSharp;
using RestSharp.Authenticators;
using Xunit;

namespace Recurly.Tests
{
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
            var json = "{\"my_string\":\"benjamin\",\"my_decimal\":3.14,\"my_int\": 3}";
            var resource = _jsonSerializer.Deserialize<MyResource>(MockResourceResponse(json));
            Assert.Equal("benjamin", resource.MyString);
            Assert.Equal(3.14m, resource.MyDecimal);
            Assert.Equal(3, resource.MyInt);
        }

        [Fact]
        public void DeserializeWithDateTime()
        {
            var json = "{\"my_date_time\":\"2019-04-26T12:00:00Z\"}";
            var resource = _jsonSerializer.Deserialize<MyResource>(MockResourceResponse(json));
            Assert.Equal(new DateTime(2019, 4, 26, 12, 0, 0), resource.MyDateTime);
        }

        [Fact]
        public void DeserializeWithEmbeddedSubResource()
        {
            var json = "{\"my_sub_resource\":{\"my_string\": \"subresource\"}}";
            var resource = _jsonSerializer.Deserialize<MyResource>(MockResourceResponse(json));
            Assert.Equal("subresource", resource.MySubResource.MyString);
        }

        [Fact]
        public void DeserializeWithArrays()
        {
            var json = "{\"my_array_string\":[\"a\", \"b\"], \"my_array_sub_resource\": [{ \"my_string\": \"subresource1\" }, { \"my_string\": \"subresource2\" } ]}";
            var resource = _jsonSerializer.Deserialize<MyResource>(MockResourceResponse(json));
            var expectedStrings = new List<string>() { "a", "b" };
            Assert.Equal(expectedStrings, resource.MyArrayString);
            Assert.Equal("subresource1", resource.MyArraySubResource[0].MyString);
            Assert.Equal("subresource2", resource.MyArraySubResource[1].MyString);
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
        public void DeserializeWithDefinedEnumValue()
        {
            var json = "{\"my_string\":\"benjamin\",\"enum_value\":\"allowed_enum\"}";
            var resource = _jsonSerializer.Deserialize<MyResource>(MockResourceResponse(json));
            // It should ignore the the unrecognized new field but still parse other properties
            Assert.Equal(Recurly.Tests.Constants.EnumValue.AllowedEnum, resource.EnumValue);
        }

        [Fact]
        public void DeserializeWithUndefinedEnumValue()
        {
            var json = "{\"my_string\":\"benjamin\",\"enum_value\":\"undefined_enum\"}";
            var resource = _jsonSerializer.Deserialize<MyResource>(MockResourceResponse(json));
            // It should ignore the the unrecognized new field but still parse other properties
            Assert.Equal(Recurly.Tests.Constants.EnumValue.Undefined, resource.EnumValue);
        }

        [Fact]
        public void Serialize()
        {
            // make sure it can serialize all primitive types and convert b/w snake and camel case
            var resource = new MyResource()
            {
                MyString = "benjamin",
                MyDecimal = 3.14m,
                MyInt = 3,
                MySubResource = new MySubResource() { MyString = "subresource" },
                MyArrayString = new List<string>() { "a", "b" },
                MyArraySubResource = new List<MySubResource>()
                {
                    new MySubResource() { MyString = "subresource1" },
                    new MySubResource() { MyString = "subresource2" },
                },
                EnumValue = Recurly.Tests.Constants.EnumValue.AllowedEnum
            };
            var jsonStr = _jsonSerializer.Serialize(resource);
            var json = "{\"my_string\":\"benjamin\",\"my_decimal\":3.14,\"my_int\":3,\"my_sub_resource\":{\"my_string\":\"subresource\"},\"my_array_string\":[\"a\",\"b\"],\"my_array_sub_resource\":[{\"my_string\":\"subresource1\"},{\"my_string\":\"subresource2\"}],\"enum_value\":\"allowed_enum\"}";
            Assert.Equal(jsonStr, json);
        }
        private RestSharp.IRestResponse MockResourceResponse(string json)
        {
            var mockResponse = new Mock<IRestResponse<Account>>();
            mockResponse.Setup(_ => _.StatusCode).Returns(System.Net.HttpStatusCode.OK);
            mockResponse.Setup(_ => _.Content).Returns(json);
            mockResponse.Setup(_ => _.Headers).Returns(new List<Parameter> { });
            return mockResponse.Object;
        }
    }
}
