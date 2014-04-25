using Recurly.Configuration;

namespace Recurly.Test
{
    public class SettingsFixture
    {
        internal static Settings TestSettings
        {
            get
            {
                return new Settings("8f1359864cfa4f378542d639e655229c", "client-lib-test",
                    "382c053318a04154905c4d27a48f74a6", 50);
            }
        }
    }
}