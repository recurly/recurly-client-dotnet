//using System;
//using System.Collections.Generic;
//using System.Text;
//using Recurly;
//using NUnit.Framework;

//namespace Recurly.Test
//{
//    [TestFixture]
//    class ChargeTest
//    {
//        [Test]
//        public void CreateCharge()
//        {
//            Account acct = Factories.NewAccount("Create Charge");
//            acct.Create();

//            RecurlyCharge charge = RecurlyCharge.ChargeAccount(acct.AccountCode, 512, "$5.12 test charge");
//            Assert.IsNotNull(charge);
//        }
//    }
//}
