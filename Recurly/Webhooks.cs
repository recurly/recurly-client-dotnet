using System;
using System.Collections;
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
        public static readonly byte PeriodByte = Convert.ToByte('.');

        internal const string WebhookErrParsing = "webhook signature header parsing failed";
	    internal const string WebhookErrToleranceExceeded = "webhook tolerance exceeded";
	    internal const string WebhookErrSignatureMismatch = "webhook signatures do not match";
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
        /// <param name="secret">endpoint-specific secret key of a configured webhook</param>
        /// <param name="body">complete, raw HTTP body of the Webhook payload</param>
        /// <param name="tolerance">difference tolerance between current timestamp and
        ///     header-provided timestamp</param>
        /// <param name="throwOnFailure">if true, then an exception will be thrown
        ///     if the signature fails validation for any reason, defaults to false</param>
        /// <returns>true if the validation succeeds, false if the validation fails for any
        ///     reason and <code>throwOnFailure</code> parameter is false</returns>
        public static bool VerifyWebhookSignature(string header, string secret, string body,
            long tolerance = DefaultTolerance,
            bool throwOnFailure = false)
        {
            var secretBytes = Encoding.UTF8.GetBytes(secret);
            var headerParts = header.Split(HeaderSplitChars, 2);
            if (headerParts.Length < 2)
            {
                return throwOnFailure
                    ? throw new FormatException(WebhookErrParsing)
                    : false;
            }

            var headerTimestamp = headerParts[0];
            var headerSigs = headerParts[1].Split(HeaderSplitChars);
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

            var dataSize = headerTimestamp.Length + 1 + body.Length;
            var dataBuffer = new byte[dataSize];

            string hashHex = null;
            using (var hmac = new HMACSHA256(secretBytes))
            using (var stream = new MemoryStream(dataBuffer))
            {
                var tsBytes = Encoding.UTF8.GetBytes(headerTimestamp);
                var bodyBytes = Encoding.UTF8.GetBytes(body);

                stream.Write(tsBytes, 0, tsBytes.Length);
                stream.WriteByte(PeriodByte);
                stream.Write(bodyBytes, 0, bodyBytes.Length);

                stream.Seek(0, SeekOrigin.Begin);
                var hashBytes = hmac.ComputeHash(stream);
                hashHex = BitConverter.ToString(hashBytes).Replace("-", "");
            }

            for (var i = 0; i < headerSigs.Length; i++)
            {
                if (string.Equals(hashHex, headerSigs[i], StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }

            return throwOnFailure
                ? throw new InvalidOperationException(WebhookErrSignatureMismatch + ";" + hashHex)
                {
                    Data =
                    {
                        ["expected"] = headerParts[1],
                        ["actual"] = hashHex,
                    },
                }
                : false;
        }
    }
}
