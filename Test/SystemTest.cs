using System;
using System.Collections.Generic;
using System.Text;
using Recurly;
using NUnit.Framework;

namespace Recurly.Test
{
    [TestFixture]
    public class SystemTest
    {
        [Test]
        public void CheckConfigFile()
        {
            Assert.IsNotEmpty(Configuration.Section.Current.ApiKey);
            Assert.IsNotEmpty(Configuration.Section.Current.PrivateKey);
            Assert.IsNotEmpty(Configuration.Section.Current.Subdomain);
        }
    }
}