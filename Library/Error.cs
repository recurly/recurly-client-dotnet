using System;
using System.Collections.Generic;
using System.Net;
using System.Xml;

namespace Recurly
{
    /// <summary>
    /// An individual error message.
    /// For more information, please visit http://docs.recurly.com/api/errors
    /// </summary>
    public class Error
    {
        /// <summary>
        /// Error message
        /// </summary>
        public string Message { get; internal set; }
        /// <summary>
        /// Field causing the error, if appropriate.
        /// </summary>
        public string Field { get; internal set; }
        /// <summary>
        /// Error code set for certain transaction failures.
        /// </summary>
        public string Code { get; internal set; }

        internal Error(XmlTextReader reader)
        {
            if (reader.HasAttributes)
            {
                try
                {
                    Field = reader.GetAttribute("field");
                }
                catch (ArgumentOutOfRangeException)
                { }
                try
                {
                    Code = reader.GetAttribute("code");
                }
                catch (ArgumentOutOfRangeException)
                { }
            }

            Message = reader.ReadElementContentAsString();
        }

        public override string ToString()
        {
            if (!Field.IsNullOrEmpty())
                return string.Format("{0} (Field: {1})", Message, Field);

            return !Code.IsNullOrEmpty() ? string.Format("{0} (Code: {1})", Message, Code) : Message;
        }

        internal static Error[] ReadResponseAndParseErrors(HttpWebResponse response)
        {
            if (response == null)
                return new Error[0];

            using (var responseStream = response.GetResponseStream())
            {
                var errors = new List<Error>();

                try
                {
                    using (var xmlReader = new XmlTextReader(responseStream))
                    {
                        // Parse errors collection
                        while (xmlReader.Read())
                        {
                            if (xmlReader.Name == "errors" && xmlReader.NodeType == XmlNodeType.EndElement)
                                break;

                            if (xmlReader.Name == "error" && xmlReader.NodeType == XmlNodeType.Element)
                                errors.Add(new Error(xmlReader));
                        }
                    }
                }
                catch (XmlException)
                {
                    // Do nothing
                }

                return errors.ToArray();
            }
        }
    }
}
