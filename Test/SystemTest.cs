using FluentAssertions;
using Recurly.Configuration;
using Xunit;

namespace Recurly.Test
{
    public class SystemTest
    {
        [RecurlyFact(TestEnvironment.Type.Integration)]
        public void Config_file_is_present_and_correct()
        {
            Section.Current.ApiKey.Should().NotBeNullOrEmpty();
            Section.Current.PrivateKey.Should().NotBeNullOrEmpty();
            Section.Current.Subdomain.Should().NotBeNullOrEmpty();
            Section.Current.PageSize.Should().NotBe(default(int));
        }
    }
}