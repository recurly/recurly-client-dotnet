using Recurly.Configuration;
using Xunit;

namespace Recurly.Test
{
    public class SettingsManagerTest : BaseTest
    {
        [RecurlyFact(TestEnvironment.Type.Integration)]
        public void SetApiKey()
        {
            SettingsManager.Initialize("api", "subdomain", "private", 100, 600);

            Assert.True("api" == Settings.Instance.ApiKey);
            Assert.True("subdomain" == Settings.Instance.Subdomain);
            Assert.True("private" == Settings.Instance.PrivateKey);
            Assert.True(100 == Settings.Instance.PageSize);
            Assert.True(600 == Settings.Instance.RequestTimeoutMilliseconds);
        }

        [RecurlyFact(TestEnvironment.Type.Integration)]
        public void SetFromConfigFile()
        {
            SettingsManager.InitializeFromConfig();

            Assert.NotNull(Settings.Instance.ApiKey);
            Assert.NotNull(Settings.Instance.Subdomain);
            Assert.NotNull(Settings.Instance.PrivateKey);
            Assert.NotNull(Settings.Instance.PageSize);
            Assert.NotNull(Settings.Instance.RequestTimeoutMilliseconds);
        }
    }
}