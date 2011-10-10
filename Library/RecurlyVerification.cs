using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;

namespace Recurly
{
    /// <summary>
    /// Verification for Recurly.js
    /// </summary>
    public class RecurlyVerification
    {
        // Claims
        public const string BILLING_INFO_UPDATE = "billinginfoupdate";

        public const string BILLING_INFO_UPDATED = "billinginfoupdated";
        public const string SUBSCRIPTION_CREATE = "subscriptioncreate";
        public const string SUBSCRIPTION_CREATED = "subscriptioncreated";
        public const string TRANSACTION_CREATE = "transactioncreate";
        public const string TRANSACTION_CREATED = "transactioncreated";

        private const string SIGNATURE_DELIMITER = "-";

        /// <summary>
        /// Nested class in order to be able to override current time. Mainly used for unit testing.
        /// </summary>
        public static class SystemTime
        {
            // If this project had .Net 3.5 and LINQ support, it would be a one liner:
            //public static Func<DateTime> Now = () => DateTime.Now;

            public delegate DateTime NowDelegate();
            public static NowDelegate Now;

            static SystemTime()
            {
                Now = () => DateTime.UtcNow;
            }
        }

        /// <summary>
        /// Nested class in order to be able to override the private key. Mainly used for unit testing.
        /// </summary>
        public static class PrivateKey
        {
            public delegate string KeyDelegate();
            public static KeyDelegate Key;

            static PrivateKey()
            {
                Key = () => RecurlyClient.PrivateKey;
            }
        }

        /// <summary>
        /// Generates the signature for a given claim and arguments with the current timestamp.
        /// </summary>
        /// <param name="claim">The claim.</param>
        /// <param name="args">The args.</param>
        /// <returns></returns>
        public static string GenerateSignature(string claim, object args)
        {
            return GenerateSignature(claim, SystemTime.Now(), args);
        }

        /// <summary>
        /// Generates the signature for a given claim, timestamp and arguments.
        /// </summary>
        /// <param name="claim">The claim.</param>
        /// <param name="timestamp">The timestamp.</param>
        /// <param name="args">The args.</param>
        /// <returns></returns>
        public static string GenerateSignature(string claim, DateTime timestamp, object args)
        {
            var privateKey = PrivateKey.Key();

            if (string.IsNullOrEmpty(privateKey))
                throw new RecurlyException("A private key must be configured to use the Recurly signatures. Please update your application configuration.");

            int unixTimeStamp = GetUnixTimeStamp(timestamp);

            var message = DigestData(args);
            message = string.Format("[{0},{1},{2}]", unixTimeStamp, claim, message);

            // In order to get the same result as the Ruby library, we need to hash the private key. 
            // It wouldn't be necessary, since the .Net HMAC hashed a too long key itself.
            // See verification.rb, lines 36-38
            byte[] hashedKey = SHA1.Create().ComputeHash(Encoding.UTF8.GetBytes(privateKey));

            var hmacSha1 = new HMACSHA1(hashedKey);
            byte[] hashedMsg = hmacSha1.ComputeHash(Encoding.UTF8.GetBytes(message));
            hmacSha1.Clear();

            return string.Format("{0}{1}{2}", BytesToLoweredHexString(hashedMsg), SIGNATURE_DELIMITER, unixTimeStamp);
        }

