using System;
using System.Collections.Generic;
using System.Net;
using System.Xml;

namespace Recurly
{
    /// <summary>
    /// Transaction Errors
    /// </summary>
    public class TransactionError
    {
        /// <summary>
        /// Transaction Error Code
        /// </summary>
        public string ErrorCode { get; internal set; }

        /// <summary>
        /// Category of error
        /// </summary>
        public string ErrorCategory { get; internal set; }

        /// <summary>
        /// A localized message you can show your customer
        /// </summary>
        public string CustomerMessage { get; internal set; }

        /// <summary>
        /// English advice for the merchant on how to resolve the transaction error
        /// </summary>
        public string MerchantAdvice { get; internal set; }

        /// <summary>
        /// The error code given by the gateway
        /// </summary>
        public string GatewayErrorCode { get; internal set; }

        internal TransactionError(XmlTextReader reader)
        {
            while (reader.Read())
            {
   
                if (reader.Name == "transaction_error" &&
                    reader.NodeType == XmlNodeType.EndElement)
                    break;

                switch (reader.Name)
                {
                    case "error_code":
                        ErrorCode = reader.ReadElementContentAsString();
                        break;
                    case "error_category":
                        ErrorCategory = reader.ReadElementContentAsString();
                        break;
                    case "customer_message":
                        CustomerMessage = reader.ReadElementContentAsString();
                        break;
                    case "merchant_advice":
                        MerchantAdvice = reader.ReadElementContentAsString();
                        break;
                    case "gateway_error_code":
                        GatewayErrorCode = reader.ReadElementContentAsString();
                        break;
                }
            }
        }

        public override string ToString()
        {
            return string.Format("Code: \"{0}\" Category: \"{1}\" CustomerMessage: \"{2}\" MerchantAdvice: \"{3}\" GatewayCode: \"{4}\""
                , ErrorCode, ErrorCategory, CustomerMessage, MerchantAdvice, GatewayErrorCode);
        }

        internal static TransactionError ReadResponseAndParseError(HttpWebResponse response)
        {
            if (response == null)
                return null;

            using (var responseStream = response.GetResponseStream())
            {
                TransactionError error = null;

                try
                {
                    using (var xmlReader = Client.BuildXmlTextReader(responseStream))
                    {
                        while (xmlReader.Read())
                        {
                            if (xmlReader.Name == "transaction_error" && xmlReader.NodeType == XmlNodeType.Element)
                                error = new TransactionError(xmlReader);

                            if (xmlReader.Name == "transaction_error" && xmlReader.NodeType == XmlNodeType.EndElement)
                                break;
                        }
                    }
                }
                catch (XmlException)
                {
                    // Do nothing
                }

                return error;
            }
        }
    }
}
