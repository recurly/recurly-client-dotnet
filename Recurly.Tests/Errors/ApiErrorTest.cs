using Xunit;
using Recurly;
using Newtonsoft.Json;
using System;

namespace Recurly.Tests
{
    public class ApiErrorTest
    {
        [Fact]
        public void ConstructorTest()
        {
            var err = new Recurly.Resources.ErrorMayHaveTransaction()
            {
                Message = "Something bad happened"
            };
            var ex = new MyApiError(err.Message) { Error = err };
            Assert.Equal(err.Message, ex.Message);
            Assert.Equal(err, ex.Error);
        }
    }
}
