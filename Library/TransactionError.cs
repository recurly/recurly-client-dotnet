﻿using System;
using System.Collections.Generic;
using System.Linq;
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
        public TransactionErrorCodeEnum ErrorCodeEnum
        {
            get
            {
                TransactionErrorCodeEnum errorEnum;
                if (Enum.TryParse(ErrorCode, out errorEnum))
                {
                    return errorEnum;
                }
                else
                {
                    return TransactionErrorCodeEnum.not_recognized;
                }
            }
        }

        /// <summary>
        /// Transaction Decline Code
        /// </summary>
        public string DeclineCode { get; internal set; }
        public TransactionDeclineCodeEnum DeclineCodeEnum
        {
            get
            {
                TransactionDeclineCodeEnum declineEnum;
                if (Enum.TryParse(DeclineCode, out declineEnum))
                {
                    return declineEnum;
                }
                else
                {
                    return TransactionDeclineCodeEnum.not_recognized;
                }
            }
        }

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

        /// <summary>
        /// The 3DS Action token to pass into RecurlyJS
        /// </summary>
        public string ThreeDSecureActionTokenId { get; internal set; }

        public TransactionError() { }

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
                    case "three_d_secure_action_token_id":
                        ThreeDSecureActionTokenId = reader.ReadElementContentAsString();
                        break;
                    case "decline_code":
                        DeclineCode = reader.ReadElementContentAsString();
                        break
                }
            }
        }

        public override string ToString()
        {
            return String.Concat(this.GetType().GetProperties().Select(i => $"{i.Name}: \"{i.GetValue(this, null)}\" "));
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