        /// <summary>
        /// Verifies the result of an action. The data is most likely POSTed from Recurly.js.
        /// The arguments are expected to be an anonymous type and to include the signature.
        /// </summary>
        /// <param name="claim">The claim.</param>
        /// <param name="args">The args.</param>
        /// <example>
        /// RecurlyVerification.VerifyResult("billinginfoupdated", new { signature = Request.Form["signature"], account_code = "123" });
        /// </example>
        public static bool VerifyResult(string claim, object args)
        {
            PropertyInfo signatureProperty = args.GetType().GetProperty("signature");

            if (signatureProperty == null)
                throw new ForgedQueryStringException("Signature is missing");

            object oSig = signatureProperty.GetValue(args, null);
            var expectedSignature = oSig.ToString();

            // Remove signature
            var argDictionary = GetDictionaryFromAnonObject(args);
            argDictionary.Remove("signature");

            var sigTokens = expectedSignature.Split(new[] { SIGNATURE_DELIMITER }, StringSplitOptions.RemoveEmptyEntries);
            if (sigTokens.Length != 2)
                throw new ForgedQueryStringException("Invalid signature");

            var sTimestamp = sigTokens[1];
            int timestamp;

            if (!int.TryParse(sTimestamp, out timestamp))
                throw new ForgedQueryStringException("Invalid signature");

            // Check whether the timestamp is within +- 1 hour from now
            int age = GetUnixTimeStamp(SystemTime.Now()) - timestamp;
            if (age > 3600 || age < -3600)
                throw new ForgedQueryStringException("Timestamp is too new or too old.");

            var dtTimestamp = GetDateTimeFromUnixTimestamp(timestamp);
            var actualSignature = GenerateSignature(claim, dtTimestamp, argDictionary);

            if (!actualSignature.Equals(expectedSignature, StringComparison.OrdinalIgnoreCase))
                throw new ForgedQueryStringException("Signature cannot be verified");

            return true;
        }

        /// <summary>
        /// Returns the message for the given parameters as explained at http://docs.recurly.com/recurlyjs/signatures/spec/
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string DigestData(object data)
        {
            if (data == null)
                return "[]";

            var sb = new StringBuilder();
            var type = data.GetType();

            if (type.IsPrimitive || data is string || data is Guid)
            {
                var val = data.ToString();
                val = EscapeSyntaxChars(val);

                return val;
            }

            if (data is Array)
            {
                foreach (var el in (Array)data)
                {
                    sb.AppendFormat("{0},", DigestData(el));
                }

                sb.Remove(sb.Length - 1, 1);
            }
            else if (data is IDictionary<string, object>)
            {
                foreach (var pair in new SortedDictionary<string, object>((IDictionary<string, object>)data))
                {
                    sb.AppendFormat("{0}:{1},", pair.Key, DigestData(pair.Value));
                }

                if (sb.Length > 0)
                    sb.Remove(sb.Length - 1, 1);
            }
            else if (IsAnonymousType(data))
            {
                var properties = type.GetProperties(BindingFlags.Instance | BindingFlags.Public);

                Array.Sort(properties, (p1, p2) => p1.Name.CompareTo(p2.Name));

                foreach (var property in properties)
                {
                    var value = property.GetValue(data, null);
                    if (value == null)
                        continue;
                    sb.AppendFormat("{0}:", property.Name);
                    sb.AppendFormat("{0},", DigestData(value));
                }
                // Remove trailing comma
                if (sb.Length > 0)
                    sb.Remove(sb.Length - 1, 1);
            }

            // Add enclosing brackets
            if (sb.Length > 0)
            {
                sb.Insert(0, "[");
                sb.Append("]");
            }
            else
            {
                return "[]";
            }

            return sb.ToString();
        }

        /// <summary>
        /// Verifies that the subscription was created and the credit card was processed.
        /// The arguments will most likely come directly from a Recurly.js POST to the successURL of Recurly.buildSubscriptionForm().
        /// </summary>
        /// <param name="args">The args.</param>
        /// <returns></returns>
        public static bool VerifySubscription(object args)
        {
            return VerifyResult(SUBSCRIPTION_CREATED, args);
        }

        /// <summary>
        /// Creates a signature for the billing info update.
        /// </summary>
        /// <param name="accountCode">The account code.</param>
        /// <returns></returns>
        public static string SignBillingInfoUpdate(string accountCode)
        {
            return GenerateSignature(BILLING_INFO_UPDATE, new { account_code = accountCode });
        }

        /// <summary>
        /// Verifies the billing info update.
        /// The arguments are expected to be an anonymous type and to include the signature.
        /// </summary>
        /// <param name="args">The args.</param>
        /// <returns></returns>
        /// <example>
        /// RecurlyVerification.VerifyBillingInfoUpdate(new { signature = Request.Form["signature"], account_code = "123" });
        /// </example>
        public static bool VerifyBillingInfoUpdate(object args)
        {
            return VerifyResult(BILLING_INFO_UPDATED, args);
        }

