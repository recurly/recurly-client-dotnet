using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Xunit;

namespace Recurly.Tests
{
    public class WebhooksTests
    {
        public const string Secret = "354fab5bd35f5a0d50845ee7e30165244468b13c2c343f104e4e730a59326d9d";
        public const string SecretAlt = "244468b13c2c343f104e4e730a59326d9d354fab5bd35f5a0d50845ee7e30165";
        public const string Body = "{\"id\":\"rjxwmwedwqug\",\"object_type\":\"account\",\"site_id\":\"qc326l1hl8k9\",\"event_type\":\"created\",\"event_time\":\"2022-09-13T21:18:40Z\",\"account_code\":\"adfas23zzz14123\"}";

        public const string OldTimetamp = "1663103925004";
        public const string ExpectedSignatureAtOldTimestamp = "ad24699f3beaa24c9af2cc7ada3ce4c835da0090194241b9d3add83d27f14bc3";
        public const string ExpectedSignatureAltAtOldTimestamp = "FCE309484E6A8360250DF367CCA0BCFC9FFFDC420AEAC2D97B9ED4560D8E4485";

        public static readonly string OldHeader = $"{OldTimetamp},{ExpectedSignatureAtOldTimestamp}";

        [Fact]
        public void ValidSignature()
        {
            var ts = DateTimeOffset.Now.ToUnixTimeMilliseconds() - 1000; // Jump back in time by 1s
            var secret = Secret;
            var header = ts.ToString();
            using (var hmac = new HMACSHA256())
            {
                hmac.Key = Encoding.UTF8.GetBytes(secret);
                header += "," + BitConverter.ToString(hmac.ComputeHash(
                    Encoding.UTF8.GetBytes($"{ts}.{Body}"))).Replace("-", "");
            }

            Assert.True(Webhooks.VerifySignature(header, Body, secret),
                "signature should validate");
            Assert.True(Webhooks.VerifySignature(header, Body, secret,
                throwOnFailure: true),
                "signature should validate and not throw");
        }
        [Fact]
        public void ValidSignatureFromMultiSigHeader()
        {
            var ts = DateTimeOffset.Now.ToUnixTimeMilliseconds() - 1000; // Jump back in time by 1s
            var secret = SecretAlt;
            var header = ts.ToString();
            using (var hmac = new HMACSHA256())
            {
                // To simulate multiple sigs in the header
                // we just prepend and append any old sigs

                header += "," + ExpectedSignatureAtOldTimestamp;

                hmac.Key = Encoding.UTF8.GetBytes(secret);
                header += "," + BitConverter.ToString(hmac.ComputeHash(
                    Encoding.UTF8.GetBytes($"{ts}.{Body}"))).Replace("-", "");

                header += "," + ExpectedSignatureAltAtOldTimestamp;
            }

            Assert.True(Webhooks.VerifySignature(header, Body, secret),
                "signature should validate");
            Assert.True(Webhooks.VerifySignature(header, Body, secret,
                throwOnFailure: true),
                "signature should validate and not throw");
        }

        /// <summary>
        /// Tests just the signature computation and comparison, ignoring
        /// the timestamp component by specifying a huge tolerance.
        /// </summary>
        [Fact]
        public void ValidSignatureIgnoringTimestamp()
        {
            var header = OldHeader;
            var secret = Secret;
            var tolerance = long.MaxValue;

            Assert.True(Webhooks.VerifySignature(header, Body, secret,
                tolerance: tolerance),
                "signature should validate");
            Assert.True(Webhooks.VerifySignature(header, Body, secret,
                tolerance: tolerance,
                throwOnFailure: true),
                "signature should validate and not throw");
        }
        [Fact]
        public void ValidAltSignatureIgnoringTimestamp()
        {
            var header = $"{OldHeader},{ExpectedSignatureAltAtOldTimestamp}";
            var secret = SecretAlt;

            Assert.True(Webhooks.VerifySignature(header, Body, secret,
                tolerance: long.MaxValue),
                "signature should validate");
            Assert.True(Webhooks.VerifySignature(header, Body, secret,
                tolerance: long.MaxValue,
                throwOnFailure: true),
                "signature should validate and not throw");
        }

        [Fact]
        public void InvalidTimestamp()
        {
            var header = OldHeader;
            var secret = Secret;

            // Test with and without throwOnFailure
            Assert.False(Webhooks.VerifySignature(header, Body, secret),
                "signature verification should fail");
            
            var ex = Assert.Throws<InvalidOperationException>(() =>
                Webhooks.VerifySignature(header, Body, secret,
                    throwOnFailure: true));
            Assert.False(ex.Data.Contains("expected"),
                "exception should not contain `expected` data");
            Assert.False(ex.Data.Contains("actual"),
                "exception should not contain `actual` data");
        }

        [Fact]
        public void InvalidSignature()
        {
            var ts = DateTimeOffset.Now.ToUnixTimeMilliseconds() - 1000; // Jump back in time by 1s
            var secret = Secret;
            var header = ts.ToString();
            using (var hmac = new HMACSHA256())
            {
                hmac.Key = Encoding.UTF8.GetBytes(secret);
                var badSig = new string((BitConverter.ToString(hmac.ComputeHash(
                    Encoding.UTF8.GetBytes($"{ts}.{Body}"))).Replace("-", ""))
                    .Reverse()
                    .ToArray());
                header += "," + badSig;
            }

            Assert.False(Webhooks.VerifySignature(header, Body, secret),
                "signature should not validate");
            var ex = Assert.Throws<InvalidOperationException>(() =>
                Webhooks.VerifySignature(header, Body, secret,
                    throwOnFailure: true));
            Assert.True(ex.Data.Contains("expected"),
                "exception should contain `expected` data");
            Assert.True(ex.Data.Contains("actual"),
                "exception should contain `actual` data");
        }

        [Fact]
        public void InvalidSecretKey()
        {
            var header = OldHeader;
            var secret = SecretAlt;

            // Test with and without throwOnFailure
            Assert.False(Webhooks.VerifySignature(header, Body, secret,
                tolerance: long.MaxValue));
            
            var ex = Assert.Throws<InvalidOperationException>(() =>
                Webhooks.VerifySignature(header, Body, secret,
                    tolerance: long.MaxValue,
                    throwOnFailure: true));
            Assert.True(ex.Data.Contains("expected"),
                "exception should contain `expected` data");
            Assert.True(ex.Data.Contains("actual"),
                "exception should contain `actual` data");
        }
    }
}
