using System;
using System.Collections.Generic;
using System.Text;
using Recurly;
using NUnit.Framework;

namespace Recurly.Test
{
    [TestFixture]
    class ChargeTest
    {
        [Test]
        public void CreateCharge()
        {
            RecurlyAccount acct = Factories.NewAccount("Create Charge");
            acct.Create("haro-test");

            RecurlyCharge charge = RecurlyCharge.ChargeAccount("haro-test", acct.AccountCode, 512, "$5.12 test charge");
            Assert.IsNotNull(charge);
        }
    }
}
