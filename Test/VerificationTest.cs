using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Recurly.Test
{
    // ReSharper disable InconsistentNaming

    [TestFixture]
    public class VerificationTest
    {
        // These values are taken from verification_spec.rb
        private const string _testSignature = "fb5194a51aa97996cdb995a89064764c5c1bfd93-1312806801";
        private const int _timestamp = 1312806801;

        [Test]
        public void Verification_Should_Ignore_Empty_And_Null_Args()
        {
            // Arrange

            // Act
            var data1 = RecurlyVerification.DigestData(null);
            var data2 = RecurlyVerification.DigestData(new { });
            var data3 = RecurlyVerification.DigestData(new { });
            var data4 = RecurlyVerification.DigestData(new Dictionary<string, object>());
            string s = null;
            var data5 = RecurlyVerification.DigestData(new { s });

            // Assert
            Assert.That(data1, Is.EqualTo("[]"));
            Assert.That(data2, Is.EqualTo("[]"));
            Assert.That(data3, Is.EqualTo("[]"));
            Assert.That(data4, Is.EqualTo("[]"));
            Assert.That(data5, Is.EqualTo("[]"));
        }

        [Test]
        public void Verification_Should_Encode_Nested_Args()
        {
            // Arrange
            var args = new
            {
                a = new[] { 1, 2, 3 },
                b = new
                {
                    c = "123",
                    d = "456"
                }
            };

            // Act
            var data = RecurlyVerification.DigestData(args);

            // Assert
            Assert.That(data, Is.EqualTo("[a:[1,2,3],b:[c:123,d:456]]"));
        }

        [Test]
        public void Verification_Should_Escape_Syntax_Characters_In_Args()
        {
            // Arrange

            // Act
            var data = RecurlyVerification.DigestData(new
            {
                a = ":",
                c = ",",
                d = "[",
                e = "]",
                b = @"\"
            });

            // Assert
            Assert.That(data, Is.EqualTo(@"[a:\:,b:\\,c:\,,d:\[,e:\]]"));
        }

        [Test]
        public void Verification_Should_Sort_Args_By_Key()
        {
            // Arrange

            // Act
            var data = RecurlyVerification.DigestData(new
            {
                b = "bar",
                a = "foo"
            });

            // Assert
            Assert.That(data, Is.EqualTo("[a:foo,b:bar]"));
        }

        [Test]
        [ExpectedException(typeof(RecurlyException))]
        public void GenerateSignature_Should_Assert_That_Private_Key_Is_Configured()
        {
            // Arrange
            RecurlyVerification.PrivateKey.Key = () => null;

            // Act
            RecurlyVerification.GenerateSignature(RecurlyVerification.BILLING_INFO_UPDATE, null);
        }

        [Test]
        public void GenerateSignature_Should_Generate_Valid_Signature()
        {
            // Arrange
            RecurlyVerification.PrivateKey.Key = () => "0123456789abcdef0123456789abcdef";
            RecurlyVerification.SystemTime.Now = () => RecurlyVerification.GetDateTimeFromUnixTimestamp(_timestamp);

            // Act
            var signature = RecurlyVerification.GenerateSignature(
                "update",
                new { a = "foo", b = "bar" });

            // Assert
            Assert.That(signature, Is.EqualTo(_testSignature));
        }

        [Test]
        public void VerifyResult_Should_Validate_Valid_Signature_Case_Insensitive()
        {
            // Arrange
            RecurlyVerification.PrivateKey.Key = () => "0123456789abcdef0123456789abcdef";
            var dt = RecurlyVerification.GetDateTimeFromUnixTimestamp(_timestamp);
            RecurlyVerification.SystemTime.Now = () => dt.AddMinutes(5);

            // Act
            var result = RecurlyVerification.VerifyResult(
                "update",
                new { signature = _testSignature.ToUpper(), a = "foo", b = "bar" });

            // Assert
            Assert.That(result, Is.True);
        }

        [Test]
        public void VerifyResult_Should_Validate_Valid_5_Minutes_Old_Signature()
        {
            // Arrange
            RecurlyVerification.PrivateKey.Key = () => "0123456789abcdef0123456789abcdef";
            var dt = RecurlyVerification.GetDateTimeFromUnixTimestamp(_timestamp);
            RecurlyVerification.SystemTime.Now = () => dt.AddMinutes(5);

            // Act
            var result = RecurlyVerification.VerifyResult(
                "update",
                new { signature = _testSignature, a = "foo", b = "bar" });

            // Assert
            Assert.That(result, Is.True);
        }

        [Test]
        [ExpectedException(typeof(ForgedQueryStringException))]
        public void VerifyResult_Should_Not_Validate_Valid_70_Minutes_Old_Signature()
        {
            // Arrange
            RecurlyVerification.PrivateKey.Key = () => "0123456789abcdef0123456789abcdef";
            var dt = RecurlyVerification.GetDateTimeFromUnixTimestamp(_timestamp);
            RecurlyVerification.SystemTime.Now = () => dt.AddMinutes(70);

            // Act
            var result = RecurlyVerification.VerifyResult(
                "update",
                new { signature = _testSignature, a = "foo", b = "bar" });

            // Assert
            Assert.That(result, Is.True);
        }

        [Test]
        [ExpectedException(typeof(ForgedQueryStringException))]
        public void VerifyResult_Should_Not_Validate_Valid_Signature_With_Future_Timestamp()
        {
            // Arrange
            RecurlyVerification.PrivateKey.Key = () => "0123456789abcdef0123456789abcdef";
            var dt = RecurlyVerification.GetDateTimeFromUnixTimestamp(_timestamp);
            RecurlyVerification.SystemTime.Now = () => dt.AddMinutes(-70);

            // Act
            var result = RecurlyVerification.VerifyResult(
                "update",
                new { signature = _testSignature, a = "foo", b = "bar" });

            // Assert
            Assert.That(result, Is.True);
        }

        [Test]
        [ExpectedException(typeof(ForgedQueryStringException))]
        public void VerifyResult_Should_Not_Validate_Invalid_5_Minutes_Old_Signature()
        {
            // Arrange
            RecurlyVerification.PrivateKey.Key = () => "0123456789abcdef0123456789abcdef";
            var dt = RecurlyVerification.GetDateTimeFromUnixTimestamp(_timestamp);
            RecurlyVerification.SystemTime.Now = () => dt.AddMinutes(5);

            // Act
            var result = RecurlyVerification.VerifyResult(
                "update",
                new { signature = "badsignature", a = "foo", b = "bar" });

            // Assert
            Assert.That(result, Is.True);
        }

        [Test]
        public void VerifySubscription_Should_Validate_Valid_Subscription_Data()
        {
            // Arrange
            // This test data is taken from test_verification.php in the PHP client. 
            // Note that this is not necessarly what is sent after to in the POST after creating a new subscription.
            RecurlyVerification.PrivateKey.Key = () => "c8b27bb177534f8da94e707356fe5013";
            const string signature = "42f18ee561113ed06c806889b4f2f9ee19f813ff-1313727371";
            const int timestamp = 1313727371;
            var dt = RecurlyVerification.GetDateTimeFromUnixTimestamp(timestamp);
            RecurlyVerification.SystemTime.Now = () => dt.AddMinutes(5);

            // Act
            var result = RecurlyVerification.VerifySubscription(
                new
                {
                    signature = signature,
                    account_code = "123",
                    plan_code = "gold",
                    add_ons =
                    new[]
                        {
                            new { add_on_code = "extra", quantity = 5 },
                            new { add_on_code = "bonus", quantity = 2 }
                        },
                    quantity = 1
                });

            // Assert
            Assert.That(result, Is.True);
        }

        [Test]
        public void SignBillingInfoUpdate_Should_Generate_Valid_Signature()
        {
            // Arrange
            RecurlyVerification.PrivateKey.Key = () => "0123456789abcdef0123456789abcdef";
            const int timestamp = 1313727561;
            var dt = RecurlyVerification.GetDateTimeFromUnixTimestamp(timestamp);
            RecurlyVerification.SystemTime.Now = () => dt;

            // Act
            var signature = RecurlyVerification.SignBillingInfoUpdate("123");

            // Assert
            Assert.That(signature, Is.EqualTo("824c2ac45c66236c76bd746998a0e050836c1c3e-1313727561"));
        }

        [Test]
        public void SignTransaction_Should_Generate_Valid_Signature()
        {
            // Arrange
            RecurlyVerification.PrivateKey.Key = () => "0123456789abcdef0123456789abcdef";
            const int timestamp = 1313727561;
            var dt = RecurlyVerification.GetDateTimeFromUnixTimestamp(timestamp);
            RecurlyVerification.SystemTime.Now = () => dt;

            // Act
            var signature = RecurlyVerification.SignTransaction("123", 5000, "USD");

            // Assert
            Assert.That(signature, Is.EqualTo("ccedb6a88e15cbec07187d6d21ff0041bc1fbc94-1313727561"));
        }

        [Test]
        public void VerifyTransaction_Should_Validate_Valid_Transaction_Data()
        {
            // Arrange
            // This test data is taken from test_verification.php in the PHP client
            RecurlyVerification.PrivateKey.Key = () => "c8b27bb177534f8da94e707356fe5013";
            const string signature = "2eda29820cf6dd8276f492b2eba3d7c831fad1a4-1313727371";
            const int timestamp = 1313727371;
            var dt = RecurlyVerification.GetDateTimeFromUnixTimestamp(timestamp);
            RecurlyVerification.SystemTime.Now = () => dt.AddMinutes(5);

            // Act
            var result = RecurlyVerification.VerifyTransaction(
                new
                {
                    signature = signature,
                    account_code = "123",
                    amount_in_cents = 5000,
                    currency = "USD",
                    uuid = "922ee630daa240da983bdac150d001a1"
                });

            // Assert
            Assert.That(result, Is.True);
        }

        [Test]
        [ExpectedException(typeof(ForgedQueryStringException))]
        public void VerifyTransaction_Should_Not_Validate_Invalid_Transaction_Data()
        {
            // Arrange
            // This test data is taken from test_verification.php in the PHP client
            RecurlyVerification.PrivateKey.Key = () => "c8b27bb177534f8da94e707356fe5013";
            const string signature = "2eda29820cf6dd8276f492b2eba3d7c831fad1a4-1313727371";
            const int timestamp = 1313727371;
            var dt = RecurlyVerification.GetDateTimeFromUnixTimestamp(timestamp);
            RecurlyVerification.SystemTime.Now = () => dt.AddMinutes(5);

            // Act
            var result = RecurlyVerification.VerifyTransaction(
                new
                {
                    signature = signature,
                    account_code = "123",
                    amount_in_cents = 500,
                    currency = "USD",
                    uuid = "922ee630daa240da983bdac150d001a1"
                });

            // Assert
            Assert.That(result, Is.True);
        }
    }

    // ReSharper restore InconsistentNaming
}