        /// <summary>
        /// Creates a signature for a transaction with the given account, amount and currency.
        /// </summary>
        /// <param name="accountCode">The account code</param>
        /// <param name="amountInCents">The amount in cents</param>
        /// <param name="currency">The currency abbreviation, such as USD</param>
        /// <returns>The signature</returns>
        public static string SignTransaction(string accountCode, int amountInCents, string currency)
        {
            return GenerateSignature(TRANSACTION_CREATE,
                                     new
                                     {
                                         account_code = accountCode,
                                         amount_in_cents = amountInCents,
                                         currency = currency
                                     });
        }

        /// <summary>
        /// Verifies the transaction.
        /// </summary>
        /// <param name="args">The args.</param>
        /// <returns></returns>
        public static bool VerifyTransaction(object args)
        {
            return VerifyResult(TRANSACTION_CREATED, args);
        }

        /// <summary>
        /// Gets the unix time stamp.
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// If the project targeted .Net 3.5 or higher, this method could be implemented as an extension method for DateTime.
        /// Name suggestion: DateTime.ToUnixTimestamp()
        /// </remarks>
        private static int GetUnixTimeStamp(DateTime timestamp)
        {
            var referenceDate = new DateTime(1970, 1, 1);
            var ts = new TimeSpan(timestamp.Ticks - referenceDate.Ticks);

            return (Convert.ToInt32(ts.TotalSeconds));
        }

        /// <summary>
        /// Gets the date time form unix timestamp.
        /// </summary>
        /// <param name="timestamp">The timestamp.</param>
        /// <returns></returns>
        /// <remarks>
        /// If the project would target .Net 3.5 or higher, this method could be implemented as an extension method for int.
        /// </remarks>
        public static DateTime GetDateTimeFromUnixTimestamp(int timestamp)
        {
            var referenceDate = new DateTime(1970, 1, 1);
            var ts = TimeSpan.FromSeconds(timestamp);

            return new DateTime(ts.Ticks + referenceDate.Ticks);
        }

        /// <summary>
        /// Gets a hex string with lowered chars from a byte array.
        /// </summary>
        /// <param name="bytes">The bytes.</param>
        /// <returns></returns>
        private static string BytesToLoweredHexString(byte[] bytes)
        {
            string hex = BitConverter.ToString(bytes);
            hex = hex.Replace("-", string.Empty);

            return hex.ToLower();
        }

        /// <summary>
        /// Gets a dictionary containing all properties from an anonymous type.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        private static IDictionary<string, object> GetDictionaryFromAnonObject(object obj)
        {
            IDictionary<string, object> result = new Dictionary<string, object>();
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(obj);
            foreach (PropertyDescriptor property in properties)
            {
                result.Add(property.Name, property.GetValue(obj));
            }
            return result;
        }

        private static string EscapeSyntaxChars(string val)
        {
            val = val.Replace(@"\", @"\\");
            val = val.Replace("[", @"\[");
            val = val.Replace("]", @"\]");
            val = val.Replace(",", @"\,");
            val = val.Replace(":", @"\:");

            return val;
        }

        private static bool IsAnonymousType(object obj)
        {
            // Anonymous object? Seems to be the only way to find out.
            // See http://jclaes.blogspot.com/2011/05/checking-for-anonymous-types.html
            var type = obj.GetType();

            return type.IsGenericType &&
                   (type.Attributes & TypeAttributes.NotPublic) == TypeAttributes.NotPublic &&
                   (type.Name.StartsWith("<>", StringComparison.OrdinalIgnoreCase) ||   // created by C# 
                    type.Name.StartsWith("VB$", StringComparison.OrdinalIgnoreCase)) && // created by VB.Net
                   type.Name.Contains("AnonymousType") &&
                   Attribute.IsDefined(type, typeof(CompilerGeneratedAttribute), false);
        }
    }
}
