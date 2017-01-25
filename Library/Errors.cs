using System;
using System.Collections.Generic;
using System.Net;
using System.Xml;

namespace Recurly
{
    /// <summary>
    /// An internal class for parsing and handling errors
    /// </summary>
    internal class Errors
    {
        /// <summary>
        /// Error objects message
        /// </summary>
        public Error[] ValidationErrors { get; internal set; }

        /// <summary>
        /// Transaction error if set
        /// </summary>
        public TransactionError TransactionError { get; internal set; }

        internal Errors() { }

        internal Errors(XmlTextReader xmlReader)
        {
            bool list = false;
            var validationErrors = new List<Error>();

            while (xmlReader.Read())
            {
            
                if ((xmlReader.Name == "errors" || xmlReader.Name == "error") &&
                    xmlReader.NodeType == XmlNodeType.EndElement)
                    break;

                if (xmlReader.Name == "errors" && xmlReader.NodeType == XmlNodeType.Element)
                    list = true;

                if (xmlReader.Name == "error" && xmlReader.NodeType == XmlNodeType.Element)
                    validationErrors.Add(new Error(xmlReader, list));

                if (xmlReader.Name == "transaction_error" && xmlReader.NodeType == XmlNodeType.Element)
                    TransactionError = new TransactionError(xmlReader);
            }

            ValidationErrors = validationErrors.ToArray();
        }

        internal static Errors ReadResponseAndParseErrors(HttpWebResponse response)
        {
            if (response == null)
                return null;

            Errors errors = null;

            using (var responseStream = response.GetResponseStream())
            {
                try
                {
                    using (var xmlReader = new XmlTextReader(responseStream))
                        errors = new Errors(xmlReader);
                }
                catch (XmlException)
                {
                    // Do nothing
                }

                return errors;
            }
        }
    }
}
