using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Recurly
{
    public static class Webhooks
    {
        /// <summary>
        /// Default signature timestamp difference tolerance in milliseconds.
        /// </summary>
        public const long DefaultTolerance = 5 * 60 * 1000;

        internal const string WebhookErrParsing = "webhook signature header parsing failed";
        internal const string WebhookErrToleranceExceeded = "webhook tolerance exceeded";
        internal const string WebhookErrSignatureMismatch = "webhook signatures do not match";

        private static readonly byte PeriodByte = Convert.ToByte('.');
        private static readonly char[] HeaderSplitChars = new[] { ',' };

        /// <summary>
        /// Verifies the header-provided signature for a JSON Webhook payload.
        /// </summary>
        /// <remarks>
        /// Recurly webhook signature verification is based on
        /// <see href="https://docs.recurly.com/v1.3/docs/signature-verification"
        ///     >this documentation</see>.
        /// </remarks>
        /// <param name="header">value of the <code>recurly-signature</code></param>
        /// <param name="body">complete, raw HTTP body of the Webhook payload</param>
        /// <param name="secret">endpoint-specific secret key of a configured webhook</param>
        /// <param name="tolerance">difference tolerance between current timestamp and
        ///     header-provided timestamp</param>
        /// <param name="throwOnFailure">if true, then an exception will be thrown
        ///     if the signature fails validation for any reason, defaults to false</param>
        /// <returns>true if the validation succeeds, false if the validation fails for any
        ///     reason and <code>throwOnFailure</code> parameter is false</returns>
        public static bool VerifySignature(string header, string body, string secret,
            long tolerance = DefaultTolerance,
            bool throwOnFailure = false)
        {
            var secretBytes = Encoding.UTF8.GetBytes(secret);
            return VerifyWebhookSignature(header, body, secretBytes, tolerance, throwOnFailure);
        }

        /// <summary>
        /// Verifies the header-provided signature for a JSON Webhook payload.
        /// </summary>
        /// <remarks>
        /// Recurly webhook signature verification is based on
        /// <see href="https://docs.recurly.com/v1.3/docs/signature-verification"
        ///     >this documentation</see>.
        /// </remarks>
        /// <param name="header">value of the <code>recurly-signature</code></param>
        /// <param name="body">complete, raw HTTP body of the Webhook payload</param>
        /// <param name="secret">endpoint-specific secret key of a configured webhook</param>
        /// <param name="tolerance">difference tolerance between current timestamp and
        ///     header-provided timestamp</param>
        /// <param name="throwOnFailure">if true, then an exception will be thrown
        ///     if the signature fails validation for any reason, defaults to false</param>
        /// <returns>true if the validation succeeds, false if the validation fails for any
        ///     reason and <code>throwOnFailure</code> parameter is false</returns>
        public static bool VerifyWebhookSignature(string header, string body, byte[] secretBytes,
            long tolerance = DefaultTolerance,
            bool throwOnFailure = false)
        {
            if (!ValidateTimestamp(header, tolerance, throwOnFailure,
                out var headerTimestamp, out var headerSigs))
            {
                return false;
            }

            var hashHex = ComputeHash(headerTimestamp, body, secretBytes);
            foreach (var sig in headerSigs.Split(HeaderSplitChars))
            {
                if (string.Equals(hashHex, sig, StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }

            return ReturnOrThrowSignatureMismatch(throwOnFailure, headerSigs, hashHex);
        }

        private static bool ValidateTimestamp(string header, long tolerance, bool throwOnFailure,
            out string headerTimestamp, out string headerSigs)
        {
            var headerParts = header.Split(HeaderSplitChars, 2);
            if (headerParts.Length < 2)
            {
                headerTimestamp = null;
                headerSigs = null;

                return throwOnFailure
                    ? throw new FormatException(WebhookErrParsing)
                    : false;
            }

            headerTimestamp = headerParts[0];
            headerSigs = headerParts[1];
            if (!long.TryParse(headerTimestamp, out var sigUnixTimestamp))
            {
                return throwOnFailure
                    ? throw new FormatException(WebhookErrParsing)
                    : false;
            }

            var sigTimestamp = DateTimeOffset.FromUnixTimeMilliseconds(sigUnixTimestamp);
            var curTimestamp = DateTimeOffset.UtcNow;
            if ((curTimestamp - sigTimestamp).TotalMilliseconds > tolerance)
            {
                return throwOnFailure
                    ? throw new InvalidOperationException(WebhookErrToleranceExceeded)
                    : false;
            }

            return true;
        }

        private static string ComputeHash(string timestamp, string body, byte[] secretBytes)
        {
            var timestampBytes = Encoding.UTF8.GetBytes(timestamp);
            var bodyBytes = Encoding.UTF8.GetBytes(body);

            var dataSize = timestampBytes.Length + 1 + bodyBytes.Length;
            var dataBuffer = new byte[dataSize];

            using (var hmac = new HMACSHA256(secretBytes))
            using (var stream = new MemoryStream(dataBuffer))
            {
                stream.Write(timestampBytes, 0, timestampBytes.Length);
                stream.WriteByte(PeriodByte);
                stream.Write(bodyBytes, 0, bodyBytes.Length);

                stream.Seek(0, SeekOrigin.Begin);
                var hashBytes = hmac.ComputeHash(stream);
                var hashHex = BitConverter.ToString(hashBytes).Replace("-", "");

                return hashHex;
            }
        }

        private static bool ReturnOrThrowSignatureMismatch(bool throwOnFailure,
            string expected, string actual)
        {
            if (throwOnFailure)
            {
                throw new InvalidOperationException(WebhookErrSignatureMismatch)
                {
                    Data =
                    {
                        [nameof(expected)] = expected,
                        [nameof(actual)] = actual,
                    },
                };
            }

            return false;
        }
    }
}
