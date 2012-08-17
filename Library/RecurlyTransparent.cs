//using System;
//using System.Collections.Generic;
//using System.Net;
//using System.Security.Cryptography;
//using System.Text;
//using System.Xml;

//namespace Recurly
//{
//    /// <summary>
//    /// Transparent Post API
//    /// </summary>
//    public class RecurlyTransparent
//    {
//        public string RedirectUrl { get; private set; }
//        public string AccountCode { get; private set; }

//        // TODO: Set other protected attributes... Subscription plan, transaction amount, etc.

//        public RecurlyTransparent(string redirectUrl, string accountCode)
//        {
//            this.RedirectUrl = redirectUrl;
//            this.AccountCode = accountCode;
//        }

//        #region Transparent Post URLs

//        private const string SubscribeUrlFormat = "/transparent/{0}/subscription";
//        private const string TransactionUrlFormat = "/transparent/{0}/transaction";
//        private const string UpdateBillingUrlFormat = "/transparent/{0}/billing_info";

//        private const string ResultsUrlPrefix = "/transparent/results/";

//        /// <summary>
//        /// Create Subscription POST URL
//        /// </summary>
//        public static string SubscriptionUrl
//        {
//            get { return Url(SubscribeUrlFormat); }
//        }

//        /// <summary>
//        /// Create Transaction POST URL
//        /// </summary>
//        public static string TransactionUrl
//        {
//            get { return Url(TransactionUrlFormat); }
//        }

//        /// <summary>
//        /// Update Billing Info POST URL
//        /// </summary>
//        public static string UpdateBillingUrl
//        {
//            get { return Url(UpdateBillingUrlFormat); }
//        }

//        private static string Url(string urlFormat)
//        {
//            return RecurlyClient.ServerUrl(Configuration.RecurlySection.Current.Environment) +
//                   String.Format(urlFormat, Configuration.RecurlySection.Current.Subdomain);
//        }

//        #endregion

//        /// <summary>
//        /// Hidden input field containing protected data
//        /// </summary>
//        /// <returns></returns>
//        public System.Web.UI.HtmlControls.HtmlInputHidden HiddenFieldData()
//        {
//            System.Web.UI.HtmlControls.HtmlInputHidden input = new System.Web.UI.HtmlControls.HtmlInputHidden();
//            input.Name = "data";
//            input.Value = EncodedData();
//            input.EnableViewState = false;
//            input.EnableTheming = false;

//            return input;
//        }

//        private string EncodedData()
//        {
//            string dataToProtect = String.Format("redirect_url={0}&account%5Baccount_code%5D={1}",
//                System.Uri.EscapeUriString(this.RedirectUrl),
//                System.Uri.EscapeUriString(this.AccountCode));

//            return String.Format("{0}|{1}", ComputePrivateHash(dataToProtect), dataToProtect);
//        }

//        private static string ComputePrivateHash(string dataToProtect)
//        {
//            if (String.IsNullOrEmpty(Configuration.RecurlySection.Current.PrivateKey))
//                throw new RecurlyException("A Private Key must be configured to use the Recurly Transparent Post API.");

//            byte[] salt_binary = SHA1.Create().ComputeHash(Encoding.ASCII.GetBytes(dataToProtect));
//            string salt_hex = BitConverter.ToString(salt_binary).Replace("-", "").ToLower();
//            string salt = salt_hex.Substring(0, 20);

//            HMACSHA1 hmac_sha1 = new HMACSHA1(Encoding.ASCII.GetBytes(Configuration.RecurlySection.Current.PrivateKey));
//            hmac_sha1.Initialize();

//            byte[] private_key_binary = System.Text.Encoding.ASCII.GetBytes(salt);
//            byte[] passkey_binary = hmac_sha1.ComputeHash(private_key_binary, 0, private_key_binary.Length);

//            return Convert.ToBase64String(passkey_binary).Trim();
//        }

//        /// <summary>
//        /// Validate the Transparent Post result has not been tampered with.
//        /// </summary>
//        public static void ValidateResult(System.Web.HttpRequest currentRequest)
//        {
//            int statusCode;

//            if (Int32.TryParse(currentRequest.Params["status"], out statusCode))
//                ValidateResult(currentRequest.Params["type"], statusCode, currentRequest.Params["result"], currentRequest.Params["confirm"]);
//        }

//        /// <summary>
//        /// Validate the Transparent Post result has not been tampered with.
//        /// </summary>
//        /// <param name="type">Response type</param>
//        /// <param name="status">HTTP Status Code</param>
//        /// <param name="resultKey">32-character result key</param>
//        /// <param name="confirm">32-character confirmation key</param>
//        public static void ValidateResult(string type, int status, string resultKey, string confirm)
//        {
//            string resultHash = ComputePrivateHash(String.Format("type={0}&status={1}&result={2}", type, status, resultKey));

//            if (!resultHash.Equals(confirm, StringComparison.OrdinalIgnoreCase))
//                throw new ForgedQueryStringException("Query string confirmation does not match.");
//        }

//        #region Get Results

//        public static RecurlySubscription GetSubscriptionResult(string resultKey)
//        {
//            RecurlySubscription subscription = new RecurlySubscription(new RecurlyAccount(String.Empty));
//            HttpStatusCode statusCode = GetResult(resultKey, new RecurlyClient.ReadXmlDelegate(subscription.ReadXml));

//            if (statusCode == HttpStatusCode.NotFound)
//                return null;

//            return subscription;
//        }

//        public static RecurlyTransaction GetTransactionResult(string resultKey)
//        {
//            RecurlyTransaction transaction = new RecurlyTransaction();
//            HttpStatusCode statusCode = GetResult(resultKey, new RecurlyClient.ReadXmlDelegate(transaction.ReadXml));

//            if (statusCode == HttpStatusCode.NotFound)
//                return null;

//            return transaction;
//        }

//        public static RecurlyBillingInfo GetUpdateBillingResult(string resultKey)
//        {
//            RecurlyBillingInfo billingInfo = new RecurlyBillingInfo(new RecurlyAccount(String.Empty));
//            HttpStatusCode statusCode = GetResult(resultKey, new RecurlyClient.ReadXmlDelegate(billingInfo.ReadXml));

//            if (statusCode == HttpStatusCode.NotFound)
//                return null;

//            return billingInfo;
//        }

//        private static HttpStatusCode GetResult(string resultKey, RecurlyClient.ReadXmlDelegate readXmlDelegate)
//        {
//            HttpStatusCode statusCode = RecurlyClient.PerformRequest(RecurlyClient.HttpRequestMethod.Get,
//                ResultsUrlPrefix + System.Uri.EscapeUriString(resultKey),
//                readXmlDelegate);

//            return statusCode;
//        }

//        #endregion
//    }
//}
