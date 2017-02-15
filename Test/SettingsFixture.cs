using Recurly.Configuration;

namespace Recurly.Test
{
    public class SettingsFixture
    {
        internal static Settings TestSettings
        {
            get
            {
                var returnSettings = new Settings();
                returnSettings.Initialize("a14307396dde4ecc86cd5c75b844151e", "bhelx",
                    "382c053318a04154905c4d27a48f74a6", 50);
                return returnSettings;
            }
        }
    }
}